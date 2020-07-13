using System;

namespace Eplayers_Tarde.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public int Equipe1 { get; set; }
        public int Equipe2 { get; set; }
        public DateTime Horario { get; set; }
    }
}