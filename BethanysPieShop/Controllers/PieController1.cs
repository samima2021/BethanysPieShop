﻿using BethanysPieShop.Interface;
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BethanysPieShop.Controllers
{
    public class PieController1 : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PieController1(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
                _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        //GET :/<controller>/
        //public IActionResult List()
        //{
        //    ViewBag.CurrenCategory = "Chese cakes";
        //    return View(_pieRepository.AllPies);
        //    PieListViewModel piesListViewModel = new PieListViewModel();
        //    piesListViewModel.Pies = _pieRepository.AllPies;

        //    piesListViewModel.CurrentCategory = "Cheese cakes";
        //    return View(piesListViewModel);

        //}


        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;
            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new PieListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory,
            });
        }
        public  IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
        
    }
}
