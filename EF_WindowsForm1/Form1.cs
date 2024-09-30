using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace EF_WindowsForm1
{
    public partial class Form1 : Form
    {
        db2Entities2 db2 = new db2Entities2();
        public Form1()
        {
            InitializeComponent();          
        }
        private void Form1_Load(object sender, EventArgs e)
        {           
           this.dataGridView1.DataSource = db2.Phone_Books.ToList();           
        }

        private void button1_Click(object sender, EventArgs e)
        { //Insert

            Phone_Book PB = new Phone_Book();


          
 //in ghesmat mogheii ke az "try catch" Estefade Mikrdm Eror ra neshon midad vali id 0 dar database darj mikard

           if (txt_ID.Text == string.Empty) { MessageBox.Show("!آیدی نباید خالی باشد", "Eror 401"); }
           if (txt_Phone.Text == string.Empty) { MessageBox.Show("!شماره نباید خالی باشد", "Eror 401"); } 
           
           

           //Khastam Az "Regular Expression" Estefade Konam Vali HAr Kari Kardam Natonstm
            PB.ID = Convert.ToInt32(txt_ID.Text);                 
            PB.First_Name = txt_Name.Text;
            PB.Last_Name = txt_Fmily.Text;
            PB.Phone_Number = Convert.ToInt64(txt_Phone.Text);
           
            db2.Phone_Books.Add(PB);

            db2.SaveChanges();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = db2.Phone_Books.ToList();
   }

        public void show()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = db2.Phone_Books.ToList();

        }
        private void button2_Click(object sender, EventArgs e)
        { //Delete

            int current =Convert.ToInt32( this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

            Phone_Book PB= db2.Phone_Books.First(c => c.ID == current);

            db2.Phone_Books.Remove(PB);

            db2.SaveChanges();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = db2.Phone_Books.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
            int current = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

            Phone_Book PB = db2.Phone_Books.First(c => c.ID == current);

          //PB.ID = Convert.ToInt32(txt_ID.Text);
            PB.First_Name = txt_Name.Text;
            PB.Last_Name = txt_Fmily.Text;
            PB.Phone_Number = Convert.ToInt64(txt_Phone.Text);

            db2.SaveChanges();
            
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = db2.Phone_Books.ToList();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int current = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            Phone_Book PB = db2.Phone_Books.First(c => c.ID == current);

             txt_ID.Text = PB.ID.ToString();
             txt_Name.Text= PB.First_Name.ToString();
             txt_Fmily.Text = PB.Last_Name.ToString(); 
             txt_Phone.Text= PB.Phone_Number.ToString() ;        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Select

            try
            {
                int currentID = Convert.ToInt32(txt_searchID.Text);


                Phone_Book PB = db2.Phone_Books.First(c => c.ID == currentID);

                txt_ID.Text = PB.ID.ToString();
                txt_Name.Text = PB.First_Name.ToString();
                txt_Fmily.Text = PB.Last_Name.ToString(); ;
                txt_Phone.Text = PB.Phone_Number.ToString();

                txt_searchID.Text = string.Empty.Trim();
            }
            catch (Exception)
            {

                MessageBox.Show("!کاربر مورد نظر وجود ندارد","Eror 404");
                txt_searchID.Text = string.Empty.Trim();
            }

        }    
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_searchID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_ID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        { 
            //Empty

            txt_ID.Text = string.Empty.Trim();
            txt_Name.Text = string.Empty.Trim();
            txt_Fmily.Text = string.Empty.Trim();
            txt_Phone.Text = string.Empty.Trim();
        }

        private void txt_Phone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
