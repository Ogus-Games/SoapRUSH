using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void GameScene(){
        SceneManager.LoadScene("Game");
    }
    public void SettingsMenu(){
        SceneManager.LoadScene("Settings");
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void PauseMenu(){
        SceneManager.LoadScene("PauseMenu");
    }
    public void LevelManu(){
        SceneManager.LoadScene("Level");
    }
    
}
