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
                textBox1.Location = new Point(textBox1.Location.X, textBox1.Location.Y - y);
                int poz = textBox1.Location.Y;
                label1.Text = poz.ToString();
                label2.Text = "Верх";
            }
            if (e.KeyCode == Keys.PageDown)
            {
                int y = 10;
                label2.Text = "Вниз";
                textBox1.Location = new Point(textBox1.Location.X, textBox1.Location.Y + y);
                int poz = textBox1.Location.Y;
                label1.Text = poz.ToString();
            }
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(saveFileDialog.FileName);
                        streamWriter.WriteLine(textBox1.Text);
                        streamWriter.Close();
                    }

                    break;

                case 1:
                    textBox1.Location = new Point(66, 140);
                    OpenFileDialog o = new OpenFileDialog();
                    o.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    if (o.ShowDialog() == DialogResult.OK)
                    {
                        textBox1.Text = System.IO.File.ReadAllText(o.FileName, System.Text.Encoding.Default);
                    }
                    label3.Visible = true;
                    break;

                case 2:
                    panel1.Visible = false;
                    textBox1.Location = new Point(66, 140);
                    textBox1.Text = null;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = Properties.Settings.Default.FormSize;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FormSize = this.Size;
            Properties.Settings.Default.Loc = this.Location;
            Properties.Settings.Default.Save();
        }
    }
}
