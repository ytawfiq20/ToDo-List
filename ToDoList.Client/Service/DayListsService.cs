using System.Net.Http.Json;

using ToDoList.Client.Service.IService;
using ToDoList.Shared.Entities;

namespace ToDoList.Client.Service
{
    public class DayListsService : IDayLists
    {
        private readonly HttpClient httpClient;
        public DayListsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddNewList(DayLists list)
        {
            await httpClient.PostAsJsonAsync("List/AddList", list);
        }

        public async Task DeleteList(Guid id)
        {
            await httpClient.DeleteAsync($"List/DeleteList/{id}");
        }

        public async Task<IEnumerable<DayLists>> GetAllLists()
        {
            try
            {
                HttpResponseMessage? response = await httpClient.GetAsync("List/GetAllLists");
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(IEnumerable<DayLists>);
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<DayLists>>(); 
                }
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status code: {response.StatusCode}, Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DayLists> GetListById(Guid id)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"List/GetListById/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(DayLists);
                    }
                    return await response.Content.ReadFromJsonAsync<DayLists>();
                }
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status code: {response.StatusCode}, Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateList(DayLists list)
        {
            await httpClient.PutAsJsonAsync("List/UpdateList", list);
        }
    }
}
