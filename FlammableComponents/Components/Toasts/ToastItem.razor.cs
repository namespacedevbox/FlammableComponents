using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public partial class ToastItem : FlammableComponentBase, IDisposable
    {
        private const int _timeout = 5;

        [Parameter] public ToastInstance ToastInstance { get; set; }
        [CascadingParameter] public ToastsWrapper ToastsContainer { get; set; }

        private CountdownTimer _countdownTimer;

        protected override void OnInitialized()
        {
            _countdownTimer = new CountdownTimer(_timeout);
            _countdownTimer.OnElapsed += ToastCloseAsync;
            _countdownTimer.Start();
        }

        private async Task ToastCloseAsync()
        {
            await ToastsContainer.RemoveToastAsync(ToastInstance.Id);
        }

        public void Dispose()
        {
            _countdownTimer.OnElapsed -= ToastCloseAsync;
            _countdownTimer.Dispose();
        }
    }
}
