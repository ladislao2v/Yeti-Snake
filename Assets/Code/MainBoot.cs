using System;
using Code.Services.RecordService;
using Code.Services.SceneLoaderService;
using Code.UI.Game;
using UnityEngine;

namespace Code
{
    public class MainBoot : MonoBehaviour
    {
        [SerializeField] private MainWindow _mainWindow;
        [SerializeField] private LevelsWindow _levelsWindow;

        private IRecordService _recordService;
        private ISceneLoaderService _sceneLoaderService;
        
        private void Awake()
        {
            _sceneLoaderService = new SceneLoaderService();
            _recordService = new RecordService();
            _recordService.Load();
            
            _mainWindow.Construct(_sceneLoaderService, _recordService);
            _levelsWindow.Construct(_sceneLoaderService);
            
            _mainWindow.Show();
        }
    }
}