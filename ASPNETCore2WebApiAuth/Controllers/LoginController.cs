using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularASPNETCore2WebApiAuth.ViewModels;
using ASPNETCore2WebApiAuth.DataAccess;
using ASPNETCore2WebApiAuth.Helpers;
using ASPNETCore2WebApiAuth.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore2WebApiAuth.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public LoginController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        
        [HttpGet]
       // [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return new string[] { "Login Controller" };
        }

        // POST api/Register
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userIdentity = _mapper.Map<AppUser>(model);

                var result = await _userManager.CreateAsync(userIdentity, model.Password);

                if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                await _appDbContext.Customers.AddAsync(new Customer { IdentityId = userIdentity.Id, Location = model.Location });
                await _appDbContext.SaveChangesAsync();

                return new OkObjectResult("Account created");
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
            
        }
    }
}