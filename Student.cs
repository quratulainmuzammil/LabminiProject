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
using System.Configuration;
namespace FYP_proj
{
    public partial class Student : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-MRCNKC7;Initial Catalog=ProjectA;Integrated Security=True");
        public Student()
        {
            InitializeComponent();
        }
        //Insert
        private void button1_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;
            string RegistrationNo = txtregistration.Text;
            if (Id == " ")
            {
                MessageBox.Show("Null value not accepted");
            }
            else
            {
                string query = "INSERT INTO Advisor VALUES( '" + Id + "' ,'" + RegistrationNo + "');";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int flag = command.ExecuteNonQuery();
                if (flag > 0)
                {
                    txtId.Text = "";
                    txtregistration.Text = "";
                    displayButton.PerformClick();

                }
                else
                {
                    MessageBox.Show("Try again");
                    connection.Close();
                }
            }
        }
        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;

            string query = "DELETE FROM Evaluation WHERE Id= '" + Id + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int flag = command.ExecuteNonQuery();
            if (flag > 0)
            {
                displayButton.PerformClick();

            }
            connection.Close();

        }
        //update
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Enter Id To Update");
                }
                else
                {
                    SqlCommand cmdupdate = new SqlCommand("Update Evaluation SET Id=('" + txtId.Text.ToString() + "'),RegistrationNo=('" + Convert.ToInt32(txtregistration.Text) + "') , WHERE Id = '" + Convert.ToInt32(txtId.Text) + "';", connection);
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
        //display
        private void displayButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM  Evaluation";
            SqlCommand command = new SqlCommand(query, connection);



            DataTable myTable = new DataTable();
            SqlDataAdapter myAdapter = new SqlDataAdapter(command);
            myAdapter.Fill(myTable);
            std_data.DataSource = myTable;
            connection.Close();
        }
        //Linking
        private void button4_Click(object sender, EventArgs e)
        {
            Project p = new Project();
            p.Show();
        }
    }
}