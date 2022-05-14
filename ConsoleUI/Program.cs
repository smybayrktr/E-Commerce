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
            //EntityFrameworkGetAllTest();
            //CategoryManagerTest();
            //GetProductDetailsTest();
            //ProductTest();
        }

        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    var result = productManager.GetProductDetails();
        //    if (result.Success)
        //    {
        //        foreach (var item in result.Data)
        //        {
        //            Console.WriteLine(item.ProductName + " - " + item.CategoryName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}

        //private static void GetProductDetailsTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    foreach (var item in productManager.GetProductDetails().Data)
        //    {
        //        Console.WriteLine(item.ProductName + " - " + item.CategoryName);
        //    }
        //}

        //private static void CategoryManagerTest()
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //    foreach (var item in categoryManager.GetAll().Data)
        //    {
        //        Console.WriteLine(item.CategoryName);
        //    }
        //}

        //private static void EntityFrameworkGetAllTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    foreach (var item in productManager.GetAll().Data)
        //    {
        //        Console.WriteLine(item.ProductName);
        //    }
        //}

        //private static void InMemoryGetAllTest()
        //{
        //    ProductManager productManager = new ProductManager(new InMemoryProductDal());
        //    foreach (var item in productManager.GetAll().Data)
        //    {
        //        Console.WriteLine(item.ProductName);
        //    }
        //}
    }
}
