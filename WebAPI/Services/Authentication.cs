using Microsoft.AspNetCore.Http;
using System;

namespace WebAPI.Services
{
    public class Authentication
    {
        private const string TOKEN = "123456";
        private const string AUTHENTICATION_FAILURE = "Falha de autenticação de Token...";

        private readonly IHttpContextAccessor _contextAccessor;

        public Authentication(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Authenticate()
        {
            try
            {
                string SendToken = _contextAccessor.HttpContext.Request.Headers["Token"].ToString();

                if (!string.Equals(TOKEN, SendToken))
                    throw new Exception(AUTHENTICATION_FAILURE);
            }
            catch (Exception)
            {
                throw new Exception(AUTHENTICATION_FAILURE);
            }
        }
    }
}