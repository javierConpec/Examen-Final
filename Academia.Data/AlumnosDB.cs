using Academia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Data
{
    public class AlumnosDB
    {
        public List<Alumnos> Listar()
        {
            var listado = new List<Alumnos>();

            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Alumnos", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Alumnos alumnos;
                            while (lector.Read())
                            {
                                // creamos el objeto alumno
                                alumnos = new Alumnos();
                                alumnos.ID = (int)lector["ID"];
                                alumnos.Codigo = lector["Codigo"].ToString();
                                alumnos.Apellidos= lector["Apellidos"].ToString();
                                alumnos.Nombres = lector["Nombres"].ToString();
                                alumnos.Direccion = lector["Direccion"].ToString();
                                alumnos.Email = lector["Email"].ToString();

                                // AGREGAR EL CLIENTE AL LISTADO
                                listado.Add(alumnos);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public int Insertar(Alumnos alumnos)
        {
            int filas = 0;
            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                var query = "INSERT INTO [dbo].[Alumnos] " +
                    "([Codigo],[Apellidos],[Nombres],[Direccion],[Email]" +
                    "VALUES(@Codigo,@Apellidos,@Nombres,@Direccion,@Email)";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Codigo", alumnos.Codigo);
                    comando.Parameters.AddWithValue("@Apellidos", alumnos.Apellidos);
                    comando.Parameters.AddWithValue("@Nombres", alumnos.Nombres);
                    comando.Parameters.AddWithValue("@Direccion", alumnos.Direccion);
                    comando.Parameters.AddWithValue("@Email", alumnos.Email);
                    filas = comando.ExecuteNonQuery();
                }
            }
            return filas;
        }
}
}
