using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactData.FormInfo
{
    class formInformation
    {
        // get properties
        // data to store in database
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string number { get; set; }
        public string adress { get; set; }
        public string gender { get; set; }

        //connection to database
         static string connection = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        //selecting data from database

        public DataTable SelectQuery()
        {
            //database connection
            SqlConnection conn = new SqlConnection(connection);
            DataTable table = new DataTable();

            try
            {
                // sql queary
                string sql = "Select * from tbl_info";
                //creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // creating sqldataadapter using cmd
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                conn.Open();
                sda.Fill(table);
            }
            catch(Exception ex)
            {


            }
            finally
            {

                conn.Close();
            }
            return table;
        }
        //inserting data to database

        public bool insertValueQuery(formInformation e)
        {
            //creating a default return type and setting its value to false
            bool isCorrect = false;
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                // sql queary
                string sql = "insert into tbl_info(firstName, lastName, contactNum ,adress, gender) values (@firstName, @lastName, @contactNum, @adress, @gender)";
                //creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@firstName", e.firstName);
                cmd.Parameters.AddWithValue("@lastName", e.lastName);
                cmd.Parameters.AddWithValue("@contactNum", e.number);
                cmd.Parameters.AddWithValue("@adress", e.adress);
                cmd.Parameters.AddWithValue("@gender", e.gender);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the queary runs succesful then the value of rows will be greater than 0 
                // else its value will be 0 

                if(rows > 0)
                {
                    isCorrect = true;
                }
                else 
                {
                    isCorrect = false;
                }
                
            }
            catch (Exception ex)
            {


            }
            finally
            {

                conn.Close();
            }

            return isCorrect;


        }


        public bool updateDataQuery(formInformation e)
        {
            bool isCorrect = false;
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                // sql queary
                string sql = "update tbl_info set firstName=@firstName, lastName=@lastName, contactNum=@contactNum, adress=@adress,gender=@gender where id=@id";
                //creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@firstName", e.firstName);
                cmd.Parameters.AddWithValue("@lastName", e.lastName);
                cmd.Parameters.AddWithValue("@contactNum", e.number);
                cmd.Parameters.AddWithValue("@adress", e.adress);
                cmd.Parameters.AddWithValue("@gender", e.gender);
                cmd.Parameters.AddWithValue("@id", e.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the queary runs succesful then the value of rows will be greater than 0 
                // else its value will be 0 

                if (rows > 0)
                {
                    isCorrect = true;
                }
                else
                {
                    isCorrect = false;
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {

                conn.Close();
            }

            return isCorrect;

        }

        public bool deleteQuery(int e)
        {

            bool isCorrect = false;
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                // sql queary
                string sql = "delete from tbl_info where id=@id";
                //creating sql command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", e);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // if the queary runs succesful then the value of rows will be greater than 0 
                // else its value will be 0 

                if (rows > 0)
                {
                    isCorrect = true;
                }
                else
                {
                    isCorrect = false;
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {

                conn.Close();
            }

            return isCorrect;

        }

    }
}
