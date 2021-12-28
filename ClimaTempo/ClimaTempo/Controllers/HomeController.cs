using ClimaTempo.Context;
using ClimaTempo.Models;
using ClimaTempo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            var cidades = db.Cidade.Select(c => new
            {
                Id = c.Id,
                Nome = c.Nome
            }).ToList();

            ViewBag.Cidades = new SelectList(cidades, "Id", "Nome");

            var model = GetDetails();

            return View(model);
        }

        [HttpPost]
        public void Upload (HttpPostedFileBase file, string txtname, CidadeViewModel cddAS)
        {
            try
            {
                string attachmentFilePath = file.FileName;
                string fileName = attachmentFilePath.Substring(attachmentFilePath.LastIndexOf("\\") + 1);

            }
            catch (Exception ex)
            {}
        }

        [HttpPost]
        public ActionResult Send(string cidade)
        {
            var con = DateTime.Now.ToString() + "-" + cidade;
            return View(con);
        }

        [HttpPost]
        public ActionResult Index(Cidade um)
        {
            return View(um);
        }

        public PartialViewResult GetCidadePrevisao(int CidadeId)
        {
            var previsaoClima = (from pc in db.PrevisaoClima
                                 where pc.CidadeId == CidadeId
                                 select pc);

            return PartialView("_EmpTestPartial", previsaoClima);
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