<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicalExamType.aspx.cs" Inherits="HospitalHelper.PhysicalExamType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" DataKeyNames="TYPE">
            <Columns>
                <asp:BoundField DataField="NAME" HeaderText="报告类别" SortExpression="TYPE" />
                <asp:CommandField CancelText="取消" DeleteText="删除" EditText="修改" HeaderText="修改" 
                    InsertText="插入" ShowEditButton="True" UpdateText="修改" />
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            CommandName="Delete" 
                            onclientclick="return confirm('确认要删除吗？')" onclick="LinkButton1_Click">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TYPE" HeaderText="标记" Visible="False" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
            SelectCommand="SELECT * FROM [TESTTYPE]" 
            DeleteCommand="DELETE FROM [TESTTYPE] WHERE [TYPE] = @TYPE"
            InsertCommand="INSERT INTO [TESTTYPE] ([TYPE],[NAME]) VALUES (@TYPE, @NAME)" 
            UpdateCommand="UPDATE [TESTTYPE] SET [NAME] = @NAME WHERE [TYPE] = @TYPE">
            <DeleteParameters>
                <asp:Parameter Name="TYPE" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="NAME" Type="String" />
                <asp:Parameter Name="TYPE" Type="Int32" />
            </UpdateParameters>
            </asp:SqlDataSource>
    
    </div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加类别" />
    </form>
</body>
</html>
