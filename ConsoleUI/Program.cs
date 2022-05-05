using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // InMemoryGetAllTest();
            EntityFrameworkGetAllTest();
        }

        private static void EntityFrameworkGetAllTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void InMemoryGetAllTest()
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            foreach (var item in productManager.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
