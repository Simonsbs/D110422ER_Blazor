using MyShop.Shared;
using MyShopAPI.Contexts;

namespace MyShop.Api.Models {
    public class EmployeeRepository : IEmployeeRepository {
        private readonly MyShopContext _MyShopContext;
        
        public EmployeeRepository(MyShopContext MyShopContext) {
            _MyShopContext = MyShopContext ?? throw new ArgumentNullException(nameof(MyShopContext));
        }

        public IEnumerable<Employee> GetAllEmployees() {
            return _MyShopContext.Employees;
        }

        public Employee GetEmployeeById(int employeeId) {
            return _MyShopContext.Employees.FirstOrDefault(c => c.ID == employeeId);
        }

        public Employee AddEmployee(Employee employee) {
            var addedEntity = _MyShopContext.Employees.Add(employee);
            _MyShopContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Employee UpdateEmployee(Employee employee) {
            var foundEmployee = _MyShopContext.Employees.FirstOrDefault(e => e.ID == employee.ID);

            if (foundEmployee != null) {
                foundEmployee.FirstName = employee.FirstName;
                foundEmployee.LastName = employee.LastName;
                foundEmployee.Image = employee.Image;

                _MyShopContext.SaveChanges();

                return foundEmployee;
            }

            return null;
        }

        public void DeleteEmployee(int employeeId) {
            var foundEmployee = _MyShopContext.Employees.FirstOrDefault(e => e.ID == employeeId);
            if (foundEmployee == null) return;

            _MyShopContext.Employees.Remove(foundEmployee);
            _MyShopContext.SaveChanges();
        }
    }
}
