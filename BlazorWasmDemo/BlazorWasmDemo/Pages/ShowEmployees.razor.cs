using BlazorWasmDemo.Models;

namespace BlazorWasmDemo.Pages {
    public partial class ShowEmployees {
        public List<Employee> Employees { get; set; }

        protected override void OnInitialized() {
            base.OnInitialized();

            Employees = MockData.Employees;
        }        
    }
}