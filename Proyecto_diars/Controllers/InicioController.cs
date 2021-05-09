using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_diars.DB;
using Proyecto_diars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_diars.Controllers
{
    public class InicioController : Controller
    {
            private AppCartaContext context;
            public InicioController(AppCartaContext context)
            {
                this.context = context;
            }
            public IActionResult Index()
        {
            return View();
        }
        public IActionResult carta()
        {
            return View(context.cartas.ToList());
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            var reserva = context.reservas.ToList();
            return View(reserva);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Reserva reserva)
        {
            context.reservas.Add(reserva);
            context.SaveChanges();
            return RedirectToAction("Create");
        }
        public ViewResult Detalle(int id)
        {
            var carta = context.cartas;

            Carta carta1 = carta.FirstOrDefault(item => item.Id_carta == id);
            return View(carta1);
        }
        }
}
