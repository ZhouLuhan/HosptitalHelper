<%@ Page Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="NewPatientII.aspx.cs" Inherits="HospitalHelper.NewPatientII" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Label ID="Ltnum" runat="server" Text="住院号码"></asp:Label>
    
    <asp:TextBox ID="Ttnum" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltclinic" runat="server" Text="门诊号"></asp:Label>
    <asp:TextBox ID="Ttclinic" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltpatienttype" runat="server" Text="病人类型"></asp:Label>
    <asp:TextBox ID="Ttpatienttype" runat="server"></asp:TextBox>
    
    <br />
    <asp:Label ID="Ltpatientsource" runat="server" Text="病人来源"></asp:Label>
    <asp:TextBox ID="Ttpatientsource" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltclinicdoc" runat="server" Text="门诊医生"></asp:Label>
    <asp:TextBox ID="Ttclinicdoc" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltclinicdia" runat="server" Text="门诊诊断"></asp:Label>
    <asp:TextBox ID="Ttclinicdia" runat="server"></asp:TextBox>
    
    <br />
    <asp:Label ID="Ltpatientstatus" runat="server" Text="病人状态"></asp:Label>
    <asp:TextBox ID="Ttpatientstatus" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltcriticallevel" runat="server" Text="危重级别"></asp:Label>
    <asp:TextBox ID="Ttcriticallevel" runat="server"></asp:TextBox>
    
    <br />
    <br />
    <asp:Label ID="Ltinsituation" runat="server" Text="入院状况"></asp:Label>
    <asp:TextBox ID="Ttinsituation" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltinway" runat="server" Text="入院途径"></asp:Label>
    <asp:TextBox ID="Ttinway" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltinbed" runat="server" Text="入院床位"></asp:Label>
    <asp:TextBox ID="Ttinbed" runat="server"></asp:TextBox>
    
    <br />
    <asp:Label ID="Ltindepartment" runat="server" Text="入院科室"></asp:Label>
    <asp:TextBox ID="Ttindepartment" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltinarea" runat="server" Text="入院病区"></asp:Label>
    <asp:TextBox ID="Ttinarea" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltincount" runat="server" Text="入院次数"></asp:Label>
    <asp:TextBox ID="Ttincount" runat="server"></asp:TextBox>
    
    <br />
    <asp:Label ID="Ltinhosdate" runat="server" Text="入院日期"></asp:Label>
    <asp:TextBox ID="Ttinhosdate" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltinareadate" runat="server" Text="入区日期"></asp:Label>
    <asp:TextBox ID="Ttinareadate" runat="server"></asp:TextBox>
    
    <asp:Label ID="Linisclinical" runat="server" Text="纳入临床路径"></asp:Label>
    <asp:TextBox ID="Tinisclinical" runat="server"></asp:TextBox>
    
    <br />
    <br />
    <asp:Label ID="Ltoutdepartment" runat="server" Text="出院科室"></asp:Label>
    <asp:TextBox ID="Ttoutdepartment" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltoutarea" runat="server" Text="出院病区"></asp:Label>
    <asp:TextBox ID="Ttoutarea" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltoutbed" runat="server" Text="出院床位"></asp:Label>
    <asp:TextBox ID="Ttoutbed" runat="server"></asp:TextBox>
    
    <br />
    <asp:Label ID="Ltouthosdate" runat="server" Text="出院日期"></asp:Label>
    <asp:TextBox ID="Ttouthosdate" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltoutareadate" runat="server" Text="出区日期"></asp:Label>
    <asp:TextBox ID="Ttoutareadate" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltoutdaycount" runat="server" Text="住院天数"></asp:Label>
    <asp:TextBox ID="Ttoutdatecount" runat="server"></asp:TextBox>
    
    <br />
    <asp:Label ID="Ltoutway" runat="server" Text="出院方式"></asp:Label>
    <asp:TextBox ID="Ttoutway" runat="server"></asp:TextBox>
    
    <asp:Label ID="Ltoutxrayinfo" runat="server" Text="X线信息"></asp:Label>
    <asp:TextBox ID="Ttoutxrayinfo" runat="server"></asp:TextBox>
    
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Bsave" runat="server" Text="保存" />
    
</asp:Content>