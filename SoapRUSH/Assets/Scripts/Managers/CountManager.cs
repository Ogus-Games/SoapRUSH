using Managers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountManager : MonoBehaviour
{
    private int levelNo;

    public Text bText1;
    public int btn1RemainingUsage;
    public Text bText2;
    public int btn2RemainingUsage;
    public Text bText3;
    public int btn3RemainingUsage;
    public Text bText4;
    public int btn4RemainingUsage;

    private LevelManager _levelManager;
    
    private void Start()
    {
        _levelManager = FindObjectOfType<LevelManager>();
        levelNo = _levelManager.levelNumber;
        bText1 = GameObject.FindGameObjectWithTag("btn1text").GetComponent<Text>();
        bText2 = GameObject.FindGameObjectWithTag("btn2text").GetComponent<Text>();
        bText3 = GameObject.FindGameObjectWithTag("btn3text").GetComponent<Text>();
        bText4 = GameObject.FindGameObjectWithTag("btn4text").GetComponent<Text>();
        
        SetSoapAmountForLevel();
    }

    private void Update()
    {
        SetUpTexts();
        RemainingTotalAmount();
    }

    private int RemainingTotalAmount()
    {
        var count = btn1RemainingUsage + btn2RemainingUsage + btn3RemainingUsage; // Fourth soup may be added
        if (count == 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        return btn1RemainingUsage + btn2RemainingUsage + btn3RemainingUsage + btn4RemainingUsage;
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
        if (levelNo <= 10)
        {
            btn1RemainingUsage = 10;
            btn2RemainingUsage = 5;
            btn3RemainingUsage = 4;
            btn4RemainingUsage = 1;
        }
        else if (10 < levelNo && levelNo <= 20)
        {
            btn1RemainingUsage = 7;
            btn2RemainingUsage = 3;
            btn3RemainingUsage = 3;
            btn4RemainingUsage = 1;
        }
        else if (20 < levelNo && levelNo <= 30)
        {
            btn1RemainingUsage = 5;
            btn2RemainingUsage = 5;
            btn3RemainingUsage = 2;
            btn4RemainingUsage = 1;
        }
        else if (30 < levelNo && levelNo <= 40)
        {
            btn1RemainingUsage = 4;
            btn2RemainingUsage = 5;
            btn3RemainingUsage = 1;
            btn4RemainingUsage = 1;
        }
        else if (40 < levelNo && levelNo <= 50)
        {
            btn1RemainingUsage = 3;
            btn2RemainingUsage = 2;
            btn3RemainingUsage = 1;
            btn4RemainingUsage = 1;
        }

    }
}
