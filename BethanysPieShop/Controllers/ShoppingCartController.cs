﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly ShoppingCart shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository, ShoppingCart shoppingCart)
        {
            this.pieRepository = pieRepository;
            this.shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = shoppingCart,
                ShoppingCartTotal = shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                shoppingCart.AddToCart(selectedPie, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
                shoppingCart.RemoveFromCart(selectedPie);

            return RedirectToAction("Index");
        }
    }
}
