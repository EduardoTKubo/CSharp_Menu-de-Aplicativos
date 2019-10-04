using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Aplicativos.Classes;

namespace Aplicativos
{
    public partial class frmCRM : Form
    {
        public frmCRM()
        {
            InitializeComponent();
            this.Text = Application.ProductName.ToString();
            lblVersao.Text = Application.ProductVersion;
            Carrega_Campanha();
        }

        private void Carrega_Campanha()
        {
            cboCampanha.Items.Clear();
            cboCRM.Items.Clear();
            listCRM.Items.Clear();

            foreach (DataRow item in Classes.clsBanco.Consulta("select distinct campanha from aplicativos where ativo = 1 order by campanha").Rows)
            {
                cboCampanha.Items.Add(item[0].ToString());
            }
        }

        private void Carrega_CRM()
        {
            foreach (DataRow item in Classes.clsBanco.Consulta("select aplicativo ,caminho from aplicativos where ativo = 1 and Campanha = '" + cboCampanha.Text + "' order by aplicativo").Rows)
            {
                cboCRM.Items.Add(item[0].ToString());
                listCRM.Items.Add(item[1].ToString());
            }
        }

        private void cboCampanha_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCRM.Items.Clear();
            listCRM.Items.Clear();

            if (cboCampanha.Text != "")
            {
                Carrega_CRM();
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                //System.Diagnostics.Process.Start("http://10.0.32.7/login/signin");
                //System.Diagnostics.Process.Start("http://10.0.32.56/");

                if (cboCampanha.Text != "" && cboCRM.Text != "")
                {
                    btnAbrir.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;

                    listCRM.SelectedIndex = cboCRM.FindStringExact(cboCRM.Text, listCRM.SelectedIndex);
                    clsVariaveis.GstrIni = listCRM.Text.ToString();

                    if (File.Exists(@"\" + clsVariaveis.GstrIni))
                    {
                        clsVariaveis.GstrExe = clsProcessos.Retorna_ArqExe(clsVariaveis.GstrIni);

                        if (File.Exists(@"\" + clsVariaveis.GstrExe))
                        {
                            System.Diagnostics.Process.Start(@"\" + clsVariaveis.GstrExe);

                            this.Close();
                            Application.Exit();
                        }
                        else
                        {
                            MessageBox.Show(clsVariaveis.GstrIni, "app nao localizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show(clsVariaveis.GstrIni, "pasta nao localizada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, btnAbrir.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            btnAbrir.Enabled = true;
            this.Cursor = Cursors.Default;

        }

        private void frmCRM_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
        }
    }
}
