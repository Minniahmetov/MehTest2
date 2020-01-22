using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace MehTest2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (DataStringContext db = new DataStringContext())
            {
                //DataString AddString = new DataString();
                //DataString dataString2 = new DataString { Name = "555555555" };

                //db.DataStrings.Add(dataString1);
                //db.DataStrings.Add(dataString2);
                //db.SaveChanges();

                button1.Enabled = false;
                button2.Enabled = false;
                textBox1.Text = "Введите значение";

                var DataStrings = db.DataStrings;
                foreach(DataString D in DataStrings)
                {
                    listBox1.Items.Add(D.Name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DataStringContext db = new DataStringContext())
            {
                DataString AddString = new DataString();
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    if (listBox1.FindStringExact(textBox1.Text) != -1)
                    {
                        errorProvider1.SetError(textBox1, "Данное значение уже существует в спискe!");
                    }
                    else
                    {
                        errorProvider1.Clear();
                        listBox1.Items.Add(textBox1.Text);
                        AddString.Name = textBox1.Text;
                        db.DataStrings.Add(AddString);
                        db.SaveChanges();
                        textBox1.Clear();

                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button2.Enabled = true;
            }

            if (listBox1.SelectedIndex == -1)
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (DataStringContext db = new DataStringContext())
            {
                //DataString RemoveString = new DataString();
                DataString RemoveString = db.DataStrings.FirstOrDefault(str => str.Name == listBox1.SelectedItem.ToString());
                db.DataStrings.Remove(RemoveString);
                db.SaveChanges();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = System.Drawing.Color.Black;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
        }
    }
}

