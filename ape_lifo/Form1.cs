using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ape_lifo
{
    public partial class frmPrincipal : Form
    {
        Procesador lifo = new Procesador();
        static Random rand = new Random();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            int vContVacio = 0;

            for (int i = 0; i < 200; i++)
            {
                if (rand.Next(1, 101) <= 25)
                {
                    Proceso nuevoP = new Proceso();
                    lifo.push(nuevoP);
                }

                Proceso vProceso = lifo.peek();
                if (vProceso != null)
                    lifo.atender();
                else
                    vContVacio++;
            }

            txtInformacion.Text = "Ciclos que estuvo vacía: " + vContVacio.ToString() + Environment.NewLine +
                                    lifo.procPendientesYTerminados() + Environment.NewLine;
                                     
        }
    }
}
