using LibraryEventAPI.Data;
using LibraryEventAPI.Models;
using LibraryEventAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LibraryEventAPI.Service
{
    public class UserService : IUserInterface
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<UserModel>> SignUp(SignUpDto data)
        {
            var response = new ResponseModel<UserModel>();
            try
            {
                var email = await _context.Users.FirstOrDefaultAsync(u=> u.Email == data.Email);
                if (email != null)
                {
                    response.Message = "Email já cadastrado";
                    return response;
                }

                var user = new UserModel
                {
                    Name = data.Name,
                    Email = data.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(data.Password)
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                response.Data = user;
                response.Message = "Usuário cadastrado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UserModel>> SignIn(SignInDto data)
        {
            var response = new ResponseModel<UserModel>();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u=> u.Email == data.Email);
                if(user == null)
                {
                    response.Message = "Usuário não encontrado";
                    return response;
                }

                var checkPass = BCrypt.Net.BCrypt.Verify(data.Password, user.Password);
                if (checkPass == false)
                {
                    response.Message = "Senha incorreta";
                    return response;
                }

                response.Data = user;
                response.Message = "Usuário logado com sucesso";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
