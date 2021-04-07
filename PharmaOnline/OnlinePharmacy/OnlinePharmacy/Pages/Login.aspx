<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlinePharmacy.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <style type="text/css">
        .auto-style2 {
            font-size: xx-large;
            text-align: center;
        }

        .auto-style3 {
            width: 100%;
        }

        .auto-style5 {
            width: 480px;
            text-align: center;
        }

        .auto-style6 {
            width: 320px;
            text-align: center;
        }

        .auto-style7 {
            text-align: center;
        }

        .auto-style8 {
            text-align: left;
        }

        .auto-style9 {
            width: 480px;
            text-align: right;
        }
        
        .rounded-25{
            border-radius:25px !important;
        }
        body{
            width:100% !important;
            height: 100% !important;
            background-image: url("https://i.pinimg.com/originals/06/5a/e5/065ae5ade83875101e58d2657b76ea90.gif");
            background-size:cover !important;
            text-align: -webkit-center !important;
        }

        .form-logreg{
            opacity:0.7 !important;
        }

        .form-logreg:hover{
            opacity:1 !important;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server" style="text-align: center;" class="w-100 container row justify-content-center mt-5 ">

        <div class="form-logreg bg-white rounded-25" style="border:1px solid #007bff;width:25em;">

            <div class="mb-5 " style="background:#007bff;border-radius:25px;">
                <strong >
                    <br />
                    <div  style="color:white;font-size:40px;">Login </div>
                    <br />
                </strong>
            </div>
            <div class="form-group" style="text-align: -webkit-center;">
                <label for="txtUser" style="color:#007bff;">Username</label>
                <asp:TextBox ID="txtUser" CssClass="form-control col-10" runat="server" Width="254px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUser" ErrorMessage="Please enter Username" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group" style="text-align: -webkit-center;">
                <label for="txtUser" style="color:#007bff;">Password</label>

                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control col-10" TextMode="Password"  Width="252px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPass" ErrorMessage="Please enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <br />
            <a href="/Pages/Register.aspx"> Register now </a>
            <br /><br />
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary col-8" OnClick="Button1_Click" Text="Login" Width="214px" /> <br /><br /> <br />
        </div>
    </form>
</body>
</html>
