using SabadoMVX.Models;
using SabadoMVX.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SabadoMVX.AccesoDeDatos
{
    public class AD_Personas
    {
        public static bool InsertarNuevaPersona(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"INSERT INTO personas 
                                   VALUES(@nombre, @apellido, @edad, @telefono, @idSexo, 0)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@apellido", p.Apellido);
                cmd.Parameters.AddWithValue("@edad", p.Edad);
                cmd.Parameters.AddWithValue("@telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@idSexo", p.IdSexo);
                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }


        public static List<Persona> ObtenerListaPersonas()
        {
            List<Persona> resultado = new List<Persona>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM personas WHERE Baja = 0";
                cmd.Parameters.Clear();
                

                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Persona aux = new Persona();
                        aux.Id = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Apellido = dr["Apellido"].ToString();
                        aux.Telefono = dr["Telefono"].ToString();
                        aux.Edad = int.Parse(dr["Edad"].ToString());
                       // aux.IdSexo = int.Parse(dr["IdSexo"].ToString());
                        resultado.Add(aux);
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static List<Persona> ObtenerListaPersonasInactivas()
        {
            List<Persona> resultado = new List<Persona>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM personas WHERE Baja = 1";
                cmd.Parameters.Clear();


                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Persona aux = new Persona();
                        aux.Id = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Apellido = dr["Apellido"].ToString();
                        aux.Telefono = dr["Telefono"].ToString();
                        aux.Edad = int.Parse(dr["Edad"].ToString());
                        // aux.IdSexo = int.Parse(dr["IdSexo"].ToString());
                        resultado.Add(aux);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }


        public static List<SexoItemVM> ObtenerListaSexos()
        {
            List<SexoItemVM> resultado = new List<SexoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM sexos";
                cmd.Parameters.Clear();


                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        SexoItemVM aux = new SexoItemVM();
                        aux.IdSexo = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        

                        resultado.Add(aux);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static Persona ObtenerPersona(int idPersona)
        {
           Persona resultado = new Persona();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM personas WHERE Id = @id AND Baja=0";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idPersona);

                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        
                        resultado.Id = int.Parse(dr["Id"].ToString());
                        resultado.Nombre = dr["Nombre"].ToString();
                        resultado.Apellido = dr["Apellido"].ToString();
                        resultado.Telefono = dr["Telefono"].ToString();
                        resultado.Edad = int.Parse(dr["Edad"].ToString());
                        resultado.IdSexo = int.Parse(dr["IdSexo"].ToString());

                        
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static Persona ObtenerPersonaInactiva(int idPersona)
        {
            Persona resultado = new Persona();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM personas WHERE Id = @id AND Baja=1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idPersona);

                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {

                        resultado.Id = int.Parse(dr["Id"].ToString());
                        resultado.Nombre = dr["Nombre"].ToString();
                        resultado.Apellido = dr["Apellido"].ToString();
                        resultado.Telefono = dr["Telefono"].ToString();
                        resultado.Edad = int.Parse(dr["Edad"].ToString());
                        resultado.IdSexo = int.Parse(dr["IdSexo"].ToString());


                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static bool ActualizarDatosPersona(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE personas SET Nombre =@nombre, Apellido = @apellido, Edad = @edad, Telefono = @telefono, IdSexo = @idSexo, Baja=0 WHERE Id= @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", p.Id);

                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@apellido", p.Apellido);
                cmd.Parameters.AddWithValue("@edad", p.Edad);
                cmd.Parameters.AddWithValue("@telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@idSexo", p.IdSexo);
                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static bool ActualizarDatosPersonaInactiva(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE personas SET Nombre =@nombre, Apellido = @apellido, Edad = @edad, Telefono = @telefono, IdSexo = @idSexo, Baja=1 WHERE Id= @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", p.Id);

                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@apellido", p.Apellido);
                cmd.Parameters.AddWithValue("@edad", p.Edad);
                cmd.Parameters.AddWithValue("@telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@idSexo", p.IdSexo);
                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static bool AltaPersonaInactiva(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE personas SET Nombre =@nombre, Apellido = @apellido, Edad = @edad, Telefono = @telefono, IdSexo = @idSexo, Baja=0 WHERE Id= @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", p.Id);

                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@apellido", p.Apellido);
                cmd.Parameters.AddWithValue("@edad", p.Edad);
                cmd.Parameters.AddWithValue("@telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@idSexo", p.IdSexo);
                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static bool EliminarPersona(Persona p)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "UPDATE personas set Baja = 1 WHERE Id = @id";
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", p.Id);

               
                //ejecutara una consulta sql y le diremos cual va a ser el texto de la consulta
                cmd.CommandType = System.Data.CommandType.Text; // si fuera un procedimiento almacenado seria .storeProcedure
                // ahora le asigno el texto
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

    }
}