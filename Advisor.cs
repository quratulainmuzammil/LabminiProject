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

    public partial class Advisor : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-MRCNKC7;Initial Catalog=ProjectA;Integrated Security=True");
        public Advisor()
        {
            InitializeComponent();
        }
//Insert
        private void button1_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;
            string Designition = txtDesignition.Text;
            string Salary = txtSalary.Text;
            if (Salary == " ")
            {
                MessageBox.Show("Null value not accepted");
            }
            else
            {
                string query = "INSERT INTO Advisor VALUES( '" + Id + "' ,'" + Designition + "', '" + Salary + "');";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                int flag = command.ExecuteNonQuery();
                if (flag > 0)
                {
                    txtId.Text = "";
                    txtDesignition.Text = "";
                    txtSalary.Text = "";
                    displayButton.PerformClick();

                }
                else
                {
                    MessageBox.Show("Try again");
                    connection.Close();
                }
            }
        }
//Delete
        private void button3_Click(object sender, EventArgs e)
        {
            string Id = txtId.Text;

            string query = "DELETE FROM Evaluation WHERE Id= '" + Id+ "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int flag = command.ExecuteNonQuery();
            if (flag > 0)
            {
                displayButton.PerformClick();

            }
            connection.Close();
        }
//Update
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtId.Text == "")
                {
                    MessageBox.Show("Enter Name To Update");
                }
                else
                {
                    SqlCommand cmdupdate = new SqlCommand("Update Evaluation SET Id=('" + txtId.Text.ToString() + "'),Designition=('" + Convert.ToInt32(txtDesignition.Text) + "') ,Salary=('" + Convert.ToInt32(txtSalary.Text) + "') WHERE Id = '" + Convert.ToInt32(txtId.Text) + "';", connection);
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
//Display
        private void displayButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM  Evaluation";
            SqlCommand command = new SqlCommand(query, connection);



            DataTable myTable = new DataTable();
            SqlDataAdapter myAdapter = new SqlDataAdapter(command);
            myAdapter.Fill(myTable);
            adv_data.DataSource = myTable;
            connection.Close();
        }
//Linking
        private void button4_Click(object sender, EventArgs e)
        {
            Evaluation eva = new Evaluation();
            eva.Show();

        }
    }
}
