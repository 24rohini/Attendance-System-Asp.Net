using Microsoft.CSharp.RuntimeBinder;
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
    public partial class Mark_Attendance : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            if (!IsPostBack)
            {
                DrpCourse();
                DateTime now = DateTime.Now;
                Label4.Text = "Today's Date:" + now;


            }

        }
        private void DrpCourse()
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course", con);
            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataTextField = "CourseName";
            DropDownList1.DataValueField = "CID";
            DropDownList1.DataBind();
            con.Close();
            DropDownList1.Items.Insert(0, "Select Course");
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int courseID = Convert.ToInt32(DropDownList1.SelectedValue);
            //string year = DropDownList2.SelectedItem.Text;
            //string sem = DropDownList5.SelectedItem.Text;
            //SqlConnection con = new SqlConnection(str);
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select * from Subject where CID='" + courseID + "'and Year='" + year + "' and Sem='" + sem + "'", con);
            //DropDownList3.DataSource = cmd.ExecuteReader();
            //DropDownList3.DataTextField = "SubjectName";
            //DropDownList3.DataValueField = "SID";
            //DropDownList3.DataBind();
            //DropDownList3.Items.Insert(0, "Select Subject");
            //con.Close();
            try
            {
                int courseID = Convert.ToInt32(DropDownList1.SelectedValue);
                string year = DropDownList2.SelectedItem?.Text;
                string sem = DropDownList5.SelectedItem?.Text;

                if (!string.IsNullOrEmpty(year) && !string.IsNullOrEmpty(sem))
                {
                    SqlConnection con = new SqlConnection(str);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Subject WHERE CID = @CourseID AND Year = @Year AND Sem = @Sem", con);
                    cmd.Parameters.AddWithValue("@CourseID", courseID);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@Sem", sem);

                    DropDownList3.DataSource = cmd.ExecuteReader();
                    DropDownList3.DataTextField = "SubjectName";
                    DropDownList3.DataValueField = "SID";
                    DropDownList3.DataBind();
                    DropDownList3.Items.Insert(0, "Select Subject");
                    con.Close();
                }
                else
                {
                    // Handle null or empty values for year or semester
                    // Example: Display an error message or clear DropDownList3
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                // Example: Display error message to the user
                Label1.Text = "An error occurred: " + ex.Message;
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Select Course" && DropDownList2.SelectedValue == "Select Year" && DropDownList5.SelectedValue == "Select Semester" && DropDownList4.SelectedValue == "Select " && DropDownList3.SelectedValue == "Select Subject")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList1.SelectedValue == "Select Course")
            {

                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList4.SelectedValue == "Select ")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList2.SelectedValue == "Select Year")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList3.SelectedValue == "Select Subject")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList5.SelectedValue == "Select semester")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList1.SelectedValue == "Select Course" && DropDownList2.SelectedValue == "Select Year")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList1.SelectedValue == "Select Course" && DropDownList5.SelectedValue == "Select semester")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList1.SelectedValue == "Select Course" && DropDownList3.SelectedValue == "Select Subject")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList1.SelectedValue == "Select Course" && DropDownList4.SelectedValue == "Select ")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList2.SelectedValue == "Select Year" && DropDownList5.SelectedValue == "Select semester")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList2.SelectedValue == "Select Year" && DropDownList4.SelectedValue == "Select ")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList2.SelectedValue == "Select Year" && DropDownList3.SelectedValue == "Select Subject")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList5.SelectedValue == "Select semester" && DropDownList4.SelectedValue == "Select ")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList5.SelectedValue == "Select semester" && DropDownList3.SelectedValue == "Select Subject")
            {
                Label1.Text = "plz Select All The Fields";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select SID,Roll,SName as StudentName from Student Where Course='" + DropDownList1.SelectedItem.Text + "' and Year='" + DropDownList2.SelectedItem.Text + "' and Sem='" + DropDownList5.SelectedItem.Text + "'", con);
                DataSet ds = new DataSet();
                sda.Fill(ds, "Student");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                con.Close(); ;


            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow row in GridView1.Rows)
                {
                    int Roll_No = Convert.ToInt32(row.Cells[2].Text);
                    string Stud_Name = row.Cells[3].Text;
                    int Stud_ID = Convert.ToInt32(row.Cells[1].Text);
                    RadioButton rb1 = (RadioButton)row.Cells[0].FindControl("RadioButton1"); // Corrected RadioButton reference
                    int status = rb1.Checked ? 1 : 0;

                    string course = DropDownList1.SelectedItem.Text;
                    string year = DropDownList2.SelectedItem.Text;
                    string subject = DropDownList3.SelectedItem.Text;
                    int Total_Lect = Int32.Parse(DropDownList4.SelectedItem.Text);
                    int TLecture = (Total_Lect * status); // Corrected calculation for taken lectures
                    string sem = DropDownList5.SelectedItem.Text;
                    DateTime date = DateTime.Now;

                    using (SqlConnection con = new SqlConnection(str))
                    {
                        con.Open();
                        // Insert into StudentAttendance table
                        SqlCommand cmd = new SqlCommand("INSERT INTO StudentAttendance (STID, StudentName, Course, Year, Subject, Roll, Status, Date, Lecture, Sem) VALUES (@1, @2, @3, @4, @5, @6, @7, @8, @9, @10)", con);
                        cmd.Parameters.AddWithValue("@1", Stud_ID);
                        cmd.Parameters.AddWithValue("@2", Stud_Name);
                        cmd.Parameters.AddWithValue("@3", course);
                        cmd.Parameters.AddWithValue("@4", year);
                        cmd.Parameters.AddWithValue("@5", subject);
                        cmd.Parameters.AddWithValue("@6", Roll_No);
                        cmd.Parameters.AddWithValue("@7", status);
                        cmd.Parameters.AddWithValue("@8", date);
                        cmd.Parameters.AddWithValue("@9", TLecture); // Updated parameter to reflect taken lectures
                        cmd.Parameters.AddWithValue("@10", sem);
                        cmd.ExecuteNonQuery();




                        // Insert into T_Lectures table
                       if (Session["TeacherID"] != null)
                        {
                            SqlCommand cmd1 = new SqlCommand("INSERT INTO T_Lectures (TID, TName, Date, LTaken, Course, Year, Subject, Sem) VALUES (@1, @2, @3, @4, @5, @6, @7, @8)", con);
                            cmd1.Parameters.AddWithValue("@1", Session["TeacherID"]);
                            cmd1.Parameters.AddWithValue("@2", Session["TeacherName"]);
                            cmd1.Parameters.AddWithValue("@3", date);
                            cmd1.Parameters.AddWithValue("@4", TLecture); // Updated parameter to reflect taken lectures
                            cmd1.Parameters.AddWithValue("@5", course);
                            cmd1.Parameters.AddWithValue("@6", year);
                            cmd1.Parameters.AddWithValue("@7", subject);
                            cmd1.Parameters.AddWithValue("@8", sem); // Corrected parameter index
                            cmd1.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }

                Label3.Text = "Attendance saved successfully";
                Label3.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                // Log or display the exception message
                Label3.Text = "An error occurred while saving attendance: " + ex.Message;
                Label3.ForeColor = System.Drawing.Color.Red;
            }
        }


    }
}
    


