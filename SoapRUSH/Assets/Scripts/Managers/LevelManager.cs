using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public int levelNumber;
        private string levelStr = "Level"; 

        private void Start()
        {
            levelNumber = PlayerPrefs.GetInt("LevelNumber");
        }

        public void ContinueToNewScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GoMainMenu()
        {
            SceneManager.LoadScene("Scenes/MenuScenes/MainMenu");
        }
    }
}
