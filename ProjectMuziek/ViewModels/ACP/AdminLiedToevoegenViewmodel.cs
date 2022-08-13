using GalaSoft.MvvmLight.Command;
using ProjectMuziek_Model;
using ProjectMuziek_Model.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ProjectMuziek.ViewModels.ACP
{
    public class AdminLiedToevoegenViewmodel : BaseViewmodel
    {
        private List<Genre> m_Genres;

        public List<Genre> Genres
        {
            get => m_Genres;
            set => Set(ref m_Genres, value);
        }
        private List<Zanger> m_Zangers;

        public List<Zanger> Zangers
        {
            get => m_Zangers;
            set => Set(ref m_Zangers, value);
        }
        public string Foutmelding { get; set; }
        public string Titel { get; set; }
        public string Zanger { get; set; }
        public string Producer { get; set; }
        public string Uitgavejaar { get; set; }
        public string PlatenLabel { get; set; }
        public Genre Genre { get; set; }
        public RelayCommand LiedToevoegenKnop { get; set; }
        public AdminLiedToevoegenViewmodel()
        {
            Genres = unitOfWork.GenreRepo.Ophalen().ToList();
            Zangers = unitOfWork.ZangerRepo.Ophalen().ToList();
            LiedToevoegenKnop = new RelayCommand(() => LiedToevoegen());
        }

        void LiedToevoegen()
        {
            var allZangers = unitOfWork.ZangerRepo.Ophalen().ToList();
            if (validate())
            {
                if (!allZangers.Any(x => x.VolledigeNaam == Zanger))
                {
                    var zanger = new Zanger(Zanger);
                    unitOfWork.ZangerRepo.Toevoegen(zanger);
                    unitOfWork.LiedRepo.Toevoegen(new Lied(Titel, Uitgavejaar, Genre.GenreId, zanger.ZangerId,PlatenLabel,Producer));
                    unitOfWork.Save();
                    OpenPage("ACPLieds");
                }
                else
                {
                    var bestaandeZanger = allZangers.Find(x => x.VolledigeNaam == Zanger);
                    unitOfWork.LiedRepo.Toevoegen(new Lied(Titel, Uitgavejaar, Genre.GenreId, bestaandeZanger.ZangerId, PlatenLabel, Producer));
                    unitOfWork.Save();
                    OpenPage("ACPLieds");
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

            if (string.IsNullOrEmpty(Titel))
            {
                Foutmelding += "Titel ontbreekt!" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(Producer))
            {
                Foutmelding += "Producer ontbreekt!" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(Uitgavejaar))
            {
                Foutmelding += "Uitgavejaar ontbreekt!" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(PlatenLabel))
            {
                Foutmelding += "PLatenlabel ontbreekt!" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(Zanger))
            {
                Foutmelding += "Zanger ontbreekt!" + Environment.NewLine;
            }
            if (Genre == null)
            {
                Foutmelding += "Selecteer een genre!" + Environment.NewLine;
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
