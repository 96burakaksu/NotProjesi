using Newtonsoft.Json;
using NoteProject.Models;
using NoteProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NoteProject.Service
{
    public class NoteService : INoteService
    {
        public CustomResponse AddNote(AddNoteRequest content)
        {

            using (var httpClient = new HttpClient())
            {
                var endPoint = new Uri("https://localhost:44379/NotesApi/AddNote");
                var data = JsonConvert.SerializeObject(content);
                HttpContent httpContent = new StringContent(data, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.PostAsync(endPoint, httpContent).GetAwaiter().GetResult();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //var webResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    //JsonSerializer.Deserialize<ContentsModel>(webResult);
                    return new CustomResponse { Success = true };


                }
                else
                {
                    return new CustomResponse { Success = true };
                }
            }

        }

        public CustomResponse DeleteNote(DeleteNoteRequest content)
        {

            using (var httpClient = new HttpClient())
            {
                var endPoint = new Uri("https://localhost:44379/NotesApi/DeleteNote");
                var data = JsonConvert.SerializeObject(content);
                HttpContent httpContent = new StringContent(data, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.PostAsync(endPoint, httpContent).GetAwaiter().GetResult();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return new CustomResponse { Success = true };
                }
                else
                {
                    return new CustomResponse { Success = true };
                }
            }

        }

        public CustomResponse<List<NoteResponse>> NoteList()
        {

            using (var httpClient = new HttpClient())
            {
                var endPoint = new Uri("https://localhost:44379/NotesApi/NoteList");
           
                HttpContent httpContent = new StringContent("", Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.PostAsync(endPoint, httpContent).GetAwaiter().GetResult();


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var webResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return JsonConvert.DeserializeObject<CustomResponse<List<NoteResponse>>>(webResult);
                }
                else
                {
                    return new CustomResponse<List<NoteResponse>> { Success = false ,Message=" İşlem Başarısız."};
                }
            }

        }
    }
}
