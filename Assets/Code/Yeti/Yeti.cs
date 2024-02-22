using System;
using UnityEngine;

namespace Code.Yeti
{
    public class Yeti : MonoBehaviour
    {
        public event Action<Yeti> PickUped;

        public void PickUp()
        {
            PickUped?.Invoke(this);
        }
    }
}