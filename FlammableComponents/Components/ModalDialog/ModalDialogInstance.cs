using System;
using System.Threading.Tasks;
using FlammableComponents.Enums;
using Microsoft.AspNetCore.Components;
using FlammableComponents.Components.ModalDialog;

namespace FlammableComponents
{
    public class ModalDialogInstance
    {
        private readonly IModalDialogService _modalDialogService;
        private readonly TaskCompletionSource<ModalResult> _resultCompletion;

        public string Id { get; }
        public string Title { get; }
        public RenderFragment Body { get;  }
        public string ModalDialogSize { get; }
        public Task<ModalResult> Result => _resultCompletion.Task;

        public ModalDialogInstance(string title, RenderFragment body, ModalDialogSize modalDialogSize, IModalDialogService modalDialogService)
        {
            _modalDialogService = modalDialogService;
            _resultCompletion = new TaskCompletionSource<ModalResult>();

            Body = body;
            Title = title;
            Id = Guid.NewGuid().ToString();

            switch (modalDialogSize)
            {
                case Enums.ModalDialogSize.Default:
                    ModalDialogSize = string.Empty;
                    break;
                case Enums.ModalDialogSize.Small:
                    ModalDialogSize = "modal-sm";
                    break;
                case Enums.ModalDialogSize.Large:
                    ModalDialogSize = "modal-lg";
                    break;
                case Enums.ModalDialogSize.ExtraLarge:
                    ModalDialogSize = "modal-xl";
                    break;
                default:
                    break;
            }
        }

        public async Task CloseAsync(ModalResult obj)
        {
            await _modalDialogService.CloseAsync(this);
            _resultCompletion.TrySetResult(obj);
        }
    }
}
