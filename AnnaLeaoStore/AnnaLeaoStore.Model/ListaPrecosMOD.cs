﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaLeaoStore.Model
{
    public class ListaPrecosMOD
    {
        public Int32 ID { get; set; }
        public string Descricao { get; set; }
        public DateTime Validade { get; set; }
    }
}