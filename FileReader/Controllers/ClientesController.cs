using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FileReader.DAL;
using FileReader.Models;

namespace FileReader.Controllers
{
    public class ClientesController : Controller
    {
        private EFContext db = new EFContext();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,ClienteNome,DataNascimento,Sexo,Email,Ativo,Produto")] Cliente cliente)
        {
            string[] arquivo = System.IO.File.ReadAllLines("C:/Users/André Luiz/Downloads/ARQUIVO1.txt");

            //ArrayList listaTemporaria = new ArrayList();

            foreach (var linha in arquivo)
            {
                int indice = 0;

                List<String> palavras;
                palavras = linha.Split(';').ToList();

                for (int i = 0; i < 3; i++)
                {
                    if (indice == 0)
                    {
                        cliente.ClienteNome = palavras[0].Substring(2, 13).Replace(",", " ");
                        cliente.DataNascimento = palavras[0].Substring(16, 10);
                        cliente.Sexo = palavras[0].Substring(27, 9);
                        //cliente.Email = palavras[0].Substring(37, 20);
                        cliente.Ativo = true;
                        cliente.Produto = "Produto A";
                    }
                    if (indice == 1)
                    {
                        cliente.ClienteNome = palavras[1].Substring(2, 14).Replace(",", " ");
                        cliente.DataNascimento = palavras[1].Substring(17, 10);
                        cliente.Sexo = palavras[1].Substring(28, 8);
                        //cliente.Email = palavras[1].Substring(37, 20);
                        cliente.Ativo = true;
                        cliente.Produto = "Produto B";
                    }
                    if (indice == 2)
                    {
                        cliente.ClienteNome = palavras[2].Substring(2, 16).Replace(",", " ");
                        cliente.DataNascimento = palavras[2].Substring(19, 10);
                        cliente.Sexo = palavras[2].Substring(30, 10);
                        //cliente.Email = palavras[2].Substring(37, 20);
                        cliente.Ativo = true;
                        cliente.Produto = "Produto C";
                    }

                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    indice++;
                }
                
                
            }

            if (ModelState.IsValid)
            {
                //db.Clientes.Add(cliente);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,ClienteNome,DataNascimento,Sexo,Email,Ativo,Produto")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ArrayList Teste()
        {
            string[] arquivo = System.IO.File.ReadAllLines("ARQUIVO1.txt");

            ArrayList listaTemporaria = new ArrayList();

            foreach (var linha in arquivo)
            {
                List<String> palavras;
                palavras = linha.Split(';').ToList();
                listaTemporaria.Add(palavras);
            }

            return listaTemporaria;
        }
        
    }
}
