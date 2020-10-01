using System;
using FlammableComponents.Enums;
using Microsoft.AspNetCore.Components;

namespace FlammableComponents
{
    public class ModalDialogInstance
    {
        public string Id { get; private set; }
        public string ModalDialogSizeClass { get; private set; }
        public string Header { get; set; }
        public RenderFragment Body { get; set; }

        public ModalDialogInstance(ModalDialogSize modalDialogSize, RenderFragment body, string header)
        {
            Id = Guid.NewGuid().ToString();
            Header = header;
            Body = body;

            switch (modalDialogSize)
            {
                case ModalDialogSize.Default:
                    ModalDialogSizeClass = string.Empty;
                    break;
                case ModalDialogSize.Small:
                    ModalDialogSizeClass = "modal-sm";
                    break;
                case ModalDialogSize.Large:
                    ModalDialogSizeClass = "modal-lg";
                    break;
                case ModalDialogSize.ExtraLarge:
                    ModalDialogSizeClass = "modal-xl";
                    break;
                default:
                    break;
            }
        }
    }
}
