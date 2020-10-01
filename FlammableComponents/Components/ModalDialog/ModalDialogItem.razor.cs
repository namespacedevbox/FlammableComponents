using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public partial class ModalDialogItem : FlammableComponentBase
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        [Parameter] public ModalDialogInstance ModalDialogInstance { get; set; }
        [CascadingParameter] public ModalDialogsWrapper ModalDialogsWrapper { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
                return;

            await JSRuntime.InvokeVoidAsync("showModalDialog", ModalDialogInstance.Id);
            await InvokeAsync(StateHasChanged);
        }

        private async Task CloseDialogAsync()
        {
            await JSRuntime.InvokeVoidAsync("hideModalDialog", ModalDialogInstance.Id);
            await ModalDialogsWrapper.CloseDialogAsync(ModalDialogInstance.Id);
        }
    }
}
