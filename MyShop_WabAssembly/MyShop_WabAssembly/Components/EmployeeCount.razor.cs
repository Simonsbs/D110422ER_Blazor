using Microsoft.AspNetCore.Components;
using MyShop.Shared;
using MyShop.UI.WebAssembly.Services;

namespace MyShop.UI.WebAssembly.Components {
    public partial class EmployeeCount {
        [Inject]
        IEmployeeService EmployeeService { get; set; }

        public int Count { get; set; }

        //protected override void OnInitialized() {
        //    Count = MockData.Employees.Count;

        //    base.OnInitialized();
        //}

        protected async override Task OnInitializedAsync() {
            Count = (await EmployeeService.GetAllEmployees()).Count();
        }
    }
}
