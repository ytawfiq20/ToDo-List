using System.Net.Http.Json;
using System.Threading.Tasks;

using ToDoList.Client.Service.IService;
using ToDoList.Shared.Entities;

namespace ToDoList.Client.Service
{
    public class TaskNotesService : ITaskNotes
    {
        private readonly HttpClient httpClient;
        public TaskNotesService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddNote(TaskNotes note)
        {
            await httpClient.PostAsJsonAsync("TaskNotes/AddNote", note);
        }

        public async Task DeleteNote(Guid noteId)
        {
            await httpClient.DeleteAsync($"TaskNotes/DeleteNote/{noteId}");
        }

        public async Task<IEnumerable<TaskNotes>> GetAllNotes()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"TaskNotes/GetAllNotes");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(IEnumerable<TaskNotes>);
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<TaskNotes>>();
                }
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode}, Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TaskNotes>> GetAllNotesByTaskId(Guid taskId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"TaskNotes/GetAllNotesByTaskId/{taskId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(IEnumerable<TaskNotes>);
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<TaskNotes>>();
                }
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode}, Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TaskNotes> GetNoteById(Guid noteId)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"TaskNotes/GetNoteById/{noteId}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(TaskNotes);
                    }
                    return await response.Content.ReadFromJsonAsync<TaskNotes>();
                }
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode}, Message: {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateNote(TaskNotes note)
        {
            await httpClient.PutAsJsonAsync($"TaskNotes/UpdateNote", note);
        }
    }
}
