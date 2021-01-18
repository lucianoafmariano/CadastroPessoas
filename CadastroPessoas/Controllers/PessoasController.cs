using CadastroPessoas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoas.Controllers
{
    public class PessoasController : Controller
    {
        private readonly Contexto _contexto;

        public PessoasController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Pessoas.ToListAsync());
        }

        [HttpGet]
        public IActionResult CriarPessoa()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarPessoa(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(pessoa);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            else return View(pessoa);
        }
    }
}
