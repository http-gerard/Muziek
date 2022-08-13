using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using ProjectMuziek.Helpers;
using ProjectMuziek.Views;
using ProjectMuziek_DALS;
using ProjectMuziek_DALS.Data.UnitOfWork;
using ProjectMuziek_Model;
using ProjectMuziek_Model.Statics;


namespace ProjectMuziek.ViewModels
{
    public class InloggenViewmodel : BaseViewmodel
    {
        public string Email { get; set; }
        public string Foutmelding { get; set; }
        public Gebruiker User { get; set; }
        public string Wachtwoord { get; set; }
        public RelayCommand LoginKnop { get; set; }

        public InloggenViewmodel()
        {
            LoginKnop = new RelayCommand(() => Login());
        }

        void Login()
        {
            User = unitOfWork.GebruikerRepo.Ophalen(x => x.Email == Email && x.Wachtwoord == Wachtwoord).SingleOrDefault();
            if (validate())
            {
                Statics.AangemeldeGebruiker = User;
                OpenPage("Lieds");
                if (Statics.AangemeldeGebruiker.IsAdmin == true)
                {
                    ShowLoggedInButtonsAdmin();
                }
                else
                {
                    ShowLoggedInButtonsUser();
                }
            }
            else
            {
                MessageBox.Show(Foutmelding);
            }

        }

        bool validate()
        {
            Foutmelding = "";
            if (string.IsNullOrEmpty(Email))
            {
                Foutmelding += "E-mailadres ontbreekt!" + Environment.NewLine;
            }
            else if (User == null)
            {
                Foutmelding += "E-mailadres & wachtwoord onjuist" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(Wachtwoord))
            {
                Foutmelding += "Wachtwoord ontbreekt!" + Environment.NewLine;
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
