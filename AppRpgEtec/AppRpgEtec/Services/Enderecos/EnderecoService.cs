using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;

namespace AppRpgEtec.Services.Enderecos
{
    public class EnderecoService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "https://nominatim.openstreetmap.org/search";

        private string _token;
        public EnderecoService(string token)
        {
            _request = new Request();
        }

        public async Task<Endereco> GetEnderecoByCep(string name)
        {
            string urlComplementar = string.Format("/{0}", name);
            Console.WriteLine(apiUrlBase + urlComplementar);
            var endereco = await _request.GetAsync<Models.Endereco>(apiUrlBase + urlComplementar, _token);
            return endereco;
        }
    }
}
