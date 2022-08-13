using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMuziek_Model;
using ProjectMuziek_Model.Statics;
using GalaSoft.MvvmLight.Command;

namespace ProjectMuziek.ViewModels.Account
{
    public class MijnBeluisterdViewmodel : BaseViewmodel
    {
        private List<BeluisterdLied> m_MijnBeluisterde;

        public List<BeluisterdLied> MijnBeluisterde
        {
            get => m_MijnBeluisterde;
            set => Set(ref m_MijnBeluisterde, value);
        }
        public BeluisterdLied SelectedBeluisterdLied { get; set; }

        public MijnBeluisterdViewmodel()
        {

            MijnBeluisterde = unitOfWork.BeluisterdLiedRepo.Ophalen(x => x.GebruikerId == Statics.AangemeldeGebruiker.GebruikerId, x => x.Lied).ToList();
        }

        
    }
}
