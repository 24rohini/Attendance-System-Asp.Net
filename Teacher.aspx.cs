﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceSystem
{
    public partial class Teacher : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridShow();
        }
        private void GridShow()
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select TName as Name,TUserID as EmailID from Teacher", con);
            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con2 = new SqlConnection(str);
            //SqlDataAdapter sda1 = new SqlDataAdapter("Select * from Teacher where  TUserID='" + TextBox3.Text.ToString() + "'", con2);
            //DataTable dt = new DataTable();
            //sda1.Fill(dt);
            //if (dt.Rows.Count == 1)
            //{
            //    Label1.Text = "Entered email id is already existing";
            //    Label1.ForeColor = System.Drawing.Color.Red;
            //}
            //else
            //{
            //    string Fname = TextBox2.Text;
            //    string Lname = TextBox4.Text;
            //    string FullName = Fname + Lname;
            //    SqlConnection con = new SqlConnection(str);
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("insert into Teacher(TName,TUserID,TPassword) values(@1,@2,@3)", con);
            //    cmd.Parameters.AddWithValue("@1", FullName);
            //    cmd.Parameters.AddWithValue("@2", TextBox3.Text);
            //    cmd.Parameters.AddWithValue("@3", TextBox1.Text);
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    Label1.Text = "Successfully added";
            //    Label1.ForeColor = System.Drawing.Color.Green;
            //    TextBox2.Text = "";
            //    TextBox3.Text = "";
            //    TextBox1.Text = "";
            //    TextBox4.Text = "";

            //}
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; // Retrieve connection string from configuration

            try
            {
                using (SqlConnection con2 = new SqlConnection(connectionString))
                {
                    con2.Open();

                    // Check if the email already exists
                    using (SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * FROM Teacher WHERE TUserID = @TUserID", con2))
                    {
                        sda1.SelectCommand.Parameters.AddWithValue("@TUserID", TextBox3.Text.Trim());

                        DataTable dt = new DataTable();
                        sda1.Fill(dt);

                        if (dt.Rows.Count == 1)
                        {
                            Label1.Text = "Entered email id is already existing";
                            Label1.ForeColor = System.Drawing.Color.Red;
                            return; // Exit the function
                        }
                    }

                    // If the email doesn't exist, proceed with insertion
                    string Fname = TextBox2.Text.Trim();
                    string Lname = TextBox4.Text.Trim();
                    string FullName = Fname + " " + Lname; // Assuming you want a space between first and last name

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Teacher (TName, TUserID, TPassword) VALUES (@TName, @TUserID, @TPassword)", con))
                        {
                            cmd.Parameters.AddWithValue("@TName", FullName);
                            cmd.Parameters.AddWithValue("@TUserID", TextBox3.Text.Trim());
                            cmd.Parameters.AddWithValue("@TPassword", TextBox1.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }
                    }

                    Label1.Text = "Successfully added";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox1.Text = "";
                    TextBox4.Text = "";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.Message;
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            GridShow();
        }
        
    }
    
}