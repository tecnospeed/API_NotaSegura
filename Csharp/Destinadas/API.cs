using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Destinadas
{
    class API
    {
        public String Token { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        private String Auth { get; set; }
        private String Url_raiz { get; set; }

        public API(string token, string login, string senha)
        {
            Token = token;
            Login = login;
            Senha = senha;

            Auth = Convert.ToBase64String(Encoding.Default.GetBytes(Login + ":" + Senha));
            Url_raiz = "https://app.notasegura.com.br/api/invoices";
        }

        public string RetornaChaveXML(DateTime data_ini, DateTime data_fim, string mod, string last_id, string transaction, string downloaded)
        {
            string url;
            IRestResponse retorno;
            

            url = Url_raiz + "/keys?token="+ Token +"&date_ini="+ data_ini.ToString("yyyy-MM-dd") + "&date_end="+ data_fim.ToString("yyyy-MM-dd") + "&mod="+ mod +"&transaction="+ transaction +"&limit=30&last_id="+last_id + "&filter="+downloaded;
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Basic " + Auth);

            retorno = client.Execute(request);
            
            return retorno.Content;
        }

        public string RetornaXml(string key, Boolean downloaded)
        {
            string url;
            IRestResponse retorno;

            url = Url_raiz + "/export?token=" + Token + "&invoice_key=" + key + "&mode=XML";
            if (downloaded) url += "&downloaded=true";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "Basic " + Auth);

            retorno = client.Execute(request);

            return retorno.Content;
        }

        
        public string EnviaXml(string xml)
        {
            IRestResponse retorno;

            var xmlUrl = System.Web.HttpUtility.UrlEncode(xml);

            var client = new RestClient(Url_raiz + "?token=" + Token);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Basic " + Auth);
            request.AddParameter("undefined", "xml="+ xmlUrl, ParameterType.RequestBody);;

            retorno = client.Execute(request);

            return retorno.Content;
        }
        
        

        
    }
}