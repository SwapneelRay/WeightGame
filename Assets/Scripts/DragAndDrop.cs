using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;          

public class DragAndDrop :MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;


    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    Vector2 defaultPos;
    public bool droppedOnSlot;

    [SerializeField] Transform dummy;
    /*
    public Vector3 punch;
    public float duration;
    public int vibrate;
    public float elasticity;
    public float scalemultiplier;*/

    private void Awake()
    {
       
        canvas = FindObjectOfType<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

  

    public void OnBeginDrag(PointerEventData eventData)
    {
       // transform.DOScale(Vector3.one*.2f, 1f);
        defaultPos =transform.position;
        canvasGroup.blocksRaycasts = false;
        droppedOnSlot = false;
        dummy= transform.parent;
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.blocksRaycasts = true;
        if (!droppedOnSlot)
        {
            transform.position = defaultPos;
            transform.SetParent(dummy);

        }
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

   
}
