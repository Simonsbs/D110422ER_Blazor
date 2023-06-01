﻿using MyShop.Shared;

namespace MyShop.UI.WabAssembly.Pages {
    public partial class EmployeeList {
        public List<Employee> Employees { get; set; }

        protected override void OnInitialized() {
            base.OnInitialized();

            Employees = MockData.Employees;
        }
    }
}
