using Motd.Data;
using Motd.Data.Models;
using Motd.Repositories.Contracts;
using Motd.Services.Contracts;
using Motd.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motd.Services
{
    public class PrizeService : IPrizeService
    {
        IMotdRepository<Prize> _prizeRepository = new MotdRepository<Prize>(new MotdContext());

        /// <summary>
        ///   Add new prize object to the list
        /// </summary>
        public PrizeViewModel AddNewPrize(PrizeViewModel prize)
        {
            Prize model = new Prize();
            try
            {
                model.Description = prize.Description;
                model.Id = prize.Id;
                model.IsWon = prize.IsWon;
                model.Name = prize.Name;

                _prizeRepository.Create(model);
                _prizeRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            PrizeViewModel prizeViewModel = new PrizeViewModel();
            prizeViewModel.Description = model.Description;
            prizeViewModel.Id = model.Id;
            prizeViewModel.IsWon = model.IsWon;
            prizeViewModel.Name = model.Name;


            return prizeViewModel;
        }

        /// <summary>
        ///   Get list of prizes
        /// </summary>
        public List<PrizeViewModel> GetPrizes()
        {
            var lista = _prizeRepository.Get().ToList();
            List<PrizeViewModel> returnList = null;
            if (lista != null)
            {
                returnList = new List<PrizeViewModel>();
                foreach (Prize prize in lista)
                {
                    PrizeViewModel model = new PrizeViewModel();
                    model.Description = prize.Description;
                    model.Id = prize.Id;
                    model.IsWon = prize.IsWon;
                    model.Name = prize.Name;
                    returnList.Add(model);
                }
            }
            return returnList;
        }

        /// <summary>
        ///   Delete prize from the list
        /// </summary>
        public bool DeletePrize(int id)
        {
            List<Prize> lista = _prizeRepository.Get().ToList();
            if (lista!=null)
            {
                Prize itemToDelete = lista.Find(p => p.Id == id);
                if(itemToDelete!=null)
                {
                    _prizeRepository.Delete(itemToDelete);
                    _prizeRepository.SaveChanges();
                    return true;
                } 
            }
            return false;
        }
    }
}




