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
    public partial class Student_Defaulter : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["SiD"]==null)
                {
                    Response.Redirect("Login.aspx");

                }
                //Text1.Attributes.Add("autocomplete", "off");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["SiD"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                try
                {
                    string sid = Session["SiD"].ToString();
                    DateTime datetime = DateTime.Now; // Default to current date if Text1 is not set
                    if (!string.IsNullOrEmpty(Text1.Value))
                    {
                        datetime = Convert.ToDateTime(Text1.Value);
                    }

                    using (SqlConnection con = new SqlConnection(str))
                    {
                        con.Open();

                        // Retrieve the total number of lectures attended by the student
                        SqlCommand cmdAttendance = new SqlCommand("SELECT SUM(Lecture) FROM StudentAttendance WHERE YEAR(Date) = @Year AND MONTH(Date) = @Month AND STID = @SID", con);
                        cmdAttendance.Parameters.AddWithValue("@Year", datetime.Year);
                        cmdAttendance.Parameters.AddWithValue("@Month", datetime.Month); // Add @Month parameter
                        cmdAttendance.Parameters.AddWithValue("@SID", sid);
                        object totalLecturesAttendedObj = cmdAttendance.ExecuteScalar();
                        int totalLecturesAttended = totalLecturesAttendedObj != DBNull.Value ? Convert.ToInt32(totalLecturesAttendedObj) : 0;

                        // Retrieve the total lectures available for the corresponding course, year, and semester
                        SqlCommand cmdTotalLectures = new SqlCommand("SELECT SUM(LTaken) FROM T_Lectures WHERE Course = (SELECT Course FROM Student WHERE SID = @SID) AND Year = (SELECT Year FROM Student WHERE SID = @SID) AND Sem = (SELECT Sem FROM Student WHERE SID = @SID) AND YEAR(Date) = @Year AND MONTH(Date) = @Month", con);
                        cmdTotalLectures.Parameters.AddWithValue("@SID", sid);
                        cmdTotalLectures.Parameters.AddWithValue("@Year", datetime.Year);
                        cmdTotalLectures.Parameters.AddWithValue("@Month", datetime.Month);
                        object totalLecturesObj = cmdTotalLectures.ExecuteScalar();
                        int totalLectures = totalLecturesObj != DBNull.Value ? Convert.ToInt32(totalLecturesObj) : 0;

                        // Calculate percentage
                        float percentage = totalLectures != 0 ? ((float)totalLecturesAttended / totalLectures) * 100 : 0;

                        // Display results
                        Label1.Text = "Total Lectures Attended: " + totalLecturesAttended + " out of " + totalLectures;
                        Label2.Text = "Percentage: " + percentage.ToString("0.00") + "%";

                        // Check if the student is a defaulter
                        if (percentage < 40)
                        {
                            Label3.Text = "You are a defaulter for this month.";
                            Label3.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            Label3.Text = "You are not a defaulter for this month.";
                            Label3.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception
                    // For example, you can log the exception and display a user-friendly message
                    Label3.Text = "An error occurred: " + ex.Message;
                    Label3.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        //if (Session["SiD"]==null)
        //{
        //    Response.Redirect("Login.aspx");
        //}
        //else
        //{
        //    string sid = Session["SiD"].ToString();
        //    DateTime datetime = Convert.ToDateTime(Text1.Value);
        //    string datime = datetime.ToString("yyyy-MM");
        //    SqlConnection con = new SqlConnection(str);
        //    SqlDataAdapter sda = new SqlDataAdapter("select Lecture from StudentAttendace where DATEPART(yy,Date)='" + datetime.Year + "' and DATEPART(M,Date)='" + datetime.Month + "' and SID='" + sid + "'", con);
        //    DataSet ds = new DataSet();
        //    sda.Fill(ds, "StudentAttendance");
        //    int r = 0;
        //    int total = 0;
        //    int itotal;
        //    int ftotal;
        //    if (ds.Tables[0].Rows.Count>0)
        //    {
        //        for(int i = 0; i <= ds.Tables[0].Rows.Count-1;i++)
        //        {
        //            int days = Convert.ToInt32(((DataRow)ds.Tables[0].Rows[r])["Lecture"]);

        //            itotal = days;
        //            ftotal = (total + itotal);
        //            total = ftotal;
        //            r++;
        //        }
        //        SqlDataAdapter sda1 = new SqlDataAdapter("select Course,Year,Sem from Student where SID='" + sid + "'", con);
        //        DataSet ds1 = new DataSet();
        //        sda1.Fill(ds1, "Student");
        //        string course = ds1.Tables[0].Rows[0][0].ToString();
        //        string year = ds1.Tables[0].Rows[0][1].ToString();
        //        string sem= ds1.Tables[0].Rows[0][2].ToString();

        //        SqlDataAdapter sda2 = new SqlDataAdapter("select LTaken from T_Lectures where Course='" + course + "' and Year='" + year + "' and Sem='" + sem + "' and DATEPART(yy,Date)='" + datetime.Year + "' and DATEPART(M,Date)='" + datetime.Month + "'", con);
        //        DataSet ds2 = new DataSet();
        //        sda1.Fill(ds2, "T_Lectures");

        //        int r1 = 0;
        //        int total1 = 0;
        //        int itotal1, ftotal1;
        //        int x1, y1;
        //        float per;
        //        string totalTakenLectures, TotalLectureAttended;

        //        if (ds2.Tables[0].Rows.Count>0)
        //        {

        //            for (int i = 0; i <= ds2.Tables[0].Rows.Count-1;i++)
        //            {
        //                int days = Convert.ToInt32(((DataRow)ds2.Tables[0].Rows[r1])["LTaken"]);

        //                itotal1 = days;
        //                ftotal1 = (total1 + itotal1);
        //                total1 = ftotal1;
        //                r1++;
        //            }
        //            totalTakenLectures = total1.ToString();
        //            TotalLectureAttended = total.ToString();

        //            Label1.Text = "Total Lectures Attended:" + TotalLectureAttended + "/" + totalTakenLectures;

        //            x1 = Convert.ToInt32(totalTakenLectures);
        //            y1 = Convert.ToInt32(TotalLectureAttended);
        //            per = ((y1 * 100) / x1);
        //            Label2.Text = "Percentage:" + per + "%";
        //            if(per<40)
        //            {
        //                Label3.Text = "You are in Defaulter for this month(" + datetime + ").";
        //                Label3.ForeColor = System.Drawing.Color.Red;
        //            }


        //        }

        //    }
        //}
    }
    
}