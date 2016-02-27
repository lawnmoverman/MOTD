using Motd.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Motd.Data;
using Motd.Repositories;
using Motd.Services;
using Motd.Data.Models;


namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //MotdContext ctx = new MotdContext();
            //IMotdRepository<Prize> repository = new MotdRepository<Prize>(ctx);
            //PrizeService servis = new PrizeService(repository);
            //List<Prize> lista = servis.GetPrizes().ToList();

            MotdContext ctx = new MotdContext();
            IMotdRepository<User> repository = new MotdRepository<User>(ctx);
            UserService servis2 = new UserService(repository);
            List<User> lista = servis2.GetUsers().ToList();

            foreach (User item in lista)
            {
                Console.WriteLine(item.Name +" "+ item.LastName);              

            }

            Console.ReadLine();
        }
    }
}
