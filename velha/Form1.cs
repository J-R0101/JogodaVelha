using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace velha {
    public partial class Form1 : Form {
        bool xies = true;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            B11.Click += new EventHandler(BClick);
            B12.Click += new EventHandler(BClick);
            B13.Click += new EventHandler(BClick);
            B21.Click += new EventHandler(BClick);
            B22.Click += new EventHandler(BClick);
            B23.Click += new EventHandler(BClick);
            B31.Click += new EventHandler(BClick);
            B32.Click += new EventHandler(BClick);
            B33.Click += new EventHandler(BClick);
            foreach (Control item in this.Controls) {
                if ( item is Button) {
                    item.TabStop = false ;
                }
            }
        }
        private void BClick(object sender, EventArgs e) {
            ((Button)sender).Text = this.xies ? "x" : "o";
            ((Button)sender).Enabled = false;

            VerificarGanhador();

            xies = !xies;

            defalt.Text = String.Format("{0}, é sua vez", this.xies ? "x" : "o");
        }

        private void VerificarGanhador() {
            if (
             B11.Text != String.Empty && B11.Text == B12.Text && B12.Text == B13.Text ||
             B21.Text != String.Empty && B21.Text == B22.Text && B22.Text == B23.Text ||
             B31.Text != String.Empty && B31.Text == B32.Text && B32.Text == B33.Text ||

             B11.Text != String.Empty && B11.Text == B21.Text && B21.Text == B31.Text ||
             B12.Text != String.Empty && B12.Text == B22.Text && B22.Text == B32.Text ||
             B13.Text != String.Empty && B13.Text == B23.Text && B23.Text == B33.Text ||

             B11.Text != String.Empty && B11.Text == B22.Text && B22.Text == B33.Text ||
             B13.Text != String.Empty && B13.Text == B22.Text && B22.Text == B31.Text 
            ) {
                MessageBox.Show(String.Format("O ganhador é: {0}", xies ? "x" : "o"), "Temos um vitorioso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reiniciar();
            }
           else {
                VerificarEmpate();
            }
        }

        private void VerificarEmpate() {
            bool TodosDesabilitados = true;
            foreach(Control item in this.Controls) {
                if(item is Button && item.Enabled) {
                    TodosDesabilitados = false;
                    break;
                }
            }
            if (TodosDesabilitados) {
                MessageBox.Show(String.Format("Deu empate"), "Ops!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Reiniciar();
            }
            
        }

        private void Reiniciar() {
            foreach(Control item in this.Controls) {
                if(item is Button) {
                    item.Enabled = true;
                    item.Text = String.Empty;
                }
            }
        }
    }
}
