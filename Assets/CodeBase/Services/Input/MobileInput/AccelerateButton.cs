using UnityEngine;
using UnityEngine.EventSystems;

namespace Services.Input
{
    public class AccelerateButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public static bool IsAccelerate { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsAccelerate = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsAccelerate = false;
        }
    }
}