using UnityEngine;
using UnityEngine.UI;

public class PlaneSkinsPanel : MonoBehaviour
{
    [SerializeField] private int _price;

    [SerializeField] private int _planeIndex;
    [SerializeField] private GameObject _flag;

    [SerializeField] private GameObject _mainPlane;
    [SerializeField] private Sprite _newPlane;

    [SerializeField] private GameObject _priceText;
    [SerializeField] private GameObject _unlockedText;

    private void Start()
    {
        LoadPlanes();
    }

    private void LoadPlanes()
    {
        int index0 = PlayerPrefs.GetInt("player_0", -1);
        if (index0 == _planeIndex)
        {
            MakeBtnUnlicked();
        }
        int index1 = PlayerPrefs.GetInt("player_1", -1);
        if (index1 == _planeIndex)
        {
            MakeBtnUnlicked();
        }
        int index2 = PlayerPrefs.GetInt("player_2", -1);
        if (index2 == _planeIndex)
        {
            MakeBtnUnlicked();
        }
        int index3 = PlayerPrefs.GetInt("player_3", -1);
        if (index3 == _planeIndex)
        {
            MakeBtnUnlicked();
        }
        int index4 = PlayerPrefs.GetInt("player_4", -1);
        if (index4 == _planeIndex)
        {
            MakeBtnUnlicked();
        }
        int index5 = PlayerPrefs.GetInt("player_5", -1);
        if (index5 == _planeIndex)
        {
            MakeBtnUnlicked();
        }
    }

    private void MakeBtnUnlicked()
    {
        gameObject.GetComponent<Button>().interactable = true;
        gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        _priceText.SetActive(false);
        _unlockedText.SetActive(true);
    }

    public void ClickClack()
    {
        transform.parent.gameObject.GetComponent<Image>().color = new Color(0.5647027f, 0.8867924f, 0.5675792f);
        _flag.transform.SetParent(gameObject.transform);
        _mainPlane.GetComponent<Image>().sprite = _newPlane;

        _priceText.SetActive(false);
        _unlockedText.SetActive(true);

        SavePlaneIndex();
    }

    private void SavePlaneIndex()
    {
        if (gameObject.transform.parent.transform.parent.name.Contains("0"))
        {
            PlayerPrefs.SetInt("player_0", _planeIndex);
        }
        else if (gameObject.transform.parent.transform.parent.name.Contains("1"))
        {
            PlayerPrefs.SetInt("player_1", _planeIndex);
        }
        else if (gameObject.transform.parent.transform.parent.name.Contains("2"))
        {
            PlayerPrefs.SetInt("player_2", _planeIndex);
        }
        else if (gameObject.transform.parent.transform.parent.name.Contains("3"))
        {
            PlayerPrefs.SetInt("player_3", _planeIndex);
        }
        else if (gameObject.transform.parent.transform.parent.name.Contains("4"))
        {
            PlayerPrefs.SetInt("player_4", _planeIndex);
        }
        else if (gameObject.transform.parent.transform.parent.name.Contains("5"))
        {
            PlayerPrefs.SetInt("player_5", _planeIndex);
        }
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