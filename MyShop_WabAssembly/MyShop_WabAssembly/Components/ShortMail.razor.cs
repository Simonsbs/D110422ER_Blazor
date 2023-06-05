using Microsoft.AspNetCore.Components;
using MyShop.UI.WebAssembly.Services;

namespace MyShop.UI.WebAssembly.Components {
    public partial class ShortMail {
        [Inject]
        public AppState AppState { get; set; }
        
        public int Count { get; set; }

        protected override void OnInitialized() {
            Count = AppState.MailCount;
            base.OnInitialized();
        }
    }
}
