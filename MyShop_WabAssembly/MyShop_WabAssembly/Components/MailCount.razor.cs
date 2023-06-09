﻿using Microsoft.AspNetCore.Components;
using MyShop.UI.WebAssembly.Services;

namespace MyShop.UI.WebAssembly.Components {
    public partial class MailCount {
        [Inject]
        public AppState AppState { get; set; }

        public int Count { get; set; }

        protected override void OnInitialized() {
            Count = new Random().Next(0, 100);

            AppState.MailCount = Count;

            base.OnInitialized();
        }
    }
}
