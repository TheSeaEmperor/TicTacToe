using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject draggableobject;
    public GameObject piece_prefab;
    public bool ismoveable;
    private Vector3 start_pos;
    private Transform start_parent;
    private Transform root_parent;


    private void Start()
    {
        root_parent = transform.parent;
        ismoveable = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        draggableobject = gameObject;
        start_pos = transform.position;
        start_parent = transform.parent;

        if (root_parent != start_parent)
            return;

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (root_parent != start_parent)
        {
            ismoveable = false;
            return;
        }
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draggableobject = null;
        if (transform.parent == start_parent || transform.parent == transform.root)
        {
            transform.position = start_pos;
            transform.SetParent(start_parent);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        ReplacePieces();
    }

    public void ReplacePieces()
    {
        //Checks if the Piece Starting Position currenly contains a piece and creates one if not
        if (root_parent.childCount == 0)
        {
            Instantiate(piece_prefab, root_parent);
        }
    }


}
