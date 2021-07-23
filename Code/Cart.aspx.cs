using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class Cart : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList SelectedProductIndices = (ArrayList)Session["CartInfo"];

            HttpCookie cookie = Request.Cookies["UserInfo"];


            if (cookie != null)
            {

                if (SelectedProductIndices == null || SelectedProductIndices.Count == 0)
                {
                    Panel_User_Info.Visible = false;
                    Panel_Cart.Visible = false;
                    Panel_Info.Visible = true;
                    lbl_info.Text = "You're cart is empty! Return to the ";
                    lbl_info.ForeColor = System.Drawing.Color.Red;
                    hlbl_link.Text = "Main Page";
                    hlbl_link.ForeColor = System.Drawing.Color.Blue;
                    hlbl_link.NavigateUrl = "~/Default.aspx";
                }
                else
                {
                    Panel_Cart.Visible = true;
                    Panel_User_Info.Visible = true;
                    Panel_Info.Visible = false;
                    lbl_user_name.Text = cookie["first_name"] + " " + cookie["last_name"];
                    Show_Cart();
                }

            }
            else
            {
                Panel_Info.Visible = true;
                Panel_Cart.Visible = false;
                Panel_User_Info.Visible = false;
                lbl_info.Text = "You are not loged please ";
                hlbl_link.Text = "loging!";
                hlbl_link.NavigateUrl = "~/Login.aspx";
            }
        }

        public void Show_Cart()
        {
            ArrayList SelectedProductIndices = (ArrayList)Session["CartInfo"];

            int count = SelectedProductIndices.Count;

            for (int i = 0; i < count; i++)
            {
                Product temp = Find_Product(System.Convert.ToInt32(SelectedProductIndices[i]));
                Add_Product_Cart(temp, i);
            }
        }

        public void Add_Product_Cart(Product movie,int array_seq)
        {
            System.Web.UI.HtmlControls.HtmlTableRow r = new System.Web.UI.HtmlControls.HtmlTableRow();
            System.Web.UI.HtmlControls.HtmlTableCell c1 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl figure = new HtmlGenericControl("figure");
            figure.Attributes.Add("class", "media");

            HtmlGenericControl div_img_wrap = new HtmlGenericControl("div");
            div_img_wrap.Attributes.Add("class", "img-wrap");

            Image cell_image = new Image();
            cell_image.ImageUrl = movie.ProductImage;
            cell_image.CssClass = "img-thumbnail img-sm";
            cell_image.Width = 90;
            cell_image.Height = 120;
            div_img_wrap.Controls.Add(cell_image);

            HtmlGenericControl div_media_body = new HtmlGenericControl("div");
            div_media_body.Attributes.Add("class", "media-body");

            Label cell_label_title = new Label();
            cell_label_title.Text = movie.ProductName;
            cell_label_title.CssClass = "title text-truncate";
            div_media_body.Controls.Add(cell_label_title);

            figure.Controls.Add(div_img_wrap);
            figure.Controls.Add(div_media_body);

            c1.Controls.Add(figure);

            r.Cells.Add(c1);

            System.Web.UI.HtmlControls.HtmlTableCell c2 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl div_price_wrap_1 = new HtmlGenericControl("div");
            div_price_wrap_1.Attributes.Add("class", "price-wrap");

            Label cell_label_category = new Label();
            cell_label_category.Text = movie.ProductCategoryName;
            cell_label_category.CssClass = "title text-truncate";
            div_price_wrap_1.Controls.Add(cell_label_category);

            c2.Controls.Add(div_price_wrap_1);

            r.Cells.Add(c2);

            System.Web.UI.HtmlControls.HtmlTableCell c3 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl div_price_wrap_2 = new HtmlGenericControl("div");
            div_price_wrap_2.Attributes.Add("class", "price-wrap");

            Label cell_label_decription = new Label();
            cell_label_decription.Text = movie.ProductDecription;
            cell_label_decription.CssClass = "title text-truncate";
            div_price_wrap_2.Controls.Add(cell_label_decription);

            c3.Controls.Add(div_price_wrap_2);

            r.Cells.Add(c3);

            System.Web.UI.HtmlControls.HtmlTableCell c4 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl div_price_wrap_3 = new HtmlGenericControl("div");
            div_price_wrap_3.Attributes.Add("class", "price-wrap");

            Label cell_label_price = new Label();
            cell_label_price.Text = movie.ProductPrice.ToString() + " $";
            cell_label_price.CssClass = "title text-truncate";
            div_price_wrap_3.Controls.Add(cell_label_price);

            c4.Controls.Add(div_price_wrap_3);

            r.Cells.Add(c4);

            System.Web.UI.HtmlControls.HtmlTableCell c5 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl div_price_wrap_4 = new HtmlGenericControl("div");
            div_price_wrap_4.Attributes.Add("class", "price-wrap");

            Label cell_label_brand = new Label();
            cell_label_brand.Text = movie.ProductBrand;
            cell_label_brand.CssClass = "title text-truncate";
            div_price_wrap_4.Controls.Add(cell_label_brand);

            c5.Controls.Add(div_price_wrap_4);

            r.Cells.Add(c5);

            System.Web.UI.HtmlControls.HtmlTableCell c6 = new System.Web.UI.HtmlControls.HtmlTableCell();

            HtmlGenericControl div_price_wrap_5 = new HtmlGenericControl("div");
            div_price_wrap_5.Attributes.Add("class", "price-wrap");

            Label cell_label_quantity = new Label();
            cell_label_quantity.Text = movie.ProductQuantity.ToString();
            cell_label_quantity.CssClass = "title text-truncate";
            div_price_wrap_5.Controls.Add(cell_label_quantity);

            c6.Controls.Add(div_price_wrap_5);

            r.Cells.Add(c6);

            System.Web.UI.HtmlControls.HtmlTableCell c7 = new System.Web.UI.HtmlControls.HtmlTableCell();
            
            HtmlGenericControl div_price_wrap_6 = new HtmlGenericControl("div");
            div_price_wrap_5.Attributes.Add("class", "price-wrap text-right");

          

            c7.Controls.Add(div_price_wrap_6);

            r.Cells.Add(c7);

            Panel_element.Controls.Add(r);
            


        }

        public Product Find_Product(int id)
        {
            ArrayList All_ProductIndices = (ArrayList)Session["Info_Product"];

            Product temp = new Product(-1, "", -1, "", "","",-1, "");
            int count = All_ProductIndices.Count;

            for(int i=0;i<count;i++)
            {
                temp = (Product)All_ProductIndices[i];

                if(id == temp.ProductID)
                {
                    return temp;
                }
            }
            return temp;
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            ArrayList SelectedMovieIndices = (ArrayList)Session["CartInfo"];

            Button send = (Button)sender;
            String id = send.ID;
            id = id.Substring(id.Length - 1);

            SelectedMovieIndices.RemoveAt(System.Convert.ToInt32(id));
            Session["CartInfo"] = SelectedMovieIndices;

            Response.Redirect("Cart.aspx");

        }

        protected void btn_log_out_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("Default.aspx");
        }

        protected void btn_go_default_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}