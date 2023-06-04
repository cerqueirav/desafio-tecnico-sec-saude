using Newtonsoft.Json;
using System.Net;
using System;
using DesafioTecnicoSecSaude.Utils.Viacep.Model;

namespace DesafioTecnicoSecSaude.Utils.Viacep.Service
{
    public class ViaCepService
    {
        public ViaCepModel GetEnderecoByCep(string cep)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var json = client.DownloadString($"https://viacep.com.br/ws/{cep}/json/");
                    return JsonConvert.DeserializeObject<ViaCepModel>(json);
                }
                catch (WebException)
                {
                    return null;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
