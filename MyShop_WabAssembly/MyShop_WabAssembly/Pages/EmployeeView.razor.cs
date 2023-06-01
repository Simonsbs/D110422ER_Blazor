using Microsoft.AspNetCore.Components;
using MyShop.Shared;

namespace MyShop.UI.WebAssembly.Pages {
    public partial class EmployeeView {
        [Parameter]
        //[SupplyParameterFromQuery(Name = "id")]
        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }

        protected override void OnInitialized() {
            Employee = MockData.Employees.FirstOrDefault(e => e.ID == EmployeeID);

            base.OnInitialized();
        }

    }
}
