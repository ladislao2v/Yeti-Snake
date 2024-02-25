using UnityEngine;
using Dan.Main;
using Code.Services.RecordService;
using Assets.Code.Services.UserService;
using Assets.Code.Leaderboard;
using Code.Services.Factories;
using Dan.Models;

namespace Leaderboard
{
    public class Leaderboard : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private UserViewFactory _userViewFactory;

        private IUserService _userService;
        private IRecordService _recordService;
        
        private int Score => _recordService.Record;

        public void Construct(IRecordService recordService, IUserService userService)
        {
            _recordService = recordService;
            _userService = userService;
        }

        private void OnEnable()
        {
            UploadEntry();
        }

        private void LoadEntries()
        {
            Clear();

            Leaderboards.Main.GetEntries(entries =>
            {
                var length = entries.Length;

                for (int i = 0; i < length; i++)
                    SetUserView(entries[i]);
            });
        }


        public void UploadEntry()
        {
            Leaderboards.Main.UploadNewEntry(_userService.UserName, Score, isSuccessful =>
            {
                if (isSuccessful)
                    LoadEntries();
            });
        }
        private void Clear()
        {
            var userViews = _container.GetComponentsInChildren<UserView>();

            if(userViews.Length < 1 || userViews == null)
                return;

            foreach (var userView in userViews)
            {
                Destroy(userView);
            }
        }

        private void SetUserView(Entry entry)
        {
            var userView = _userViewFactory.Create(entry.Rank, entry.Username, entry.Score);
            userView.transform.parent = _container;
            userView.transform.localScale = Vector3.one;
        }
    }
}
