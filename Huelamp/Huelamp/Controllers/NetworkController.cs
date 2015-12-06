using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Huelamp.Controllers
{
    class NetworkController
    {
        private string ip;
        private int port;
        private string username;
        private string usercode;
        private MainPage mp;

        public NetworkController(MainPage mp)
        {
            this.mp = mp;
        }
        public NetworkController(string ip, int port, string username,MainPage mp)
        {
            this.ip = ip;
            this.port = port;
            this.username = username;
            this.mp = mp;
        }

        public void initializeNC()
        {
            MainPage.RetrieveSettings(out ip, out port, out username);
            getUsername();
            //Debug.WriteLine("usercode: " + usercode);
        }

        private async void getUsername()
        {
            string cmd = await PostCommand("api", "{\"devicetype\":\"MijnApp#{" + username + "}\"}");
            string[] data = cmd.Split('\"');
            usercode = data[5];
            getAllInfo();
        }

        public async void getAllInfo()
        {
            string cmd = await GetCommand("api/" + usercode + "/lights");
            JObject allInfo = JObject.Parse(cmd);
            foreach (var item in allInfo)
            {
                var light = allInfo["" + item.Key];
                mp.hlManger.addHuelamp(light);
            }
            mp.loadLamps();
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
