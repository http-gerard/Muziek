using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using ProjectMuziek.Helpers;
using ProjectMuziek.Views;
using ProjectMuziek_DALS;
using ProjectMuziek_DALS.Data.UnitOfWork;
using ProjectMuziek_Model;
using ProjectMuziek_Model.Statics;
namespace ProjectMuziek.ViewModels
{
    public class LiedjesViewmodel : BaseViewmodel
    {
        private List<Lied> m_Lieds;

        public List<Lied> Lieds
        {
            get => m_Lieds;
            set => Set(ref m_Lieds, value);
        }

        private List<Genre> m_Genres;

        public List<Genre> Genres
        {
            get => m_Genres;
            set => Set(ref m_Genres, value);
        }

        public string Foutmelding { get; set; }

        public Genre SelectedGenre { get; set; }
        public RelayCommand ZoekLiedKnop { get; set; }

        public RelayCommand ResetFiltersKnop { get; set; }

        public string Zoekterm { get; set; }
        public RelayCommand<Lied> UitleningCommand { get; set; }

        public LiedjesViewmodel()
        {

            Lieds = unitOfWork.LiedRepo.Ophalen(x => x.Zanger, x => x.Genre).ToList();
            Genres = unitOfWork.GenreRepo.Ophalen().ToList();
            ZoekLiedKnop = new RelayCommand(() => Zoeken());
            ResetFiltersKnop = new RelayCommand(() => OpenPage("Lieds"));
            UitleningCommand = new RelayCommand<Lied>(beluisteren);
        }

        void beluisteren(Lied aLied)
        {
            if (validate())
            {

                    unitOfWork.BeluisterdLiedRepo.Toevoegen(new BeluisterdLied(DateTime.Now,
                   Statics.AangemeldeGebruiker.GebruikerId, aLied.LiedId));
                    aLied.IsBeluisterd = true;
                    unitOfWork.LiedRepo.Aanpassen(aLied);
                    unitOfWork.Save();
                    Lieds = unitOfWork.LiedRepo.Ophalen(x => x.IsBeluisterd == false).ToList();
                }

        }

        void Zoeken()
        {
            if (SelectedGenre != null && !string.IsNullOrWhiteSpace(Zoekterm))
            {
                Lieds = unitOfWork.LiedRepo.Ophalen(x => x.Titel.Contains(Zoekterm) &&
                                                          x.GenreId == SelectedGenre.GenreId, x => x.Zanger).ToList();
            }
            
            else if (!string.IsNullOrWhiteSpace(Zoekterm))
            {
                Lieds = unitOfWork.LiedRepo
                    .Ophalen(x => x.Titel.Contains(Zoekterm), x => x.Zanger).ToList();
            }
            else if (SelectedGenre != null)
            {
                Lieds = unitOfWork.LiedRepo.Ophalen(x => x.GenreId == SelectedGenre.GenreId,
                    x => x.Zanger).ToList();
            }
            
        }



        bool validate()
        {
            Foutmelding = "";

            if (Statics.AangemeldeGebruiker == null)
            {
                Foutmelding += "Om een lied te beluisteren moet je aangemeld zijn" + Environment.NewLine;
            }
            else if (Statics.AangemeldeGebruiker.IsAdmin == true || Statics.AangemeldeGebruiker.IsSuperAdmin == true)
            {
                Foutmelding += "U bent admin!" + Environment.NewLine;
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

