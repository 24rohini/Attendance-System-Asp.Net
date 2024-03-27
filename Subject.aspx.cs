using System;
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
    public partial class Subject : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridShow();
                ShowSubject();


            }

        }
        private void GridShow()
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course", con);

            con.Open();
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataTextField = "CourseName";
            DropDownList1.DataValueField = "CID";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select Course");
            con.Close();
        }
        private void ShowSubject()
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT CourseName as Course, Year, Sem as Semester, SubjectName as Subject FROM Subject", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            //SqlConnection con = new SqlConnection(str);
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT CourseName AS Course, Year, Sem AS Semester, SubjectName AS Subject FROM Subject", con);
            //DataTable dt = new DataTable();
            //con.Open();
            //sda.Fill(dt);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();

            // Get the selected value of DropDownList2
            string selectedYear = DropDownList2.SelectedValue;

            // Populate DropDownList3 based on the selected year
            if (selectedYear == "1")
            {
                // Add semesters for the first year
                DropDownList3.Items.Add(new ListItem("Sem I", "1"));
                DropDownList3.Items.Add(new ListItem("Sem II", "2"));
            }
            else if (selectedYear == "2")
            {
                // Add semesters for the second year
                DropDownList3.Items.Add(new ListItem("Sem III", "3"));
                DropDownList3.Items.Add(new ListItem("Sem IV", "4"));
            }
            else if (selectedYear == "3")
            {
                // Add semesters for the third year
                DropDownList3.Items.Add(new ListItem("Sem V", "5"));
                DropDownList3.Items.Add(new ListItem("Sem VI", "6"));
            }
            else
            {
                // Handle unexpected selection (optional)
                DropDownList3.Items.Add(new ListItem("Select Semester", "0"));
            }
            //if(int.Parse(DropDownList2.SelectedValue)>0)
            //{
            //    DataTable statedt = new DataTable();
            //    statedt.Columns.Add("SemId", typeof(int));
            //    statedt.Columns.Add("SemName");

            //    if(DropDownList2.SelectedValue=="1")
            //    {
            //        statedt.Rows.Add(1, "Sem I");
            //        statedt.Rows.Add(2, "Sem II");

            //    }
            //    if (DropDownList2.SelectedValue == "2")
            //    {
            //        statedt.Rows.Add(3, "Sem III");
            //        statedt.Rows.Add(4, "Sem IV");

            //    }

            //    if (DropDownList2.SelectedValue == "3")
            //    {
            //        statedt.Rows.Add(5, "Sem V");
            //        statedt.Rows.Add(6, "Sem VI");

            //    }
            //    DropDownList3.DataSource = statedt;
            //    DropDownList3.DataTextField = "SemName";
            //    DropDownList3.DataValueField = "SemID";
            //    DropDownList3.DataBind();
            //}

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //SqlConnection con2 = new SqlConnection(str);
            //SqlDataAdapter sda1 = new SqlDataAdapter("select * from Subject where CourseName'" + DropDownList1.SelectedItem.Text + "' and Year='" + DropDownList2.SelectedItem.Text + "' and Sem='" + DropDownList3.SelectedItem.Text + "' and SubjectName='" + TextBox1.Text.ToString() + "'", con2);
            //DataTable dt = new DataTable();
            //sda1.Fill(dt);
            //if (dt.Rows.Count == 1)
            //{
            //    Label1.Text = "The Subject" + TextBox1.Text.ToString() + "is already present for the selected Course=" + DropDownList1.SelectedItem.Text + ",Year=" + DropDownList2.SelectedItem.Text + "and Semester=" + DropDownList3.SelectedItem.Text + ".";
            //    Label1.ForeColor = System.Drawing.Color.Red;
            //}
            //else
            //{
            //    SqlConnection con = new SqlConnection(str);
            //    SqlDataAdapter sda = new SqlDataAdapter("select CID from Course where CourseName='" + DropDownList1.SelectedItem.Text + "'", con);
            //    DataSet ds = new DataSet();
            //    sda.Fill(ds, "Cousre");
            //    string cousreID = ds.Tables[0].Rows[0]["CID"].ToString();
            //    SqlConnection con1 = new SqlConnection(str);
            //    con1.Open();
            //    SqlCommand cmd = new SqlCommand("insert into Subject(CID,CourseName,Year,SubjectName,Sem) values (@1,@2,@3,@4,@5)", con1);
            //    cmd.Parameters.AddWithValue("@1", cousreID);
            //    cmd.Parameters.AddWithValue("@2", DropDownList1.SelectedItem.Text);
            //    cmd.Parameters.AddWithValue("@3", DropDownList2.SelectedItem.Text);
            //    cmd.Parameters.AddWithValue("@4", TextBox1.Text);
            //    cmd.Parameters.AddWithValue("@5", DropDownList3.SelectedItem.Text);
            //    cmd.ExecuteNonQuery();
            //    con1.Close();
            //    Label1.Text = "Subject Added Succesfuly";
            //    Label1.ForeColor = System.Drawing.Color.Green;
            //    clear();



            //}
            try
            {
                // Check if all necessary dropdowns are selected
                if (DropDownList1.SelectedItem == null || DropDownList2.SelectedItem == null || DropDownList3.SelectedItem == null)
                {
                    Label1.Text = "Please select Course, Year, and Semester.";
                    Label1.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Create a connection to the database
                using (SqlConnection con1 = new SqlConnection(str))
                {
                    // Open the database connection
                    con1.Open();

                    // Check if the subject already exists
                    SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM Subject WHERE CourseName = @CourseName AND Year = @Year AND Sem = @Sem AND SubjectName = @SubjectName", con1);
                    cmdCheck.Parameters.AddWithValue("@CourseName", DropDownList1.SelectedItem.Text);
                    cmdCheck.Parameters.AddWithValue("@Year", DropDownList2.SelectedItem.Text);
                    cmdCheck.Parameters.AddWithValue("@Sem", DropDownList3.SelectedItem.Text);
                    cmdCheck.Parameters.AddWithValue("@SubjectName", TextBox1.Text);
                    int existingSubjectsCount = (int)cmdCheck.ExecuteScalar();

                    // If subject already exists, display an error message
                    if (existingSubjectsCount > 0)
                    {
                        Label1.Text = "The Subject '" + TextBox1.Text + "' is already present for the selected Course='" + DropDownList1.SelectedItem.Text + "', Year='" + DropDownList2.SelectedItem.Text + "' and Semester='" + DropDownList3.SelectedItem.Text + "'.";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        // Insert the subject into the database
                        SqlCommand cmdInsert = new SqlCommand("INSERT INTO Subject (CourseName, Year, SubjectName, Sem) VALUES (@CourseName, @Year, @SubjectName, @Sem)", con1);
                        cmdInsert.Parameters.AddWithValue("@CourseName", DropDownList1.SelectedItem.Text);
                        cmdInsert.Parameters.AddWithValue("@Year", DropDownList2.SelectedItem.Text);
                        cmdInsert.Parameters.AddWithValue("@SubjectName", TextBox1.Text);
                        cmdInsert.Parameters.AddWithValue("@Sem", DropDownList3.SelectedItem.Text);
                        cmdInsert.ExecuteNonQuery();

                        // Display success message
                        Label1.Text = "Subject Added Successfully";
                        Label1.ForeColor = System.Drawing.Color.Green;

                        // Clear input fields
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message
                Label1.Text = "An error occurred: " + ex.Message;
                Label1.ForeColor = System.Drawing.Color.Red;
            }

        }
        private void clear()
        {
            DropDownList1.SelectedValue = "Select Course";
            ////DropDownList2.SelectedValue = "Select Year";
            ////DropDownList3.SelectedValue = "Select Semester";
            TextBox1.Text = "";
        }
        
    }
}