using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public partial class KernelConfiguration : Form
    {
        protected int size;
        protected int[,] kernel;

        public KernelConfiguration()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            size = System.Convert.ToInt32(textBox1.Text);
            if (size <= 0)
            {
                MessageBox.Show("Wrong input of kernel size");
                return;
            }
            dataGridView1.ColumnCount = size;
            dataGridView1.RowCount = size;
            kernel = new int[size, size];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    kernel[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
        }
    }
}
