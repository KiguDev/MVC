using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurantes.Core.Interfaces;
using Restaurantes.Infrastructure.Identity;

namespace Restaurantes.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class EmpleadosController : Controller
    {
        private IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }
    }
}
