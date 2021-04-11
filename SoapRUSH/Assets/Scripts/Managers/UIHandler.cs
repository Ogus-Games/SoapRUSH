using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject starMenu;
    
    public void OpenStarMenu()
    {
        starMenu.SetActive(true);
    }
}
