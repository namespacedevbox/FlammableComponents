using FlammableComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public class ToastService : IToastService
    {
        public event Func<ToastType, RenderFragment, string, Task> OnShow;

        public async Task ShowToastAsync(string message, ToastType toastType, string header = "")
        {
            await OnShow?.Invoke(toastType, builder => builder.AddContent(0, message), header);
        }
    }
}
