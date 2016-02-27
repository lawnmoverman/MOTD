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
     
        IMotdRepository<Prize> _prizeRepositor = new MotdRepository<Prize>(new MotdContext());

        public PrizeViewModel AddNewPrize(PrizeViewModel prize)
        {
            Prize model = new Prize();
            try
            {
               
                model.Description = prize.Description;
                model.Id = prize.Id;
                model.IsWon = prize.IsWon;
                model.Name = prize.Name;


                _prizeRepositor.Create(model);
                _prizeRepositor.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            PrizeViewModel prizeViewModel = new PrizeViewModel();
            prizeViewModel.Description = model.Description;
            prizeViewModel.Id = model.Id;
            prizeViewModel.IsWon = model.IsWon;
            prizeViewModel.Name = model.Name;


            return prizeViewModel;
        }


        //public PrizeService(IMotdRepository<Prize> prizeRepositor)
        //      : base()
        //  {
        //      _prizeRepositor = prizeRepositor;

        //  }

        public List<PrizeViewModel> GetPrizes()
      {
          List<Prize> lista=_prizeRepositor.Get().ToList();
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

       
      
    }        

}




