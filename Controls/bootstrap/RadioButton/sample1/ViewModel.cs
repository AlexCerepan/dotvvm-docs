using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.bootstrap.RadioButton.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string RadioResult { get; set; }
        public string Radio { get; set; }

        public void UpdateRadio()
        {
            RadioResult = Radio;
        }
    }
}
