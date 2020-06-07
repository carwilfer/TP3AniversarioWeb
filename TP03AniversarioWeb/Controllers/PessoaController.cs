using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index(string? message)
        {
            ViewBag.Message = message;
            return View(Pessoas);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(Guid id)
        
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            return View(pessoa);
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
                if (ModelState.IsValid == false)
                    return View();

                pessoa.Id = Guid.NewGuid();

                // TODO: Add insert logic here
                Pessoas.Add(pessoa);
                return RedirectToAction("Index","Pessoa", new { message = "Pessoa cadastrada com sucesso" });
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public IActionResult Edit([FromQuery] Guid id)
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromQuery]  Guid id, Pessoa pessoaModel)
        {
            try
            {
                //var guid = Guid.Parse(id);
                var pessoaEdit = Pessoas.FirstOrDefault(x => x.Id == id);

                Pessoas.Remove(pessoaEdit);
                pessoaModel.Id = id;
                Pessoas.Add(pessoaModel);

                return RedirectToAction("Index", "Pessoa", new { message = "Pessoa cadastrada com sucesso" });
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(Guid id)
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
                Pessoas.Remove(pessoa);

                return RedirectToAction("Index", "Pessoa", new { menssage = "Pessoa excluida com sucesso" });
            }
            catch
            {
                return View();
            }
        }

        /*
        [HttpGet]
        public ActionResult Pesquisa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pesquisa(string texto)
        {
            return View(Pessoas.Where(x => x.Nome.Contains(texto)).OrderBy(x => x.Nome));
        }
        */
        /*
        public ActionResult Pesquisar()
        {
             return View(pessoa);
        }
        [HttpPost]
        public ActionResult Pesquisar(Pessoa pessoa)
        {
            using (var db = new EstudoEntities())
            {
               var pessoa = Pessoas.FirstOrDefault(x => x.Id == id)
                                where ((pessoa.Nome == null)
                                || (pessoas.Nome == pessoa.Nome.Trim()))
                                select new
                                {
                                    Id = pessoas.Id,
                                    Nome = pessoas.Nome,
                                    Email = pessoas.Email,
                                    DataNascimento = pessoas.DataNascimento
                                };
                foreach (var reg in nomePesquisa)
                {
                    Cliente clientevalor = new Cliente();
                    clientevalor.Id = reg.Id;
                    clientevalor.Nome = reg.Nome;
                    listaClientes.Add(clientevalor);
                }
                pessoa.Clientes = listaClientes;
                return View(pessoa);
            }
        }*/
    }
}