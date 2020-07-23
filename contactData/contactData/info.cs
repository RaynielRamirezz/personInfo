using contactData.FormInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contactData
{
    public partial class info : Form
    {

        static string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public info()
        {
            InitializeComponent();
        }

        formInformation objectt = new formInformation();

        private void info_Load(object sender, EventArgs e)
        {
            DataTable dt = objectt.SelectQuery();
            dataGridView1.DataSource = dt;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            objectt.firstName = fName.Text;
            objectt.lastName = lName.Text;
            objectt.number = numberTextBox.Text;
            objectt.adress = adressTextBox.Text;
            objectt.gender = GenderBox.Text;

            bool success = objectt.insertValueQuery(objectt);

            if (success = true)
            {
                MessageBox.Show("Data succesfully added.");
                clearInfo();

            } else
            {
                MessageBox.Show("Data was not able to be added.");

            }

            DataTable dt = objectt.SelectQuery();
            dataGridView1.DataSource = dt;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            objectt.firstName = fName.Text;
            objectt.lastName = lName.Text;
            objectt.number = numberTextBox.Text;
            objectt.adress = adressTextBox.Text;
            objectt.gender = GenderBox.Text;
            objectt.id = Convert.ToInt32(idTextbox.Text);

            bool success = objectt.updateDataQuery(objectt);

            if (success = true)
            {
                MessageBox.Show("Data succesfully updated.");
                clearInfo();

            }
            else
            {
                MessageBox.Show("Data was not able to update. Try again later.");

            }

            DataTable dt = objectt.SelectQuery();
            dataGridView1.DataSource = dt;

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            int id = Convert.ToInt32(idTextbox.Text);
            //objectt.id = Convert.ToInt32(idTextbox.Text);

            bool success = objectt.deleteQuery(id);

            if (success = true)
            {
                MessageBox.Show("Data succesfully deleted.");
                clearInfo();

            }
            else
            {
                MessageBox.Show("Data was not able to be deleted. Try again later.");

            }

            DataTable dt = objectt.SelectQuery();
            dataGridView1.DataSource = dt;

        }     

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void clearInfo()
        {
            idTextbox.Text = null;
            fName.Text = null;
            lName.Text = null;
            numberTextBox.Text = null;
            adressTextBox.Text = null;
            GenderBox.Text = null;
            
        }

        private void searchTextbox_TextChanged(object sender, EventArgs e)
        {
                //database connection
                SqlConnection conn = new SqlConnection(connection);           
                // creating sqldataadapter using cmd
                SqlDataAdapter sda = new SqlDataAdapter("select * from tbl_info where firstName like '%" + searchTextbox.Text + "%'" + "or lastName like '%" + searchTextbox.Text + "%'" + "or id like '%" + searchTextbox.Text + "%'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);               
                dataGridView1.DataSource = dt;           
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearInfo();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // take the specific index of the row and place them on the corresponding textboxes
            int rowIndex = e.RowIndex;
            idTextbox.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            fName.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            lName.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            numberTextBox.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            adressTextBox.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            GenderBox.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
        }
     
    }
}
