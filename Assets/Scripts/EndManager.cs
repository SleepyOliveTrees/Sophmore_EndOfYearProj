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

        if (songTimer <= 0.0f)
        {
            ShowEndPanel();
        }

    }


    void ShowEndPanel()
    {
        EndPanel.SetActive(true);
        finalScoreText.text = "Score: " + ScoreManager.GetScore().ToString();
        totalHitsText.text = "Hits: " + ScoreManager.GetHitCount().ToString();
        totalMissesText.text = "Misses: " + ScoreManager.GetMissCount().ToString();
    }
}