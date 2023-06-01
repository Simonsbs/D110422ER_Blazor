using Microsoft.AspNetCore.Components;
using MyShop.Shared;

namespace MyShop.UI.WabAssembly.Components {
    public partial class EmployeeCard {
        [Parameter]
        public Employee InputEmployee { get; set; }
    }
}
