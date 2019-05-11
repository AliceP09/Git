using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UsuarioController : Controller
    {
            // GET: Usuario
            public ActionResult Login()
            {
                return View();
            }
            public ActionResult Index()
            {
                return RedirectToAction("Index", "Home");
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(Usuario u)
            {
                if (ModelState.IsValid)
                {
                    using (var db = new Packed_Lunch_4Entities7()) // Nome do entity localizado no Usuario.Context
                    {
                    
                        //var login = from a in db.usuarios select a;
                        var v = db.Usuario.Where(a => a.login.Equals(u.login) && a.senha.Equals(u.senha)).FirstOrDefault();
                        if (v != null)
                        {
                            if (v.func.Equals("adm"))
                            {
                                Session["nomeUsuarioLogado"] = v.login.ToString();
                                Session["login"] = v.login.ToString();
                                return RedirectToAction("administrador", "Usuario");
                            }
                            if (v.func.Equals("func"))
                            {
                                Session["nomeUsuarioLogado"] = v.login.ToString();
                                return RedirectToAction("funcionario", "Usuario");
                            }
                        }
                    }

                }

                return View(u);
            }
            public ActionResult Administrador()
            {
                return View();
            }
            public ActionResult funcionario()
            {
                return View();
            }
        }
    }

