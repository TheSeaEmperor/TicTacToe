using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject draggableobject;
    private Vector3 start_pos;
    private Transform start_parent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        draggableobject = gameObject;
        start_pos = transform.position;
        start_parent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //GetComponentInParent<GridLayout>().enabled = false;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //GetComponentInParent<GridLayout>().enabled = true;
        draggableobject = null;
        if (transform.parent == start_parent || transform.parent == transform.root)
        {
            transform.position = start_pos;
            transform.SetParent(start_parent);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
