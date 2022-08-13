using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace ProjectMuziek.ViewModels.ACP
{
    public class AdminPanelViewmodel : BaseViewmodel
    {
        public RelayCommand ACPLieds { get; set; }

        public AdminPanelViewmodel()
        {
            ACPLieds = new RelayCommand(() => OpenPage("ACPLieds"));

        }
    }
}
