using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [SerializeField] private Transform _child;
    [SerializeField] private LayerMask layerMask;

    public Vector2 _pointedPosition => rectTransform.position;

    [Inject]
    private CoblosContainer coblosContainer;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("onBeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("onDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("onEndDrag");
        canvasGroup.blocksRaycasts = true;

        RaycastHit2D hit = Physics2D.Raycast(_child.transform.position, Vector2.zero, Mathf.Infinity, layerMask);

        if (hit.collider != null)
        {
            coblosContainer.selected = hit.collider.gameObject;
            coblosContainer.newPos = _child.transform.position;
            coblosContainer.onNyoblos();
        }
            
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("onPointerDown");
    }
}
