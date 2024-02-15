using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeBehavior : MonoBehaviour
{
    [SerializeField] private Button _hitBtn;
    [SerializeField] private Image _hitImage;
    [SerializeField] private Button _AutoBtn;
    [SerializeField] private Image _AutoImage;

    [SerializeField] private TMP_Text _hitText;
    [SerializeField] private TMP_Text _autoText;

    [SerializeField] private TMP_Text _priceHitText;
    [SerializeField] private TMP_Text _priceAutoText;

    private int[] _priceHit = { 10, 50, 100, 500, 1000, 2000, 5000, 10000, 50000, 100000, 500000, 1000000, 5000000, 20000000, 50000000, 100000000 };
    private int[] _priceAuto = { 10, 50, 100, 500, 1000, 2000, 5000, 10000, 50000, 100000, 500000, 1000000, 5000000, 20000000, 50000000, 100000000 };

    private int priceHitIndex;
    private int priceAutoIndex;
    private int _hitLevel;
    private int _autoLevel;

    private void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        priceHitIndex = PlayerPrefs.GetInt("priseHitIndex", 0);
        priceAutoIndex = PlayerPrefs.GetInt("priseAutoIndex", 0);
        _hitLevel = PlayerPrefs.GetInt("_hitLevel", 1);
        _autoLevel = PlayerPrefs.GetInt("_autoLevel", 1);
    }

    private void Update()
    {
        CheckHitBtn();
        CheckAutoBtn();
        ShowLvlInfo();
        ShowPriceInfo();
    }

    private void CheckHitBtn()
    {
        if (_priceHit[priceHitIndex] > ClickBehavior.score)
        {
            _hitBtn.interactable = false;
            _hitImage.color = new Color(0.5f, 0.5f, 0.5f);
            _hitText.GetComponent<TMP_Text>().color = new Color(0.5f, 0.5f, 0.5f);
            _priceHitText.GetComponent<TMP_Text>().color = new Color(0.5f, 0.5f, 0.5f);
        }

        else if (_priceHit[priceHitIndex] <= ClickBehavior.score)
        {
            _hitBtn.interactable = true;
            _hitImage.color = new Color(1, 1, 1);
            _hitText.GetComponent<TMP_Text>().color = new Color(1, 1, 1);
            _priceHitText.GetComponent<TMP_Text>().color = new Color(1, 1, 1);
        }
    }

    private void CheckAutoBtn()
    {
        if (_priceAuto[priceAutoIndex] > ClickBehavior.score)
        {
            _AutoBtn.interactable = false;
            _AutoImage.color = new Color(0.5f, 0.5f, 0.5f);
            _autoText.GetComponent<TMP_Text>().color = new Color(0.5f, 0.5f, 0.5f);
            _priceAutoText.GetComponent<TMP_Text>().color = new Color(0.5f, 0.5f, 0.5f);
        }

        else if (_priceAuto[priceAutoIndex] <= ClickBehavior.score)
        {
            _AutoBtn.interactable = true;
            _AutoImage.color = new Color(1, 1, 1);
            _autoText.GetComponent<TMP_Text>().color = new Color(1,1,1);
            _priceAutoText.GetComponent<TMP_Text>().color = new Color(1, 1, 1);
        }
    }

    private void ShowLvlInfo()
    {
        _hitText.text = $"Level {_hitLevel}: +1";
        _autoText.text = $"Level {_autoLevel}: +0.5";
    }

    private void ShowPriceInfo()
    {
        _priceHitText.text = $"Price:  {_priceHit[priceHitIndex]}";
        _priceAutoText.text = $"Price:  {_priceAuto[priceAutoIndex]}";
    }

    public void ClickUpgradeHit()
    {
        if (ClickBehavior.score >= _priceHit[priceHitIndex])
        {
            ClickBehavior.hitPower++;
            _hitLevel++;
            ClickBehavior.score -= _priceHit[priceHitIndex];
            priceHitIndex++;
        }
    }

    public void ClickUpgradeAuto()
    {
        if (ClickBehavior.score >= _priceAuto[priceAutoIndex])
        {
            ClickBehavior.pointsPerSecond += 0.5f;
            _autoLevel++;
            ClickBehavior.score -= _priceAuto[priceAutoIndex];
            priceAutoIndex++;
        }
    }

    private void OnDisable()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("priseHitIndex", priceHitIndex);
        PlayerPrefs.SetInt("priseAutoIndex", priceAutoIndex);
        PlayerPrefs.SetInt("_hitLevel", _hitLevel);
        PlayerPrefs.SetInt("_autoLevel", _autoLevel);
    }
}
