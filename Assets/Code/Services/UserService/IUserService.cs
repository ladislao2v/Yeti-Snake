using System.Globalization;

namespace Assets.Code.Services.UserService
{
    public interface IUserService
    {
        public string UserName { get; }

        public void Rename(string newName);
    }
}
