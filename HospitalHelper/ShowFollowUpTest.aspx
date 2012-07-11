<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowFollowUpTest.aspx.cs" Inherits="HospitalHelper.ShowFollowUpTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true"
            DataSourceID="SqlDataSource1" DataTextField="NAME" DataValueField="TYPE" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
            SelectCommand="SELECT * FROM [TESTTYPE]"></asp:SqlDataSource>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="TID,TYPE" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="TID" HeaderText="No." ReadOnly="True" 
                    SortExpression="TID" />
                <asp:BoundField DataField="NAME" HeaderText="项目" SortExpression="NAME" />
                <asp:BoundField DataField="UNIT" HeaderText="单位" SortExpression="UNIT" />
                <asp:BoundField DataField="MINVALUE" HeaderText="参考值" 
                    SortExpression="MINVALUE" />
                <asp:BoundField DataField="MAXVALUE" HeaderText="最大值"
                    SortExpression="MAXVALUE" />
                <asp:BoundField DataField="RESULT" HeaderText="结果" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
            SelectCommand="SELECT * FROM [TESTITEM],[TESTRESULT] WHERE TESTITEM.TYPE = @TYPE AND TESTITEM.TID=TESTRESULT.TID AND TESTITEM.TYPE=TESTRESULT.TYPE">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="TYPE" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
