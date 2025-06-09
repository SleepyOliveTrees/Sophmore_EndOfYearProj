using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro comboText;
    static int comboScore;
    static int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        score = 0;
        comboScore = 0;
    }
    
    public static void Hit()
    {
        score += 1 + comboScore;
        comboScore += 1;
        Instance.hitSFX.Play();
    }
    public static void Miss()
    {
        comboScore = 0;
        Instance.missSFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        comboText.text = "x" + comboScore.ToString();
    }
}
