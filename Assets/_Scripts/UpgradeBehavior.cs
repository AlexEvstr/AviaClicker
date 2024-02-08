using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text _hitText;
    [SerializeField] private TMP_Text _autoText;

    [SerializeField] private TMP_Text _priseHitText;
    [SerializeField] private TMP_Text _priseAutoText;

    private int[] _priseHit = { 10, 50, 100, 500, 1000, 2000, 5000, 10000, 50000, 100000, 500000, 1000000, 5000000, 20000000, 50000000, 100000000 };
    private int[] _priseAuto = { 10, 50, 100, 500, 1000, 2000, 5000, 10000, 50000, 100000, 500000, 1000000, 5000000, 20000000, 50000000, 100000000 };

    private int priseHitIndex;
    private int priseAutoIndex;
    private int _hitLevel;
    private int _autoLevel;

    private void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        priseHitIndex = PlayerPrefs.GetInt("priseHitIndex", 0);
        priseAutoIndex = PlayerPrefs.GetInt("priseAutoIndex", 0);
        _hitLevel = PlayerPrefs.GetInt("_hitLevel", 1);
        _autoLevel = PlayerPrefs.GetInt("_autoLevel", 1);
    }

    private void Update()
    {
        _hitText.text = $"lvl: {_hitLevel} \n \n +1";
        _autoText.text = $"lvl: {_autoLevel} \n \n +0.5";

        _priseHitText.text = $"Price: {_priseHit[priseHitIndex]}";
        _priseAutoText.text = $"Price: {_priseAuto[priseAutoIndex]}";
    }

    public void ClickUpgradeHit()
    {
        if (ClickBehavior.score >= _priseHit[priseHitIndex])
        {
            ClickBehavior.hitPower++;
            _hitLevel++;
            ClickBehavior.score -= _priseHit[priseHitIndex];
            priseHitIndex++;
        }
        
        Debug.Log($"Hit Power: {ClickBehavior.hitPower}");
    }

    public void ClickUpgradeAuto()
    {
        if (ClickBehavior.score >= _priseAuto[priseAutoIndex])
        {
            ClickBehavior.pointsPerSecond += 0.5f;
            _autoLevel++;
            ClickBehavior.score -= _priseAuto[priseAutoIndex];
            priseAutoIndex++;
        }
        
        Debug.Log($"Auto Click: {ClickBehavior.pointsPerSecond}");
    }

    private void OnDisable()
    {
        SaveData();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("priseHitIndex", priseHitIndex);
        PlayerPrefs.SetInt("priseAutoIndex", priseAutoIndex);
        PlayerPrefs.SetInt("_hitLevel", _hitLevel);
        PlayerPrefs.SetInt("_autoLevel", _autoLevel);
    }
}
