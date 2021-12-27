using ClimaTempo.Context;
using ClimaTempo.Models;
using ClimaTempo.Models.ViewModel;
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
            //List<Cidade> cidades = db.Cidade.ToList();
            //List<PrevisaoClima> previsoes = db.PrevisaoClima.ToList();
            //List<Estado> estados = db.Estado.ToList();

            ViewBag.Cidade = new SelectList(db.Cidade, "Id", "Nome");

            var model = GetDetails();

            //var query = from p in previsoes
            //            join c in cidades on p.CidadeId equals c.Id into table1
            //            from c in table1.ToList()
            //            where p.DataPrevisao == DateTime.Today
            //            select p;

            return View(model);
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

            var query = from st in db.PrevisaoClima.ToList()
                        where st.Clima == "Quente"
                        select st;

            return View(query);
        }
    }
}