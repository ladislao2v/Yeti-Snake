using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        public void Render(float value)
        {
            _image.fillAmount = value;
            Debug.Log(value);
        }
    }
}