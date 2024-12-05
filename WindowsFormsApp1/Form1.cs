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
using System.Windows.Forms.VisualStyles;
using WindowsFormsApp1.Data_Access;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DatabaseHelper dbHelper = new DatabaseHelper();

        private void Form1_Load(object sender, EventArgs e) { LoadData(); }
        private void LoadData() { dataGridView1.DataSource = dbHelper.GetProducts(); }
        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    dbHelper.AddProduct(txtProductName.Text, decimal.Parse(txtPrice.Text),
        //    chkInStock.Checked, txtImagePath.Text, dateTimePicker1.Value);
        //    LoadData();
        //}
        private void btnUpdate_Click(object sender, EventArgs e) { dbHelper.UpdateProduct(int.Parse(txtProductID.Text), txtProductName.Text, decimal.Parse(txtPrice.Text), chkInStock.Checked, txtImagePath.Text, dateTimePicker1.Value); LoadData(); }
        private void btnDelete_Click(object sender, EventArgs e) { dbHelper.DeleteProduct(int.Parse(txtProductID.Text)); LoadData(); }
        private void btnLoadImage_Click(object sender, EventArgs e) { 
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            { openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"; 
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                { string imagePath = openFileDialog.FileName; 
                    txtImagePath.Text = imagePath;
                    pictureBox1.Image = Image.FromFile(imagePath); } } }
        private void btnSave_Click(object sender, EventArgs e)
        { // Save the image to the desired location
          if (pictureBox1.Image != null && !string.IsNullOrEmpty(txtImagePath.Text))
            { 
                pictureBox1.Image.Save(txtImagePath.Text); 
                MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); } 
            else { MessageBox.Show("No image to save or path is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } 
        }
        private void btnbrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) 
            { openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"; 
                if (openFileDialog.ShowDialog() == DialogResult.OK) 
                {
                 string d=   Directory.GetCurrentDirectory();
                    string imagePath = Path.Combine(d,"Images", openFileDialog.FileName); 
                    pictureBox1.Image = Image.FromFile(imagePath);
                    this.txtImagePath.Text = imagePath;
                }
            }
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            dbHelper.AddProduct(txtProductName.Text, decimal.Parse(txtPrice.Text),
           chkInStock.Checked, txtImagePath.Text, dateTimePicker1.Value);
            LoadData();
        }
    }
}
