using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsAmount : MonoBehaviour
{
    private Text text;
    public static int gemsAmount;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = gemsAmount.ToString();
    }
}
