using BethanysPieShop.Models;
using System.Collections.Generic;

namespace BethanysPieShop.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
