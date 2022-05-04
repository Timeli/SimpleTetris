using UnityEngine;
using UnityEngine.EventSystems;

namespace Services.Input
{
    public class MoveLeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public static bool Pressed { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            Pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Pressed = false;
        }
    }
}