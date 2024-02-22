using UnityEngine;

namespace Code.Snake
{
    public interface IMovable
    {
        void Move(Vector3Int direction);
    }
}