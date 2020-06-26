using SegundoParcialSaurit.Models;
using SegundoParcialSaurit.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace SegundoParcialSaurit.AccesoDeDatos
{
    public class AD_Socios
    {
        public static bool InsertarNuevoSocio(Socio s)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"INSERT INTO socios 
                                   VALUES(@nombre, @apellido, @idTipoDocumento, @nroDocumeto, @idDeporte)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", s.Nombre);
                cmd.Parameters.AddWithValue("@apellido", s.Apellido);
                cmd.Parameters.AddWithValue("@idTipoDocumento", s.IdTipoDocumento);
                cmd.Parameters.AddWithValue("@nroDocumeto", s.NroDocumento);
                cmd.Parameters.AddWithValue("@idDeporte", s.IdDeporte);
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

        public static List<SocioItemVM> ObtenerListaSocios()
        {
            List<SocioItemVM> resultado = new List<SocioItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"SELECT s.Nombre, s.Apellido, s.NroDocumento, d.Nombre Deporte FROM socios s INNER JOIN deportes d ON s.IdDeporte=d.Id";
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
                        SocioItemVM aux = new SocioItemVM();
                        
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Apellido = dr["Apellido"].ToString();
                        
                        aux.NroDocumento = dr["NroDocumento"].ToString();
                        aux.DeporteNombre = dr["Deporte"].ToString();
                        ;
                        resultado.Add(aux);
                    }
                }

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

        public static List<TipoDocItemVM> ObtenerListaTipoDocumentos()
        {
            List<TipoDocItemVM> resultado = new List<TipoDocItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM TiposDocumentos";
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
                        TipoDocItemVM aux = new TipoDocItemVM();
                        aux.IdDocumento = int.Parse(dr["Id"].ToString());
                        aux.NombreTipoDocumento = dr["Nombre"].ToString();


                        resultado.Add(aux);
                    }
                }

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

        public static List<DeporteItemVM> ObtenerListaDeportes()
        {
            List<DeporteItemVM> resultado = new List<DeporteItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM Deportes";
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
                        DeporteItemVM aux = new DeporteItemVM();
                        aux.IdDeporte = int.Parse(dr["Id"].ToString());
                        aux.NombreDeporte = dr["Nombre"].ToString();


                        resultado.Add(aux);
                    }
                }

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

        public static List<DeporteItemVM> ObtenerReporte()
        {
            List<DeporteItemVM> resultado = new List<DeporteItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"SELECT s.IdDeporte ,d.Nombre, count(*) Cantidad  FROM socios s INNER JOIN deportes d ON s.IdDeporte=d.Id
                                    group by s.IdDeporte, d.Nombre";
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
                        DeporteItemVM aux = new DeporteItemVM();

                        aux.IdDeporte = int.Parse(dr["IdDeporte"].ToString());
                        aux.NombreDeporte = dr["Nombre"].ToString();

                        aux.Cantidad = int.Parse( dr["Cantidad"].ToString());
                        
                        ;
                        resultado.Add(aux);
                    }
                }

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
    }
}