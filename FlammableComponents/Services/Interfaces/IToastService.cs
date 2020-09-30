using FlammableComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public interface IToastService
    {
        public event Func<ToastType, RenderFragment, string, Task> OnShow;
        Task ShowToastAsync(string message, ToastType toastType, string header = "");
    }
}
