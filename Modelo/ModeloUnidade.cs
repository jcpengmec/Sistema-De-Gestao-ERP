using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloUnidade
    {
        private int unid_Id;
        public int UnidId
        {
            get { return this.unid_Id; }
            set { this.unid_Id = value; }
        }
        private String unid_Descricao;
        public String UnidDescricao
        {
            get { return this.unid_Descricao; }
            set { this.unid_Descricao = value; }
        }
        
    }
}
