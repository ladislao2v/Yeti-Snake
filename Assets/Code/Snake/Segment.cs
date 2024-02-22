using UnityEngine;

namespace Code.Snake
{
    public class Segment : MonoBehaviour
    {
        public Vector3 Position => transform.position;
        
        public void MoveTo(Vector3 position)
        {
            transform.position = position;
        }
    }
}