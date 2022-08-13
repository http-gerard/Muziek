using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMuziek.Helpers;
using System.Windows.Controls;
using ProjectMuziek_DALS;
using ProjectMuziek_DALS.Data.UnitOfWork;
using System.Windows;
using ProjectMuziek.Views;
using ProjectMuziek.Views.Aanmelden;
using ProjectMuziek.Views.Account;
using ProjectMuziek.Views.ACP;
using ProjectMuziek.ViewModels;
using ProjectMuziek.ViewModels.Account;
using ProjectMuziek.ViewModels.ACP;

namespace ProjectMuziek.ViewModels
{
    public class BaseViewmodel : NotificationBase
    {
        private UserControl m_Content;

        public UserControl Content
        {
            get => m_Content;
            set => Set(ref m_Content, value);
        }

        public static void HideLoggedInButtons()
        {

            HomePageViewmodel.Instance.Aanmelden = Visibility.Visible;
            HomePageViewmodel.Instance.User = Visibility.Hidden;
            HomePageViewmodel.Instance.Admin = Visibility.Hidden;
            HomePageViewmodel.Instance.Uitloggen = Visibility.Hidden;
        }

        public static void ShowLoggedInButtonsUser()
        {

            HomePageViewmodel.Instance.Admin = Visibility.Hidden;
            HomePageViewmodel.Instance.Aanmelden = Visibility.Hidden;
            HomePageViewmodel.Instance.User = Visibility.Visible;
            HomePageViewmodel.Instance.Uitloggen = Visibility.Visible;
        }

        public static void ShowLoggedInButtonsAdmin()
        {

            HomePageViewmodel.Instance.Aanmelden = Visibility.Hidden;
            HomePageViewmodel.Instance.User = Visibility.Hidden;
            HomePageViewmodel.Instance.Admin = Visibility.Visible;
            HomePageViewmodel.Instance.Uitloggen = Visibility.Visible;
        }

        public IUnitOfWorks unitOfWork = new UnitOfWorks(new ProjectMuziekEntities());

        public void OpenPage(string Page)
        {
            switch (Page)
            {
                case "AdminLiedAanpassen":
                    HomePageViewmodel.Instance.Content = new AdminLiedsAanpassen();
                    HomePageViewmodel.Instance.Content.DataContext = new AdminLiedAanpassenViewmodel();
                    break;
                case "Inloggen":
                    HomePageViewmodel.Instance.Content = new InloggensPage();
                    HomePageViewmodel.Instance.Content.DataContext = new InloggenViewmodel();
                    break;
                case "Lieds":
                    HomePageViewmodel.Instance.Content = new LiedjeWindow();
                    HomePageViewmodel.Instance.Content.DataContext = new LiedjesViewmodel();
                    break;
                case "ACP":
                    HomePageViewmodel.Instance.Content = new AdminPanelsWindow();
                    HomePageViewmodel.Instance.Content.DataContext = new AdminPanelViewmodel();
                    break;
                case "User":
                    HomePageViewmodel.Instance.Content = new AccountGegevenWindow();
                    HomePageViewmodel.Instance.Content.DataContext = new AccountGegegevensViewmodel();
                    break;
                case "ACPLieds":
                    HomePageViewmodel.Instance.Content = new AdminLiedsOverzicht();
                    HomePageViewmodel.Instance.Content.DataContext = new AdminLiedOverzichtViewmodel();
                    break;
                case "AdminLiedToevoegen":
                    HomePageViewmodel.Instance.Content = new AdminLiedsToevoegen();
                    HomePageViewmodel.Instance.Content.DataContext = new AdminLiedToevoegenViewmodel();
                    break;
                case "MijnBeluisterde":
                    HomePageViewmodel.Instance.Content = new MijnBeluisterdenWindow();
                    HomePageViewmodel.Instance.Content.DataContext = new MijnBeluisterdViewmodel();
                    break;
            }
        }
    }
}
