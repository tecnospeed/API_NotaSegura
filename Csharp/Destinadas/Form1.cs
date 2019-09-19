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
using System.Security;
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
            rdEmitidas.Checked = true;
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtToken.Text = "";
            

        }

        private void BtnConsulta_Click(object sender, EventArgs e)
        {

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




        private void Destinadas_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnConsulta_Click_1(object sender, EventArgs e)
        {
            DateTime dataini;
            DateTime datafim;
            string last_id = "";
            string transaction = "sent";
            dynamic json;
            int contador = 0;
            lbAguarde.Text = "Buscando informações, aguarde...";

            if (rdEmitidas.Checked)
                transaction = "sent";
            if (rdRecebidas.Checked)
                transaction = "received";
            if (rdOutras.Checked)
                transaction = "other";
            if (rdTodas.Checked)
                transaction = "all";


            try
            {
                //Instanciando objeto para buscar os dados
                dataini = DateTime.Parse(txtDtInicial.Text);
                datafim = DateTime.Parse(txtDtFinal.Text);
                API busca = new API(txtToken.Text, txtLogin.Text, txtSenha.Text);



                var retorno_notas = busca.RetornaChaveXML(dataini, datafim, "NFE", last_id, transaction);  ///Método que busca as notas utilizando a API do nota segura

                dynamic result = JsonConvert.DeserializeObject(retorno_notas);


                //Percorrendo as chaves dos xml's encontrado


                List<Nota> notas = new List<Nota>();
                foreach (var invoices in result.data.invoices)
                {
                    contador += 1;
                    notas.Add(new Nota(invoices.key, invoices.id, invoices.mod, invoices.serie, invoices.cnpj_emitter, invoices.number, invoices.date_emission, invoices.value));

                }

                /// Verficação realizada para identificar se existe mais notas para serem busdas
                int total = result.data.total;
                int count = result.data.count;
                last_id = result.data.last_id;
                total -= count;

                while (total > 0)
                {
                    retorno_notas = busca.RetornaChaveXML(dataini, datafim, "NFE", last_id, transaction);
                    result = JsonConvert.DeserializeObject(retorno_notas);

                    foreach (var invoices in result.data.invoices)
                    {
                        contador += 1;
                        notas.Add(new Nota(invoices.key, invoices.id, invoices.mod, invoices.serie, invoices.cnpj_emitter, invoices.number, invoices.date_emission, invoices.value));

                    }

                    last_id = result.data.last_id;
                    count = result.data.count;
                    total -= count;
                }
                this.dataGridView1.DataSource = notas;

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
                lbAguarde.Text = "";
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                lbAguarde.Text = "";
            }

            lb.Text = "Total: " + contador.ToString();

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            API busca = new API(txtToken.Text, txtLogin.Text, txtSenha.Text);
            try
            {
                txtRetornoXml.Text = busca.EnviaXml(txtArquivoXml.Text);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            


        }

        private void BtnEscolher_Click(object sender, EventArgs e)
        {

            this.dialogArquivo.Multiselect = true;
            this.dialogArquivo.Title = "Selecionar arquivo xml";
            dialogArquivo.InitialDirectory = @"C:\Users\desktop";

            dialogArquivo.Filter = "XML Files (*.xml)|*.xml";
            dialogArquivo.CheckFileExists = true;
            dialogArquivo.CheckPathExists = true;
            dialogArquivo.FilterIndex = 2;
            dialogArquivo.RestoreDirectory = true;
            dialogArquivo.ReadOnlyChecked = true;
            dialogArquivo.ShowReadOnly = true;

            DialogResult dr = this.dialogArquivo.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String arquivo in dialogArquivo.FileNames)
                {
                    try
                    {
                        XmlDocument xmlLoad = new XmlDocument();
                        xmlLoad.Load(arquivo);

                        txtArquivoXml.Text =  xmlLoad.OuterXml;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não é possível carregar o xml:  " + ex.Message);
                    }
                }
            }



        }
        //SALVAR XML NAS PASTAS SELECIONADAS
        private void Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                lbExportacaoXML.Text = "Arquivos sendo exportados, aguarde...";
                dynamic json;
                foreach (DataGridViewRow dataGridViewRow in dataGridView1.Rows)
                {

                    object s = dataGridViewRow.Cells["key"].Value;
                    API busca = new API(txtToken.Text, txtLogin.Text, txtSenha.Text);

                    var retorno = busca.RetornaXml(s.ToString());
                    json = JsonConvert.DeserializeObject(retorno);

                    salvarArquivo(json.data.xml.ToString(), s.ToString());
                }
                lbExportacaoXML.Text = "";

                MessageBox.Show("Dados exportados com sucesso!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                lbExportacaoXML.Text = "";
            }
        }
    }



    //**********************************************************************************************************************
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
