using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementInputs : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] Image knobBase;
    [SerializeField] Image knobMove;
    Vector2 touchPos;
    public Vector2 Direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        touchPos = eventData.position;
        knobBase.gameObject.SetActive(true);
        knobMove.gameObject.SetActive(true);
        knobBase.rectTransform.position = touchPos;
        knobMove.rectTransform.position = touchPos;

    }


    public void OnDrag(PointerEventData eventData)
    {
        Direction = eventData.position - touchPos;
        Direction.Normalize();
        knobMove.rectTransform.position = eventData.position;
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
        knobBase.gameObject.SetActive(false);
        knobMove.gameObject.SetActive(false);

    }
}
