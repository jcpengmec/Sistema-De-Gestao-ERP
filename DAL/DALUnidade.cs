using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALUnidade
    {
        private DALConexao conexao;
        public DALUnidade(DALConexao cx)
        {
            this.conexao = cx;
        }
        public void Incluir(ModeloUnidade modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into Unidades(unid_descricao) values(@descricao); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@descricao", modelo.UnidDescricao);
            conexao.Conectar();
            modelo.UnidId = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloUnidade modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update Unidades set unid_descricao = @descricao where unid_id = @id;";
            cmd.Parameters.AddWithValue("@descricao", modelo.UnidDescricao);
            cmd.Parameters.AddWithValue("@id", modelo.UnidId);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from Unidades where unid_id = @id;";            
            cmd.Parameters.AddWithValue("@id", id);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Unidades where unid_descricao like '%" +
                valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }
        public ModeloUnidade CarregaModeloUnidade(int codigo)
        {
            ModeloUnidade modelo = new ModeloUnidade();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from Unidade where unid_id = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.UnidId = Convert.ToInt32(registro["unid_id"]);
                modelo.UnidDescricao = Convert.ToString(registro["unid_descricao"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
