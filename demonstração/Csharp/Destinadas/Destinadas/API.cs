using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destinadas
{
    class API
    {
        public String Token { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        private String Auth { get; set; }


        public API(string token, string login, string senha)
        {
            Token = token;
            Login = login;
            Senha = senha;

            Auth = Convert.ToBase64String(Encoding.Default.GetBytes(Login + ":" + Senha));
        }

        public string RetornaChaveXML(DateTime data_ini, DateTime data_fim, string mod, string last_id )
        {
            string url;
            IRestResponse retorno;
            

            url = "https://app.notasegura.com.br/api/invoices/keys?token="+ Token +"&date_ini="+ data_ini.ToString("yyyy-MM-dd") + "&date_end="+ data_fim.ToString("yyyy-MM-dd") + "&mod="+ mod +"&transaction=received&limit=30&last_id="+last_id;
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "482c5917-475e-4c5c-8ead-af39a739bdb3");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", "Basic " + Auth);

            retorno = client.Execute(request);
            
            return retorno.Content;
        }

        public string RetornaXml(string key)
        {
            string url;
            IRestResponse retorno;

            url = "https://app.notasegura.com.br/api/invoices/export?token=" + Token + "&invoice_key=" + key + "&mode=XML";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Postman-Token", "482c5917-475e-4c5c-8ead-af39a739bdb3");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Authorization", "Basic " + Auth);

            retorno = client.Execute(request);

            return retorno.Content;
        }

        

        
    }
}