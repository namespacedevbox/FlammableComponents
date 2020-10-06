using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace FlammableComponents
{
    public partial class FormLabel<TValue> : FlammableComponentBase
    {
        [Parameter] public RenderFragment Suffix { get; set; }

        [Parameter] public Expression<Func<TValue>> For { get; set; }


        public string DisplayName { get; set; }
        public bool IsRequired { get; set; }

        protected override void OnInitialized()
        {
            var expression = (MemberExpression)For.Body;
            IsRequired = expression.Member.GetCustomAttribute<RequiredAttribute>() != null ? true : false;

            var displayNameAttribute = expression.Member.GetCustomAttribute<DisplayAttribute>();
            DisplayName = displayNameAttribute != null ? displayNameAttribute.Name : expression.Member.Name;
        }
    }
}
