using Microsoft.AspNetCore.Components;
using MyShop.Shared;
using System.Net.Http.Json;

namespace MyShop.UI.WebAssembly.Pages {
    public partial class EmployeeList {
        [Inject]
        public HttpClient HttpClient { get; set; }

        private Employee _selectedEmployee;

        public List<Employee> Employees { get; set; }

        /*protected override void OnInitialized() {
            base.OnInitialized();

            Employees = MockData.Employees;
        }*/

        protected async override Task OnInitializedAsync() {
            var data = await HttpClient.GetFromJsonAsync<List<Employee>>("https://localhost:7085/api/employee");
            Employees = data;
        }

        public void EmployeePopupRequested(Employee selectedEmployee) {
            _selectedEmployee = selectedEmployee;
        }
    }
}
