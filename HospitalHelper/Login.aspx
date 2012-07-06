<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="HospitalHelper._Default" %>
     <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
</head>
<body>
<form id="form1" runat="server">
<asp:Label ID="Luser" runat="server" Text="用户名 ："></asp:Label>

<asp:TextBox ID="Tuser" runat="server" Height="22px"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ControlToValidate="Tuser" ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator>
<%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
    ControlToValidate="Tuser" ErrorMessage="只能输入数字且不超过10位" 
    ValidationExpression="^\d{1,10}"></asp:RegularExpressionValidator>--%>
<br />
<asp:Label ID="Lpsw" runat="server" Text="密码 ："></asp:Label>&nbsp;&nbsp;
<asp:TextBox ID="Tpsw" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
    ControlToValidate="Tpsw" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
<br />

<br />
<asp:Button ID="Blogin" runat="server" Text="登陆" onclick="Blogin_Click" />


</form>
</body>
</html>