using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.Services.MapService
{
    public class MapService : MonoBehaviour, IMapService
    {
        [SerializeField] private int _verticalDistance;
        [SerializeField] private int _horizontalDistance;
        [SerializeField] private Tilemap _tilemap;

        public Vector3 ConvertToGridCell(Vector3 position, Vector3Int direction)
        {
            var cell = GetPositionOnGrid(position);
                
            if (IsNearMapBounds(cell, direction, out Vector3Int reversePosition))
                return _tilemap.GetCellCenterWorld(reversePosition);
                    
            return (_tilemap.GetCellCenterWorld(cell + direction));
        }

        public Vector3Int GetPositionOnGrid(Vector3 position) =>
            _tilemap.WorldToCell(position);

        private bool IsNearMapBounds(Vector3Int cell, Vector3Int direction, out Vector3Int reversePosition)
        {
            reversePosition = Vector3Int.zero;
            
            if (cell.y == _verticalDistance && direction == Vector3Int.up)
            {
                reversePosition = new Vector3Int(cell.x, -_verticalDistance);
                return true;
            }
            else if (cell.y == -_verticalDistance && direction == Vector3Int.down)
            {
                reversePosition = new Vector3Int(cell.x, _verticalDistance);
                return true;
            }
            else if (cell.x == (_horizontalDistance - 1) && direction == Vector3Int.right)
            {
                reversePosition = new Vector3Int(-_horizontalDistance - 1, cell.y);
                return true;
            } 
            else if (cell.x == (-_horizontalDistance - 1) && direction == Vector3Int.left)
            {
                reversePosition = new Vector3Int(_horizontalDistance - 1, cell.y);
                return true;
            }

            return false;
        }
    }
}