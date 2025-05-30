using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class songselector : MonoBehaviour
{
    public Songs[] songList;

    public void OpenScene(int songIndex)
    {
        SongSelector.Instance.SelectedSong(songList[songIndex]);
        SceneManager.LoadScene("TestGame");
    }
}
