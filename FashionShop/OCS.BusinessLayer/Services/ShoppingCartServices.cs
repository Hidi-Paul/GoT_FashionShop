using AutoMapper;
using OCS.BusinessLayer.Models;
using OCS.DataAccess.DTO;
using OCS.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCS.BusinessLayer.Services
{
    public class ShoppingCartServices : IShoppingCartServices
    {
        private readonly IShoppingCartRepository repo;
        private readonly IProductRepository productRepo;

        public ShoppingCartServices(IShoppingCartRepository repo, IProductRepository productRepo)
        {
            this.repo = repo;
            this.productRepo = productRepo;
        }

        public ShoppingCartModel GetShoppingCartByUser(string user)
        {
            ShoppingCart cart = repo.GetByUser(user);

            if (cart == null)
            {
                cart = new ShoppingCart();
                cart.ShoppingCartID = new Guid();
                cart.ShoppingCartItems = new List<ShoppingCartItem>();

                repo.AddCart(cart);
                repo.SaveChangesAsync();
            }
            
            ShoppingCartModel cartModel = Mapper.Map<ShoppingCartModel>(cart);

            return cartModel;
        }

        public void AddProduct(ShoppingCartItemModel model, string user)
        {
            if (model == null)
            {
                throw new ApplicationException("Shopping Cart Item cannot be null");
            }

            ShoppingCartItem mappedModel = Mapper.Map<ShoppingCartItem>(model);
            mappedModel.ShoppingCartItemID = new Guid();

            var product = productRepo.GetProductById(model.Product.ProductID);
            if (product == null)
            {
                throw new ApplicationException("Product not found");
            }

            mappedModel.Product = product;

            ShoppingCart cart = repo.GetByUser(user);
            if (cart == null)
            {
                cart = new ShoppingCart();
                cart.ShoppingCartID = new Guid();
                cart.ShoppingCartItems = new List<ShoppingCartItem>();

                repo.AddCart(cart);
            }

            cart.ShoppingCartItems.Add(mappedModel);
            repo.SaveChangesAsync();
        }


    }
}
