using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Eplayers_Tarde.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Eplayers_Tarde.Controllers
{
    public class NoticiaController : Controller
    {
       Noticias noticiasModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiasModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias noticia = new Noticias();
            noticia.IdNoticia = Int32.Parse( form["IdNoticia"] );
            noticia.Titulo = form["Titulo"];
            noticia.Texto = form["Texto"];
            noticia.Imagem = form["Imagem"];

            
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticia");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                noticia.Imagem   = file.FileName;
            }
            else
            {
                noticia.Imagem   = "padrao.png";
            }
            noticiasModel.Create(noticia);
            

            ViewBag.Noticias = noticiasModel.ReadAll();
            return LocalRedirect("~/Noticia");


        }
        
        [Route("[controller]/{id}")]
        public IActionResult Excluir(int id)
        {
            noticiasModel.Delete(id);
            ViewBag.Noticias = noticiasModel.ReadAll();
            return LocalRedirect("~/Noticia");
        }
    }
}
