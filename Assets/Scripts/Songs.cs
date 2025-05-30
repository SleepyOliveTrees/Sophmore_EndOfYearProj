using Melanchall.DryWetMidi.Core;
using UnityEngine;

[CreateAssetMenu(fileName = "Songs", menuName = "Scriptable Objects/Songs")]
public class Songs : ScriptableObject
{
    public AudioClip audioFile;
    public string midiFile;
    public float bpm;
}
