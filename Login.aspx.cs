
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace AttendanceSystem
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from Teacher where TUserID=@UserID and Tpassword=@Password", con);
                sda.SelectCommand.Parameters.AddWithValue("@UserID", TextBox1.Text);
                sda.SelectCommand.Parameters.AddWithValue("@Password", TextBox2.Text);
                SqlDataAdapter sda1= new SqlDataAdapter("select * from Student where Email=@Email and Password=@Password", con);
                sda1.SelectCommand.Parameters.AddWithValue("@Email", TextBox1.Text);
                sda1.SelectCommand.Parameters.AddWithValue("@Password", TextBox2.Text);

                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                sda.Fill(dt);
                sda1.Fill(dt1);

                if (TextBox1.Text == "Admin" && TextBox2.Text == "123")
                {
                    Response.Redirect("Admin_Home.aspx");
                }
                else if (dt.Rows.Count == 1)
                {
                    Session["TeacherID"] = dt.Rows[0][0].ToString();
                    Session["TeacherName"] = dt.Rows[0][1].ToString();
                    Session["TUserID"] = TextBox1.Text;
                    Response.Redirect("Teacher_Home.aspx");
                }
                else if (dt1.Rows.Count == 1)
                {
                    Session["StudentEmail"] = TextBox1.Text;
                    int sid = Convert.ToInt32(dt1.Rows[0][0]);
                    Session["SiD"] = sid;
                    Response.Redirect("Student_Home.aspx");

                    
                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Login Failed.....";
                }
            }
        }
    }
}