using UnityEngine;
using UnityEngine.EventSystems;

public class DragObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public AnimalData animalData;

    private Vector3 startPosition;
    private Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        // Check if dropped on bucket
        GameObject target = eventData.pointerEnter;
        if (target != null && target.CompareTag("Bucket"))
        {
            FindObjectOfType<AnimalQuizManager>().EvaluateAnimal(animalData, target);
            Destroy(gameObject);
        }
        else
        {
            transform.position = startPosition; // Reset position if not placed in bucket
        }
    }
}
