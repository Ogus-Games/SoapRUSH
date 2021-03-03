using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Text volume;
    public Text ses;

    public Text geri;
    public Text retu;
   public AudioMixer audioMixer;
   public Slider slider;
   public Dropdown dropdown;
    void Start() {
        //initial volume settings
        float f = PlayerPrefs.GetFloat("Vol");
        audioMixer.SetFloat("MainVolume",f);
        slider.value = f;

        // initial language settings
        int lang = PlayerPrefs.GetInt("Lang");
        dropdown.value = lang;
        if(lang == 0){
            volume.enabled = false;
            ses.enabled = true;
            retu.enabled = false;
            geri.enabled = true;
        }
        else{
            retu.enabled = true;
            geri.enabled = false;
            volume.enabled = true;
            ses.enabled = false;
        }
    }

   public void SetVolume(float volume){
       audioMixer.SetFloat("MainVolume", volume);
       PlayerPrefs.SetFloat("Vol",volume);
   }

//change texts according to the language choice and save it for the other scenes.
   public void HandleInputData(int val){
       int value = dropdown.value;
       if(value == 0){
           PlayerPrefs.SetInt("Lang",0);
           volume.enabled = false;
           ses.enabled = true;
           retu.enabled = false;
           geri.enabled = true;
       }
       else{
           PlayerPrefs.SetInt("Lang",1);
           retu.enabled = true;
           geri.enabled = false;
           volume.enabled = true;
           ses.enabled = false;
       }
   }
}
