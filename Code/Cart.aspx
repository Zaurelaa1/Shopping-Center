<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Final.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous">
</head>
<body>
    <form id="form1" class="alert-dark" runat="server">

        <header>
            <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #eacbf2;">
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                    <a class="navbar-brand" href="#">
                        
                    </a>
                    <a class="navbar-brand text-primary font-weight-bold" href="Default.aspx" >SHOPPING CENTER</a>
                </div>
            </nav>
        </header>

        <div>
            <br />
            <asp:Panel ID="Panel_Info" runat="server">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_info" runat="server" CssClass="text-danger" Text="You are not loged! Please "></asp:Label>
                &nbsp;<asp:HyperLink ID="hlbl_link" Navigate="Login.aspx" runat="server" CssClass="text-warning" Text="LOGIN!" NavigateUrl="~/Login.aspx"></asp:HyperLink>

            </asp:Panel>
        </div>


        <div class="container-fluid card-deck">
            <div class="row">
                <div class="col-2">
                    <asp:Panel ID="Panel_User_Info" runat="server">
                        <div class="card text-center">
                            <div class="card-body bg-dark">
                                <div>
                               
                                    <asp:Label ID="lbl_welcome" runat="server" Text=" Welcome " CssClass="text-primary"></asp:Label><br />
                                    <asp:Label ID="lbl_user_name" runat="server" Text="Label" CssClass="text-primary"></asp:Label>
                                </div>
                                <br />

                                <br />
                                <asp:Button ID="btn_log_out" runat="server" Text="Log Out" CssClass="btn btn-primary btn-block" BackColor="#eacbf2" BorderColor="#eacbf2" ClientIDMode="Predictable" ForeColor="Black" OnClick="btn_log_out_Click" />

                            </div>
                        </div>
                    </asp:Panel>
                </div>

                <div class="col-10 text-center">
                    <asp:Panel ID="Panel_Cart" runat="server">

                        <br>
                        <div class="text-center">
                            <asp:Label ID="Label_cart_header" runat="server" CssClass="font-weight-bold h3" ForeColor="#d442f5" Text="Shopping Cart" Font-Bold="True"></asp:Label>
                        </div>
                        <hr>

                        <div class="card alert-dark">
                            <table class="table table-hover shopping-cart-wrap" id="T">
                                <thead class="text-muted">
                                    <tr class="text-center" ForeColor="#d442f5">
                                        <th scope="col" width="400">Product</th>
                                        <th scope="col" width="110">Category</th>
                                        <th scope="col" width="110">Description</th>
                                        <th scope="col" width="110">Price</th>
                                        <th scope="col" width="110">Brand</th>
                                        <th scope="col" width="110">Quantity</th>
                                        <th scope="col" width="110"></th>
                                    </tr>
                                </thead>


                                <tbody>
                                    <asp:Panel ID="Panel_element" runat="server">
                                    </asp:Panel>
                                </tbody>

                            </table>
                            <br /><br />

                       
                    </asp:Panel>
                </div>
            </div>
        </div>

        <div class="container">
        </div>
    </form>

    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>

</body>
</html>
