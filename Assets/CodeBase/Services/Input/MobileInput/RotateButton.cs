using UnityEngine;
using UnityEngine.EventSystems;

namespace Services.Input
{
    public class RotateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public static bool IsRotate { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsRotate = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsRotate = false;
        }
    }
}