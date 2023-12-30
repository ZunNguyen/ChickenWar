using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Delete : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected GameObject highlight;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropObj = eventData.pointerDrag;
        DragItem dragItem = dropObj.GetComponent<DragItem>();
        if (dragItem == null) return;
        Spawner.Instance.Despawn(dragItem.transform);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.SetActive(false);
    }
} 