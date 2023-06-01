namespace MyShop.UI.WebAssembly.Components {
    public partial class MailCount {
        public int Count { get; set; }

        protected override void OnInitialized() {
            Count = new Random().Next(0, 100);
            
            base.OnInitialized();
        }
    }
}
