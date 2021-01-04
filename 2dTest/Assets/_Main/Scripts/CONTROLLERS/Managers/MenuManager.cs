﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Button buttonExit = null;

    [SerializeField] 
    private Button buttonPlay = null;

    [SerializeField] 
    private Button buttonHelp = null;

    [SerializeField] 
    private string gameSceneName = null;

    [SerializeField] 
    private TextMeshProUGUI title = null;

    [SerializeField] private GameObject helpMenu = null;
    [SerializeField] private GameObject mainMenu = null;

    float timeToPlay = 1f;
    float currentTimeToPlay = 0f;

    bool canCount;

    private void Awake()
    {
        buttonHelp.onClick.AddListener(OnClickHelpHandler);
        
        buttonPlay.onClick.AddListener(OnClickHandler);

        buttonExit.onClick.AddListener(OnExitClickHandler);
    }

    private void Start()
    {
        helpMenu.gameObject.SetActive(false);
    }

    void OnClickHandler()
    {
        canCount = true;
        helpMenu.gameObject.SetActive(false);
        title.text = "GO!";
    }

    void OnClickHelpHandler()
    {
        helpMenu.gameObject.SetActive(true);
        buttonExit.gameObject.SetActive(false);
        buttonPlay.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
    }

    void OnExitClickHandler()
    {
        Application.Quit();
        Debug.Log("mal de app");
    }

    void Update()
    {
        if(canCount)
        {
            currentTimeToPlay += Time.deltaTime;

            if (currentTimeToPlay >= timeToPlay)
            {
                SceneManager.LoadScene(gameSceneName);
            }
                
        }
    }
}
