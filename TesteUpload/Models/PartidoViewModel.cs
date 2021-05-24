using System;
using Microsoft.AspNetCore.Http;

namespace TesteUpload.Models
{
    public class PartidoViewModel
    {
        public PartidoViewModel()
        {
            this.ID = new Guid();
        }

        public Guid ID { get; set; }

        public string Nome { get; set; }

        public IFormFile Logotipo { get; set; }

        public string  Logotipo2 { get; set; }

    }
}