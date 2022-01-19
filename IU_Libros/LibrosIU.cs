using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IU_Libros
{
    public partial class LibrosIU : Form
    {
        public LibrosIU()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
                var context = new SistemasEntities();
                var libro = new Libros()
                {
                    id = Convert.ToInt32(txtId.Text.ToString()),
                    autor = txtAutor.Text.ToString(),
                    titulo = txtTitulo.Text.ToString(),
                    precio = Convert.ToDecimal(txtPrecio.Text.ToString()),
                    editorial = txtEditorial.Text.ToString()
                };
                context.Libros.Add(libro);
                context.SaveChanges();
                MessageBox.Show("Se agrego con exito...");
                txtId.Clear();
                txtAutor.Clear();
                txtTitulo.Clear();
                txtPrecio.Clear();
                txtEditorial.Clear();
                VerGrid();
        }
        public void VerGrid()
        {
            using(SistemasEntities ObjGrid=new SistemasEntities())
            {
                IQueryable<Libros> qlibros = from q in ObjGrid.Libros select q;
                List<Libros> lista = qlibros.ToList();
                dataGridLibros.DataSource = lista;
                
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("DESEAS Eliminar...?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    var context = new SistemasEntities();
                    var libro2 = new Libros()
                    {
                        id = Convert.ToInt32(txtId.Text.ToString())

                    };
                    context.Libros.Attach(libro2);
                    context.Libros.Remove(libro2);
                    context.SaveChanges();
                    MessageBox.Show("Libro eliminado...", "ELIMINO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtId.Clear();
                    txtAutor.Clear();
                    txtTitulo.Clear();
                    txtPrecio.Clear();
                    txtEditorial.Clear();
                    VerGrid();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("DESEAS ACTUALIZAR...?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    int autorID = Convert.ToInt32(txtBusca.Text.ToString());
                    using (SistemasEntities IDcontext=new SistemasEntities())
                    {
                        Libros oLibros = (from q in IDcontext.Libros where q.id == autorID select q).First();
                        oLibros.id = Convert.ToInt32(txtId.Text.ToString());
                        oLibros.autor = txtAutor.Text.ToString();
                        oLibros.titulo = txtTitulo.Text.ToString();
                        oLibros.precio = Convert.ToDecimal(txtPrecio.Text.ToString());
                        oLibros.editorial = txtEditorial.Text.ToString();
                        IDcontext.SaveChanges();
                        MessageBox.Show("Libro actualizado.....");
                        txtId.Clear();
                        txtAutor.Clear();
                        txtTitulo.Clear();
                        txtPrecio.Clear();
                        txtEditorial.Clear();
                        VerGrid();

                    }
            }
        }

        private void LibrosIU_Load(object sender, EventArgs e)
        {
            VerGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
                int busqueda = Convert.ToInt32(txtBusca.Text.ToString());
                using (SistemasEntities Busqueda = new SistemasEntities())
                {
                    IQueryable<Libros> objBuscar = from q in Busqueda.Libros where q.id == busqueda select q;
                    List<Libros> lista = objBuscar.ToList();
                    var oID = lista[0];
                    txtId.Text = Convert.ToString(oID.id.ToString());
                    txtAutor.Text = oID.autor;
                    txtTitulo.Text = oID.titulo;
                    txtPrecio.Text = Convert.ToString(oID.precio.ToString());
                    txtEditorial.Text = oID.editorial;
                }
          
            }
        }
    }
 

