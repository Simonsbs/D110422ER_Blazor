using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyShop.Shared;
using MyShop.UI.WebAssembly.Services;

namespace MyShop.UI.WebAssembly.Pages {
    public partial class EmployeeEdit {
        IBrowserFile selectedFile;

        [Parameter]
        public int? ID { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public bool IsSaved { get; set; } = false;
        public string DisplayMessage { get; set; } = String.Empty;
        public string AlertType { get; set; } = "alert-primary";

        protected async override Task OnParametersSetAsync() {
            await OnInitializedAsync();
        }

        protected async override Task OnInitializedAsync() {
            if (ID.HasValue) {
                Employee = await EmployeeService.GetEmployeeById(ID.Value);
            } else {
                Employee = new Employee();
            }
        }

        private void SetMsg(string msg, bool isSuccess = true) {
            DisplayMessage = msg;
            AlertType = isSuccess ? "alert-success" : "alert-warning";
        }

        public async Task HandleValidSubmit() {
            IsSaved = false;
            DisplayMessage = string.Empty;

            if (ID.HasValue && ID.Value > 0) {
                // EDIT / UPDATE

                await EmployeeService.UpdateEmployee(Employee);

                IsSaved = true;
                SetMsg("The employee was updated");
            } else {
                // NEW / INSERT

                MemoryStream ms = new MemoryStream();
                using (Stream stream = selectedFile.OpenReadStream()) {
                    await stream.CopyToAsync(ms);
                }
                
                Employee.ImageData = ms.ToArray();
                Employee.Image = selectedFile.Name;

                var employee = await EmployeeService.AddEmployee(Employee);

                if (employee == null) {
                    IsSaved = false;
                    SetMsg("There was an issue saving the employee", false);
                } else {
                    IsSaved = true;
                    SetMsg("The employee was added");
                }
            }
        }

        public void HandleInvalidSubmit() {
            IsSaved = false;
            SetMsg("There was an issue saving the employee", false);
        }

        public async void HandleOnDelete() {
            if (!ID.HasValue) {
                return;
            }
            await EmployeeService.DeleteEmployee(ID.Value);

            NavigateToList();
        }

        public void NavigateToList() {
            NavigationManager.NavigateTo("/employees");
        }

        public void HandleFileChange(InputFileChangeEventArgs e) {
            selectedFile = e.File;
        }
    }
}
