using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace FlammableComponents
{
    public class FlammableComponentBase : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();
    }
}
