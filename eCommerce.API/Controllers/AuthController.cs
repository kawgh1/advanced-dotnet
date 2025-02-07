using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")] // - /api/auth
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IUserService userService, ILogger<AuthController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    // User Registration Endpoint
    [HttpPost("register")] // POST - /api/auth/register
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        // Check for invalid register request
        if (registerRequest == null)
        {
            _logger.LogError("Invalid request");
            return BadRequest("Invalid registration request");
        }
        
        AuthenticationResponse? authResponse = await _userService.Register(registerRequest);

        if (authResponse == null || authResponse.Success == false)
        {
            _logger.LogError("Failed to register user");
            return BadRequest(authResponse);
        }

        string email = registerRequest.Email ?? string.Empty;
        _logger.LogInformation("User {email} registered successfully", email);
        return Ok(authResponse); // 200
    }
    
    // User Login Endpoint
    [HttpPost("login")] // POST - /api/auth/login
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        // Check for invalid register request
        if (loginRequest == null)
        {
            _logger.LogError("Invalid login request");
            return BadRequest("Invalid login request");
        }
        
        AuthenticationResponse? authResponse = await _userService.Login(loginRequest);

        if (authResponse == null || authResponse.Success == false)
        {
            _logger.LogError("Unauthorized: Failed to login user");
            return Unauthorized(authResponse);
        }
        string email = loginRequest.Email ?? string.Empty;
        _logger.LogInformation("User {email} logged in successfully", email);
        return Ok(authResponse); // 200
    }
}