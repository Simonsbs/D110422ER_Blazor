using MyShop.Shared;

namespace MyShop.UI.WebAssembly.Pages {
    public partial class EmployeeEdit {
        public Employee Employee { get; set; } = new Employee() {
            FirstName = "First Name",
            LastName = "Last Name"
        };
    }
}
