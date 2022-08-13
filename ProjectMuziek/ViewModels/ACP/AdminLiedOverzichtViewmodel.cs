using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using ProjectMuziek.Views;
using ProjectMuziek.Views.ACP;
using ProjectMuziek_DALS;
using ProjectMuziek_DALS.Data.UnitOfWork;
using ProjectMuziek_Model;
using ProjectMuziek_Model.Statics;
using System.Windows;

namespace ProjectMuziek.ViewModels.ACP
{
    public class AdminLiedOverzichtViewmodel : BaseViewmodel
    {
        private ObservableCollection<Lied> m_Lieds;

        public ObservableCollection<Lied> Lieds
        {
            get => m_Lieds;
            set => Set(ref m_Lieds, value);
        }
        public RelayCommand LiedToevoegen { get; set; }
        public RelayCommand LiedVerwijderen { get; set; }
        public RelayCommand LiedAanpassen { get; set; }
        public Lied SelectedLied { get; set; }

        public AdminLiedOverzichtViewmodel()
        {
            Lieds = new ObservableCollection<Lied>(unitOfWork.LiedRepo.Ophalen(x => x.Zanger, x => x.Genre).ToList());
            LiedToevoegen = new RelayCommand(() => OpenPage("AdminLiedToevoegen"));
            LiedVerwijderen = new RelayCommand(() => DeleteLied());
            LiedAanpassen = new RelayCommand(() => AanpassenLied());
        }

        void AanpassenLied()
        {
            if (SelectedLied != null)
            {
                Statics.AanpassenLied = SelectedLied;
                OpenPage("AdminLiedAanpassen");
            }
            else
            {
                MessageBox.Show("Selecteer een lied!");
            }

        }
        void DeleteLied()
        {
            if (SelectedLied != null)
            {
                unitOfWork.LiedRepo.Verwijderen(SelectedLied);
                unitOfWork.Save();
                Lieds.Remove(SelectedLied);
            }
            else
            {
                MessageBox.Show("Selecteer een lied!");
            }

        }
    }
}
