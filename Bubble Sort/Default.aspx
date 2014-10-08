<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" href="../Logo.png">
    <title>Bubble Sort</title>
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
    
        Number of element：<asp:DropDownList ID="ddlNum" runat="server" Height="27px" 
            Width="114px" AutoPostBack="True" 
            onselectedindexchanged="ddlNum_SelectedIndexChanged">
            <asp:ListItem Value="3">3</asp:ListItem>
            <asp:ListItem Value="4">4</asp:ListItem>
            <asp:ListItem Value="5">5</asp:ListItem>
            <asp:ListItem Value="6">6</asp:ListItem>
            <asp:ListItem Value="7">7</asp:ListItem>
            <asp:ListItem Value="8">8</asp:ListItem>
            <asp:ListItem Value="9">9</asp:ListItem>
            <asp:ListItem Selected="True">==Num==</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp; ball color：<asp:DropDownList ID="ddlColor" runat="server" 
            AutoPostBack="True" onselectedindexchanged="ddlColor_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="==color=="></asp:ListItem>
            <asp:ListItem Value="r">red</asp:ListItem>
            <asp:ListItem Value="g">green</asp:ListItem>
            <asp:ListItem Value="b">blue</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Enter numbers：
        <asp:TextBox ID="t1" runat="server" class="txtBox"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t2" runat="server" class="txtBox"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t3" runat="server" class="txtBox"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t4" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t5" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t6" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t7" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t8" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;<asp:TextBox ID="t9" runat="server" class="txtBox" Visible="False"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="Confirm" />
        <br />
        <b>（please input distinct numbers）</b><br />
    
    </div>
    <asp:TextBox ID="txtMsg" runat="server" Height="250px" TextMode="MultiLine" 
        Width="609px" ReadOnly="True"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <div style="width: 187px; position: absolute; top: 17px; left: 727px; height: 595px;">
        Detail：<asp:TextBox ID="txtDetail" runat="server" Height="554px" Width="120px" 
            ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
    </div>
    
    &nbsp;&nbsp;</form>
    <!-- <a href="冒泡排序动画演示.html" target =_blank>冒泡排序动画演示</a> -->
    <div style="position:absolute; left: 26px; top: 382px;">
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="550" height="200" title="Animation">
      <param name="movie" value="冒泡排序动画演示.swf" />
      <param name="quality" value="high" />
      <param name="wmode" value="opaque" />
      <embed src="冒泡排序动画演示.swf" quality="high" wmode="opaque" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="550" height="200"></embed>
    </object>
    </div>
</body>
</html>
