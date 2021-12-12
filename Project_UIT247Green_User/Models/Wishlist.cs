﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_UIT247Green_User.Models
{
    public class Wishlist
    {   
        public int id_wish { set; get; }
        public int id_user { set; get; }
        public int id_pro { set; get; }
        public static int Insert(int id, int id_pro)
        {
            using (var context = new DataContext())
            {
                context.Wishlist.Add(new Wishlist
                {
                    id_user = id,
                    id_pro = id_pro
                });
                return context.SaveChanges();
            }
        }
        public static void Delete(int id_user, int id_pro)
        {
            using (var context = new DataContext())
            {
                Wishlist wishlist = (from p in context.Wishlist
                                 where (p.id_user == id_user && p.id_pro == id_pro)
                             select p).FirstOrDefault();
                if (wishlist != null)
                {
                    context.Remove(wishlist);
                }
                context.SaveChanges();
            }
        }
        public static List<Wishlist> Select()
        {
            using (var context = new DataContext())
            {
                var list  = context.Wishlist.ToList();
                return list;
            }
        }
    }
}
