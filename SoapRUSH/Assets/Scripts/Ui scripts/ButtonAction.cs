using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{

    // Start is called before the first frame update

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
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void LevelManu()
    {
        SceneManager.LoadScene("Level");
    }
    public void AboutMenu()
    {
        SceneManager.LoadScene("AboutMenu");
    }

}
