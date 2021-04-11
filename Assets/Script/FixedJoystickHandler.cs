using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FixedJoystickHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Transform content;
    public UnityEvent beginControl;
    public UnityEvent<Vector3> controlling;
    public UnityEvent endControl;

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.beginControl.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this.content)
        {
            this.controlling.Invoke(this.content.localPosition.normalized);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.endControl.Invoke();
    }
}