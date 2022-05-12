using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    public int count = 0; 
    // Start is called before the first frame update
    void Start()
    {
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


}
