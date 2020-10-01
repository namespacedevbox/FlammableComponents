using FlammableComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public partial class ModalDialogsWrapper : FlammableComponentBase, IDisposable
    {
        [Inject] private IModalDialogService ModalDialogService { get; set; }

        private List<ModalDialogInstance> ModalDialogItems { get; set; }

        protected override void OnInitialized()
        {
            ModalDialogItems = new List<ModalDialogInstance>();
            ModalDialogService.OnShow += OpenDialogAsync;
        }

        public async Task CloseDialogAsync(string modalDialogId)
        {
            await InvokeAsync(() =>
            {
                ModalDialogItems.Remove(ModalDialogItems.SingleOrDefault(x => x.Id == modalDialogId));
                StateHasChanged();
            });
        }

        public async Task OpenDialogAsync(string heading, RenderFragment body, ModalDialogSize modalDialogSize)
        {
            await InvokeAsync(() =>
            {
                ModalDialogItems.Add(new ModalDialogInstance(modalDialogSize, body, heading));
                StateHasChanged();
            });
        }

        public void Dispose()
        {
            ModalDialogService.OnShow -= OpenDialogAsync;
        }
    }
}
