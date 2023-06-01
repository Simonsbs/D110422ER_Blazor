using Microsoft.AspNetCore.Components;

namespace MyShop.UI.WebAssembly.Components {
    public partial class MyTitle {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
