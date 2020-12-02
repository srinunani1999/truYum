using CartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Repositories
{
    public class CartRepository : IRepository
    {
        static Dictionary<int,List< MenuItem>> menuItems ;
        static CartRepository()
        {
            menuItems = new Dictionary<int,List<MenuItem>>();
        }
        public MenuItem AddToCart(int userid,MenuItem menuItem)
        {
            foreach (var item in menuItems.Keys)
            {
                if (item == userid)
                {
                    menuItems[userid].Add(menuItem);
                    return menuItem;
                }
            }
            menuItems.Add(userid, new List<MenuItem>());
            menuItems[userid].Add(menuItem);


           
            return menuItem;
            

           
        }

        public bool Delete(int userid,int menuitemid)
        {
           var cartItems= menuItems[userid];

            var item = cartItems.FirstOrDefault(c => c.Id==menuitemid);
           return  cartItems.Remove(item);

         
        }

        public bool RemoveAfterOrder(int userid)
        {
             menuItems[userid].Clear();
            if (menuItems[userid].Count==0)
            {
                return true;
            }
            return false;

        }
        public IEnumerable<MenuItem> getCartItems(int id)
        {
            return menuItems[id];
        }
    }
}
