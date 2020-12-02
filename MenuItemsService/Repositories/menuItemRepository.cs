using MenuItemsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuItemsService.Repositories
{
    public class menuItemRepository : IRepository<MenuItem>
    {
        static List<MenuItem> menuItems;
        static menuItemRepository()
        {
            menuItems = new List<MenuItem>() {
            new MenuItem(){Id=1,Active=true,category="Desert",DateOflaunch=DateTime.Parse("10-10-2019"),FreeDelivery=true,Name="Vinnila Icecream",Price=100},
            new MenuItem(){Id=2,Active=true,category="Main Course",DateOflaunch=DateTime.Parse("10-10-2020"),FreeDelivery=true,Name="Hyd Biryani",Price=200},
            new MenuItem(){Id=3,Active=false,category="Starters",DateOflaunch=DateTime.Parse("10-10-2020"),FreeDelivery=true,Name="Chicken 65",Price=200},
            new MenuItem(){Id=4,Active=true,category="Main Course",DateOflaunch=DateTime.Parse("10-10-2020"),FreeDelivery=false,Name="Fried Rice",Price=300},
            new MenuItem(){Id=5,Active=false,category="snacks",DateOflaunch=DateTime.Parse("10-10-2021"),FreeDelivery=true,Name="Burger",Price=400}


            };

        }
        public void Add(MenuItem menuItem)
        {
            menuItems.Add(menuItem);
        }

        public bool Delete(int id)
        {
            var menuitem = menuItems.FirstOrDefault(m => m.Id == id);
           var IsDeleted=  menuItems.Remove(menuitem);
            return IsDeleted;
        }

        public  IEnumerable<MenuItem> Get()
        {
            return  menuItems;
        }

        public MenuItem GetById(int id)
        {
            var menuitem = menuItems.FirstOrDefault(m => m.Id == id);
            return menuitem;
        }

        public MenuItem Update(MenuItem menuItem)
        {
            var updatemenuitem = menuItems.FirstOrDefault(m => m.Id == menuItem.Id);

            updatemenuitem.Name = menuItem.Name;
            updatemenuitem.DateOflaunch = menuItem.DateOflaunch;
            updatemenuitem.category = menuItem.category;
            updatemenuitem.FreeDelivery = menuItem.FreeDelivery;
            updatemenuitem.Active = menuItem.Active;
            return updatemenuitem;
            
        }
    }
}
