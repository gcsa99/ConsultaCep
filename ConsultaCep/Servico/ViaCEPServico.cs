﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsultaCep.Servico.Modelo;
using Newtonsoft.Json;

namespace ConsultaCep.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";
        public static Endereco BuscaEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;
            return end;
        }
    }
}
