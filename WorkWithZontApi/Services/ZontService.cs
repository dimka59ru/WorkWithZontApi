using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithZontApi.Services
{
    public class ZontService
    {
        const string _email = "rizan59ru@yandex.ru";

        public string GetResponse(string uri, string json, string email)
        {
            var request = WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Headers["X-ZONT-Client"] = email;
            //request.Headers["Authorization"] = "";
            request.Method = "POST";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                JObject o = JObject.Parse(json);
                json = o.ToString();
                streamWriter.Write(json);
            }

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                using var responseStream = response.GetResponseStream();
                using var reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
            catch(WebException ex)
            {
                using var stream = ex.Response.GetResponseStream();
                using var reader = new StreamReader(stream);
                return reader.ReadToEnd();
            } 
        }

        public Task<string> GetDevicesAsync()
        {
            return Task.Run(() =>
            {
                string json = "{'load_io': 'True'}";
                return GetResponse("https://zont-online.ru/api/devices", json, _email);
            });
        }
    }
}
