using Microsoft.AspNetCore.Components;
using System;

namespace FlammableComponents
{
    public partial class DateTimePicker : FlammableComponentBase
    {
        [Parameter] public DateTime? Value { get; set; }
        [Parameter] public EventCallback<DateTime?> ValueChanged { get; set; }

        private void OnValueChanged(ChangeEventArgs args)
        {
            var datetime = args.Value.ToString();

            if (string.IsNullOrEmpty(datetime))
                return;

            ValueChanged.InvokeAsync(DateTime.Parse(datetime));
        }
    }
}