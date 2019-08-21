using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Destinadas
{
    public partial class Destinadas : Form
    {

        public Destinadas()
        {
            InitializeComponent();
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtToken.Text = "";


        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {

            DateTime dataini;
            DateTime datafim;
            string last_id = "";
            dynamic json;
            int contador = 0;

            try
            {
                //Instanciando objeto para buscar os dados
                dataini = DateTime.Parse(txtDtInicial.Text);
                datafim = DateTime.Parse(txtDtFinal.Text);
                API busca = new API(txtToken.Text, txtLogin.Text, txtSenha.Text);

                var teste = busca.RetornaChaveXML(dataini, datafim, "NFE", last_id);  ///Método que busca as notas utilizando a API do nota segura
                string key, id;
                dynamic result = JsonConvert.DeserializeObject(teste);


                //Percorrendo as chaves dos xml's encontrado
                List<Xml> xmls = new List<Xml>();
                foreach (var invoices in result.data.invoices)
                {
                    contador += 1;

                    key = invoices.key;
                    id = invoices.id;
                    var retorno = busca.RetornaXml(key);
                    json = JsonConvert.DeserializeObject(retorno);

                    //Extraindo informações do xml com XmlDocument
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(json.data.xml.ToString());

                    //Verificando se a tag ide existe, para que possa extrar as informações
                    var n = xmlDoc.GetElementsByTagName("ide").OfType<XmlNode>();
                    if (n != null && n.Count() > 0)
                    {
                        XmlNodeList ideXml = xmlDoc.GetElementsByTagName("ide");

                        string serie = ideXml[0]["serie"].InnerText;
                        string numero = ideXml[0]["nNF"].InnerText;
                        string dtemissao = ideXml[0]["dhEmi"].InnerText;


                        //Verificando se a tag emit existe, para que possa extrar as informações
                        var n2 = xmlDoc.GetElementsByTagName("emit").OfType<XmlNode>();
                        if (n2 != null && n2.Count() > 0)
                        {
                            XmlNodeList ideXml2 = xmlDoc.GetElementsByTagName("emit");
                            string cnpj = ideXml2[0]["CNPJ"].InnerText;

                            xmls.Add(new Xml(key, serie, numero, dtemissao, cnpj));
                        }
                        else
                        {
                            xmls.Add(new Xml(key, serie, numero, dtemissao));
                        }
                    }
                    else {
                        xmls.Add(new Xml(key));
                    }

                }

                /// Verficação realizada para identificar se existe mais notas para serem busdas
                int total = result.data.total;
                int count = result.data.count;
                last_id = result.data.last_id;
                total -= count;

                while (total > 0)
                {
                    teste = busca.RetornaChaveXML(dataini, datafim, "NFE", last_id);
                    result = JsonConvert.DeserializeObject(teste);

                    foreach (var invoices in result.data.invoices)
                    {
                        contador += 1;
                        key = invoices.key;
                        id = invoices.id;

                        var retorno2 = busca.RetornaXml(key);
                        json = JsonConvert.DeserializeObject(retorno2);

                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(json.data.xml.ToString());

                        //Estraindo os dados da nota fiscal
                        var n = xmlDoc.GetElementsByTagName("ide").OfType<XmlNode>();
                        if (n != null && n.Count() > 0)
                        {
                            XmlNodeList ideXml = xmlDoc.GetElementsByTagName("ide");

                            string serie = ideXml[0]["serie"].InnerText;
                            string numero = ideXml[0]["nNF"].InnerText;
                            string dtemissao = ideXml[0]["dhEmi"].InnerText;

                            //Extraindo dados do emitente e adicionando na lista
                            var n2 = xmlDoc.GetElementsByTagName("emit").OfType<XmlNode>();
                            if (n2 != null && n2.Count() > 0 )
                            {
                                XmlNodeList ideXml2 = xmlDoc.GetElementsByTagName("emit");
                                string cnpj = ideXml2[0]["CNPJ"].InnerText;

                                xmls.Add(new Xml(key, serie, numero, dtemissao, cnpj));
                            }

                            
                        }
                        else
                        {
                            xmls.Add(new Xml(key));
                        }
                    }

                    last_id = result.data.last_id;
                    count = result.data.count;
                    total -= count;
                }
                this.dataGridView1.DataSource = xmls;

                ////DIFININDO TAMANHO DOS CAMPOS NA GRID
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.DataPropertyName == "Key")
                        column.Width = 300;
                    else if (column.DataPropertyName == "Serie")
                        column.Width = 50;

                    else if (column.DataPropertyName == "Numero")
                        column.Width = 60;

                    else if (column.DataPropertyName == "DtEmissao")
                        column.Width = 170;
                    else
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception erro) {
                MessageBox.Show(erro.Message);
            }

            lb.Text = "Total: " + contador.ToString();
        }

        public void salvarArquivo(string xml, string chave)
        {
            FileStream a = new FileStream(txtCaminho.Text + chave +".xml", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(a);
            sw.WriteLine(xml);
            sw.Flush();
            sw.Close();
            a.Close();
        }

        //SALVAR XML NAS PASTAS SELECIONADAS
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic json;
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {

                    object s = dataGridViewRow.Cells["key"].Value;
                    API busca = new API(txtToken.Text, txtLogin.Text, txtSenha.Text);

                    var retorno = busca.RetornaXml(s.ToString());
                    json = JsonConvert.DeserializeObject(retorno);

                    salvarArquivo(json.data.xml.ToString(), s.ToString());
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            
        }

        private void Destinadas_Load(object sender, EventArgs e)
        {

        }
    }

    //OBJETO XML
    class Xml
    {
        public string Key { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string DtEmissao { get; set; }
        public string CnpjEmitente { get; set; }

        public Xml(string key)
        {
            Key = key;
        }

        public Xml(string key, string serie, string numero, string dtEmissao) : this(key)
        {
            Serie = serie;
            Numero = numero;
            DtEmissao = dtEmissao;
        }

        public Xml(string key, string serie, string numero, string dtEmissao, string cnpjEmitente) : this(key, serie, numero, dtEmissao)
        {
            CnpjEmitente = cnpjEmitente;
        }

        public Xml(){ }
    }
}
