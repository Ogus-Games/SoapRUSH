using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitch : MonoBehaviour
{
    public Text resume;
    public Text devam;

    public Text geri;
    public Text retu;

    // Start is called before the first frame update
    void Start()
    {
        int lang = PlayerPrefs.GetInt("Lang");
        if(lang == 0){
            resume.enabled = false;
            devam.enabled = true;
            retu.enabled = false;
            geri.enabled = true;

        }
        else{
            retu.enabled = true;
            geri.enabled = false;
            resume.enabled = true;
            devam.enabled = false;

        }
    }

}
