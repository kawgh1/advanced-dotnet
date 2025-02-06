using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
        if (user == null)
        {
            return null;
        }

        return new AuthenticationResponse(user.UserId, user.Email, user.PersonName, user.Gender, "token",
            Success: true);
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        ApplicationUser user = new ApplicationUser()
        {
            PersonName = registerRequest.PersonName,
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Gender = registerRequest.Gender.ToString(),
        };

        ApplicationUser? registeredUser = await _userRepository.AddUser(user);
        
        // Fail
        if (registeredUser == null)
        {
            return null;
        }
        // Success
        return new AuthenticationResponse(user.UserId, user.Email, user.PersonName, user.Gender, "token",
            Success: true);    }
}