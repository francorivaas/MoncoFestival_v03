using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoAmount : MonoBehaviour
{
    private Text text;
    public static int ammoAmount;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = ammoAmount.ToString();
    }
}
