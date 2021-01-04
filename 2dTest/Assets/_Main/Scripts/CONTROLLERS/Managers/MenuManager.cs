using System.Collections;
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

    [SerializeField] private GameObject optionsMenu = null;
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
        /*
        optionsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        */

        optionsMenu.gameObject.SetActive(false);
    }

    void OnClickHandler()
    {
        canCount = true;
        optionsMenu.gameObject.SetActive(false);
        title.text = "GO!";
    }

    void OnClickHelpHandler()
    {
        optionsMenu.gameObject.SetActive(true);
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
