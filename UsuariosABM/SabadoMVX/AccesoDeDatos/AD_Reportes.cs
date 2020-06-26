using SabadoMVX.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SabadoMVX.AccesoDeDatos
{
    public class AD_Reportes
    {
        public static List<SexoItemVM> ObtenerCantidadPersonasPorSexo()
        {
            List<SexoItemVM> resultado = new List<SexoItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"select s.Nombre Sexo, COUNT(*) Cantidad
                                    from sexos s
                                    JOIN personas p ON p.IdSexo=s.Id
                                    AND Baja=0
                                    group by s.Nombre";
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
                        
                        aux.Nombre = dr["Sexo"].ToString();
                        
                        aux.Cantidad = int.Parse(dr["Cantidad"].ToString());
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

        public static List<PersonaItemVM> ObtenerReportePersonas()
        {
            List<PersonaItemVM> resultado = new List<PersonaItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();

            SqlConnection cn = new SqlConnection(cadenaConexion);

            try
            {
                SqlCommand cmd = new SqlCommand();

                string consulta = @"select p.Id,p.Nombre, p.Apellido, p.Edad, p.Telefono, s.Nombre Sexo
                                    from personas p
                                    INNER JOIN sexos s ON p.IdSexo=s.Id
                                    AND Baja=0";
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
                        PersonaItemVM aux = new PersonaItemVM();
                        aux.Id = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Apellido = dr["Apellido"].ToString();
                        aux.Telefono = dr["Telefono"].ToString();
                        aux.Edad = int.Parse(dr["Edad"].ToString());
                        aux.SexoNombre = dr["Sexo"].ToString();
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

    }
}