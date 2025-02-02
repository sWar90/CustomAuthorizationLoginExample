using CustomAuthorizationLoginExample.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAuthorizationLoginExample.Domain.Features.Login;

public class LoginService
{
    private readonly AppDbContext _dbContent;

    public LoginService(AppDbContext dbContent)
    {
        _dbContent = dbContent;
    }

    public async Task HandleAsyc(LoginRequestModel requestModel)
    {
        try
        {
            var user = _dbContent.TblUsers.Where(x =>
                x.UserName == requestModel.UserName &&
                x.Password == requestModel.Password).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("Invalid username or password");
            }

            TblLogin login= new TblLogin
            {
                SessionId = Guid.NewGuid().ToString(),
                SessionExpired = DateTime.Now.AddMinutes(30),
                UserId=user.UserId
            };

            _dbContent.TblLogins.Add(login);
            await _dbContent.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}

public class LoginRequestModel
{
    public string UserName { get; set; }

    public string Password { get; set; }
}

public class LoginResponseModel
{
    public string UserId { get; set; }
    public string SessionId { get; set; }

    public DateTime SessionExpired { get; set; }

}