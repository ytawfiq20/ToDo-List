using System.Net.Http.Json;

using ToDoList.Client.Service.IService;
using ToDoList.Shared.Entities;

namespace ToDoList.Client.Service
{
    public class ListTasksService : IListTasks
    {
        private readonly HttpClient httpClient;
        public ListTasksService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task AddTask(ListTasks task)
        {
            await httpClient.PostAsJsonAsync("ListTasks/AddTask", task);
        }

        public async Task DeleteTask(Guid id)
        {
            await httpClient.DeleteAsync($"ListTasks/DeleteTask/{id}");
        }

        public async Task<IEnumerable<ListTasks>> GetAllTasks()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("ListTasks/GetAllTasks");
                if (response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(IEnumerable<ListTasks>);
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ListTasks>>();
                }
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"HttpStatus Code: {response.StatusCode}, Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ListTasks>> GetAllTasksByListId(Guid listId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"ListTasks/GetTasksByListId/{listId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(IEnumerable<ListTasks>);
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ListTasks>>();
                }
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"HttpStatus Code: {response.StatusCode}, Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ListTasks> GetTaskById(Guid id)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"ListTasks/GetTaskById/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ListTasks);
                    }
                    return await response.Content.ReadFromJsonAsync<ListTasks>();
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

        public async Task UpdateTask(ListTasks task)
        {
            await httpClient.PutAsJsonAsync("ListTasks/UpdateTask", task);
        }
    }
}
