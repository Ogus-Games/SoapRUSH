using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
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
    }
}
