using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DifZachetAlgoritm_KirillMalugin
{
    public partial class Form1 : Form
    {
        string filename;
        string filenametwo;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                button1.Visible = false;
                button2.Visible = true;
            }
            else 
            {
                MessageBox.Show("Вы не выбрали файл, выберите файл", "Файл", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filenametwo = openFileDialog1.FileName;
                button1.Visible = false;
                button2.Visible = false;
                panel1.Visible = true;
                label2.Visible = true;
                button3.Visible = true;
                MessageBox.Show("Файлы успешно выбраны!", "Сообщение", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл, выберите файл", "Файл", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                panel2.Visible=true;
                listBox1.Items.Clear();
                List<Country> countries = new List<Country>();
                using (StreamReader str = new StreamReader(filename))
                {
                    string line;
                    while ((line = str.ReadLine()) != null)
                    {
                        string[] array = line.Split(' ');
                        countries.Add(new Country { id = int.Parse(array[0]), countryname = array[1] });
                    }
                }
                List<Hotel> hotels = new List<Hotel>();
                using (StreamReader str = new StreamReader(filenametwo))
                {
                    string line;
                    while ((line = str.ReadLine()) != null)
                    {
                        string[] array = line.Split(' ');
                        hotels.Add(new Hotel { typeraz = array[0], id = int.Parse(array[1]), namehotel = array[2], price = int.Parse(array[3]) });
                    }
                }
                var twocollect = countries.Join(hotels, item => item.id, info => info.id, (item, info) => new
                {
                    item.id,
                    item.countryname,
                    info.typeraz,
                    info.namehotel,
                    info.price
                }
                ).OrderBy(item => item.id);
                foreach (var q in twocollect)
                {
                    listBox1.Items.Add($"{q.id} {q.countryname} {q.typeraz} {q.namehotel} {q.price}");
                }
            }
            else if (radioButton2.Checked == true)
            {
                    panel2.Visible = true;
                    listBox1.Items.Clear();
                    List<Country> countries = new List<Country>();
                    using (StreamReader str = new StreamReader(filename))
                    {
                        string line;
                        while ((line = str.ReadLine()) != null)
                        {
                            string[] array = line.Split(' ');
                            countries.Add(new Country { id = int.Parse(array[0]), countryname = array[1] });
                        }
                    }
                    List<Hotel> hotels = new List<Hotel>();
                    using (StreamReader str = new StreamReader(filenametwo))
                    {
                        string line;
                        while ((line = str.ReadLine()) != null)
                        {
                            string[] array = line.Split(' ');
                            hotels.Add(new Hotel { typeraz = array[0], id = int.Parse(array[1]), namehotel = array[2], price = int.Parse(array[3]) });
                        }
                    }
                    var twocollect = countries.Join(hotels, item => item.id, info => info.id, (item, info) => new
                    {
                        item.id,
                        item.countryname,
                        info.typeraz,
                        info.namehotel,
                        info.price
                    }
                    ).OrderBy(info=>info.price);
                    foreach (var q in twocollect)
                    {
                        listBox1.Items.Add($"{q.id} {q.countryname} {q.typeraz} {q.namehotel} {q.price}");
                    }
            }
        }
      
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectitem=listBox1.SelectedIndex;
            if (selectitem != -1)
                listBox1.Items.RemoveAt(selectitem);
            else MessageBox.Show("Выберите элемент для удаления!", "Сообщение", MessageBoxButtons.OK);
        }
    }
}
