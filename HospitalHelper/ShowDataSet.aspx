<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDataSet.aspx.cs" Inherits="HospitalHelper.ShowDataSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="病人ID"></asp:Label>
        <asp:TextBox ID="TPid" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="月份数"></asp:Label>
        <asp:TextBox ID="Tmonth" runat="server"></asp:TextBox>
    
        <asp:Button ID="Badd" runat="server" Text="添加" onclick="Badd_Click" />
    
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
            SelectCommand="SELECT * FROM [TESTTYPE]"></asp:SqlDataSource>
    
        <asp:Button ID="Bsubmit" runat="server" Text="提交" onclick="Bsubmit_Click" />
    
    </div>
    </form>
</body>
</html>
