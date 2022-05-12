using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // public GameObject menu_manager,level_manager,title;
    // public Button start_btn, credit_btn;
    // public Button levle_btn_1, levle_btn_2, levle_btn_3, levle_btn_4, levle_btn_5;



    // private void Awake()
    // {
    //     start_btn.onClick.AddListener(Start_btn_Click);
    //     credit_btn.onClick.AddListener(Credit_btn_Click);
    //     levle_btn_1.onClick.AddListener(Level_1_btn_Click);
    //     levle_btn_2.onClick.AddListener(Level_2_btn_Click);
    //     levle_btn_3.onClick.AddListener(Level_3_btn_Click);
    //     levle_btn_4.onClick.AddListener(Level_4_btn_Click);
    //     levle_btn_5.onClick.AddListener(Level_5_btn_Click);
    // }

    // private void Level_5_btn_Click()
    // {
    //     SceneManager.LoadScene(6);
    // }

    // private void Level_4_btn_Click()
    // {
    //     SceneManager.LoadScene(5);
    // }

    // private void Level_3_btn_Click()
    // {
    //     SceneManager.LoadScene(4);
    // }


    // private void Level_2_btn_Click()
    // {
    //     SceneManager.LoadScene(3);
    // }

    // private void Level_1_btn_Click()
    // {
    //     SceneManager.LoadScene(2);
    // }

    // private void Credit_btn_Click()
    // {
    //     SceneManager.LoadScene(1);
    // }

    // private void Start_btn_Click()
    // {
    //     menu_manager.SetActive(false);
    //     title.SetActive(false);
    //     level_manager.SetActive(true);
    // }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
