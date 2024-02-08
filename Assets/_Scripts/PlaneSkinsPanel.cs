using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneSkinsPanel : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private GameObject _flag;

    [SerializeField] private GameObject _mainPlane;
    [SerializeField] private Sprite _newPlane;

    [SerializeField] private GameObject _priceText;
    [SerializeField] private GameObject _unlockedText;

    private ArrayList names;

    private string _isLock;

    private void Start()
    {
        _isLock = PlayerPrefs.GetString("isLock", "");
        Debug.Log(_isLock);
        //if (_isLock.Contains(gameObject.transform.parent.transform.parent.name))
        //{
        //    gameObject.GetComponent<Button>().interactable = true;
        //    gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        //    _priceText.SetActive(false);
        //    _unlockedText.SetActive(true);
        //}
    }

    public void ClickClack()
    {
        transform.parent.gameObject.GetComponent<Image>().color = new Color(0.5647027f, 0.8867924f, 0.5675792f);
        _flag.transform.SetParent(gameObject.transform);
        _mainPlane.GetComponent<Image>().sprite = _newPlane;

        _priceText.SetActive(false);
        _unlockedText.SetActive(true);
        //names.Add(gameObject.transform.parent.transform.parent);
        PlayerPrefs.SetString("isLock", names.ToString());
    }

    private void Update()
    {
        ChechScore();
        CheckParent();
    }

    private void ChechScore()
    {
        if (_price < ClickBehavior.score)
        {
            gameObject.GetComponent<Button>().interactable = true;
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else if (_price >= ClickBehavior.score)
        {
            gameObject.GetComponent<Button>().interactable = false;
            gameObject.GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }

    private void CheckParent()
    {
        if (gameObject.transform.childCount == 0)
        {
            transform.parent.gameObject.GetComponent<Image>().color = new Color(0.5849056f, 0.5849056f, 0.5849056f);
        }
    }
}
