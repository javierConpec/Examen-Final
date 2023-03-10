using Academia.Entidades;
using Academia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Academia.Negocio
{
    public static class NotasBL
    {
        public static List<Notas>Listar()
        { 
            var listado = new List<Notas>();
            return listado;
        }

     /*   public  static bool Insertar(Notas notas)
        {
            var exito = false;
            using(var notas = new TransactionScope)
            return exito;
        }*/
    }
}
