using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSkinsPanel : MonoBehaviour
{
    [SerializeField] private Image _mainBackground;
    [SerializeField] private Sprite _bgImage;

    [SerializeField] private int _price;

    [SerializeField] private GameObject _priceText;
    [SerializeField] private GameObject _unlockedText;

    [SerializeField] private GameObject _backgroundFlag;

    [SerializeField] private int _bgIndex;


    private void Start()
    {
        LoadStatus();
    }

    private void LoadStatus()
    {
        int index0 = PlayerPrefs.GetInt("bgStatus_0", -1);
        if (index0 == _bgIndex)
        {
            MakeBtnUnlicked();
        }
        int index1 = PlayerPrefs.GetInt("bgStatus_1", -1);
        if (index1 == _bgIndex)
        {
            MakeBtnUnlicked();
        }
        int index2 = PlayerPrefs.GetInt("bgStatus_2", -1);
        if (index2 == _bgIndex)
        {
            MakeBtnUnlicked();
        }
        int index3 = PlayerPrefs.GetInt("bgStatus_3", -1);
        if (index3 == _bgIndex)
        {
            MakeBtnUnlicked();
        }
    }

    private void MakeBtnUnlicked()
    {
        gameObject.transform.GetChild(0).GetComponent<Button>().interactable = true;
        gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1);
        _priceText.SetActive(false);
        _unlockedText.SetActive(true);
    }

    public void ChooseBackground()
    {
        if (_priceText.activeInHierarchy)
        {
            ClickBehavior.score -= _price;
        }
        _mainBackground.GetComponent<Image>().sprite = _bgImage;
        SaveBackground();
        _backgroundFlag.transform.SetParent(gameObject.transform);

        _priceText.SetActive(false);
        _unlockedText.SetActive(true);

        SaveStatus();
    }

    private void SaveBackground()
    {
        if (gameObject.transform.name.Contains("0"))
        {
            PlayerPrefs.SetInt("background", 0);
        }
        else if (gameObject.transform.name.Contains("1"))
        {
            PlayerPrefs.SetInt("background", 1);
        }
        else if (gameObject.transform.name.Contains("2"))
        {
            PlayerPrefs.SetInt("background", 2);
        }
        else if (gameObject.transform.name.Contains("3"))
        {
            PlayerPrefs.SetInt("background", 3);
        }
    }

    private void Update()
    {
        CheckPrice();
        CheckFlag();
    }

    private void CheckPrice()
    {
        if (_price <= ClickBehavior.score)
        {
            gameObject.transform.GetChild(0).GetComponent<Button>().interactable = true;
            gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else if (_price > ClickBehavior.score)
        {
            gameObject.transform.GetChild(0).GetComponent<Button>().interactable = false;
            gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }

    private void CheckFlag()
    {
        if (gameObject.transform.childCount < 4)
        {
            gameObject.GetComponent<Image>().color = new Color(0.6981132f, 0.6981132f, 0.6981132f);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(0.7312143f, 1f, 0.7311321f);
        }
    }

    private void SaveStatus()
    {
        if (gameObject.transform.name.Contains("0"))
        {
            PlayerPrefs.SetInt("bgStatus_0", _bgIndex);
        }
        else if (gameObject.transform.name.Contains("1"))
        {
            PlayerPrefs.SetInt("bgStatus_1", _bgIndex);
        }
        if (gameObject.transform.name.Contains("2"))
        {
            PlayerPrefs.SetInt("bgStatus_2", _bgIndex);
        }
        if (gameObject.transform.name.Contains("3"))
        {
            PlayerPrefs.SetInt("bgStatus_3", _bgIndex);
        }
    }
}
