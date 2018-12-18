using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.GridView.sample10
{
    public class ViewModel : DotvvmViewModelBase
    {
        public GridViewUserSettings UserSettings { get; set; }
        public BusinessPackDataSet<Customer> Customers { get; set; }

        public override Task Init()
        {
            Customers = new BusinessPackDataSet<Customer> {
                PagingOptions = {
                    PageSize = 10
                }
            };

            UserSettings = new GridViewUserSettings {
                ColumnsSettings = new List<GridViewColumnSettings> {
                    new GridViewColumnSettings {
                        ColumnName = "CustomerId",
                        DisplayOrder = 0,
                        Width = 50
                    },
                    new GridViewColumnSettings {
                        ColumnName = "CustomerName",
                        DisplayOrder = 1,
                        Width = 400
                    },
                    new GridViewColumnSettings {
                        ColumnName = "CustomerBirthdate",
                        DisplayOrder = 2
                    },
                    new GridViewColumnSettings {
                        ColumnName = "CustomerOrders",
                        DisplayOrder = 3
                    }
                }
            };

            return base.Init();
        }

        public override Task Load()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(GetQueryable(15));
            }

            return base.Load();
        }

        private IQueryable<Customer> GetQueryable(int size)
        {
            var numbers = new List<Customer>();
            for (var i = 0; i < size; i++)
            {
                numbers.Add(new Customer { Id = i + 1, Name = $"Customer {i + 1}", BirthDate = DateTime.Now.AddYears(-i), Orders = i });
            }
            return numbers.AsQueryable();
        }
    }
}
