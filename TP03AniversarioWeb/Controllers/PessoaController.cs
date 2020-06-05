using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP03AniversarioWeb.Models;

namespace TP03AniversarioWeb.Controllers
{
    public class PessoaController : Controller
    {
        public static List<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
        // GET: Pessoa
        public ActionResult Index(string? message)
        {
            ViewBag.Message = message;
            return View(Pessoas);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details([FromQuery] Guid id, Pessoa pessoa)
        
        {
            return View(Pessoas);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                // TODO: Add insert logic here
                Pessoas.Add(pessoa);
                return RedirectToAction($"Index","Pessoa", new { message = "Pessoa cadastrada com sucesso" });
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pessoa pessoa)
        {
            try
            {
                // TODO: Add update logic here
                var pessoaOld = Pessoas.FirstOrDefault(x => x.Id == id);
                Pessoas.Remove(pessoaOld);

                pessoa.Id = id;
                Pessoas.Add(pessoa);

                return RedirectToAction($"Index", "Pessoa", new { message = "Pessoa cadastrada com sucesso" });
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
                Pessoas.Remove(pessoa);

                return RedirectToAction($"Index", "Pessoa", new { menssage = "Pessoa excluida com sucesso" });
            }
            catch
            {
                return View();
            }
        }
        /*
        public ActionResult BuscarPessoa()
        {
            using (var db = new EstudoEntities())
            {
                var _pessoa = db.Pessoas.ToList();
                var data = new Pessoa()
                {
                    Pessoas = _pessoa
                };
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult BuscarPessoa(Pessoa _pessoaCriada)
        {
            using (var db = new EstudoEntities())
            {
                var pesquisar = from pessoacre in db.Pessoas
                                where ((_pessoaCriada.Nome == null)
                                || (pessoacre.Nome == _pessoaCriada.Nome.Trim()))
                                select new
                                {
                                    Id = pessoacre.Id,
                                    Nome = pessoacre.Nome,
                                    Email = pessoacre.Email,
                                    DataNascimento = pessoacre.DataNascimento
                                };
            }
        }*/
    }
}