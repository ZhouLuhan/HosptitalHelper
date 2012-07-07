<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewFollowUpProspect.aspx.cs" Inherits="HospitalHelper.NewFollowUpProspect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lTime" runat="server" Text="时间"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tTime" runat="server"></asp:TextBox>
    
        <br />
        <asp:Label ID="lDescription" runat="server" Text="描述"></asp:Label>
        <br />
        <asp:TextBox ID="tDescription" runat="server" Height="226px" Width="666px"></asp:TextBox>
    
        <br />
        <asp:Label ID="lTag" runat="server" Text="标签"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tTag" runat="server" Width="584px"></asp:TextBox>
    
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lComment1" runat="server" Text="*不同的标签项目用逗号隔开"></asp:Label>
    
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lDoctor" runat="server" Text="落款"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tDoctor" runat="server"></asp:TextBox>
    
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bNext" runat="server" Text="下一步" onclick="bNext_Click" />
    
    </div>
    </form>
</body>
</html>
