using FlammableComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public class ModalDialogService : IModalDialogService
    {
        public event Func<string, RenderFragment, ModalDialogSize, Task> OnShow;
        public event Func<Task> OnClose;
        public event Func<Task> OnCancel;

        public async Task ShowAsync(string header, RenderFragment body, ModalDialogSize modalDialogSize = ModalDialogSize.Default)
        {
            await OnShow?.Invoke(header, body, modalDialogSize);
        }

        public async Task CloseAsync()
        {
            await OnClose?.Invoke();
        }

        public async Task CancelAsync()
        {
            await OnCancel?.Invoke();
        }
    }
}
