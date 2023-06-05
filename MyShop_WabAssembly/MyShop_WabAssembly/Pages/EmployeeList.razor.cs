using Microsoft.AspNetCore.Components;
using MyShop.Shared;
using MyShop.UI.WebAssembly.Services;
using System.Net.Http.Json;

namespace MyShop.UI.WebAssembly.Pages {
    public partial class EmployeeList {
        //[Inject]
        //public HttpClient HttpClient { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        private Employee _selectedEmployee;

        public List<Employee> Employees { get; set; }

        /*protected override void OnInitialized() {
            base.OnInitialized();

            Employees = MockData.Employees;
        }*/

        /*
        protected async override Task OnInitializedAsync() {
            var data = await HttpClient.GetFromJsonAsync<List<Employee>>("https://localhost:7085/api/employee");
            Employees = data;
        }
        */

        protected async override Task OnInitializedAsync() {
            var data = await EmployeeService.GetAllEmployees();
            Employees = data.ToList();
        }

        public void EmployeePopupRequested(Employee selectedEmployee) {
            _selectedEmployee = selectedEmployee;
        }
    }
}
