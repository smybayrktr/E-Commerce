﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ ProductId=1, CategoryId=1, ProductName="Elma", UnitPrice=11, UnitsInStock=5 },
                new Product{ ProductId=2, CategoryId=1, ProductName="Armut", UnitPrice=10, UnitsInStock=3 },
                new Product{ ProductId=3, CategoryId=2, ProductName="Saat", UnitPrice=21, UnitsInStock=0 },
                new Product{ ProductId=4, CategoryId=2, ProductName="Lamba", UnitPrice=44, UnitsInStock=50 },
                new Product{ ProductId=5, CategoryId=3, ProductName="Boya", UnitPrice=101, UnitsInStock=40 },
                new Product{ ProductId=6, CategoryId=3, ProductName="Fırça", UnitPrice=80, UnitsInStock=7 }
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId );
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId );
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.CategoryId= product.CategoryId;
            

        }
    }
}