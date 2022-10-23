using AutoMapper;
using HRVacancies.Dtos;
using HRVacancies.Models;
using HRVacancies.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRVacancies.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IConfiguration _config;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtTokenGenerator jwtTokenGenerator,
            IMapper mapper,
            IConfiguration config)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
            _config = config;
        }

        [HttpGet("login")]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] UserLoginDto userForLoginDto)
        {
            var user = await userManager.FindByNameAsync(userForLoginDto.UserName);

            if (user == null) return BadRequest(new
            {
                result = "المستخدم غير موجود"
            });

            var result = await signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized();
            {
                var appUser = await userManager.Users.FirstOrDefaultAsync(u =>
                    u.NormalizedUserName == userForLoginDto.UserName.ToUpper());

                var userToReturn = appUser;

                var token = await jwtTokenGenerator.GenerateJwtTokenString(userToReturn);

                HttpContext.Session.SetString("Token", token);

                return Redirect("/");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userForRegisterDto)
        {
            var userToCreate = _mapper.Map<ApplicationUser>(userForRegisterDto);


            var result = await userManager.CreateAsync(userToCreate, userForRegisterDto.Password);
            await userManager.AddToRoleAsync(userToCreate, "NormalUser");

            if (!result.Succeeded) return BadRequest();
            return Ok("تم تسجيل المستخدم بنجاح");
        }
    }
}