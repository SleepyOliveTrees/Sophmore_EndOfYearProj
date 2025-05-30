using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;
using System;


public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public AudioSource audioSource;
    public Lane[] lanes;
    public float songDelayInSeconds;
    public double marginOfError; // in seconds
    public int inputDelayInMiliseconds;

    //public string fileLocation;
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;
    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    // this is where the MIDIfile loads on RAM (I think...)
    public static MidiFile midiFile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60; // Force 60 FPS for smoother note movement

        Instance = this;

        //Get the selected song from  SongSelector
        Songs selectedSong = SongSelector.Instance.selectedSong;

        //Assign the song's audio file to the audio source so it can be played
        audioSource.clip = selectedSong.audioFile;

        if (Application.streamingAssetsPath.StartsWith("http://") || Application.streamingAssetsPath.StartsWith("https://"))
        {
            StartCoroutine(ReadFromWebsite(selectedSong.midiFile));
        }
        else
        {
            ReadFromFile(selectedSong.midiFile);
        }
    }

    //need parameter to get midiFile of the selected song for both ReadFromFile and ReadFromWebsite
    private void ReadFromFile(string mFile)
    {
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + mFile);
        GetDataFromMidi();
    }

    private IEnumerator ReadFromWebsite(string mFile)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Application.streamingAssetsPath + "/" + mFile))
        {
            yield return www.SendWebRequest();
            
            if (www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                byte[] results = www.downloadHandler.data;
                using (var stream = new MemoryStream(results))
                {
                    midiFile = MidiFile.Read(stream);
                    GetDataFromMidi();
                }
            }
        }
    }

    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();
        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        // Debug: Log all notes loaded from the MIDI file
        foreach (var note in array)
        {
            Debug.Log($"Note: {note.NoteName}{note.Octave}, Time: {note.Time}, Length: {note.Length}");
        }

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelayInSeconds);
    }

    public void StartSong()
    {
        audioSource.Play();
    }

    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
