using Microsoft.AspNetCore.Components;
using MyShop.Shared;

namespace MyShop.UI.WebAssembly.Components {
    public partial class EmployeePopup {
        private Employee? _employee;

        [Parameter]
        public Employee? Employee { get; set; }

        protected override void OnParametersSet() {
            base.OnParametersSet();

            _employee = Employee;
        }
    }
}
