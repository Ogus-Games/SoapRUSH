using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private StarHandler _starManager;
    
        void Start()
        {
            _starManager = GameObject.FindGameObjectWithTag("starManager").GetComponent<StarHandler>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_starManager.menuIsOpen)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
