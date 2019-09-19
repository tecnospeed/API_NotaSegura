using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destinadas
{
    class Nota
    {
        public string Key { get; set; }
        public string Id { get; set; }
        public string Mod { get; set; }
        public string Serie { get; set; }
        public string Cnpj_emitter { get; set; }
        public string Number { get; set; }
        public string Date_emission { get; set; }
        public double Valor_total  { get; set; }

        public Nota(dynamic key, dynamic id, dynamic mod, dynamic serie, dynamic cnpj_emitter, dynamic number, dynamic date_emission, dynamic valor_total)
        {
            Key = key;
            Id = id;
            Mod = mod;
            Serie = serie;
            Cnpj_emitter = cnpj_emitter;
            Number = number;
            Date_emission = date_emission;
            Valor_total = valor_total;
        }

        public Nota()
        {
        }
    }
}
