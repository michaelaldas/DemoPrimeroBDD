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
            try
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
            catch (Exception E)
            {
                MessageBox.Show(E.Message.ToString());
            }

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

            if (MessageBox.Show("¿ESTAS SEGURO QUE DESEAS Eliminar?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var context = new SistemasEntities();
                    var libro2 = new Libros()
                    {
                        id = Convert.ToInt32(txtId.Text.ToString())

                    };
                    context.Libros.Attach(libro2);
                    context.Libros.Remove(libro2);
                    context.SaveChanges();
                    MessageBox.Show("PERSONA ELIMINADA CON EXITO", "ELIMINO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtId.Clear();
                    VerGrid();
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message.ToString());

                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ESTAS SEGURO QUE DESEAS ACTUALIZAR?", "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int autorID = Convert.ToInt32(txtBusca.Text.ToString());
                    using (SistemasEntities context=new SistemasEntities())
                    {
                        Libros oLibros = (from q in context.Libros where q.id == autorID select q).First();
                        oLibros.id = Convert.ToInt32(txtId.Text.ToString());
                        oLibros.autor = txtAutor.Text.ToString();
                        oLibros.titulo = txtTitulo.Text.ToString();
                        oLibros.precio = Convert.ToDecimal(txtPrecio.Text.ToString());
                        oLibros.editorial = txtEditorial.Text.ToString();
                        context.SaveChanges();
                        txtId.Clear();
                        txtAutor.Clear();
                        txtTitulo.Clear();
                        txtPrecio.Clear();
                        txtEditorial.Clear();
                        VerGrid();

                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show(e1.Message.ToString());

                }
            }
        }

        private void LibrosIU_Load(object sender, EventArgs e)
        {
            VerGrid();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int busqueda = Convert.ToInt32(txtBusca.Text.ToString());
                using (SistemasEntities BuscarID = new SistemasEntities())
                {
                    IQueryable<Libros> objBuscar = from q in BuscarID.Libros where q.id == busqueda select q;
                    List<Libros> lista = objBuscar.ToList();
                    var oID = lista[0];
                    txtId.Text = Convert.ToString(oID.id.ToString());
                    txtAutor.Text = oID.autor;
                    txtTitulo.Text = oID.titulo;
                    txtPrecio.Text = Convert.ToString(oID.precio.ToString());
                    txtEditorial.Text = oID.editorial;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message.ToString());
            }
          
            }
        }
    }
 

