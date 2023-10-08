using Checkpoint_2___2SEM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint_2___2SEM.Controllers

{
    public class JogoController : Controller
    {
        private static List<Jogo> jogos = new List<Jogo>();

        [HttpGet]
        public IActionResult Index(string pesquisa = "")
        {
            if (!string.IsNullOrEmpty(pesquisa))
            {
                jogos = jogos.Where(j => j.Nome.Contains(pesquisa, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(jogos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                jogos.Add(jogo);
                TempData["SuccessMessage"] = "Jogo adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var jogo = jogos.FirstOrDefault(j => j.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }
            return View(jogo);
        }

        [HttpPost]
        public IActionResult Edit(Jogo jogo)
        {
            var jogoExistente = jogos.FirstOrDefault(j => j.Id == jogo.Id);
            if (jogoExistente != null && ModelState.IsValid)
            {
                jogoExistente.Nome = jogo.Nome;
                jogoExistente.Genero = jogo.Genero;
                jogoExistente.DataLancamento = jogo.DataLancamento;
                jogoExistente.Classificacao = jogo.Classificacao;
                jogoExistente.Descricao = jogo.Descricao;
                TempData["SuccessMessage"] = "Jogo atualizado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(jogo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var jogo = jogos.FirstOrDefault(j => j.Id == id);
            if (jogo == null)
            {
                return NotFound();
            }
            return View(jogo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var jogo = jogos.FirstOrDefault(j => j.Id == id);
            if (jogo != null)
            {
                jogos.Remove(jogo);
                TempData["SuccessMessage"] = "Jogo removido com sucesso!";
            }
            return RedirectToAction("Index");
        }
    }
}
