using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            var datoteka = new StreamWriter("polaznici.txt");
            foreach (var polaznik in polaznici)
            {
                datoteka.WriteLine("{0};{1};{2};{3};{4}",
                    polaznik.Ime, polaznik.Prezime, polaznik.Oib,
                    polaznik.DatumUpisa, polaznik.Dug);
            }
            datoteka.Close();
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            polaznici.Clear();
            var redci = File.ReadAllLines("polaznici.txt");
            foreach (var red in redci)
            {
                var stupci = red.Split(';');
                var polaznik = new Polaznik();
                polaznik.Ime = stupci[0];
                polaznik.Prezime = stupci[1];
                polaznik.Oib = stupci[2];
                var ok = DateTime.TryParse(stupci[3], out DateTime datum);
                if (ok)
                    polaznik.DatumUpisa = datum;
                ok = double.TryParse(stupci[4], out double dug);
                if (ok)
                    polaznik.Dug = dug;
                polaznici.Add(polaznik);
            }
            AzurirajGrid();
        }
    }
}
