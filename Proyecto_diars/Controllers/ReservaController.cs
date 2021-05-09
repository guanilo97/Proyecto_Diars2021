using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_diars.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_diars.Controllers
{
    public class ReservaController : Controller
    {
        private AppCartaContext context;
        public ReservaController(AppCartaContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var rese = context.reservas.Include(o => o.cartass).ToList();
            return View(rese);
        }
        public IActionResult detallepedido()
        {
            return View();
        }
    }
}
