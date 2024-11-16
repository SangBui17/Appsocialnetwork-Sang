﻿using Newtonsoft.Json;
using Social_network.Models;
using Social_network.Repository;
using Social_network.Response;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Social_network.ServicesImp
{
    class UserInfoService : UserInforRepository
    {
        public async Task<UserInfoResponse> Getme()
        {
            var client = new HttpClient();
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string url = $"http://10.0.2.2:2711/user/me";

            try
            {
                var token = await SecureStorage.Default.GetAsync("access_token");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                CancellationToken cancellationToken = new CancellationToken();

                HttpResponseMessage responseMessage = await client.SendAsync(request, CancellationToken.None);
                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseContent = await responseMessage.Content.ReadAsStringAsync();
                    // Deserialize using Newtonsoft.Json
                    UserInfoResponse messageResponses = JsonConvert.DeserializeObject<UserInfoResponse>(responseContent);
                    Debug.WriteLine("\tLấy thành công.");
                    return messageResponses; // Trả về danh sách messageResponses
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tError: {ex.Message}");
            }

            return null; // Hoặc có thể trả về một danh sách rỗng nếu cần
        }
    }
}
