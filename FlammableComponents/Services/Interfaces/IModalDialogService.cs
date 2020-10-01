using FlammableComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public interface IModalDialogService
    {
        event Func<string, RenderFragment, ModalDialogSize, Task> OnShow;
        event Func<Task> OnClose;
        event Func<Task> OnCancel;

        Task ShowAsync(string header, RenderFragment body, ModalDialogSize modalDialogSize = ModalDialogSize.Default);
        Task CloseAsync();
        Task CancelAsync();
    }
}
