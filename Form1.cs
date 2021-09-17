using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuncaAusente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex) { lbError.Text = ex.Message; }
        }
        private void MoveCursor()
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X + 252, Cursor.Position.Y + 152);
            Cursor.Position = new Point(Cursor.Position.X - 250, Cursor.Position.Y - 150);
            //Cursor.Clip = new Rectangle(this.Location, this.Size);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                this.Visible = false;
                // Set the Current cursor, move the cursor's Position,
                // and set its clipping rectangle to the form. 
                Int32 Repeticiones = Convert.ToInt32(tbMinutos.Text);
                Int32 Contador = 1;
                while (Contador <= Repeticiones)
                {
                    MoveCursor();
                    Contador += 1;
                    Thread.Sleep(60000);
                }
                this.Enabled = true;
                this.Visible = true;
            }
            catch (Exception ex)
            {
                lbError.Text = ex.Message;
                this.Enabled = true;
                this.Visible = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.FileName = "https://www.paypal.me/carmelogassette";
                process.Start();
            }
            catch (Exception ex)
            {
                lbError.Text = ex.Message;
                this.Enabled = true;
                this.Visible = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
