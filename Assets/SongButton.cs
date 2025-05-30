using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongButton : MonoBehaviour
{
    //Assign the song data for this in the Inspector
    public Songs songSelected;

    private Button button;

    // Awake is called  before start methods
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    private void OnClick()
    {
        //set the selected song in the SongSelector file
        SongSelector.Instance.SelectedSong(songSelected);

        //Load the scene
        SceneManager.LoadScene("TestGame");

    }
}
