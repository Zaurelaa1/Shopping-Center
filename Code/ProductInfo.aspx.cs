using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final
{
    public partial class ProductInfo : System.Web.UI.Page
    {
        String product_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            ArrayList All_ProductIndices = new ArrayList();
            All_ProductIndices = (ArrayList)Session["Info_Product"];

            lbl_add_info.Visible = false;

            if (All_ProductIndices == null)
            {
                Response.Redirect("Default.aspx");
            }

            if (cookie != null)
            {

                product_id = Request.QueryString["id"];
                Panel_User_Info.Visible = true;
                lbl_user_name.Text = cookie["first_name"] + " " + cookie["last_name"];

                if (product_id != null && All_ProductIndices != null)
                {
                    try
                    {
                        int i = System.Convert.ToInt32(product_id);
                        
                        if(i<= All_ProductIndices.Count)
                        {
                            Product chosen_product = (Product)All_ProductIndices[i-1];
                            Panel_Info.Visible = false;
                            Panel_Product.Visible = true;

                            ImageButton_product.ImageUrl = chosen_product.ProductImage;
                            lbl_title.Text = chosen_product.ProductName;
                            lbl_category_black.Text = chosen_product.ProductCategoryName;
                            lbl_decription_black.Text = chosen_product.ProductDecription;
                            lbl_price_black.Text = chosen_product.ProductPrice.ToString() + " $";
                            lbl_brand_black.Text = chosen_product.ProductBrand;
                            lbl_quantity_black.Text = chosen_product.ProductQuantity.ToString(); 
                        }

                        else
                        {
                            Panel_Info.Visible = true;
                            Panel_Product.Visible = false;
                            hlbl_link.Visible = false;
                            Panel_User_Info.Visible = false;
                            lbl_info.Text = "Please specify a correct Product ID!";
                        }

                    }
                    catch (FormatException)
                    {
                        hlbl_link.Visible = false;
                        Panel_Product.Visible = false;
                        Panel_User_Info.Visible = false;
                        lbl_info.Text = "Please specify a correct Product ID!";
                    }
                    
                }
                else
                {
                    hlbl_link.Visible = false;
                    Panel_Product.Visible = false;
                    Panel_User_Info.Visible = false;
                    lbl_info.Text = "Please specify Product ID!";
                    
                }

            }
            else
            {
                Panel_Info.Visible = true;
                Panel_Product.Visible = false;
                Panel_User_Info.Visible = false;
            }

        }

        protected void btn_add_cart_Click(object sender, EventArgs e)
        {
            ArrayList SelectedProductIndices = (ArrayList)Session["CartInfo"];
            lbl_add_info.Visible = true;

            if (SelectedProductIndices != null)
            {
                if(SelectedProductIndices.Contains(product_id))
                {
                    lbl_add_info.Text = "Product is already in card";
                    lbl_add_info.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    SelectedProductIndices.Add(product_id);
                    lbl_add_info.Text = "Product is added to the cart";
                }
            }
            else
            {
                SelectedProductIndices = new ArrayList();
                SelectedProductIndices.Add(product_id);
                Session["CartInfo"] = SelectedProductIndices;
                lbl_add_info.Text = "Product is added to the cart";
                lbl_add_info.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btn_go_to_cart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void btn_go_default_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btn_log_out_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("Default.aspx");
        }
    }
}