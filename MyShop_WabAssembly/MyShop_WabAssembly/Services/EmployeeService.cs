using MyShop.Shared;
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

        public Task<Employee> AddEmployee(Employee employee) {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int id) {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees() {
            var stream = await _httpClient.GetStreamAsync("api/employee");
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(stream, _serializerOptions);
            return result;
        }

        public Task<Employee> GetEmployeeById(int id) {
            throw new NotImplementedException();
        }

        public Task UpdateEmployee(Employee employee) {
            throw new NotImplementedException();
        }
    }
}
