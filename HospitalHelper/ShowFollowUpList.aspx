<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowFollowUpList.aspx.cs" Inherits="HospitalHelper.ShowFollowUpList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" />
    
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
        DataKeyNames="FID">
        <Columns>
        <asp:BoundField DataField="FID" Visible="false" />
            <asp:HyperLinkField DataNavigateUrlFields="FID" 
                DataNavigateUrlFormatString="ShowFollowUpProspect.aspx?FID={0}" 
                DataTextField="FDATE" HeaderText="时间" />
            <asp:BoundField DataField="FDOCTOR" HeaderText="医生" SortExpression="FDOCTOR" />
            <asp:BoundField DataField="FDESCRIPTION" HeaderText="描述" 
                SortExpression="FDESCRIPTION" />
            <asp:BoundField DataField="DESCRIPTION" HeaderText="标签" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
        
        SelectCommand="SELECT *  FROM [FOLLOWUP] left join [TAG] ON FOLLOWUP.FID=TAG.FID WHERE ([PID] = @PID) AND ([DESCRIPTION]=@DESCRIPTION)">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="PID" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBox2" Name="DESCRIPTION" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
        ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
        
        SelectCommand="SELECT *  FROM [FOLLOWUP] left join [TAG] ON FOLLOWUP.FID=TAG.FID WHERE ([PID] = @PID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" Name="PID" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    </form>
</body>
</html>
