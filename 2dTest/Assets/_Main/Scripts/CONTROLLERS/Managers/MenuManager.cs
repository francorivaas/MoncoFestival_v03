﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Buttons")]
    
    [SerializeField]
    private Button buttonGoBack = null;

    [SerializeField]
    private Button buttonExit = null;

    [SerializeField] 
    private Button buttonPlay = null;

    [SerializeField] 
    private Button buttonHelp = null;

    [Header("Scene Settings")]

    [SerializeField] 
    private string gameSceneName = null;

    [SerializeField] 
    private TextMeshProUGUI title = null;

    [Header("Menues")]

    [SerializeField] 
    private GameObject helpMenu = null;

    [SerializeField] 
    private GameObject mainMenu = null;

    float timeToPlay = 1f;
    float currentTimeToPlay = 0f;

    bool canCount;

    [Header("Components")]

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioClip buttonPressed;

    private AudioSource audioSource;

    float timeToAnim = 1.0f;
    float currentTimeToAnim = 0.0f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        buttonHelp.onClick.AddListener(OnClickHelpHandler);
        buttonPlay.onClick.AddListener(OnClickHandler);
        buttonExit.onClick.AddListener(OnExitClickHandler);
        buttonGoBack.onClick.AddListener(OnGoBackHandler);
    }

    private void Start()
    {
        helpMenu.gameObject.SetActive(false);
        buttonGoBack.gameObject.SetActive(false);
    }

    void OnClickHandler()
    {
        audioSource.clip = buttonPressed;
        audioSource.Play();

        canCount = true;
        helpMenu.gameObject.SetActive(false);
        title.text = "GO!";
    }

    void OnGoBackHandler()
    {
        audioSource.clip = buttonPressed;
        audioSource.Play();

        //BOTONES
        helpMenu.gameObject.SetActive(false);
        buttonExit.gameObject.SetActive(true);
        buttonPlay.gameObject.SetActive(true);
        buttonGoBack.gameObject.SetActive(false);
        //TITULO
        title.gameObject.SetActive(true);
    }

    void OnClickHelpHandler()
    {
        audioSource.clip = buttonPressed;
        audioSource.Play();

        //BOTONES
        helpMenu.gameObject.SetActive(true);
        buttonExit.gameObject.SetActive(false);
        buttonPlay.gameObject.SetActive(false);
        buttonGoBack.gameObject.SetActive(true);
        //TITULO
        title.gameObject.SetActive(false);
    }

    void OnExitClickHandler()
    {
        audioSource.clip = buttonPressed;
        audioSource.Play();

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
                animator.SetTrigger("Start");

                currentTimeToAnim += Time.deltaTime;

                if (currentTimeToAnim >= timeToAnim)
                {
                    SceneManager.LoadScene(gameSceneName);
                }
            } 
        }
    }
}
