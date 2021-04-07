<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Template.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlinePharmacy.Pages.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .rounded-25 {
            border-radius: 25px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="../JSServices/UtilService.js"></script>
    <script src="../JSServices/GitCoinService.js"></script>
    <script src="../JSServices/XMLService.js"></script>

        <div>
            <canvas id="myChart" class="w-75 h-25 bg-white rounded-25 shadow p-2 m-2 "></canvas>
        </div>
    <script>

        let myLineChart;
        let xml = "../XML/gitcoinrecord.xml"
        let gitcoinrecordsObj = [];
        let gitcoinrecordsObjCopy = [];
        let ctx = document.getElementById('myChart');


        gitcoinrecordsObj = getXMLObj(xml);
        gitcoinrecordsObj = getLatestN(30,gitcoinrecordsObj);
        const chartDatas = getDataOfArray(gitcoinrecordsObj);
        const config2 = {
            type: 'line',
            data: chartDatas,
            options: {}
        };
        myLineChart = new Chart(ctx, config2);
        setInterval(function () {

            gitcoinrecordsObj = getXMLObj(xml);
            //console.log(gitcoinrecordsObj);
            gcrDiff = getArrayDiff(gitcoinrecordsObjCopy, gitcoinrecordsObj);
            //gitcoinrecordsObj = getLatestN(10, gitcoinrecordsObj);

            myLineChart.update();
            gitcoinrecordsObjCopy = gitcoinrecordsObj;
        }, 2500);





    </script>

</asp:Content>
