using UnityEngine;

namespace Code.UI
{
    [RequireComponent(typeof(Canvas))]
    public abstract class Window : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}