<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Menu.Master" 
CodeBehind="OperatorManager.aspx.cs" Inherits="HospitalHelper.OperatorManager" %>

 <asp:Content ID="Content1" ContentPlaceHolderID ="ContentPlaceHolder1" runat="server">
        
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataKeyNames="HID" DataSourceID="SqlDataSource1" AllowPaging="True" PageIndex="1">
        <Columns>
            <asp:BoundField DataField="HID" HeaderText="用户名" SortExpression="HID" 
                 />
            <asp:BoundField DataField="PSW" HeaderText="密码" SortExpression="PSW" />
            <asp:CheckBoxField DataField="LIM" HeaderText="权限" SortExpression="LIM" />
            <asp:CommandField CancelText="取消" DeleteText="删除" EditText="修改" HeaderText="修改" 
                InsertText="插入" ShowEditButton="True" UpdateText="修改" />
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Delete" onclientclick="return confirm('确认要删除吗？')">删除</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerSettings FirstPageText="第一页" LastPageText="最后一页" 
            Mode="NumericFirstLast" />
    </asp:GridView>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
         SelectCommand="SELECT * FROM [OPERATOR]" 
         DeleteCommand="DELETE FROM [OPERATOR] WHERE [HID] = @HID" 
         
         UpdateCommand="UPDATE [OPERATOR] SET [PSW] = @PSW, [LIM] = @LIM WHERE [HID] = @HID" 
         InsertCommand="INSERT INTO [OPERATOR] ([HID], [PSW], [LIM]) VALUES (@HID, @PSW, @LIM)" 
         >
        <DeleteParameters>
            <asp:Parameter Name="HID" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="HID" Type="String" />
            <asp:Parameter Name="PSW" Type="String" />
            <asp:Parameter Name="LIM" Type="Boolean" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="PSW" Type="String" />
            <asp:Parameter Name="LIM" Type="Boolean" />
            <asp:Parameter Name="HID" Type="String" />
        </UpdateParameters>
        
        </asp:SqlDataSource>
       
     <asp:Label runat="server" Text="添加用户名"></asp:Label>
     <asp:TextBox ID="Taduser" runat="server"></asp:TextBox>
     <br />
      <asp:Label ID="Label2" runat="server" Text="添加密码"></asp:Label>
     <asp:TextBox ID="Tadpsw" runat="server"></asp:TextBox>
     
     <asp:Button ID="Bcfirm" runat="server" Text="确认添加" onclick="Bcfirm_Click"/>
    <br />

</asp:Content>