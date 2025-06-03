using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SongSelector : MonoBehaviour
{
    
    public SongDatabase songDB;
    public int songIndex; // Assign this in the inspector
    [SerializeField] //Allows us to edit in the inspector
    public void SelectSong()
    {
        Debug.Log("bottoun coicekced");
        if (songIndex >= songDB.SongCount)
        {
            Debug.LogError("Invalid: Song does not exist!");
            return;
        }

        PlayerPrefs.SetInt("SelectedSongIndex", songIndex); //Stores the selected song?
        PlayerPrefs.Save(); //Makes sure the data will save

        SceneManager.LoadScene("TestGame");
    }

}
