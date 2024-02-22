using Code.Snake;
using UnityEngine;

namespace Code.Services.Factories
{
    [CreateAssetMenu(menuName = "Create BodyElementFactory", fileName = "BodyElementFactory", order = 0)]
    public class SegmentFactory : ScriptableObject
    {
        [SerializeField] private Segment _prefab;
        
        public Segment Create(Vector3 position, Transform parent) =>
            Instantiate(
                _prefab, 
                position, 
                Quaternion.identity, 
                parent);
    }
}