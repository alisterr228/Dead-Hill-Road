using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarDir : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static float move;
    public float PubMove;
    public GameObject cm;
    private Vector3 startPos;

    private void Start()
    {
        startPos = cm.transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        move = PubMove;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        move = 0f;
    }
}
