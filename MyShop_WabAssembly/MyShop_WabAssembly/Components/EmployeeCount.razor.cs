using MyShop.Shared;

namespace MyShop.UI.WebAssembly.Components {
    public partial class EmployeeCount {
        public int Count { get; set; }

        protected override void OnInitialized() {
            Count = MockData.Employees.Count;
            
            base.OnInitialized();
        }
    }
}
