using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _upgradesPanel;
    [SerializeField] private GameObject _skinsPanel;

    public void OpenSettings()
    {
        _settingsPanel.SetActive(true);
    }

    public void OpenUpgrades()
    {
        _upgradesPanel.SetActive(true);
    }

    public void OpenSkins()
    {
        _skinsPanel.SetActive(true);
    }
}
