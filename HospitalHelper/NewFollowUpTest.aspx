<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewFollowUpTest.aspx.cs" Inherits="HospitalHelper.NewFollowUpTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" />
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
            SelectCommand="SELECT * FROM [TESTTYPE]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
            SelectCommand="SELECT * FROM [TESTITEM]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
