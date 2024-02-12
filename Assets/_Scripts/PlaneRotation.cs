using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaneRotation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite[] _planes;
 
    private float _rotationIndex = 0.05f;

    private void Start()
    {
        LoadSprite();
        StartCoroutine(ChangeRotationIndex());
    }

    private void LoadSprite()
    {
        int planeSprite = PlayerPrefs.GetInt("planeSprite", 0);
        if (planeSprite == 0)
        {
            gameObject.GetComponent<Image>().sprite = _planes[0];
        }
        else if (planeSprite == 1)
        {
            gameObject.GetComponent<Image>().sprite = _planes[1];
        }
        else if (planeSprite == 2)
        {
            gameObject.GetComponent<Image>().sprite = _planes[2];
        }
        else if (planeSprite == 3)
        {
            gameObject.GetComponent<Image>().sprite = _planes[3];
        }
        else if (planeSprite == 4)
        {
            gameObject.GetComponent<Image>().sprite = _planes[4];
        }
        else if (planeSprite == 5)
        {
            gameObject.GetComponent<Image>().sprite = _planes[5];
        }
    }

    private IEnumerator ChangeRotationIndex()
    {
        while (true)
        {
            _rotationIndex = -_rotationIndex;
            yield return new WaitForSeconds(10f);
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, _rotationIndex);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnDisable()
    {
        SaveSprite();
    }

    private void SaveSprite()
    {
        if (gameObject.GetComponent<Image>().sprite.name.Contains("0"))
        {
            PlayerPrefs.SetInt("planeSprite", 0);
        }
        else if (gameObject.GetComponent<Image>().sprite.name.Contains("1"))
        {
            PlayerPrefs.SetInt("planeSprite", 1);
        }
        else if (gameObject.GetComponent<Image>().sprite.name.Contains("2"))
        {
            PlayerPrefs.SetInt("planeSprite", 2);
        }
        else if (gameObject.GetComponent<Image>().sprite.name.Contains("3"))
        {
            PlayerPrefs.SetInt("planeSprite", 3);
        }
        else if (gameObject.GetComponent<Image>().sprite.name.Contains("4"))
        {
            PlayerPrefs.SetInt("planeSprite", 4);
        }
        else if (gameObject.GetComponent<Image>().sprite.name.Contains("5"))
        {
            PlayerPrefs.SetInt("planeSprite", 5);
        }
    }
}