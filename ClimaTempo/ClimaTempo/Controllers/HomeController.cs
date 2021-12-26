using ClimaTempo.Context;
using ClimaTempo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ClimaTempo.Controllers
{
    public class HomeController : Controller
    {
        private ClimaTempoContext db = new ClimaTempoContext();

        public ActionResult Index()
        {
            List<Cidade> cidades = db.Cidade.ToList();
            List<PrevisaoClima> previsoes = db.PrevisaoClima.ToList();
            List<Estado> estados = db.Estado.ToList();

            var query = (from p in previsoes                       
                        join c in cidades on p.CidadeId equals c.Id into table1
                        from c in table1.ToList()
                        where p.DataPrevisao == DateTime.Today
                        select new ViewModel
                        {
                            cidade = c,
                            previsao = p                       
                        }).Take(3);

            ViewBag.Cidade = new SelectList(db.Cidade, "Id", "Nome");

            return View(query);
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Informações da Candidata";

            return View();
        }

        public ActionResult Clima()
        {
            ViewBag.Message = "Previsão do Tempo";

            var query = from st in db.PrevisaoClima.ToList()
                        where st.Clima == "Quente"
                        select st;

            return View(query);
        }
    }
}