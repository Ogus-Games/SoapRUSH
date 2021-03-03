using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelLanguage : MonoBehaviour
{
    public Text retu;
    public Text geri;
    // Start is called before the first frame update
    void Start()
    {
        int lang = PlayerPrefs.GetInt("Lang");
        if(lang == 0){

            retu.enabled = false;
            geri.enabled = true;
        }
        else{
            retu.enabled = true;
            geri.enabled = false;
        }
    }


}
