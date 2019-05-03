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
    public partial class Evaluation : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-MRCNKC7;Initial Catalog=ProjectA;Integrated Security=True");
        public Evaluation()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Insert data
        private void button1_Click(object sender, EventArgs e)
        {
         
            string Name = txtName.Text;
            string TotalMarks = txtMarks.Text;
            string TotalWeigtage = txtweightage.Text;
            if (Name == " ")
            {
                MessageBox.Show("Null value not accepted");
            }
            else
            {
                string query = "INSERT INTO Evaluation VALUES( '" + Name + "','" + TotalMarks + "','" + TotalWeigtage + "');";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int flag = command.ExecuteNonQuery();
                if (flag > 0)
                {
                    txtName.Text = "";
                    txtMarks.Text = "";
                    txtweightage.Text = "";
                    displayButton.PerformClick();

                }
                else
                {
                    MessageBox.Show("Try again");
                    connection.Close();
                }
            }

        }
        //Update data
        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Enter Name To Update");
                }
                else
                {
                    SqlCommand cmdupdate = new SqlCommand("Update Evaluation SET Name=('" + txtName.Text.ToString() + "'),TotalMarks=('" + Convert.ToInt32(txtMarks.Text) + "') ,TotalWeightage=('" + Convert.ToInt32(txtweightage.Text) + "') WHERE Id = '" + Convert.ToInt32(txtId.Text) + "';",connection);
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
        //Display data
        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM  Evaluation";
            SqlCommand command = new SqlCommand(query, connection);



            DataTable myTable = new DataTable();
            SqlDataAdapter myAdapter = new SqlDataAdapter(command);
            myAdapter.Fill(myTable);
            eva_data.DataSource = myTable;
            connection.Close();
        }
        //Delete data 
        private void button3_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;

            string query = "DELETE FROM Evaluation WHERE Name= '" + Name + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int flag = command.ExecuteNonQuery();
            if (flag > 0)
            {
                displayButton.PerformClick();

            }
            connection.Close();

        }
        //linking

        private void button4_Click_1(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Show();
        }
    }
}