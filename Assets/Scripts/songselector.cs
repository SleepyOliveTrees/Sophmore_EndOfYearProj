using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class songselector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OpenScene()
    {
        SceneManager.LoadScene("TestGame");
    }
}
