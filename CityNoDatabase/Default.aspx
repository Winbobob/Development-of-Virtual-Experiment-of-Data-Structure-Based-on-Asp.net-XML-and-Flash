<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search City</title>
    <link rel="icon" href="../Logo.png">

</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 356px">
        
    
        <b>Add City：</b><br />
        City Name：<asp:TextBox ID="txtCityName" runat="server">Istanbul</asp:TextBox>
        <br />
        longitude：&nbsp; 
        <asp:TextBox ID="txtLongitude" runat="server">28.97673</asp:TextBox>
        <br />
        latitude：&nbsp; 
        <asp:TextBox ID="txtAltitude" runat="server">41.010993</asp:TextBox>
&nbsp;
        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Add" />
        <br />
        <br />
       <b>delete city：</b> <br />
        City Name：<asp:TextBox ID="txtDelCityName" runat="server">Jinhua</asp:TextBox>
&nbsp;
        <asp:Button ID="btnDel" runat="server" onclick="btnDel_Click" Text="Delete" />
        <br />
        <br />
        <b>Search City：</b><br />
        City Name：<asp:TextBox ID="txtSearchCityName" runat="server">Zhejiang normal University</asp:TextBox>
&nbsp;
        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
            Text="Search" />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <b>Special Search：</b><br />
                longitude：&nbsp; <asp:TextBox ID="txtSpecLongitude" runat="server">121.277815</asp:TextBox>
        <br />
                latitude：&nbsp; <asp:TextBox ID="txtSpecAltitude" runat="server">30.180135</asp:TextBox>
        <br />
        distance：&nbsp; <asp:TextBox ID="txtDistance" runat="server" Width="133px"></asp:TextBox>
        Km&nbsp;
        <asp:Button ID="btnSpecSearch" runat="server" onclick="btnSpecSearch_Click" 
            Text="Search" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Width="343px">
        </asp:GridView>
        <br />
        <asp:TextBox ID="txtShow" runat="server" Height="140px" TextMode="MultiLine" 
            Width="338px"  ReadOnly="True"></asp:TextBox>
        <br />
        
    
    </div>
    </form>
    
     <div style="border: thin groove #000000; position:absolute; left: 378px; top: 18px; height: 650px; width: 875px;">
      <object
          classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
          codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
          width="875px"
          height="650px">
          <param name="movie" value="CityNoDatabase.swf">
          <param name="quality" value="high">
          <param name="flashVars" value="key=AIzaSyADvbBDkuscchu29hamHgSkYhn1nkBfwH4Y&sensor=false">
          <embed
            width="875px"
            height="650px"
            src="CityNoDatabase.swf"
            quality="high"
            flashVars="key=AIzaSyADvbBDkuscchu29hamHgSkYhn1nkBfwH4&sensor=false"
            pluginspage="http://www.macromedia.com/go/getflashplayer"
            type="application/x-shockwave-flash">
          </embed>
    </object>
    </div>
</body>
</html>
