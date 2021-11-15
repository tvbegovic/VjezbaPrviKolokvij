using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadatak2
{
    public partial class Glavna : Form
    {
        List<Polaznik> polaznici = new List<Polaznik>();
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var ime = txtIme.Text;
            var prezime = txtPrezime.Text;
            var oib = txtOib.Text;

            var ok = DateTime.TryParse(txtDatumUpisa.Text, out DateTime datum);
            if (!ok)
            {
                MessageBox.Show("Pogrešan format datuma", "Pogreška", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            ok = double.TryParse(txtDug.Text, out double dug);
            if (!ok)
            {
                MessageBox.Show("Pogrešan format duga", "Pogreška", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var polaznik = new Polaznik();
            try
            {
                polaznik.Ime = ime;
                polaznik.Prezime = prezime;
                polaznik.Oib = oib;
                polaznik.DatumUpisa = datum;
                polaznik.Dug = dug;
                polaznici.Add(polaznik);
                AzurirajGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dogodila se pogreška. Tekst: {ex.Message}",
                    "Pogreška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void AzurirajGrid()
        {
            dgvPolaznici.DataSource = null;
            dgvPolaznici.DataSource = polaznici;
        }
    }
}
