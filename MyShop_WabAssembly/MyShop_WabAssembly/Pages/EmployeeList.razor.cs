using MyShop.Shared;

namespace MyShop.UI.WebAssembly.Pages {
    public partial class EmployeeList {
        private Employee _selectedEmployee;

        public List<Employee> Employees { get; set; }

        protected override void OnInitialized() {
            base.OnInitialized();

            Employees = MockData.Employees;
        }

        public void EmployeePopupRequested(Employee selectedEmployee) {
            _selectedEmployee = selectedEmployee;
        }
    }
}
