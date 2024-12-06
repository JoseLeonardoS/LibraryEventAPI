using LibraryEventAPI.Models;
using LibraryEventAPI.Models.Dtos;

namespace LibraryEventAPI.Service
{
    public interface IUserInterface
    {
        public Task<ResponseModel<UserModel>> SignUp(SignUpDto data);
        public Task<ResponseModel<UserModel>> SignIn(SignInDto data);
    }
}
