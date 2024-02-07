using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text _hitText;
    [SerializeField] private TMP_Text _autoText;

    private int _hitLevel;
    private int _autoLevel;

    private void Update()
    {
        _hitText.text = $"lvl: {_hitLevel} \n \n +1";
        _autoText.text = $"lvl: {_autoLevel} \n \n +0.1";
    }

    public void ClickUpgradeHit()
    {
        ClickBehavior.hitPower++;
        _hitLevel++;
    }

    public void ClickUpgradeAuto()
    {
        ClickBehavior.pointsPerSecond += 0.1f;
        _autoLevel++;
    }
}
