using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grupo_2
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            UpdateProcessList();
            timer1.Enabled = true;

        }
        private void UpdateProcessList() {
            dgvAdministrador.Rows.Clear();
            foreach (Process p in Process.GetProcesses()){
                int n = dgvAdministrador.Rows.Add();
                dgvAdministrador.Rows[n].Cells[0].Value = p.ProcessName;
                dgvAdministrador.Rows[n].Cells[1].Value = p.Id;
                dgvAdministrador.Rows[n].Cells[2].Value = p.WorkingSet64;
                dgvAdministrador.Rows[n].Cells[3].Value = p.VirtualMemorySize64;
                dgvAdministrador.Rows[n].Cells[4].Value = p.SessionId;
            }
            txtcontador.Text = "Procesos Actuales: " + dgvAdministrador.Rows.Count.ToString();
            }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName == txtProceso.Text)
                    {
                        p.Kill(); // elimina el proceso
                    }
                }
            }
            catch (Exception x)
            { 
            MessageBox.Show(" no selecciono nigun proceso " + x, " error al eliminar ", MessageBoxButtons.OK);
            }
    }
        

        private void dgvAdministrador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProceso.Text = dgvAdministrador.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateProcessList();
        }
    }
}
