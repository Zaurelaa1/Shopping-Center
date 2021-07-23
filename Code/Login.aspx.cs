using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];

            if (cookie != null)
            {
                Panel_Login.Visible = false;
                Panel_Info.Visible = true;
                
            }
            else
            {
                Panel_Login.Visible = true;
                Panel_Info.Visible = false;
            }
        }
        /*Event when clicking log in button*/
        protected void btn_login_Click(object sender, EventArgs e)
        { /* Error message in case of not entering name or surname*/
            if(txtBox_first_name.Text == "" || txtBox_last_name.Text == "")
            {
                lbl_error.Text = "Please enter First Name and Last Name";
                lbl_error.ForeColor = System.Drawing.Color.Red;
            }
            else
            { /* Otherwise redirection in to the Main Page*/
                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie["first_name"] = txtBox_first_name.Text.ToString();
                cookie["last_name"] = txtBox_last_name.Text.ToString();
                cookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(cookie);
                Response.Redirect("Default.aspx");
            }

        }

        protected void btn_ask_login_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("Login.aspx");
        }

        protected void btn_continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}