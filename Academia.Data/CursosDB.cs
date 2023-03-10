using Academia.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Data
{
    public class CursosDB

    {
        public List<Cursos> Listar()
        {
            var listado = new List<Cursos>();

            using (var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                using (var comando = new SqlCommand("SELECT * FROM Cursos", conexion))
                {
                    using (var lector = comando.ExecuteReader())
                    {
                        if (lector != null && lector.HasRows)
                        {
                            Cursos Cursos;
                            while (lector.Read())
                            {
                                // creamos el objeto cursos
                                Cursos = new Cursos();
                                Cursos.Id = (int)lector["ID"];
                                Cursos.Nombre = lector["Nombre"].ToString();


                                // agregamos los cursos
                                listado.Add(Cursos);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public int INSERTAR(Cursos cursos) 
        {
            int filas = 0;
            using(var conexion = new SqlConnection(UtilDB.CadenaConexion()))
            {
                conexion.Open();
                var query = "INSERT INTO Cursos(Id, Nombre)" +
                    "VALUES(@Id, @Nombre)";
                using (var comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", cursos.Id);
                    comando.Parameters.AddWithValue("@Nombre", cursos.Nombre);
                    filas= comando.ExecuteNonQuery();

                }    
            }
            return filas;
        }
    }
}
