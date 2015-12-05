using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Huelamp.Controllers
{
    class NetworkController
    {
        private string ip;
        private string port;
        private string username;
        private string usercode;

        public NetworkController(string ip, string port, string username)
        {
            this.ip = ip;
            this.port = port;
            this.username = username;
        }

        private async void getUsername()
        {
            string postcmd = await PostCommand("api", "{\"devicetype\":\"MijnApp#{" + username + "}\"}");
            string[] data = postcmd.Split('\"');
            usercode = data[5];
        }

        public async Task<string> GetCommand(string url)
        {
            url = "http://" + ip + ":" + port + "/" + url;
            using (HttpClient Httpcl = new HttpClient())
            {
                var response = await Httpcl.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        public async Task<string> PostCommand(string url, string Data)
        {
            url = "http://" + ip + ":" + port + "/" + url;
            HttpContent content = new StringContent(Data, Encoding.UTF8, "application/json");
            using (HttpClient Httpcl = new HttpClient())
            {
                var response = await Httpcl.PostAsync(url,content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
        public async Task<string> PutCommand(string url, string Data)
        {
            url = "http://" + ip + ":" + port + "/" + url;
            HttpContent content = new StringContent(Data, Encoding.UTF8, "application/json");
            using (HttpClient Httpcl = new HttpClient())
            {
                var response = await Httpcl.PutAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

    }
}
