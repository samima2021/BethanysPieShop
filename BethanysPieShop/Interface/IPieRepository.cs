using BethanysPieShop.Models;
using System.Collections.Generic;

namespace BethanysPieShop.Interface
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);
    }
}
