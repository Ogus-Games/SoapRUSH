using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShow : MonoBehaviour
{
    public GameObject levels;
    // Start is called before the first frame update
    void Start()
    {
        int stars = 10;
        for (int i = 1; i <= 9; i++)
        {
            stars = PlayerPrefs.GetInt("Level" + i);
            levels = GameObject.Find("level" + i);
            if (stars < 3)
                levels.transform.Find("star3").gameObject.SetActive(false);

            if (stars < 2)
                levels.transform.Find("star2").gameObject.SetActive(false);
            if (stars < 1)
                levels.transform.Find("star1").gameObject.SetActive(false);

        }
    }
}
