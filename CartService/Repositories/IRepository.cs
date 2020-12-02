using CartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Repositories
{
    public interface IRepository
    {
        MenuItem AddToCart(int userId,MenuItem menuItem);

        IEnumerable<MenuItem> getCartItems(int id);

        bool Delete(int UserId, int menuItemI);
        bool RemoveAfterOrder(int id);
    }
}
