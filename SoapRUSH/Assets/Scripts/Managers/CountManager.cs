using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountManager : MonoBehaviour
{
    /* TO-DO
     * On each level, calculate the soap amount that how can be used for that level
     */

    public int levelNo;

    public Text bText1;
    public int btn1RemainingUsage;
    public Text bText2;
    public int btn2RemainingUsage;
    public Text bText3;
    public int btn3RemainingUsage;
    public Text bText4;
    public int btn4RemainingUsage;
    
    private void Start()
    {
        
        bText1 = GameObject.FindGameObjectWithTag("btn1text").GetComponent<Text>();
        bText2 = GameObject.FindGameObjectWithTag("btn2text").GetComponent<Text>();
        bText3 = GameObject.FindGameObjectWithTag("btn3text").GetComponent<Text>();
        bText4 = GameObject.FindGameObjectWithTag("btn4text").GetComponent<Text>();
        
        SetSoapAmountForLevel();
    }

    private void Update()
    {
        SetUpTexts();
    }

    private void SetUpTexts()
    {
        bText1.text = btn1RemainingUsage.ToString();
        bText2.text = btn2RemainingUsage.ToString();
        bText3.text = btn3RemainingUsage.ToString();
        bText4.text = btn4RemainingUsage.ToString();
    }

    private void SetSoapAmountForLevel()
    {
        btn1RemainingUsage = 10;
        btn2RemainingUsage = 5;
        btn3RemainingUsage = 2;
        btn4RemainingUsage = 1;
    }
}
