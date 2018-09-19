using System;
using System.Net;
using System.Text;

namespace WebMVC.Requests
{
    public class RequestWepApi
    {
        private const string Uri = "http://localhost:55480/api/clientes/";

        private static readonly string Token = "76148021";

        public static string RequestGet(string method, string parameter = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(Uri + method + "/" + parameter);

            request.Headers.Add("Token", Token);

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new System.IO.StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()).ReadToEnd();

            return responseString;
        }

        public static string RequesPost(string method, string jsonData)
        {
            var request = (HttpWebRequest)WebRequest.Create(Uri + method);

            var data = Encoding.ASCII.GetBytes(jsonData);

            request.Method = "POST";
            request.Headers.Add("Token!#", Token);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new System.IO.StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()).ReadToEnd();

            return responseString;
        }
    }
}
