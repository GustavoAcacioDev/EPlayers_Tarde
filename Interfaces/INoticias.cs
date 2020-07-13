using System.Collections.Generic;
using Eplayers_Tarde.Models;

namespace Eplayers_Tarde.Interfaces
{
    public interface INoticias
    {
         void Create(Noticias n);
         List<Noticias> ReadAll();
         void Update(Noticias n);
         void Delete(int IdNoticia);
    }
}