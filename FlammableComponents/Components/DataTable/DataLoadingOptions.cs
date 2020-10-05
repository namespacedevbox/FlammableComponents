﻿using System.ComponentModel;

namespace FlammableComponents.Components.DataTable
{
    public class DataLoadingOptions<TFilter> where TFilter : class, new()
    {
        public int Take { get; set; }
        public int Skip { get; set; }
        public string EntityId { get; set; }
        public TFilter Filter { get; set; }
        public string SearchText { get; set; }
        public string SortedColumn { get; set; }
        public ListSortDirection SortDirection { get; set; }

        public DataLoadingOptions()
        {
            Skip = 0;
            Take = 10;
            Filter = new TFilter();
            SearchText = string.Empty;
            SortDirection = ListSortDirection.Ascending;
        }
    }
}
