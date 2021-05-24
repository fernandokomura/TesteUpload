using System;
using Microsoft.AspNetCore.Http;

namespace TesteUpload.Models
{
    public class Partido
    {
        public Partido()
        {
            ID = new Guid();
        }

        public Guid ID { get; set; }

        public string Nome { get;set; }

        public string Logotipo { get; set; }
    }
}