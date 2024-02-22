using UnityEngine;

namespace Code.Services.MapService
{
    public interface IMapService
    {
        Vector3 ConvertToGridCell(Vector3 position, Vector3Int direction);
        Vector3Int GetPositionOnGrid(Vector3 position);
    }
}