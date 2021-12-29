using ClimaTempo.Context;
using ClimaTempo.Models;
using ClimaTempo.Models.ViewModel;
using Newtonsoft.Json;
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
            ViewBag.Cidade = db.Cidade.Select(c => new SelectListItem
            {
                Text = c.Nome,
                Value = c.Id.ToString()
            }).ToList();

            var model = GetDetails();

            return View(model);
        }

        [HttpGet]
        public ActionResult Send(int cidade)
        {
            JsonResult result = new JsonResult();

            var previsaoSeven = (from p in db.PrevisaoClima.ToList()
                                 where p.Cidade.Id == cidade 
                                       // && 
                                       //p.DataPrevisao == DateTime.Today
                                 select new ClimaViewModel()
                                 {
                                     PrevisaoVM = new PrevisaoClimaViewModel()
                                     {
                                         CidadeId = p.CidadeId,
                                         Id = p.Id,
                                         TemperaturaMaxima = p.TemperaturaMaxima,
                                         TemperaturaMinima = p.TemperaturaMinima,
                                         Clima = p.Clima,
                                         DataPrevisao = p.DataPrevisao,
                                     }
                                 }).ToList();

            result = this.Json(JsonConvert.SerializeObject(previsaoSeven), JsonRequestBehavior.AllowGet);

            return result;
        }

        public IEnumerable<ClimaViewModel> GetDetails()
        {
            return (from pc in db.PrevisaoClima
                    join c in db.Cidade on pc.CidadeId equals c.Id into table1
                    from c in table1.ToList()
                    join e in db.Estado on c.EstadoId equals e.Id into table2
                    from e in table2.ToList()
                    where pc.DataPrevisao == DateTime.Today
                    select new ClimaViewModel()
                    {
                        CidadeVM = new CidadeViewModel()
                        {
                            Id = c.Id,
                            Estado = c.Estado,
                            Nome = c.Nome,
                        },
                        EstadoVM = new EstadoViewModel()
                        {
                            Id = e.Id,
                            Nome = e.Nome,
                            UF = e.UF,
                        },
                        PrevisaoVM = new PrevisaoClimaViewModel()
                        {
                            Id = pc.Id,
                            Cidade = pc.Cidade,
                            CidadeId = pc.CidadeId,
                            TemperaturaMaxima = pc.TemperaturaMaxima,
                            TemperaturaMinima = pc.TemperaturaMinima,
                            Clima = pc.Clima,
                            DataPrevisao = pc.DataPrevisao,
                        }
                    }).ToList();

        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Informações da Candidata";

            return View();
        }

        public ActionResult Clima()
        {
            ViewBag.Message = "Previsão do Tempo";

            return View();
        }
    }
}