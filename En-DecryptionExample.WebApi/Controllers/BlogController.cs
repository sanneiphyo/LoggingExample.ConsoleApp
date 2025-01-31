using System.Text.Json.Serialization;
using En_DecryptionExample.WebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace En_DecryptionExample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly EncDecService _encDecService;

        public BlogController(EncDecService encDecService)
        {
            _encDecService = encDecService;
        }

        [HttpPost]
        public IActionResult Login(BlogLoginRequestModel requestModel)
        {
            try
            {
                var result = UserData.Users.FirstOrDefault(x =>
                  x.UserName == requestModel.UserName &&
                  x.Password == requestModel.Password);

                if (result is null) 
                {
                    return Unauthorized();
                }

                var user = new BlogLoginModel
                {
                    SessionExpired = DateTime.Now.AddMinutes(1),
                    SessionId = Guid.NewGuid().ToString(),
                    UserName = result.UserName
                };

                var json = JsonConvert.SerializeObject(user);

                var token = _encDecService.Encrypt(json);

                _encDecService.Encrypt(result.UserName);
                return Ok();
            }
            catch(Exception ex) 
            {
               return StatusCode(500,ex.ToString());
            }
        }
    }

}

public static class UserData
{
    public static List<UserDto> Users = new List<UserDto>
    {
        new UserDto
        {
            UserName = "admin",
            Password = "admin"
        },
        new UserDto
        {
            UserName = "user",
            Password = "user"
        }
    };
}

    public class BlogLoginRequestModel //controller => RequestModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class BlogLoginModel
{
    public string UserName { get; set; }
    public string SessionId { get; set; }

    public DateTime SessionExpired { get; set; }
}
public class UserDto //Database Mapping
{
    public string UserName { get; set; }

    public string Password { get; set; }

}

//15;10