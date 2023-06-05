using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyShop.Shared;

namespace MyShop.UI.WebAssembly.Components {
    public partial class EmployeeCard {
        [Parameter]
        public Employee InputEmployee { get; set; } = null;

        [Parameter]
        public EventCallback<Employee> PopupClicked { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Employee Employee { get; set; }

        protected override void OnInitialized() {
            base.OnInitialized();
        }

        protected override void OnParametersSet() {
            Employee = InputEmployee;
            base.OnParametersSet();
        }

        protected override void OnAfterRender(bool firstRender) {
            base.OnAfterRender(firstRender);
        }

        public void CalledPopup(MouseEventArgs e, int id) {

        }

        /*public void CalledFromKeyboard(KeyboardEventArgs e) {

        }*/

        private async void CallParent() {
            await PopupClicked.InvokeAsync(Employee);
        }

        private void NavigateToEmployee() {
            NavigationManager.NavigateTo("/employee/" + Employee.ID);
        }
    }

}
