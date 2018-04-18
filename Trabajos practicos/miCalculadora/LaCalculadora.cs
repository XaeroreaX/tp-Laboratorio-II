using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {

        private Numero _N1, _N2, _resultado;

        private bool isBinario;
        

        public LaCalculadora()
        {
            
            this._N1 = new Numero(0);
            this._N2 = new Numero(0);
            this._resultado = new Numero(0);

            this.lblResultado = new Label();

            this.showResultado("0");

            

            InitializeComponent();
        }

        private void showResultado(string resultado)
        {
            /*string tabulaciones = "";
                
            string  mostrar = "";
            while (mostrar.Length != 115)
            { 
                tabulaciones += " ";
                mostrar = tabulaciones + resultado;
            }*/

            this.lblResultado.Text =resultado;
        }


        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(this.isBinario == false)
            { 
                this.showResultado(this._resultado.DecimalBinario(this.lblResultado.Text));
                this.isBinario = true;
            }

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if(this.isBinario == true)
            { 
                this.showResultado(this._resultado.BinarioDecimal(this.lblResultado.Text));
                this.isBinario = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this._N1 = new Numero(0);
            this._N2 = new Numero(0);
            this._resultado = new Numero(0);

            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";

            this.showResultado("0");
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void LaCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {

            double DoubleUno, DoubleDos, DoubleResultado;

            isBinario = false;

            if (double.TryParse(txtNumero1.Text, out DoubleUno) == true && double.TryParse(txtNumero2.Text, out DoubleDos) == true)
            {

                this._N1.SetNumero = DoubleUno;
                this._N2.SetNumero = DoubleDos;
          

                DoubleResultado = Calculadora.Operar(this._N1, this._N2, cmbOperador.Text);

                this._resultado.SetNumero = DoubleResultado;

                 this.showResultado( this._resultado.show());


            }
            else { MessageBox.Show("no se pudo calcular la operacion porfavor escriba numeros en en los textBox"); }

        }
    }
}
