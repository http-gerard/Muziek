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
    class AdminLiedAanpassenViewmodel : BaseViewmodel
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
        public RelayCommand LiedAanpassenKnop { get; set; }

        public AdminLiedAanpassenViewmodel()
        {
            LiedAanpassenKnop = new RelayCommand(() => LiedOpslaan());
            InfoInladen();
        }

        void InfoInladen()
        {

            Genres = unitOfWork.GenreRepo.Ophalen().ToList();
            Zangers = unitOfWork.ZangerRepo.Ophalen().ToList();
            var zanger = unitOfWork.ZangerRepo.Ophalen(x => x.ZangerId == Statics.AanpassenLied.ZangerId)
                 .FirstOrDefault();
            Zanger = zanger.VolledigeNaam;
            Titel = Statics.AanpassenLied.Titel;
            Producer = Statics.AanpassenLied.Producer;
            PlatenLabel = Statics.AanpassenLied.PlatenLabel;
            Uitgavejaar = Statics.AanpassenLied.UitgaveJaar;


        }

        void LiedOpslaan()
        {
            var allZangers = unitOfWork.ZangerRepo.Ophalen().ToList();
            if (validate())
            {
                {
                    var bestaandeZanger = allZangers.Find(x => x.VolledigeNaam == Zanger);
                    Statics.AanpassenLied.ZangerId = bestaandeZanger.ZangerId;
                    Statics.AanpassenLied.Titel = Titel;
                    Statics.AanpassenLied.PlatenLabel = PlatenLabel;
                    Statics.AanpassenLied.UitgaveJaar = Uitgavejaar;
                    Statics.AanpassenLied.Producer = Producer;
                    Statics.AanpassenLied.GenreId = Genre.GenreId;
                    unitOfWork.LiedRepo.ToevoegenOfAanpassen(Statics.AanpassenLied);
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
            if (string.IsNullOrEmpty(PlatenLabel))
            {
                Foutmelding += "Platenlabel ontbreekt!" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(Uitgavejaar))
            {
                Foutmelding += "Uitgavejaar ontbreekt!" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(Producer))
            {
                Foutmelding += "Producer ontbreekt!" + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(Zanger))
            {
                Foutmelding += "Zanger ontbreekt!" + Environment.NewLine;
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
