<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="try.aspx.cs" Inherits="HospitalHelper._try" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button runat="server" Height="20" Width="100" Text="Click" 
            onclick="Unnamed1_Click" />
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
            SelectCommand="SELECT * FROM [TESTTYPE]"></asp:SqlDataSource>
                <div id="d1" runat=server>

                    <asp:Label ID="Label1" runat="server" Text="L1"></asp:Label>

                </div>
                <div id="d2" runat=server>

                    <asp:Label ID="Label2" runat="server" Text="L2"></asp:Label>

                </div>
    </form>
</body>
</html>
