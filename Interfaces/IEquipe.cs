using System.Collections.Generic;
using Eplayers_Tarde.Models;

namespace Eplayers_Tarde.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);
         List<Equipe> ReadAll();
         void Update(Equipe e);
         void Delete(int IdEquipe);
    }
}