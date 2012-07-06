<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="HospitalHelper.PasswordChange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" Text="原密码："></asp:Label>
    <asp:TextBox ID="Topsw" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="Topsw" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
    <br /><br />
    <asp:Label runat="server" Text="新密码:"></asp:Label>
    <asp:TextBox ID="Tnpsw" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="Tnpsw" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
    <br /><br />
    <asp:Label runat="server" Text="确认密码"></asp:Label>
    <asp:TextBox ID="Tcpsw" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="Tcpsw" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
    <br />
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="Tcpsw" ControlToValidate="Tnpsw" ErrorMessage="两次密码输入不一样"></asp:CompareValidator>
    <br />
    <asp:Button ID="Bconfirm" runat="server" Text="提交" onclick="Bconfirm_Click" />
    

</asp:Content>