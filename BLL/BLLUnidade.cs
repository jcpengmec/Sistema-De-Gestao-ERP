using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class BLLUnidade
    {
        private DALConexao conexao;
        public BLLUnidade(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloUnidade modelo)
        {
            if(modelo.UnidDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição da unidade é obrigatório");
            }
            modelo.UnidDescricao = modelo.UnidDescricao.ToUpper();
            DALUnidade DALobj = new DALUnidade(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloUnidade modelo)
        {
            if(modelo.UnidId <= 0)
            {
                throw new Exception("O código da unidade é obrigatório");
            }
            if (modelo.UnidDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição da unidade é obrigatório");
            }
            modelo.UnidDescricao = modelo.UnidDescricao.ToUpper();
            DALUnidade DALobj = new DALUnidade(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int id)
        {
            DALUnidade DALobj = new DALUnidade(conexao);
            DALobj.Excluir(id);
        }
        public DataTable Localizar(String valor)
        {
            DALUnidade DALobj = new DALUnidade(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloUnidade CarregaModeloUnidade(int codigo)
        {
            DALUnidade DALobj = new DALUnidade(conexao);
            return DALobj.CarregaModeloUnidade(codigo);
        }
    }
}
