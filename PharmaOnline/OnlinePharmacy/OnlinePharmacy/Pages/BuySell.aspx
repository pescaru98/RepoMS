<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Template.Master" AutoEventWireup="true" CodeBehind="BuySell.aspx.cs" Inherits="OnlinePharmacy.Pages.BuySell" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .rounded-25 {
            border-radius: 25px !important;
        }

        .rounded-25-up {
            border-radius: 25px 25px 0px 0px !important;
        }

        .redClr {
            color: red !important;
        }
    </style>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.0/css/all.css" integrity="sha384-lZN37f5QGtY3VHgisS14W3ExzMWZxybE1SJSEsQp9S+oqd12jhcu+A56Ebc1zFSJ" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" row ">
        <div class="col-1"></div>
        <div class="col-4 rounded-25 shadow bg-white mt-5 pl-0 pr-0">
            <div class="rounded-25-up bg-primary font-weight-bold text-lg-center w-100 text-white text p-3 mb-3">
                Sell
            </div>
            <div class="text-lg-center">

                <div class="form-group mt-5" style="text-align: -webkit-center;">

                    <asp:TextBox ID="sellGit" type="number" AutoPostBack="True" CssClass="form-control col-10" runat="server" Width="254px" PlaceHolder="GitCoin Amount" OnTextChanged="sellGit_TextChanged"></asp:TextBox>
                   <!-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="redClr" runat="server" ControlToValidate="sellGit" ErrorMessage="Please enter a value" ForeColor="Red"></asp:RequiredFieldValidator> -->
                </div>
                <i class="fa fa-exchange-alt"></i>
                <div class="form-group mt-4 mb-4" style="text-align: -webkit-center;">

                    <asp:TextBox ID="sellDollar" ReadOnly="true" type="number" CssClass="form-control col-10" runat="server" Width="254px" PlaceHolder="Dollar Amount" OnTextChanged="sellDollar_TextChanged"></asp:TextBox>
                </div>

                <asp:Button ID="sellBtn" type="button"  runat="server" CssClass="btn btn-primary col-8 mb-4" OnClick="Button1_Click" Text="Sell" Width="214px" />
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-4 rounded-25 shadow bg-white mt-5 pl-0 pr-0">
            <div class="rounded-25-up bg-primary font-weight-bold text-lg-center w-100 text-white text p-3 mb-3">
                Buy
            </div>
            <div class="text-lg-center">

                <div class="form-group mt-5" style="text-align: -webkit-center;">

                    <asp:TextBox ID="buyGit" type="number" AutoPostBack="True" CssClass="form-control col-10" runat="server" Width="254px" PlaceHolder="GitCoin Amount" OnTextChanged="buyGit_TextChanged"></asp:TextBox>
                  <!--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="redClr" runat="server" ControlToValidate="buyGit" ErrorMessage="Please enter a value" ForeColor="Red"></asp:RequiredFieldValidator> -->
                </div>
                <i class="fa fa-exchange-alt"></i>
                <div class="form-group mt-4 mb-4" style="text-align: -webkit-center;">

                    <asp:TextBox ID="buyDollar" ReadOnly="true" type="number" CssClass="form-control col-10" runat="server" Width="254px" PlaceHolder="Dollar Amount"></asp:TextBox>
                </div>

                <asp:Button ID="buyBtn" type="button" runat="server" CssClass="btn btn-primary col-8 mb-4" OnClick="Button2_Click" Text="Buy" Width="214px" />
            </div>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
