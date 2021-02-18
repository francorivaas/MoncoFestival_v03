using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIenemiesCounter : MonoBehaviour
{
    public static int points = 0;

    Text pointsText;

    private void Awake()
    {
        pointsText = GetComponent<Text>();
    }

    private void Update()
    {
        pointsText.text = points.ToString();
    }
}
