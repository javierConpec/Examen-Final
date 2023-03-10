using Academia.Entidades;
using Academia.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academia.AppWin
{
    public partial class frmAlumnos : Form
    {
        Notas notas;
        public frmAlumnos(Notas notas)
        {
            InitializeComponent();
            this.notas = notas;
        }

        public frmAlumnos()
        {
        }

        void cargarDatos()
        {
            var listadoAlumnos = AlumnosBL.Listar();
            cboAlumno.DataSource = listadoAlumnos;
            cboAlumno.DisplayMember = "Aldo";
            cboAlumno.ValueMember = "ID";

            var listadoCursos = CursosBL.Listar();
            cboCurso.DataSource = listadoCursos;
            cboCurso.DisplayMember = "CCNA";
            cboCurso.ValueMember = "ID";
        }

        private void RegistrarDatos(object sender, EventArgs e)
        {
            asignarDatos();
            this.DialogResult = DialogResult.OK;
        }
        void asignarDatos()
        {
            this.notas.Eva1 =Convert.ToDouble(txtE1.Text);
            this.notas.Eva2 = Convert.ToDouble(txtE2.Text);
            this.notas.Parcial = Convert.ToDouble(txtParcial.Text);
            this.notas.Final = Convert.ToDouble(txtFinal.Text);
            this.notas.IdAlumno = int.Parse(cboAlumno.SelectedValue.ToString());
            this.notas.IdCurso = int.Parse(cboCurso.SelectedValue.ToString());
        }
    }
}
