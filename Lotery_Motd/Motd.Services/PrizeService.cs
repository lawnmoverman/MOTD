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
        /// <summary>
        /// Metods descriptions are in interface IPrizeService
        /// </summary>
       
        IMotdRepository<Prize> _prizeRepository = new MotdRepository<Prize>(new MotdContext());
       
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
        
        public PrizeViewModel GetPrize(int id)
        {
            var lista = _prizeRepository.Get().ToList();
            Prize returnPrize = lista.FirstOrDefault(p => p.Id == id);
            PrizeViewModel model = new PrizeViewModel();

            if (returnPrize != null)
            {   
                model.Description = returnPrize.Description;
                model.Id = returnPrize.Id;
                model.IsWon = returnPrize.IsWon;
                model.Name = returnPrize.Name;
            }
            return model;
        }
      
        public bool DeletePrize(int id)
        {
            List<Prize> lista = _prizeRepository.Get().ToList();
            try
            {
                
                if (lista != null)
                {
                    Prize itemToDelete = lista.Find(p => p.Id == id);
                    if (itemToDelete != null)
                    {
                        _prizeRepository.Delete(itemToDelete);
                        _prizeRepository.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public PrizeViewModel EditPrize(PrizeViewModel prize)
        {
            var lista = _prizeRepository.Get().ToList();
            Prize FoundPrize = lista.FirstOrDefault(p => p.Id == prize.Id);
            
            try
            {
                FoundPrize.Description = prize.Description;
                FoundPrize.Id = prize.Id;
                FoundPrize.IsWon = prize.IsWon;
                FoundPrize.Name = prize.Name;

                _prizeRepository.Update(FoundPrize);
                _prizeRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return prize;
        }
       
    }
}




