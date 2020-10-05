using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public partial class TableHeaderItem : FlammableComponentBase
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public double TitleWidth { get; set; }
        [Parameter] public string SortColumn { get; set; }
        [Parameter] public string CurrentSortedColumn { get; set; }
        [Parameter] public ListSortDirection CurrentSortDirection { get; set; }
        [Parameter] public Func<string, Task> SortedColumnChanged { get; set; }
        [Parameter] public Func<ListSortDirection, Task> SortDirectionChanged { get; set; }

        private async Task SortTable()
        {
            if (CurrentSortedColumn != SortColumn)
            {
                await SortedColumnChanged.Invoke(SortColumn);
            }
            else
            {
                CurrentSortDirection = CurrentSortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
                await SortDirectionChanged.Invoke(CurrentSortDirection);
            }
        }

        private string GetSortIcon()
        {
            if (SortColumn != CurrentSortedColumn)
            {
                return string.Empty;
            }

            if (CurrentSortDirection == ListSortDirection.Ascending)
            {
                return "table-sort-arrow-up";
            }
            else
            {
                return "table-sort-arrow-down";
            }
        }
    }
}
