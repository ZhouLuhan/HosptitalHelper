<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicalExamItem.aspx.cs" Inherits="HospitalHelper.PhysicalExamItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="TYPE" DataValueField="TYPE">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
            SelectCommand="SELECT [TYPE] FROM [TESTITEM]"></asp:SqlDataSource>
    
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField DataField="TID" HeaderText="NO." SortExpression="TID" />
            <asp:BoundField DataField="NAME" HeaderText="项目" SortExpression="NAME" />
            <asp:BoundField DataField="UNIT" HeaderText="单位" SortExpression="UNIT" />
            <asp:CheckBoxField DataField="IMPORTANT" HeaderText="重要项目" 
                SortExpression="IMPORTANT" />
            <asp:BoundField DataField="MINVALUE" HeaderText="参考值下限" 
                SortExpression="MINVALUE" />
            <asp:BoundField DataField="MAXVALUE" HeaderText="参考值上限" 
                SortExpression="MAXVALUE" />
            <asp:CommandField CancelText="取消" DeleteText="删除" EditText="修改" HeaderText="修改" 
                ShowEditButton="True" UpdateText="修改" />
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Delete" onclientclick="return confirm('确认要删除吗？')">删除</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
        SelectCommand="SELECT [NAME], [TID], [IMPORTANT], [UNIT], [MINVALUE], [MAXVALUE] FROM [TESTITEM] WHERE ([TYPE] = @TYPE)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="TYPE" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
