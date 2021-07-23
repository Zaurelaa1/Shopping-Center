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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList All_ProductIndices = new ArrayList();
            
            HttpCookie cookie = Request.Cookies["UserInfo"];

            
            /*Cookie check containig the first_name and last_name*/
            if (cookie!=null)
            {
                Panel_Info.Visible = false;
                Panel_User_Info.Visible = true;
                Panel_Product.Visible = true;
                lbl_user_name.Text = cookie["first_name"] + " " + cookie["last_name"];
                
                /* 6 Products with their information that will be availble into the Main Paige*/
                Product Product_1 = new Product(1, "Razer Kraken Tornament Edition", 59.99, "images/headphones.jpg", "THX 7.1 Surround Sound Gaming HeadSet","RAZER",1, "ACCESORIES");
                Product Product_2 = new Product(2, " A515-46-R14K Slim Laptop", 379.99, "images/laptop.jpg", "15.6 Full HD IPS AMD Ryzen 3 3350U Quad-Core Mobile Processor","ACER Aspire",2, "LAPTOPS");
                Product Product_3 = new Product(3, "Gaming PC Desktop Computer", 400.05, "images/gaming_pc.jpg", "Intel Core i5-240 3.10 GHz B75 LGA", "ALARCO Intel",3, "DESKTOP COMPUTER");
                Product Product_4 = new Product(4, "Iphone 12 Pro", 2215.99, "images/iphone12.jpg","512GB Pacific Blue Bionic the fastest chip in a smartphone", "APPEL",4, "PHONE");
                Product Product_5 = new Product(5, "Essential T-shirt", 20.59, "images/t-shirt.jpg","Amazon Web Services-tshirt Size: Medium", "AWS",5, "T-SHIRTS");
                Product Product_6 = new Product(6, "Gucci Bloom", 49.99, "images/gucci-bloom.jpg", " A scent designed to celebrate the authenticity, vitality and diversity of women", "Gucci", 6, "PARFUMES");

                All_ProductIndices.Add(Product_1);
                All_ProductIndices.Add(Product_2);
                All_ProductIndices.Add(Product_3);
                All_ProductIndices.Add(Product_4);
                All_ProductIndices.Add(Product_5);
                All_ProductIndices.Add(Product_6);
                Session["Info_Product"] = All_ProductIndices;

                Add_Product_Cart(Product_1);
                Add_Product_Cart(Product_2);
                Add_Product_Cart(Product_3);
                Add_Product_Cart(Product_4);
                Add_Product_Cart(Product_5);
                Add_Product_Cart(Product_6);

            }
            else
            {
                Panel_Info.Visible = true;
                Panel_User_Info.Visible = false;
                Panel_Product.Visible = false;
            }
        }

        /*Add_Product_Cart in order to add the Products clicked into the Cart*/
        public void Add_Product_Cart(Product product)
        {
            HtmlGenericControl div_card = new HtmlGenericControl("div");
            div_card.Attributes.Add("class", "card bg-light text-center");

            HtmlGenericControl div_card_body = new HtmlGenericControl("div");
            div_card_body.Attributes.Add("class", "card-body");

            ImageButton btn_product = new ImageButton();
            btn_product.ID = "ImageButton" + product.ProductID.ToString();
            btn_product.CssClass = "card-img-top";
            btn_product.Click += product_Click;
            btn_product.Width = 300;
            btn_product.Height = 400;
            btn_product.ImageUrl = product.ProductImage;

            div_card_body.Controls.Add(btn_product);

            div_card.Controls.Add(div_card_body);

            Panel_element.Controls.Add(div_card);
        }

        /*Event when clicking the log out button in the Main Page that will display a Message and a link to rederict to LogIn*/
        protected void btn_log_out_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("Default.aspx");
        }

        /*Event that will redirect into the Cart.aspx when clicking to the image_shopping_card*/
        protected void img_shoping_cart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void product_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton send = (ImageButton)sender;
            String id = send.ID;
            id = id.Substring(id.Length - 1);
            Response.Redirect("ProductInfo.aspx?id=" + id);
        }
    }
}