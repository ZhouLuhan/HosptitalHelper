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

        <asp:Button ID="Bgrid" runat="server" Text="表格" BorderWidth="0" OnClick="Bchos_Click" />
        <asp:Button ID="Bpic" runat="server" Text="图形" BorderWidth="0" OnClick="Bchos_Click" />
    <asp:MultiView ID="Mchos" runat="server" ActiveViewIndex="0">
    <asp:View ID="View1" runat="server">
    <asp:GridView ID="gird" runat="server" />
    </asp:View>
    <asp:View ID="View2" runat="server">
<%--    <asp:Label ID="Lpic" runat="server" Text="Picture" />--%>
<br />
    <asp:Image ID="Ipic" runat="server" />
    </asp:View>
    </asp:MultiView>
    </div>
    </form>
</body>
</html>
