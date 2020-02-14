using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelDragDrop : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject hole;
    [SerializeField] private Canvas canvas;

    public int id;

    //GameObject paku;
    //DragDrop pakuDragDrop;

    RectTransform rect;

    void Awake()
    {
        rect = gameObject.GetComponent<RectTransform>();
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.sizeDelta.x,  
            canvas.pixelRect.height + rect.sizeDelta.y);
    }

}
