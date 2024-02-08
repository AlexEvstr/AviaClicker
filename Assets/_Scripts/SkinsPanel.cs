using UnityEngine;

public class SkinsPanel : MonoBehaviour
{
    [SerializeField] private GameObject _skinsPanel;

    [SerializeField] private GameObject _planeSkinsPanel;
    [SerializeField] private GameObject _backgroundSkinsPanel;

    public void OpenPlaneSkinsPanel()
    {
        _skinsPanel.SetActive(false);
        _planeSkinsPanel.SetActive(true);
    }

    public void ClosePlaneSkinsPanel()
    {
        _planeSkinsPanel.SetActive(false);
        _skinsPanel.SetActive(true);
    }

    public void OpenBackgroundSkinsPanel()
    {
        _skinsPanel.SetActive(false);
        _backgroundSkinsPanel.SetActive(true);
    }

    public void CloseBackgroundSkinsPanel()
    {
        _backgroundSkinsPanel.SetActive(false);
        _skinsPanel.SetActive(true);
    }
}
