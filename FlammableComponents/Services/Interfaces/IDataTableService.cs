using FlammableComponents.Components.DataTable;
using FlammableComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FlammableComponents
{
    public interface IDataTableService<TItem, TFilter> : IDisposable where TFilter : class, new()
    {
        DataLoadingOptions<TFilter> DataLoadingOptions { get; set; }
        public TItem SelectedEntity { get; set; }
        public List<TItem> Entities { get; set; }
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
        public bool Loading { get; }
        Task InitializeAsync(Func<DataLoadingOptions<TFilter>, Task<List<TItem>>> getEntities, Func<DataLoadingOptions<TFilter>, Task<int>> getEntitiesCount, IModalDialogService modalDialogService, Action stateHasChanged, string sortedColumn, ListSortDirection sortDirection = ListSortDirection.Ascending, string syncPropName = "Id", string entityId = null);
        Task LoadTableDataAsync();
        Task SelectedItemChangedAsync(TItem item);
        Task SortedColumnChangedAsync(string columnName);
        Task SortDirectionChangedAsync(ListSortDirection sortDirection);
        Task CurrentPageChangedAsync(int currentPage);
        Task DisplayRowsChangedAsync(int displayRows);
        Task SearchTextChangedAsync(string searchText);
        Task FilterChangedAsync(TFilter filter);
    }
}
