using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaneRotation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float _rotationIndex = 0.1f;

    private void Start()
    {
        StartCoroutine(ChangeRotationIndex());
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
}