using BLL;
using BLL.Dto;
using DAL.Entities;
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

        public IActionResult Index(User user)
        {
            
            return View(styloService.GetAll());
  
        }
        public IActionResult CrudList()
        {

            return View(styloService.GetAll());

        }
        [HttpGet] 
        public IActionResult Add() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Stylo stylo)
        {
            
            styloService.CreateStylo(stylo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Stylo stylo)
        {
            styloService.DeleteStylo(stylo);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            return View(styloService.GetStylo(id));
        }
        [HttpPost]
        public IActionResult Update(Stylo stylo)
        {
            styloService.UpdateStylo(stylo);
            return RedirectToAction("Index");
        }

    }
}
