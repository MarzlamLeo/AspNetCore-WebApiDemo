using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Marzlam_api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [Authorize]  //这各就会验证 token是否存在 来授权 通过与否
        [HttpGet]
        public IEnumerable<WeatherForecast> Getinfo()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [AllowAnonymous]
        [HttpGet]
        public string Login(string username, string password)
        {
            //验证登录
            if (username == "zhangsan" && password == "123")
            {
                //登录成功记录 身份信息  然后用jwt 生成token 后续 授权
                var claims = new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id", "ceshi", ClaimValueTypes.Integer32), // 用户id
                new Claim("name", "ceshi"), // 用户名
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JwtSetting.SecurityKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //创建令牌
                var token = new JwtSecurityToken(
                  issuer: AppSettings.JwtSetting.Issuer,
                  audience: AppSettings.JwtSetting.Audience,
                  signingCredentials: creds,
                  claims: claims,
                  notBefore: DateTime.Now,
                  expires: DateTime.Now.AddSeconds(AppSettings.JwtSetting.ExpireSeconds)
                );

                string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);


                return jwtToken;


            }
            else
            {
                return "没有生成";
            }


        }

    }
}
