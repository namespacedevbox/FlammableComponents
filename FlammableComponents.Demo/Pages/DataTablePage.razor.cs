using FlammableComponents.Components.DataTable;
using FlammableComponents.Demo.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FlammableComponents.Demo.Pages
{
    public partial class DataTablePage : ComponentBase
    {
        [Inject] IDataTableService<User, UserFilter> MainTableService { get; set; }
        private UserService _userService = new UserService();
        protected override void OnInitialized()
        {
            MainTableService.InitializeAsync(_userService.GetUsersAsync, _userService.GetUsersCountAsync, new ModalDialogService(), StateHasChanged, nameof(User.FirstName), ListSortDirection.Ascending, "GuidId");
        }
    }

    public class UserService
    {

        public async Task<List<User>> GetUsersAsync(DataLoadingOptions<UserFilter> dataLoadingOptions)
        {
            var query = new List<User>
            {
                new User
                {
                    GuidId = Guid.NewGuid().ToString(),
                    IntegerId = 22,
                    FirstName = "Vasya",
                    Lastname = "Vasilenko"

                },

                new User
                {
                    GuidId = Guid.NewGuid().ToString(),
                    IntegerId = 15,
                    FirstName = "Petya",
                    Lastname = "Petechkin"

                },

                new User
                {
                    GuidId = Guid.NewGuid().ToString(),
                    IntegerId = 24,
                    FirstName = "Pupkin",
                    Lastname = "Pup"

                },

                new User
                {
                    GuidId = Guid.NewGuid().ToString(),
                    IntegerId = 2,
                    FirstName = "Vetal",
                    Lastname = "Vetalievich"

                },

                new User
                {
                    GuidId = Guid.NewGuid().ToString(),
                    IntegerId = 51,
                    FirstName = "Alexey",
                    Lastname = "Aleshevich"

                },

            }.AsQueryable();

            //// Filter
            //if (dataLoadingOptions.Filter != null)
            //{
            //    if (dataLoadingOptions.Filter.Employee != null)
            //    {
            //        query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(dataLoadingOptions.Filter.Employee, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.Email != null)
            //    {
            //        query = query.Where(w => w.Email.Contains(dataLoadingOptions.Filter.Email, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.PhoneNumber != null)
            //    {
            //        query = query.Where(w => w.PhoneNumber.Contains(dataLoadingOptions.Filter.PhoneNumber, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.Company != null)
            //    {
            //        query = query.Where(x => x.Department.Company.Name.Contains(dataLoadingOptions.Filter.Company, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.Department != null)
            //    {
            //        query = query.Where(x => x.Department.Name.Contains(dataLoadingOptions.Filter.Department, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.Position != null)
            //    {
            //        query = query.Where(x => x.Position.Name.Contains(dataLoadingOptions.Filter.Position, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.LastSeenStartDate != null)
            //    {
            //        query = query.Where(w => w.LastSeen >= dataLoadingOptions.Filter.LastSeenStartDate);
            //    }
            //    if (dataLoadingOptions.Filter.LastSeenEndDate != null)
            //    {
            //        query = query.Where(x => x.LastSeen <= dataLoadingOptions.Filter.LastSeenEndDate);
            //    }
            //    if (dataLoadingOptions.Filter.VaultsCount != null)
            //    {
            //        query = query.Where(x => (x.HardwareVaults.Count + x.SoftwareVaults.Count) == dataLoadingOptions.Filter.VaultsCount);
            //    }
            //}

            //// Search
            //if (!string.IsNullOrWhiteSpace(dataLoadingOptions.SearchText))
            //{
            //    dataLoadingOptions.SearchText = dataLoadingOptions.SearchText.Trim();

            //    query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.Email.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.PhoneNumber.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.Department.Company.Name.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.Department.Name.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.Position.Name.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        (x.HardwareVaults.Count + x.SoftwareVaults.Count).ToString().Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase));
            //}

            // Sort Direction
            switch (dataLoadingOptions.SortedColumn)
            {
                case nameof(User.GuidId):
                    query = dataLoadingOptions.SortDirection == ListSortDirection.Ascending ? query.OrderBy(x => x.FirstName).ThenBy(x => x.GuidId) : query.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.GuidId);
                    break;
                case nameof(User.IntegerId):
                    query = dataLoadingOptions.SortDirection == ListSortDirection.Ascending ? query.OrderBy(x => x.IntegerId) : query.OrderByDescending(x => x.IntegerId);
                    break;
                case nameof(User.FirstName):
                    query = dataLoadingOptions.SortDirection == ListSortDirection.Ascending ? query.OrderBy(x => x.FirstName) : query.OrderByDescending(x => x.FirstName);
                    break;
                case nameof(User.Lastname):
                    query = dataLoadingOptions.SortDirection == ListSortDirection.Ascending ? query.OrderBy(x => x.Lastname) : query.OrderByDescending(x => x.Lastname);
                    break;
            }

            return query.Skip(dataLoadingOptions.Skip).Take(dataLoadingOptions.Take).ToList();
        }

        public async Task<int> GetUsersCountAsync(DataLoadingOptions<UserFilter> dataLoadingOptions)
        {
            var query = new List<User>
            {
                new User
                {
                    GuidId = Guid.NewGuid().ToString(),
                    IntegerId = 22,
                    FirstName = "Vasya",
                    Lastname = "Vasilenko"

                },

                new User
                {
                    GuidId = Guid.NewGuid().ToString(),
                    IntegerId = 15,
                    FirstName = "Petya",
                    Lastname = "Petechkin"

                },

                new User
                {
                    GuidId = Guid.NewGuid().ToString(),
                    IntegerId = 24,
                    FirstName = "Pupkin",
                    Lastname = "Pup"

                },

            }.AsQueryable();

            //// Filter
            //if (dataLoadingOptions.Filter != null)
            //{
            //    if (dataLoadingOptions.Filter.Employee != null)
            //    {
            //        query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(dataLoadingOptions.Filter.Employee, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.Email != null)
            //    {
            //        query = query.Where(w => w.Email.Contains(dataLoadingOptions.Filter.Email, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.PhoneNumber != null)
            //    {
            //        query = query.Where(w => w.PhoneNumber.Contains(dataLoadingOptions.Filter.PhoneNumber, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.Company != null)
            //    {
            //        query = query.Where(x => x.Department.Company.Name.Contains(dataLoadingOptions.Filter.Company, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.Department != null)
            //    {
            //        query = query.Where(x => x.Department.Name.Contains(dataLoadingOptions.Filter.Department, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.Position != null)
            //    {
            //        query = query.Where(x => x.Position.Name.Contains(dataLoadingOptions.Filter.Position, StringComparison.OrdinalIgnoreCase));
            //    }
            //    if (dataLoadingOptions.Filter.LastSeenStartDate != null)
            //    {
            //        query = query.Where(w => w.LastSeen >= dataLoadingOptions.Filter.LastSeenStartDate);
            //    }
            //    if (dataLoadingOptions.Filter.LastSeenEndDate != null)
            //    {
            //        query = query.Where(x => x.LastSeen <= dataLoadingOptions.Filter.LastSeenEndDate);
            //    }
            //    if (dataLoadingOptions.Filter.VaultsCount != null)
            //    {
            //        query = query.Where(x => (x.HardwareVaults.Count + x.SoftwareVaults.Count) == dataLoadingOptions.Filter.VaultsCount);
            //    }
            //}

            //// Search
            //if (!string.IsNullOrWhiteSpace(dataLoadingOptions.SearchText))
            //{
            //    dataLoadingOptions.SearchText = dataLoadingOptions.SearchText.Trim();

            //    query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.Email.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.PhoneNumber.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.Department.Company.Name.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.Department.Name.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        x.Position.Name.Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase) ||
            //                        (x.HardwareVaults.Count + x.SoftwareVaults.Count).ToString().Contains(dataLoadingOptions.SearchText, StringComparison.OrdinalIgnoreCase));
            //}

            return query.Count();
        }
    }
}
