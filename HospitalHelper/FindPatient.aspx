<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="FindPatient.aspx.cs" Inherits="HospitalHelper.FindPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="PID" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="PID" HeaderText="病人身份证" SortExpression="PID" />
            <asp:HyperLinkField DataNavigateUrlFields="PID" 
                DataNavigateUrlFormatString="NewPatient.aspx?PID={0}" DataTextField="PNAME" 
                HeaderText="病人名字" />
            <asp:BoundField DataField="PBIRTHCITY" HeaderText="出生城市" 
                SortExpression="PBIRTHCITY" />
            <asp:BoundField DataField="PBIRTHDISTRICT" HeaderText="出生区县" 
                SortExpression="PBIRTHDISTRICT" />
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Delete">删除</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:HospitalData %>" 
        SelectCommand="SELECT [PID], [PNAME], [PBIRTHCITY], [PBIRTHDISTRICT] FROM [PATIENT]"
        DeleteCommand="DELETE FROM [PATIENT] WHERE [PID] = @PID" 
        InsertCommand="INSERT INTO [PATIENT] ([PID], [PNAME], [PBIRTHCITY], [PBIRTHDISTRICT]) VALUES (@PID, @PNAME, @PBIRTHCITY, @PBIRTHDISTRICT)"
        UpdateCommand="UPDATE [PATIENT] SET [PNAME] = @PNAME, [PBIRTHCITY] = @PBIRTHCITY, [PBIRTHDISTRICT] = @PBIRTHDISTRICT WHERE [PID] = @PID"
        >
        <DeleteParameters>
        <asp:Parameter Name="PID" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="PID" Type="String" />
            <asp:Parameter Name="PNAME" Type="String" />
            <asp:Parameter Name="PBIRTHCITY" Type="String" />
            <asp:Parameter Name="PBIRTHDISTRICT" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="PNAME" Type="String" />
            <asp:Parameter Name="PBIRTHCITY" Type="String" />
            <asp:Parameter Name="PBIRTHDISTRICT" Type="String" />
            <asp:Parameter Name="PID" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>