using Microsoft.AspNetCore.Components;
using MyShop.Shared;
using MyShop.UI.WebAssembly.Services;

namespace MyShop.UI.WebAssembly.Pages {
    public partial class EmployeeEdit {
        [Parameter]
        public int? ID { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; } = new Employee();

        protected async override Task OnInitializedAsync() {
            if (ID.HasValue) { 
                Employee = await EmployeeService.GetEmployeeById(ID.Value);
            }
        }

        public async Task HandleValidSubmit() {
            if (ID.HasValue && ID.Value > 0) {
                // EDIT / UPDATE

                await EmployeeService.UpdateEmployee(Employee);
            } else {
                // NEW / INSERT

                var employee = await EmployeeService.AddEmployee(Employee);
            }
        }

        public void HandleInvalidSubmit() {

        }
    }
}
