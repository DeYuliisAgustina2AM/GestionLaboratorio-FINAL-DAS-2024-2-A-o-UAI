﻿using Entidades;
using Controladora;
using static Entidades.Computadora;
using static Entidades.Ticket;

namespace VISTA
{
    public partial class formTicketAM : Form
    {
        private Ticket ticket; // variable de tipo Ticket para almacenar el ticket que se va a modificar
        private bool modificar = false;

        public formTicketAM()
        {
            InitializeComponent();
            ticket = new Ticket();
            Actualizarcb();
        }

        public formTicketAM(Ticket ticketModificar)
        {
            InitializeComponent();
            ticket = ticketModificar;
            modificar = true;
            Actualizarcb();
        }

        public void Actualizarcb()
        {
            foreach (Computadora computadora in ControladoraComputadora.Instancia.RecuperarComputadoras()) //se recorren las computadoras y se agregan al cmb
            {
                cbCodigoPc.Items.Add(computadora.CodigoComputadora.ToString());
            }
            foreach (Tipo tipo in Enum.GetValues(typeof(Tipo))) //se recorren los valores del enum de Categoria y se agregan al combobox de categorias
            {
                cbTipoTicket.Items.Add(tipo.ToString());
            }
            foreach (Categoria categoria in Enum.GetValues(typeof(Categoria))) //se recorren los valores del enum de Categoria y se agregan al combobox de categorias
            {
                cbCategoria.Items.Add(categoria.ToString());
            }
            foreach (Estado estado in Enum.GetValues(typeof(Estado))) //se recorren los valores del enum de Urgencia y se agregan al combobox de urgencia
            {
                cbEstado.Items.Add(estado.ToString());
            }
            foreach (Urgencia urgencia in Enum.GetValues(typeof(Urgencia))) //se recorren los valores del enum de Urgencia y se agregan al combobox de urgencia
            {
                cbUrgencia.Items.Add(urgencia.ToString());
            }
            foreach (Tecnico tecnico in ControladoraTecnico.Instancia.RecuperarTecnicos()) //se recorren los laboratorios y se agregan al cmb
            {
                cbTecnico.Items.Add(tecnico.NombreyApellido.ToString());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void formTicketAM_Load(object sender, EventArgs e)
        {
            if (modificar)
            {
                lblAgregaroModificar.Text = "Modificar Computadora";

                dtpFechaInicio.Value = ticket.FechaCreacion;
                txtDescripcion.Text = ticket.DescripcionTicket;

                cbCodigoPc.SelectedValue = ticket.Computadora;
                cbTipoTicket.SelectedValue = ticket.tipo.ToString();
                cbCategoria.SelectedValue = ticket.categoria.ToString();
                cbEstado.SelectedValue = ticket.estado.ToString();
                cbUrgencia.SelectedValue = ticket.urgencia.ToString();
                cbTecnico.SelectedValue = ticket.Tecnico.NombreyApellido;
            }
            else lblAgregaroModificar.Text = "Agregar Ticket";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                if (modificar)
                {
                    string CodigoComputadora = cbCodigoPc.Text;
                    ticket.Computadora = ControladoraComputadora.Instancia.RecuperarComputadoras().FirstOrDefault(x => x.CodigoComputadora == CodigoComputadora);
                    ticket.Ubicacion = ticket.Computadora.Laboratorio.NombreLaboratorio;

                    string tipo = cbTipoTicket.Text;
                    ticket.tipo = (Tipo)Enum.Parse(typeof(Tipo), tipo);

                    string categoria = cbCategoria.Text;
                    ticket.categoria = (Categoria)Enum.Parse(typeof(Categoria), categoria);

                    string estado = cbEstado.Text;
                    ticket.estado = (Estado)Enum.Parse(typeof(Estado), estado);

                    string urgencia = cbUrgencia.Text;
                    ticket.urgencia = (Urgencia)Enum.Parse(typeof(Urgencia), urgencia);

                    string tecnico = cbTecnico.Text;
                    ticket.Tecnico = ControladoraTecnico.Instancia.RecuperarTecnicos().FirstOrDefault(x => x.NombreyApellido == tecnico);

                    ticket.FechaCreacion = Convert.ToDateTime(dtpFechaInicio.Value);
                    ticket.DescripcionTicket = txtDescripcion.Text;


                    var mensaje = ControladoraTicket.Instancia.ModificarTicket(ticket);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string CodigoComputadora = cbCodigoPc.Text;
                    ticket.Computadora = ControladoraComputadora.Instancia.RecuperarComputadoras().FirstOrDefault(x => x.CodigoComputadora == CodigoComputadora);
                    ticket.Ubicacion = ticket.Computadora.Laboratorio.NombreLaboratorio;
                   
                    string tipo = cbTipoTicket.Text;
                    ticket.tipo = (Tipo)Enum.Parse(typeof(Tipo), tipo);

                    string categoria = cbCategoria.Text;
                    ticket.categoria = (Categoria)Enum.Parse(typeof(Categoria), categoria);

                    string estado = cbEstado.Text;
                    ticket.estado = (Estado)Enum.Parse(typeof(Estado), estado);

                    string urgencia = cbUrgencia.Text;
                    ticket.urgencia = (Urgencia)Enum.Parse(typeof(Urgencia), urgencia);

                    string tecnico = cbTecnico.Text;
                    ticket.Tecnico = ControladoraTecnico.Instancia.RecuperarTecnicos().FirstOrDefault(x => x.NombreyApellido == tecnico);

                    ticket.FechaCreacion = Convert.ToDateTime(dtpFechaInicio.Value);
                    ticket.DescripcionTicket = txtDescripcion.Text;

                    var mensaje = ControladoraTicket.Instancia.AgregarTicket(ticket);
                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (cbCodigoPc.SelectedItem == null)
            {
                MessageBox.Show("El campo Código de Computadora no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("El campo Descripción no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           if (cbTipoTicket.SelectedItem == null)
            {
                MessageBox.Show("El campo Tipo Ticket no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbCategoria.SelectedItem == null)
            {
                MessageBox.Show("El campo Categoría no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbEstado.SelectedItem == null)
            {
                MessageBox.Show("El campo Estado no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbUrgencia.SelectedItem == null)
            {
                MessageBox.Show("El campo Urgencia no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbTecnico.SelectedItem == null)
            {
                MessageBox.Show("El campo Tecnico no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
