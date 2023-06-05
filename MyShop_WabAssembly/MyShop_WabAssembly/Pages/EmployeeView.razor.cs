using Microsoft.AspNetCore.Components;
using MyShop.Shared;
using MyShop.UI.WebAssembly.Services;

namespace MyShop.UI.WebAssembly.Pages {
    public partial class EmployeeView {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }

        //protected override void OnInitialized() {
        //    Employee = MockData.Employees.FirstOrDefault(e => e.ID == EmployeeID);

        //    base.OnInitialized();
        //}

        protected async override Task OnInitializedAsync() {
            Employee = await EmployeeService.GetEmployeeById(EmployeeID);
        }

    }
}
