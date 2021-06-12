using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{

    private StarHandler _starHandler;
    void Start()
    {
        _starHandler = GameObject.FindGameObjectWithTag("starManager").GetComponent<StarHandler>();
    }
    public void GameScene()
    {
        SceneManager.LoadScene("Level1");
    }
    public void SettingsMenu()
    {
        SceneManager.LoadScene("Settings");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        _starHandler.menuIsOpen = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _starHandler.menuIsOpen = false;
        Time.timeScale = 1;
    }
    public void LevelManu()
    {
        SceneManager.LoadScene("SwipeLevel");
    }
    public void AboutMenu()
    {
        SceneManager.LoadScene("AboutMenu");
    }
    public void AppPurchase()
    {
        SceneManager.LoadScene("AppPurchase");
    }

}
