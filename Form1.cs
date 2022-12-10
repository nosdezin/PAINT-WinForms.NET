using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        int x = -1;
        int y = -1;
        bool moving = false;
        bool Tri = false;
        int Grossura = 5;
        int GrossuraCirculo = 5;
        int larguraFormat = 50;
        int alturaFormat = 50;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black,Grossura);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            textBox1.Text = Grossura.ToString();
            textBox2.Text = alturaFormat.ToString();
            textBox3.Text = larguraFormat.ToString();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            PropsPainel.Visible = false;
            if (!Tri)
            {
                pen.Width = Grossura;
                moving = true;
                x = e.X;
                y = e.Y;
                panel1.Cursor = Cursors.Cross;
            }
            else
            {
                x = e.X;
                y = e.Y;
                pen.Width = GrossuraCirculo;
                g.DrawEllipse(pen, new Rectangle(x, y, larguraFormat, alturaFormat));
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x!=-1 && y != -1)
            {
                g.DrawLine(pen,new Point(x,y),e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Tri)
            {
                button1.BackColor = Color.Gray;
                Tri = false;
            }
            else
            {
                button1.BackColor = Button.DefaultBackColor;
                Tri = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PropsPainel.Visible = !PropsPainel.Visible;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string textoRecebido = textBox1.Text;
            int numeroOut;
            bool isNumber = int.TryParse(textoRecebido, out numeroOut);
            if (isNumber)
            {
                int numero = Int32.Parse(textoRecebido);
                Grossura = numero;
                pen.Width = Grossura;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string textoRecebido = textBox2.Text;
            int numeroOut;
            bool isNumber = int.TryParse(textoRecebido, out numeroOut);
            if (isNumber)
            {
                int numero = Int32.Parse(textoRecebido);
                alturaFormat = numero;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string textoRecebido = textBox2.Text;
            int numeroOut;
            bool isNumber = int.TryParse(textoRecebido, out numeroOut);
            if (isNumber)
            {
                int numero = Int32.Parse(textoRecebido);
                larguraFormat = numero;
            }
        }
    }
}
