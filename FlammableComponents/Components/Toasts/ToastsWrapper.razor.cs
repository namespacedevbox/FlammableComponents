﻿using FlammableComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public partial class ToastsWrapper : FlammableComponentBase, IDisposable
    {
        [Inject] private IToastService ToastService { get; set; }

        private List<ToastInstance> ToastItems { get; set; }

        protected override void OnInitialized()
        {
            ToastItems = new List<ToastInstance>();
            ToastService.OnShow += ShowToastAsync;
        }

        public async Task RemoveToastAsync(string toastId)
        {
            await InvokeAsync(() =>
            {
                ToastItems.Remove(ToastItems.SingleOrDefault(x => x.Id == toastId));
                StateHasChanged();
            });
        }

        private async Task ShowToastAsync(ToastType toastType, RenderFragment message, string heading)
        {
            await InvokeAsync(() =>
            {
                ToastItems.Add(new ToastInstance(toastType, message, heading));
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            ToastService.OnShow -= ShowToastAsync;
        }
    }
}
