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
            AutoPostBack="true"
            DataSourceID="SqlDataSource1" DataTextField="NAME" DataValueField="TYPE" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
            SelectCommand="SELECT * FROM [TESTTYPE]"></asp:SqlDataSource>
    
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TID,TYPE"
        DataSourceID="SqlDataSource2" AllowPaging="True">
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
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataKeyNames="TID,TYPE" DataSourceID="SqlDataSource2" Height="50px" 
        Width="125px" DefaultMode="Insert">
        <Fields>
            <asp:BoundField DataField="TID" HeaderText="TID" ReadOnly="True" 
                SortExpression="TID" />
            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
            <asp:CheckBoxField DataField="IMPORTANT" HeaderText="IMPORTANT" 
                SortExpression="IMPORTANT" />
            <asp:BoundField DataField="UNIT" HeaderText="UNIT" SortExpression="UNIT" />
            <asp:BoundField DataField="MINVALUE" HeaderText="MINVALUE" 
                SortExpression="MINVALUE" />
            <asp:BoundField DataField="MAXVALUE" HeaderText="MAXVALUE" 
                SortExpression="MAXVALUE" />
            <asp:CommandField CancelText="取消" InsertText="插入" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
        SelectCommand="SELECT * FROM [TESTITEM] WHERE ([TYPE] = @TYPE)" 
        DeleteCommand="DELETE FROM [TESTITEM] WHERE [TID] = @TID AND [TYPE] = @TYPE" 
        InsertCommand="INSERT INTO [TESTITEM] ([TID], [NAME], [TYPE], [IMPORTANT], [UNIT], [MINVALUE], [MAXVALUE]) VALUES (@TID, @NAME, @TYPE, @IMPORTANT, @UNIT, @MINVALUE, @MAXVALUE)" 
        UpdateCommand="UPDATE [TESTITEM] SET [NAME] = @NAME, [IMPORTANT] = @IMPORTANT, [UNIT] = @UNIT, [MINVALUE] = @MINVALUE, [MAXVALUE] = @MAXVALUE WHERE [TID] = @TID AND [TYPE] = @TYPE"
        oninserted="inserted_navigate">
        <DeleteParameters>
            <asp:Parameter Name="TID" Type="Int32" />
            <asp:Parameter Name="TYPE" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TID" Type="Int32" />
            <asp:Parameter Name="NAME" Type="String" />
            <asp:ControlParameter ControlID="DropDownList1" Name="TYPE"
                PropertyName="SelectedValue" Type="Int32" />
            <asp:Parameter Name="IMPORTANT" Type="Boolean" />
            <asp:Parameter Name="UNIT" Type="String" />
            <asp:Parameter Name="MINVALUE" Type="Double" />
            <asp:Parameter Name="MAXVALUE" Type="Double" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" Name="TYPE" 
                PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="NAME" Type="String" />
            <asp:Parameter Name="IMPORTANT" Type="Boolean" />
            <asp:Parameter Name="UNIT" Type="String" />
            <asp:Parameter Name="MINVALUE" Type="Double" />
            <asp:Parameter Name="MAXVALUE" Type="Double" />
            <asp:Parameter Name="TID" Type="Int32" />
            <asp:Parameter Name="TYPE" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
