using MyShop.Shared;
using System.Text;
using System.Text.Json;

namespace MyShop.UI.WebAssembly.Services {
    public class EmployeeService : IEmployeeService {
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _serializerOptions;

        public EmployeeService(HttpClient httpClient) {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _serializerOptions = new JsonSerializerOptions() {
                PropertyNameCaseInsensitive = true,
            };
        }

        public async Task UpdateEmployee(Employee employee) {
            var rawJson = JsonSerializer.Serialize(employee);
            var content = new StringContent(rawJson, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync("api/employee", content);
        }

        public async Task<Employee> AddEmployee(Employee employee) {
            var rawJson = JsonSerializer.Serialize(employee);
            var content = new StringContent(rawJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/employee", content);

            if (response.IsSuccessStatusCode) {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var newEmployee = JsonSerializer.Deserialize<Employee>(responseStream);
                return newEmployee;
            }

            return null;
        }

        public async Task DeleteEmployee(int id) {
            await _httpClient.DeleteAsync($"api/employee/{id}");
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees() {
            var stream = await _httpClient.GetStreamAsync("api/employee");
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(stream, _serializerOptions);
            return result;
        }

        public async Task<Employee> GetEmployeeById(int id) {
            var stream = await _httpClient.GetStreamAsync($"api/employee/{id}");
            var result = await JsonSerializer.DeserializeAsync<Employee>(stream, _serializerOptions);
            return result;
        }


    }
}
