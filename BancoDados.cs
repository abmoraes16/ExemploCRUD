using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD
{
    public class BancoDados
    {
        SqlConnection connection;
        SqlCommand comandos;
        SqlDataReader reader = null;

        public bool Adicionar(Categoria cat)
        {
            bool rs = false;

            try{
                //instancia do SqlConnection
                connection = new SqlConnection();
                connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Papelaria;user id=sa;password=senai@123";
                connection.Open();

                comandos = new SqlCommand();

                comandos.Connection = connection;

                comandos.CommandType= CommandType.Text;
                comandos.CommandText = "insert into Categorias(titulo) values (@titulo)";

                comandos.Parameters.AddWithValue("@titulo",cat.Titulo);

                int r = comandos.ExecuteNonQuery();

                if (r>0)
                    rs = true;

                comandos.Parameters.Clear();
            
            } 
            catch(SqlException se){
                throw new Exception("Erro ao tentar cadastrar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                connection.Close();
            }

            return rs;
        }

        public bool Atualizar(Categoria cat)
        {
            bool rs = false;

            try{
                //instancia do SqlConnection
                connection = new SqlConnection();
                connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Papelaria;user id=sa;password=senai@123";
                connection.Open();
                
                comandos = new SqlCommand();

                comandos.Connection = connection;

                comandos.CommandType= CommandType.Text;
                comandos.CommandText = "update Categorias set titulo=@titulo where IdCategoria=@id";

                comandos.Parameters.AddWithValue("@titulo",cat.Titulo);
                comandos.Parameters.AddWithValue("@id",cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();

                if (r>0)
                    rs = true;

                comandos.Parameters.Clear();
            
            } 
            catch(SqlException se){
                throw new Exception("Erro ao tentar atualizar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                connection.Close();
            }

            return rs;
        }

        public bool Apagar(Categoria cat)
        {
            bool rs = false;

            try{
                //instancia do SqlConnection
                connection = new SqlConnection();
                connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Papelaria;user id=sa;password=senai@123";
                connection.Open();
                
                comandos = new SqlCommand();

                comandos.Connection = connection;

                comandos.CommandType= CommandType.Text;
                comandos.CommandText = "delete from Categorias where IdCategoria=@id";

                comandos.Parameters.AddWithValue("@id",cat.IdCategoria);

                int r = comandos.ExecuteNonQuery();

                if (r>0)
                    rs = true;

                comandos.Parameters.Clear();
            
            } 
            catch(SqlException se){
                throw new Exception("Erro ao tentar apagar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                connection.Close();
            }

            return rs;
        }

        public List<Categoria> ListarCategorias(int Id){
        
        List<Categoria> lista = new List<Categoria>();

        try{
            connection = new SqlConnection();
            connection.ConnectionString = @"Data source=.\SQLEXPRESS;Initial Catalog=Papelaria;user id=sa;password=senai@123";
            connection.Open();

            Console.WriteLine("teste");

            comandos = new SqlCommand();
            comandos.Connection = connection;

            comandos.CommandType = CommandType.Text;
            comandos.CommandText = "select * from Categorias where idCategoria=@id";
            comandos.Parameters.AddWithValue("@id",Id);
            Console.WriteLine("teste2");
            reader = null;
            reader = comandos.ExecuteReader();
            Console.WriteLine("reader");

            while(reader.Read()){
                //popular lista de tipo Categoria
                lista.Add(new Categoria{
                                  IdCategoria=reader.GetInt32(0),
                                  Titulo = reader.GetString(1)
                                  }
                                  );
                Console.WriteLine("lista");
            }

            comandos.Parameters.Clear();

            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar listar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                connection.Close();
            }
            
            return lista;
        
        }

        public List<Categoria> ListarCategorias(string Titulo){
        
        List<Categoria> lista = new List<Categoria>();

        try{
            connection = new SqlConnection();
            connection.ConnectionString = @"Data source=.\SQLEXPRESS;Initial Catalog=Papelaria;user id=sa;password=senai@123";
            connection.Open();

            comandos = new SqlCommand();
            comandos.Connection = connection;

            comandos.CommandType = CommandType.Text;
            comandos.CommandText = "select * from Categorias where Titulo=@titulo";
            comandos.Parameters.AddWithValue("@titulo",Titulo);

            reader = comandos.ExecuteReader();

            while(reader.Read()){
                //popular lista de tipo Categoria
                lista.Add(new Categoria{
                                  IdCategoria=reader.GetInt32(0),
                                  Titulo = reader.GetString(1)
                                  }
                                  );
            }

            comandos.Parameters.Clear();

            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar listar. "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }
            finally{
                connection.Close();
            }
            
            return lista;
        
        }

    }
}