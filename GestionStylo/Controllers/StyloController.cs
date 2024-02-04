using BLL;
using BLL.Dto;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

namespace GestionStylo.Controllers
{
    public class StyloController : Controller
    {     
        private readonly StyloService styloService;
        public StyloController(StyloService styloService)
        {
            this.styloService = styloService;
        }


        [Authorize(Roles = "Admin,User")]
        public IActionResult Index(User user)
        {
            
            return View(styloService.GetAll());
  
        }



        [Authorize(Roles = "Admin")]
        public IActionResult CrudList()
        {

            return View(styloService.GetAll());

        }


        [Authorize(Roles = "Admin")]
        [HttpGet] 
        public IActionResult Add() 
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Stylo stylo)
        {
            
            styloService.CreateStylo(stylo);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Stylo stylo)
        {
            styloService.DeleteStylo(stylo);
            return RedirectToAction("Index");
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Update(int id)
        {

            return View(styloService.GetStylo(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Update(Stylo stylo)
        {
            styloService.UpdateStylo(stylo);
            return RedirectToAction("Index");
        }

    }
}
