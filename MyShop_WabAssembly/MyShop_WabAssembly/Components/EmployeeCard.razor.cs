using Microsoft.AspNetCore.Components;
using MyShop.Shared;

namespace MyShop.UI.WebAssembly.Components {
    public partial class EmployeeCard {
        [Parameter]
        public Employee InputEmployee { get; set; }
    }
}
