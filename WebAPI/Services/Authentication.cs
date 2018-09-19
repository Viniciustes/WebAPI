using Microsoft.AspNetCore.Http;
using System;

namespace WebAPI.Services
{
    public class Authentication
    {
        private static readonly string Token = "76148021-3a15-44ae-a919-58acff976fda";

        private const string AuthenticationFailure = "Falha de autenticação de Token...";

        private readonly IHttpContextAccessor _contextAccessor;

        public Authentication(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Authenticate()
        {
            try
            {
                var sendToken = _contextAccessor.HttpContext.Request.Headers["Token"].ToString();

                if (!string.Equals(Token, sendToken))
                    throw new Exception(AuthenticationFailure);
            }
            catch (Exception)
            {
                throw new Exception(AuthenticationFailure);
            }
        }
    }
}