using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMuziek_Model;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using ProjectMuziek_Model.Statics;
using ProjectMuziek_DALS.Data.UnitOfWork;

namespace ProjectMuziek.ViewModels.Account
{
    public class AccountGegegevensViewmodel : BaseViewmodel
    {
        public Gebruiker Gebruiker { get; set; }
        public RelayCommand SaveChanges { get; set; }
        public RelayCommand DeleteUser { get; set; }
        public RelayCommand MijnBeluisterde { get; set; }
        public string Foutmelding { get; set; }
        public AccountGegegevensViewmodel()
        {
            Gebruiker = Statics.AangemeldeGebruiker;
            SaveChanges = new RelayCommand(() => SaveChangesUser());
            DeleteUser = new RelayCommand(() => Delete());
            MijnBeluisterde = new RelayCommand(() => OpenPage("MijnBeluisterde"));
        }
        void SaveChangesUser()
        {
            if (validate())
            {
                unitOfWork.GebruikerRepo.Aanpassen(Gebruiker);
                unitOfWork.Save();
            }
            else
            {
                MessageBox.Show(Foutmelding);
            }
        }
        void Delete()
        {
            MessageBoxResult result = MessageBox.Show("Bent u zeker?", "Account Verwijderen", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    unitOfWork.GebruikerRepo.Verwijderen(Gebruiker);
                    unitOfWork.Save();
                    OpenPage("Aanbod");
                    HideLoggedInButtons();
                    break;
            }
        }

        bool validate()
        {
            Foutmelding = "";

            
            if (string.IsNullOrEmpty(Gebruiker.Voornaam))
            {
                Foutmelding += "Voornaam mag niet leeg zijn!" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(Gebruiker.Email))
            {
                Foutmelding += "E-mailadres mag niet leeg zijn!" + Environment.NewLine;
            }
            

            if (Foutmelding == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
