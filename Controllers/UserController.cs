using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _dataContext;

        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> getUsers()
        {
            var users = await _dataContext.Users.ToListAsync();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            return Ok(user);


        }
    }
}
