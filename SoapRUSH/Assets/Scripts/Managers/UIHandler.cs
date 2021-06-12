using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class UIHandler : MonoBehaviour
    {
        public GameObject starMenu;
    
        public void OpenStarMenu()
        {
            starMenu.SetActive(true);
        }
    }
}
