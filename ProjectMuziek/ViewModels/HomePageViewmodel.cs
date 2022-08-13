using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using ProjectMuziek.Views;
using ProjectMuziek_Model.Statics;

namespace ProjectMuziek.ViewModels
{
    public class HomePageViewmodel : BaseViewmodel
    {
        static HomePageViewmodel m_Instance;
        public static HomePageViewmodel Instance => m_Instance ?? (m_Instance = new HomePageViewmodel());


        private UserControl m_Gebruiker;

        public UserControl Gebruiker
        {
            get => m_Gebruiker;
            set => Set(ref m_Gebruiker, value);
        }


        public RelayCommand LiedsButton { get; set; }
        public RelayCommand InlogButton { get; set; }
        public RelayCommand HomeButton { get; set; }
        public RelayCommand AdminButton { get; set; }
        public RelayCommand UitloggenButton { get; set; }
        public RelayCommand ACPButton { get; set; }
        public RelayCommand MyProfielButton { get; set; }
        private Visibility m_User;

        public Visibility User
        {
            get => m_User;
            set => Set(ref m_User, value);
        }

        private Visibility m_Admin;
        public Visibility Admin
        {
            get => m_Admin;
            set => Set(ref m_Admin, value);
        }
        private Visibility m_Aanmelden;

        public Visibility Aanmelden
        {
            get => m_Aanmelden;
            set => Set(ref m_Aanmelden, value);
        }
        
        private Visibility m_Uitloggen;

        public Visibility Uitloggen
        {
            get => m_Uitloggen;
            set => Set(ref m_Uitloggen, value);
        }
        public HomePageViewmodel()
        {
            Content = new LiedjeWindow();
            Content.DataContext = new LiedjesViewmodel();
            LiedsButton = new RelayCommand(() => OpenPage("Lieds"));
            InlogButton = new RelayCommand(() => OpenPage("Inloggen"));
            ACPButton = new RelayCommand(() => OpenPage("ACP"));
            MyProfielButton = new RelayCommand(() => OpenPage("User"));
            UitloggenButton = new RelayCommand(() => UserUitloggen());
            if (Statics.AangemeldeGebruiker == null)
            {
                Admin = Visibility.Hidden;
                
                Aanmelden = Visibility.Visible;
                User = Visibility.Hidden;
                Uitloggen = Visibility.Hidden;
            }
        }
        void UserUitloggen()
        {
            Statics.AangemeldeGebruiker = null;
            Admin = Visibility.Hidden;
            
            Aanmelden = Visibility.Visible;
            User = Visibility.Hidden;
            Uitloggen = Visibility.Hidden;
            OpenPage("Lieds");
        }
    }
}
