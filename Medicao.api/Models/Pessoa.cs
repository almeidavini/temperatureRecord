using System;
using System.Collections.Generic;

namespace SistemaMedicao.Models
{
    public class Pessoa 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public int setorId { get; set; } 
        public Setor Setor { get; set; }
    }
}