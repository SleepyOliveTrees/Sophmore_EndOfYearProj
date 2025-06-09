using System.Collections;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public GameObject EndPanel;
    public TMPro.TextMeshProUGUI finalScoreText;
    public TMPro.TextMeshProUGUI totalHitsText;
    public TMPro.TextMeshProUGUI totalMissesText;

    public float songTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EndPanel.SetActive(false);
        songTimer = SongManager.Instance.audioSource.clip.length;
    }



    // Update is called once per frame
    void Update()
    {
        songTimer -= Time.deltaTime;

        if(songTimer <= 0.0f)
        {
            ShowEndPanel();
        }
        //Debug.Log("Better version: " + SongManager.playing);
        //Debug.Log("Clip length: " + SongManager.Instance.audioSource.clip.length);
        //Debug.Log("Time: " + SongManager.Instance.audioSource.time);\
        
        //if (SongManager.Instance != null)
        //{
        //    var source = SongManager.Instance.audioSource;
        //    if (source.clip != null && SongManager.playing == false)
        //    {
        //        Debug.Log("Song ended, triggering end panel.");
        //        ShowEndPanel();
        //    }
        //}

    }


    void ShowEndPanel()
    {
        EndPanel.SetActive(true);
        finalScoreText.text = "Score: " + ScoreManager.GetScore().ToString();
        totalHitsText.text = "Hits: " + ScoreManager.GetHitCount().ToString();
        totalMissesText.text = "Misses: " + ScoreManager.GetMissCount().ToString();
    }
}
