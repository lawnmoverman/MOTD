using Motd.Data.Models;
using Motd.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motd.Services.Contracts
{
    public interface IPrizeService
    {
        /// <summary>
        ///  Get all prizes.
        /// </summary>       
        /// <returns>List of prizes </returns>
        List<PrizeViewModel> GetPrizes();

        /// <summary>
        ///   Get single prize object by Id.
        /// </summary>
        /// <param name="id"> Primary key </param>
        /// <returns>Single prize object.</returns>
        PrizeViewModel GetPrize(int id);

        /// <summary>
        ///   Add new prize.
        /// </summary>
        /// <param name="prize"> Prize view model. </param>
        /// <returns>Prize view model. </returns>
        PrizeViewModel AddNewPrize(PrizeViewModel prize);

        /// <summary>
        ///   Delete prize.
        /// </summary>
        /// <param name="id"> primary key. </param>
        /// <returns>true/false. </returns>
        bool DeletePrize(int id);

        /// <summary>
        ///   Gets object by primary key.
        /// </summary>
        /// <param name="prize"> Prize view model. </param>
        /// <returns>Prize view model. </returns>
        PrizeViewModel EditPrize(PrizeViewModel prize);
    }
}
