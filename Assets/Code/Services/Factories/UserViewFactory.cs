using Assets.Code.Leaderboard;
using UnityEngine;

namespace Code.Services.Factories
{
    [CreateAssetMenu(fileName = "new UserViewFactory", menuName = "Create UserViewFactory")]
    public class UserViewFactory : ScriptableObject
    {
        [SerializeField] private UserView _prefab;

        public UserView Create(int rank, string username, int score)
        {
            var userView = Instantiate(_prefab);

            userView.Construct(rank, username, score);

            return userView;
        }
    }
}
