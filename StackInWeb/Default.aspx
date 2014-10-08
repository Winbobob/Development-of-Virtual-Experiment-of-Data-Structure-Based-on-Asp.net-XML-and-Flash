<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Train Carriages Rearrangement</title>
    <link rel="icon" href="../Logo.png">

    <style type="text/css">
        .txtBox
        {
            width:30px;
        }
        #btn
        {
            position:absolute;
            top: 197px;
            left: 461px;
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Choose a method：<asp:DropDownList ID="ddlSort" runat="server" Height="27px" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="112px" 
            AutoPostBack="True">
            <asp:ListItem Selected="True" Value="1">Sequence List</asp:ListItem>
            <asp:ListItem Value="2">Link List</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Choose amount of Carrages：<asp:DropDownList ID="ddlNum" runat="server" Height="27px" 
            Width="114px" AutoPostBack="True" 
            onselectedindexchanged="ddlNum_SelectedIndexChanged">
            <asp:ListItem Value="3">3</asp:ListItem>
            <asp:ListItem Value="4">4</asp:ListItem>
            <asp:ListItem Value="5">5</asp:ListItem>
            <asp:ListItem Value="6">6</asp:ListItem>
            <asp:ListItem Value="7">7</asp:ListItem>
            <asp:ListItem Value="8">8</asp:ListItem>
            <asp:ListItem Value="9">9</asp:ListItem>
            <asp:ListItem Selected="True">==Carrage number==</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        Input # of track：<asp:TextBox ID="txtTrackNum" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblAdd" runat="server" Text="Input additional track number：" Visible="False"></asp:Label>
        <asp:TextBox ID="txtAdd" runat="server" Visible="False" Width="37px"></asp:TextBox>
        <br />
        <br />
        Input # of Carriages：
        <asp:TextBox ID="t1" runat="server" class="txtBox"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t2" runat="server" class="txtBox"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t3" runat="server" class="txtBox"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t4" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t5" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t6" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t7" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t8" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t9" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="Confirm" />
        <br />
    
    </div>
    <asp:TextBox ID="txtMsg" runat="server" Height="250px" TextMode="MultiLine" 
        Width="437px"></asp:TextBox>
        <div id="btn">
        <asp:Button ID="btnConfirm" runat="server" Text="Output" 
            onclick="btnConfirm_Click" /></div>
    </form>
   
      <!--<a href="火车重排动画演示.html" target="_blank">火车重排动画演示</a> -->
     
     <div style="position: absolute; top: 73px; left: 681px;">
        <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="550" height="400" title="Animation">
               <param name="movie" value="火车重排动画演示.swf" />
               <param name="quality" value="high" />
               <param name="wmode" value="opaque" />
               <embed src="火车重排动画演示.swf" quality="high" wmode="opaque" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="550" height="400"></embed>
        </object>
      </div>
</body>
</html>
