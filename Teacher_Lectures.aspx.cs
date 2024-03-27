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
    public partial class Teacher_Lectures : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DrpCourse();
               


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
            if (DropDownList1.SelectedValue == "Select Course" || DropDownList2.SelectedValue == "Select Year" || DropDownList5.SelectedValue == "Select Semester" || DropDownList3.SelectedValue == "Select Subject" || string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                Label1.Text = "Please select all the fields";
                Label1.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                string date = TextBox1.Text.Trim();
                string course = DropDownList1.SelectedItem.Text;
                string year = DropDownList2.SelectedItem.Text;
                string subject = DropDownList3.SelectedItem.Text;
                string sem = DropDownList5.SelectedItem.Text;

                if (Session["TeacherID"] != null)
                {
                    string teacherID = Session["TeacherID"].ToString();

                    using (SqlConnection con = new SqlConnection(str))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("SELECT Date as Lecture_Date, LTaken as Lecture_Taken FROM T_Lectures WHERE TID = @TeacherID AND Course = @Course AND Year = @Year AND Sem = @Sem AND Subject = @Subject AND Date = @Date", con);
                        cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                        cmd.Parameters.AddWithValue("@Course", course);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Sem", sem);
                        cmd.Parameters.AddWithValue("@Subject", subject);
                        cmd.Parameters.AddWithValue("@Date", date);

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds, "T_Lectures");

                        if (ds.Tables["T_Lectures"].Rows.Count > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                        }
                        else
                        {
                            Label1.Text = "No lectures found for the specified criteria.";
                            Label1.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "An error occurred: " + ex.Message;
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            //    if (DropDownList1.SelectedValue == "Select Course" && DropDownList2.SelectedValue == "Select Year" && DropDownList5.SelectedValue == "Select Semester"  && DropDownList3.SelectedValue == "Select Subject" && TextBox1.Text=="")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList1.SelectedValue == "Select Course")
            //    {

            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (TextBox1.Text == "")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList2.SelectedValue == "Select Year")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList3.SelectedValue == "Select Subject")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList5.SelectedValue == "Select semester")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList1.SelectedValue == "Select Course" && DropDownList2.SelectedValue == "Select Year")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList1.SelectedValue == "Select Course" && DropDownList5.SelectedValue == "Select semester")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList1.SelectedValue == "Select Course" && DropDownList3.SelectedValue == "Select Subject")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList1.SelectedValue == "Select Course" && TextBox1.Text == " ")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList2.SelectedValue == "Select Year" && DropDownList5.SelectedValue == "Select semester")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList2.SelectedValue == "Select Year" && TextBox1.Text == " ")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList2.SelectedValue == "Select Year" && DropDownList3.SelectedValue == "Select Subject")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList5.SelectedValue == "Select semester" && TextBox1.Text == " ")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (DropDownList5.SelectedValue == "Select semester" && DropDownList3.SelectedValue == "Select Subject")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (TextBox1.Text == " " && DropDownList3.SelectedValue == "Select Subject")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else if (TextBox1.Text == " " && DropDownList3.SelectedValue == "Select Subject")
            //    {
            //        Label1.Text = "plz Select All The Fields";
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    else
            //    {
            //        string date = TextBox1.Text;
            //        string Course = DropDownList1.SelectedItem.Text;
            //        string year= DropDownList2.SelectedItem.Text;
            //        string subject= DropDownList3.SelectedItem.Text;
            //        string sem = DropDownList3.SelectedItem.Text;

            //        if (Session["TeacherID"]!=null)
            //        {
            //            string teacherID = Session["TeacherID"].ToString();

            //            SqlConnection con = new SqlConnection(str);
            //            SqlDataAdapter sda = new SqlDataAdapter("select Date as Lecture_Date,LTaken as Lecture_Taken from T_Lectures where TID='" + teacherID + "'and Course='" + Course + "' and Year='" + year + "' and Sem='" + sem + "'and Subject='" + subject + "' and Date='" + date + "'", con);
            //            DataSet ds = new DataSet();
            //            sda.Fill(ds,"T_Lectures");
            //            GridView1.DataSource = ds;
            //            GridView1.DataBind();

            //        }
            //    }

        }
    }
}