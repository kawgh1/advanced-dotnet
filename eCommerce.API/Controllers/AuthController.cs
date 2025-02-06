using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")] // - /api/auth
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    // User Registration Endpoint
    [HttpPost("register")] // POST - /api/auth/register
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        // Check for invalid register request
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration request");
        }
        
        AuthenticationResponse? authResponse = await _userService.Register(registerRequest);

        if (authResponse == null || authResponse.Success == false)
        {
            return BadRequest(authResponse);
        }
        
        return Ok(authResponse); // 200
    }
    
    // User Login Endpoint
    [HttpPost("login")] // POST - /api/auth/login
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        // Check for invalid register request
        if (loginRequest == null)
        {
            return BadRequest("Invalid registration request");
        }
        
        AuthenticationResponse? authResponse = await _userService.Login(loginRequest);

        if (authResponse == null || authResponse.Success == false)
        {
            return Unauthorized(authResponse);
        }
        
        return Ok(authResponse); // 200
    }
}