using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace FlammableComponents
{
    public partial class FormLabel<TValue> : FlammableComponentBase
    {
        [Parameter] public RenderFragment Suffix { get; set; }

        [Parameter] public Expression<Func<TValue>> For { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();

        public string DisplayName { get; set; }
        public bool IsRequired { get; set; }

        public string Css { get; set; }

        protected override void OnInitialized()
        {
            Css = (string)AdditionalAttributes.GetValueOrDefault("class");

            var expression = (MemberExpression)For.Body;
            IsRequired = expression.Member.GetCustomAttribute<RequiredAttribute>() != null ? true : false;

            var displayNameAttribute = expression.Member.GetCustomAttribute<DisplayAttribute>();
            DisplayName = displayNameAttribute != null ? displayNameAttribute.Name : expression.Member.Name;
        }
    }
}
