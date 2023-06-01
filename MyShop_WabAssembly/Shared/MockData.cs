namespace MyShop.Shared {
    public static class MockData {
        private static List<Employee> _employees = null;

        public static List<Employee> Employees {
            get {
                if (_employees == null) {
                    _employees = new List<Employee>() {
                        new Employee() {ID = 0, FirstName = "Firstname 1", LastName = "Lastname 1"},
                        new Employee() {ID = 1, FirstName = "Firstname 2", LastName = "Lastname 2"},
                        new Employee() {ID = 2, FirstName = "Firstname 3", LastName = "Lastname 3"}
                    };
                }
                return _employees;
            }
        }
    }
}
