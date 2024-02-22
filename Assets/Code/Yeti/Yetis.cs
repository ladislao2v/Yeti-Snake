using System.Collections.Generic;
using Code.Services.LevelService;
using Code.Services.MapService;
using UnityEngine;

namespace Code.Yeti
{
    public class Yetis : MonoBehaviour
    {
        [SerializeField] private List<Yeti> _yetis;
        private ILevelService _levelService;
        private IMapService _mapService;

        private int YetisCount => _yetis.Count;

        public void Construct(ILevelService levelService, IMapService mapService)
        {
            _mapService = mapService;
            _levelService = levelService;
        }
        
        private void OnEnable()
        {
            foreach (var yeti in _yetis)
            {
                yeti.PickUped += OnYetiCollected;
            }
        }

        private void OnYetiCollected(Yeti yeti)
        {
            yeti.PickUped -= OnYetiCollected;
            yeti.gameObject.SetActive(false);
            _yetis.Remove(yeti);
            
            if(YetisCount == 0)
                _levelService.EndLevel();
        }

        public bool IsIntersect(Vector3Int position)
        {
            foreach (var yeti in _yetis)
            {
                if (_mapService.GetPositionOnGrid(yeti.transform.position) == position)
                {
                    yeti.PickUp();
                    return true;
                }
            }

            return false;
        }
    }
}