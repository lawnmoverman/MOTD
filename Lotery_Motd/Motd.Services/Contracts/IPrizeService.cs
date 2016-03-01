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
        List<PrizeViewModel> GetPrizes();
        PrizeViewModel AddNewPrize(PrizeViewModel prize);
        bool DeletePrize(int id);
    }
}
