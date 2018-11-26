using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region Atributos
        private Correo correo;
        #endregion
        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia del formulario. Establece evento para el funcionamiento e instancia atributo
        /// correo.
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            this.FormClosing += new FormClosingEventHandler(this.FrmPpal_FormClosing);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Detecta cuando el formulario se va a cerrar y antes de ello cierra los hilos generados por los paquetes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
        /// <summary>
        /// Limpia los listBox del formulario y carga los paquetes nuevamente donde correspondan.
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();
            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }
        /// <summary>
        /// Agrega un paquete a la lista del formulario y actualiza los estados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            try
            {
                correo += paquete;
            }
            catch (Exception excepcion)
            {
                MessageBox.Show(excepcion.Message,"Paquete repetido",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
            this.ActualizarEstados();
        }
        /// <summary>
        /// Muestra los paquetes en el cuadro inferior izquierdo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
        /// <summary>
        /// Carga los datos de un objeto recibido al cuadro inferior izquierdo y guarda un archivo txt con información
        /// en el escritorio.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento )
        {
            if ( !object.Equals(elemento , null))
            {
                string datos = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text = datos;
                datos.Guardar("salida.txt");
            }
        }
        /// <summary>
        /// Actualiza estados al hacer click en opción mostrar del lstEntregados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        /// <summary>
        /// Verifica los subprocesos y actualiza los estados de los cuadros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
        #endregion
    }
}
