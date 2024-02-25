using UnityEngine;

namespace Assets.Code.Services.UserService
{
    public class UserService : IUserService
    {
        private const string UserNameKey = nameof(UserNameKey);

        private readonly string _standartName = "User";

        public string UserName { get; private set; }

        public UserService()
        {
            var userName = PlayerPrefs.GetString(UserNameKey);

            if(string.IsNullOrEmpty(userName))
            {
                userName = _standartName;
            }

            UserName = userName;
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrEmpty(newName))
                return;

            UserName = newName;

            PlayerPrefs.SetString(UserNameKey, UserName);
            PlayerPrefs.Save();
        }
    }
}
