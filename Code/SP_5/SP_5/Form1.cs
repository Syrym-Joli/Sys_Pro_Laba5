using System;
using System.Drawing;
using System.Windows.Forms;

namespace SP_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form form1 = new Form();
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Keys keysmod = Control.ModifierKeys;
            if (e.KeyCode == Keys.V)
            {
                panel1.Visible = true;
            }


            if (e.KeyCode == Keys.PageUp)
            {
                int y = 10;
                label2.Text = "Верх";
                textBox1.Location = new Point(textBox1.Location.X, textBox1.Location.Y - y);
            }
            if (e.KeyCode == Keys.PageDown)
            {
                int y = 10;
                label2.Text = "Вниз";
                textBox1.Location = new Point(textBox1.Location.X, textBox1.Location.Y + y);

            }
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:


                    break;

                case 1:
                    textBox1.Location = new Point(66, 140);
                    label3.Visible = true;
                    break;

                case 2:
                    panel1.Visible = false;
                    textBox1.Location = new Point(66, 140);
                    break;

                default:

                    break;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 30)
            {
                MessageBox.Show("Максимальная длина символов: 30");
            }
        }
    }
}
