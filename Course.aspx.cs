using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace AttendanceSystem
{
    public partial class Course : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridShow();
            }
        }
        private void GridShow()
        {
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Course", conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridShow();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridShow();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int CourseID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("Delete from Course where CID=@1", con1);

            cmd1.Parameters.AddWithValue("@1", CourseID);
            cmd1.ExecuteNonQuery();
            con1.Close();
            Label1.Text = "Course Deleted Succesful";
            Label1.ForeColor = System.Drawing.Color.DarkGreen;
            GridShow();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridShow();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int CID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

            string CourseName = (row.FindControl("TextBox2") as TextBox).Text;
            SqlConnection con2 = new SqlConnection(str);
            con2.Open();



            SqlCommand cmd1 = new SqlCommand("Update Course set CourseName=@1 where CID=@2", con2);
            cmd1.Parameters.AddWithValue("@1", CourseName);
            cmd1.Parameters.AddWithValue("@2", CID);
            cmd1.ExecuteNonQuery();

            con2.Close();
            Label1.Text = "Course Updated Succesful";
            Label1.ForeColor = System.Drawing.Color.DarkGreen;
            GridView1.EditIndex = -1;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //SqlConnection con1 = new SqlConnection(str);

            //SqlDataAdapter sda = new SqlDataAdapter("select * from Course where CourseName='" + TextBox1.Text.ToString() + "' ", con1);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //if(dt.Rows.Count==1)
            //{
            //    Label1.Text = "This Course is Already Present";
            //    Label1.ForeColor = System.Drawing.Color.Red;

            //}
            //else
            //{

            //    SqlConnection con = new SqlConnection(str);
            //    SqlCommand cmd = new SqlCommand("INSERT INTO Course (CourseName) VALUES ('"+TextBox1.Text+"')", con);

            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();
            //    Label1.Text = "Course Added Successfully";
            //    Label1.ForeColor = System.Drawing.Color.DarkGreen;
            //    TextBox1.Text = "";
            //    GridShow();
            //}
            //SqlConnection con = new SqlConnection(str);

            //// Check if the course already exists
            //SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Course WHERE CourseName = @CourseName", con);
            //sda.SelectCommand.Parameters.AddWithValue("@CourseName", TextBox1.Text);

            //DataTable dt = new DataTable();
            //sda.Fill(dt);

            //if (dt.Rows.Count > 0)
            //{
            //    // Course already exists
            //    Label1.Text = "This Course is Already Present";
            //    Label1.ForeColor = System.Drawing.Color.Red;
            //}
            //else
            //{
            //    // Get the maximum CID value and increment it by 1
            //    SqlCommand getMaxCID = new SqlCommand("SELECT ISNULL(MAX(CID), 0) FROM Course", con);
            //    con.Open();
            //    int nextCID = Convert.ToInt32(getMaxCID.ExecuteScalar()) + 1;
            //    con.Close();

            //    // Insert the new course with the next available CID value
            //    SqlCommand cmd = new SqlCommand("INSERT INTO Course (CID, CourseName) VALUES (@CID, @CourseName)", con);
            //    cmd.Parameters.AddWithValue("@CID", nextCID);
            //    cmd.Parameters.AddWithValue("@CourseName", TextBox1.Text);

            //    try
            //    {
            //        con.Open();
            //        cmd.ExecuteNonQuery();
            //        Label1.Text = "Course Added Successfully";
            //        Label1.ForeColor = System.Drawing.Color.DarkGreen;
            //        TextBox1.Text = "";
            //        GridShow(); // Rebind the GridView to display the newly added course
            //    }
            //    catch (Exception ex)
            //    {
            //        // Handle the exception
            //        Label1.Text = "An error occurred while adding the course: " + ex.Message;
            //        Label1.ForeColor = System.Drawing.Color.Red;
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //}
            SqlConnection con = new SqlConnection(str);

            // Check if the course already exists
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Course WHERE CourseName = @CourseName", con);
            sda.SelectCommand.Parameters.AddWithValue("@CourseName", TextBox1.Text);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Course already exists
                Label1.Text = "This Course is Already Present";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // Insert the new course
                SqlCommand cmd = new SqlCommand("INSERT INTO Course (CourseName) VALUES (@CourseName)", con);
                cmd.Parameters.AddWithValue("@CourseName", TextBox1.Text);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Label1.Text = "Course Added Successfully";
                    Label1.ForeColor = System.Drawing.Color.DarkGreen;
                    TextBox1.Text = "";
                    GridShow(); // Rebind the GridView to display the newly added course
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    Label1.Text = "An error occurred while adding the course: " + ex.Message;
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                finally
                {
                    con.Close();
                }
                GridShow();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            //{
            //    TextBox txtCID = (TextBox)e.Row.FindControl("txtCID");
            //    txtCID.Text = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
            //}
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
//System.Data.SqlClient.SqlException: 'Cannot insert the value NULL into column 'CID', table 'Attendance.dbo.Course'; column does not allow nulls. INSERT fails.
//The statement has been terminated.'