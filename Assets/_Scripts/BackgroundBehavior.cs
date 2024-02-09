using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundBehavior : MonoBehaviour
{
    [SerializeField] private Sprite[] _backgrounds;

    private void OnEnable()
    {
        LoadBackground();
    }

    private void LoadBackground()
    {
        int background = PlayerPrefs.GetInt("background", 0);
        if (background == 0)
        {
            gameObject.GetComponent<Image>().sprite = _backgrounds[0];
        }
        else if (background == 1)
        {
            gameObject.GetComponent<Image>().sprite = _backgrounds[1];
        }
        else if (background == 2)
        {
            gameObject.GetComponent<Image>().sprite = _backgrounds[2];
        }
        else if (background == 3)
        {
            gameObject.GetComponent<Image>().sprite = _backgrounds[3];
        }
    }
}
