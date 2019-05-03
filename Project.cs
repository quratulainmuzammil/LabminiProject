using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FYP_proj
{
    public partial class Project : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-MRCNKC7;Initial Catalog=ProjectA;Integrated Security=True");
        public Project()
        {
            InitializeComponent();
        }
        //Insert data
        private void button1_Click(object sender, EventArgs e)
        {

            string Description = txtDescription.Text;
            string Title = txtTitle.Text;
            
            if (Title == " ")
            {
                MessageBox.Show("Null value not accepted");
            }
            else
            {
                string query = "INSERT INTO Advisor VALUES( '" + Description + "','" + Title + "');";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int flag = command.ExecuteNonQuery();
                if (flag > 0)
                {
                    txtDescription.Text = "";
                    txtTitle.Text = "";
                  
                    displayButton.PerformClick();

                }
                else
                {
                    MessageBox.Show("Try again");
                    connection.Close();
                }
            }
        }
        //Update
        private void button2_Click(object sender, EventArgs e)
     
        {

            try
            {
                if (txtTitle.Text == "")
                {
                    MessageBox.Show("Enter Name To Update");
                }
                else
                {
                    SqlCommand cmdupdate = new SqlCommand("Update Evaluation SET Description=('" + txtDescription.Text.ToString() + "'),Title=('" + Convert.ToInt32(txtTitle.Text) + "') , WHERE Id = '" + Convert.ToInt32(txtId.Text) + "';", connection);
                    connection.Open();
                    cmdupdate.CommandType = CommandType.Text;
                    cmdupdate.ExecuteNonQuery();
                    MessageBox.Show("Data Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        //Delete
        private void button3_Click(object sender, EventArgs e)
        
        {
            string Title = txtTitle.Text;

            string query = "DELETE FROM Evaluation WHERE Title= '" + Title + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int flag = command.ExecuteNonQuery();
            if (flag > 0)
            {
                displayButton.PerformClick();

            }
            connection.Close();

        }
        //Display
        private void displayButton_Click(object sender, EventArgs e)
       
        {
            string query = "SELECT * FROM  Evaluation";
            SqlCommand command = new SqlCommand(query, connection);



            DataTable myTable = new DataTable();
            SqlDataAdapter myAdapter = new SqlDataAdapter(command);
            myAdapter.Fill(myTable);
            pro_data.DataSource = myTable;
            connection.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Advisor a = new Advisor();
            a.Show();
        }
    }
    }
  

