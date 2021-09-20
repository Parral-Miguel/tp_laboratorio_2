using System;
using System.Windows.Forms;
using Calculador;
using Operandos;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        string strN1;
        string strN2;
        double resultado;      
        string operador = "";
        string strResultado;

        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Operar_Click(object sender, EventArgs e)
        {
            resultado = Operar(strN1, strN2, operador);
            strResultado = resultado.ToString();
            label1.Text = strResultado;
            listBox1.Items.Add(strN1 + " " + operador + " " + strN2 + " " + "= " + strResultado);

        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            operador = comboBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            strN1 = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            strN2 = textBox2.Text;
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            DialogResult Salir = MessageBox.Show("¿Desea cerrar la calculadora?", "Salir", MessageBoxButtons.YesNo);
            if (Salir == DialogResult.Yes)
            {
                Close();
                Dispose();
            }
        }

        private void ConvertirADecimal_Click(object sender, EventArgs e)
        {
            resultado = Operar(strN1, strN2, operador);
            strResultado = Operando.BinarioDecimal(resultado.ToString());
            label1.Text = strResultado;
            listBox1.Items.Add(strN1 + " " + operador + " " + strN2 + " " + "= " + strResultado + " Decimal");
        }

        private void ConvertirABinario_Click(object sender, EventArgs e)
        {
            resultado = Operar(strN1, strN2, operador);
            strResultado = Operando.DecimalBinario(resultado);
            label1.Text = strResultado;
            listBox1.Items.Add(strN1 + " " + operador + " " + strN2 + " " + "= " + strResultado + " Binario");
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label1.Text = "";
            listBox1.Items.Clear();
        }

        static private double Operar(string numero1, string numero2, string operador)
        {

            if (operador == "")
            {
                operador = "+";
            }
            char operacion = char.Parse(operador);

            return Calculadora.Operar(new Operando(numero1), new Operando(numero2), operacion);

        }

    } 
}
