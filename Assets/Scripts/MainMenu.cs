using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void OpenSelection()
    {
        SceneManager.LoadScene("SongSelection");
    }
    public void OpenInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
