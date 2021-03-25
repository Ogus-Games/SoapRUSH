using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Image volume;

    public Image ses;
    public AudioMixer audioMixer;
    public Slider slider;
    void Start()
    {
        //initial volume settings
        float f = PlayerPrefs.GetFloat("Vol");
        audioMixer.SetFloat("MainVolume", f);
        slider.value = f;

        // initial language settings
        int lang = PlayerPrefs.GetInt("Lang");
        if (lang == 0)
        {
            LangtoTurkish();
        }
        else
        {
            LangtoEnglish();
        }

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MainVolume", volume);
        PlayerPrefs.SetFloat("Vol", volume);
    }


    public void LangtoTurkish()
    {
        PlayerPrefs.SetInt("Lang", 0);
        volume.enabled = false;
        ses.enabled = true;

    }
    public void LangtoEnglish()
    {
        PlayerPrefs.SetInt("Lang", 1);
        volume.enabled = true;
        ses.enabled = false;
    }


}
