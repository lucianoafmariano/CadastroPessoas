using CadastroPessoas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Controllers
{
    public class PessoasCoontroller : Controller
    {
        private readonly Contexto _contexto;

        public PessoasCoontroller(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Pessoas.ToListAsync());
        }
    }
}
