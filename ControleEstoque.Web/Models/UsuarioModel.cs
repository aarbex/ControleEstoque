using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            var ret = false;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=SP6048;Initial Catalog=ControleEstoque;Integrated Security=SSPI;";
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = string.Format(
                        "SELECT count(*) FROM Usuario WHERE login = '{0}' and senha = '{1}'", login, senha);
                    ret = ((int)cmd.ExecuteScalar() > 0);
                }

            }
            return ret;
        }
    }
}