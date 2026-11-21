using System;
using System.Drawing;
using System.Windows.Forms;

namespace LicznikAplikacja
{
    public class GlowneOkno : Form
    {
        private int licznik = 0;
        private int sumaKlikniec = 0;

        private Label lblNaglowek;
        private Label lblAutor;
        private Panel panelWyswietlacza;
        private Label lblWartosc;
        private Button btnZwieksz;
        private Button btnZmniejsz;
        private Button btnZeruj;
        private Label lblStatus;

        public GlowneOkno()
        {
            InicjalizujKomponenty();
        }

        private void InicjalizujKomponenty()
        {
            // Konfiguracja głównego okna
            this.Text = "Licznik Kliknięć - Zadanie 2.1";
            this.Size = new Size(400, 480);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            // Nagłówek aplikacji
            lblNaglowek = new Label
            {
                Text = "LICZNIK KLIKNIĘĆ",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 20),
                Size = new Size(345, 30)
            };

            // Informacja o autorze i zadaniu
            lblAutor = new Label
            {
                Text = "Zadanie 2.1 | Klasa 4TC-2 | Wojciech Januszkiewicz",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 52),
                Size = new Size(345, 20)
            };

            // Panel wyświetlacza wartości
            panelWyswietlacza = new Panel
            {
                Location = new Point(35, 85),
                Size = new Size(315, 110),
                BackColor = Color.White
            };
            panelWyswietlacza.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panelWyswietlacza.ClientRectangle,
                    Color.FromArgb(226, 232, 240), ButtonBorderStyle.Solid);
            };

            lblWartosc = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 44f, FontStyle.Bold),
                ForeColor = Color.FromArgb(37, 99, 235),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            panelWyswietlacza.Controls.Add(lblWartosc);

            // Przycisk główny: Dodaj (+1)
            btnZwieksz = new Button
            {
                Text = "+1 KLIKNIJ",
                Location = new Point(35, 215),
                Size = new Size(315, 60),
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnZwieksz.FlatAppearance.BorderSize = 0;
            btnZwieksz.Click += BtnZwieksz_Click;

            // Przycisk pomocniczy: Zmniejsz (-1)
            btnZmniejsz = new Button
            {
                Text = "-1 Odejmij",
                Location = new Point(35, 290),
                Size = new Size(150, 45),
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                BackColor = Color.FromArgb(100, 116, 139),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnZmniejsz.FlatAppearance.BorderSize = 0;
            btnZmniejsz.Click += BtnZmniejsz_Click;

            // Przycisk Zerowania (Reset)
            btnZeruj = new Button
            {
                Text = "↺ Zeruj (Reset)",
                Location = new Point(200, 290),
                Size = new Size(150, 45),
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                BackColor = Color.FromArgb(239, 68, 68),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnZeruj.FlatAppearance.BorderSize = 0;
            btnZeruj.Click += BtnZeruj_Click;

            // Pasek stanu / status
            lblStatus = new Label
            {
                Text = "Stan: Gotowy | Wykonanych kliknięć: 0",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 370),
                Size = new Size(345, 40)
            };

            // Dodanie kontrolek do formularza
            this.Controls.Add(lblNaglowek);
            this.Controls.Add(lblAutor);
            this.Controls.Add(panelWyswietlacza);
            this.Controls.Add(btnZwieksz);
            this.Controls.Add(btnZmniejsz);
            this.Controls.Add(btnZeruj);
            this.Controls.Add(lblStatus);
        }

        private void BtnZwieksz_Click(object sender, EventArgs e)
        {
            licznik++;
            sumaKlikniec++;
            AktualizujWidok("Zwiększono o 1");
        }

        private void BtnZmniejsz_Click(object sender, EventArgs e)
        {
            licznik--;
            sumaKlikniec++;
            AktualizujWidok("Zmniejszono o 1");
        }

        private void BtnZeruj_Click(object sender, EventArgs e)
        {
            licznik = 0;
            AktualizujWidok("Wyzerowano licznik");
        }

        private void AktualizujWidok(string ostatniaAkcja)
        {
            lblWartosc.Text = licznik.ToString();

            // Zmiana koloru w zależności od znaku liczby
            if (licznik > 0)
            {
                lblWartosc.ForeColor = Color.FromArgb(37, 99, 235); // Niebieski
            }
            else if (licznik < 0)
            {
                lblWartosc.ForeColor = Color.FromArgb(220, 38, 38); // Czerwony
            }
            else
            {
                lblWartosc.ForeColor = Color.FromArgb(71, 85, 105); // Neutralny
            }

            lblStatus.Text = string.Format("Akcja: {0} | Wykonanych kliknięć: {1}", ostatniaAkcja, sumaKlikniec);
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GlowneOkno());
        }
    }
}
