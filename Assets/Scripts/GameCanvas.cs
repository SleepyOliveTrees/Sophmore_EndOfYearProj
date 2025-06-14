using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    private bool isPaused;
    public GameObject PausePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        SongManager.Instance.audioSource.Pause();
        PausePanel.SetActive(true);
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        SongManager.Instance.audioSource.UnPause();
        PausePanel.SetActive(false);
        isPaused = false;
    }
    public void OpenSelection()
    {
        Debug.Log("OpenSelection called");
        SceneManager.LoadScene("SongSelection");
    }

    public void RetrySong()
    {
        SceneManager.LoadScene("TestGame");
    }
}
