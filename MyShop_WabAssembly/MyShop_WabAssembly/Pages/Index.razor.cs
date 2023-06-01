using MyShop.Shared;
using MyShop.UI.WebAssembly.Components;

namespace MyShop.UI.WebAssembly.Pages {
    public partial class Index {
        public List<Type> ListOfWidgets { get; set; } = new List<Type> {
            typeof(MailCount),
            typeof(EmployeeCount),
        };
    }
}
