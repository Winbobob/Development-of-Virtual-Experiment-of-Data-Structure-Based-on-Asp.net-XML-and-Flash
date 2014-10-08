<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default"  Async="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Dancing Question</title>
    <link rel="icon" href="../Logo.png">

    <style type="text/css">
        
        #btn
        {
            position:absolute;
            top: 141px;
            left: 350px;
            height: 33px;
        }
        #form1
        {
            width: 1158px;
        }
    </style> 
    </head>
    <body>
    <form id="form1" runat="server">
    <div style="width: 971px">
    
        Choose a method：<asp:DropDownList ID="ddlSort" runat="server" Height="27px" 
            onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="112px" 
            AutoPostBack="True">
            <asp:ListItem Value="1">sequence list</asp:ListItem>
            <asp:ListItem Value="2" Selected="True">link list</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Queue Capacity：" Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnOK" runat="server" onclick="btnOK_Click" Text="OK" 
            Visible="False" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        Girls：g1|g2|g3|g4|g5|g6|g7|g8|g9|g10|g11|g12|g13|g14&nbsp;<br />
        Boys：b1|b2|bob|b4|b5|b6|b7|b8|b9|<br />
        <br />
    
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="always">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="click"/>
            </Triggers>
            <ContentTemplate>  

                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="tick"/>
                    </Triggers>
                    <ContentTemplate>

                   <script type="text/javascript">
                       //使窗口的滚动条一直处于最下面
                       function scrollWindow() {
                           document.getElementById("txtMsg").scrollTop = 10000;
                           setTimeout("scrollWindow()", 1000);
                       }
                       setTimeout("scrollWindow()", 1000);
                    </script>

                        <asp:TextBox ID="txtMsg" runat="server" Height="520px" TextMode="MultiLine" 
                         Width="321px" AutoPostBack="True" ReadOnly="True" style="font-size: large"></asp:TextBox> 
                             
                    </ContentTemplate>
                </asp:UpdatePanel>               
                
            </ContentTemplate>            
        </asp:UpdatePanel>        
        

        <div id="btn" style="position:absolute">
            <asp:Button ID="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click" 
                Height="95px" Width="182px" style="font-size: x-large"/>
        </div>
    
      

      <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>

                <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="6000"></asp:Timer>

              <div style="position:absolute; left: 598px; top: 164px; height: 400px;">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0" width="550" height="400" title="Animation">
                  <param name="movie" value="舞池跳舞动画演示.swf" />
                  <param name="quality" value="high" />
                  <param name="wmode" value="opaque" />
                  <embed src="舞池跳舞动画演示.swf" quality="high" wmode="opaque" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" type="application/x-shockwave-flash" width="550" height="400"></embed>
                </object>
              </div>
            </ContentTemplate>
      </asp:UpdatePanel>
    </form>
   </body>
</html>
