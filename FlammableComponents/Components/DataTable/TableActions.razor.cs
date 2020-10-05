using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FlammableComponents
{
    public partial class TableActions : FlammableComponentBase
    {
        [Parameter] public RenderFragment FilterForm { get; set; }
        [Parameter] public RenderFragment ActionButtons { get; set; }
        [Parameter] public Func<string, Task> SearchTextChanged { get; set; }
        [Parameter] public bool ShowFilter { get; set; }
        [Parameter] public bool ShowFilterButton { get; set; } = true;

        public string SearchText { get; set; }

        private Timer _timer;

        protected override void OnInitialized()
        {
            SearchBoxTimer();
        }

        private void SearchBoxTimer()
        {
            _timer = new Timer(500);
            _timer.Elapsed += async (sender, args) =>
            {
                await InvokeAsync(async () =>
                {
                    await SearchTextChanged.Invoke(SearchText);
                });
            };
            _timer.AutoReset = false;
        }

        private void SearchBoxKeyUp(KeyboardEventArgs e)
        {
            _timer.Stop();
            _timer.Start();
        }
    }
}
