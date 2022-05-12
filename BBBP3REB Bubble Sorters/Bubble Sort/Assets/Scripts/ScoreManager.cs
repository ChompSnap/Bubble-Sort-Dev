using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    public int count = 0; 
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("currentScore") > 0 && SceneManager.GetActiveScene().name != "Level1") {
            count = PlayerPrefs.GetInt("currentScore");
        } else {
            PlayerPrefs.SetInt("currentScore", 0);
        }
        score.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        GameManager.addScore += addScore;
        LoseBox.add500 += addDropped;
    }

    private void addDropped(int points)
    {
        count += points;
        score.SetText($"{count}");
    }
    
    private void addScore(int points)
    {
        count += points;
        score.SetText($"{count}");
    }

    private void OnDisable()
    {
        GameManager.addScore -= addScore;
        LoseBox.add500 -= addDropped;
    }

    public void saveScore() {
        PlayerPrefs.SetInt("currentScore", count);
    }

    public void saveHighScore() {
        PlayerPrefs.SetInt("highscore", count);
    }
}
