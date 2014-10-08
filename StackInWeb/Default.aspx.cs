using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;
using StackApplication;

public partial class _Default : System.Web.UI.Page 
{
    public static int[] p1;
    public static int k;     
    public static int n;     
    public static string terminal;  
    public static StackType type;
    protected void Page_Load(object sender, EventArgs e)
    {
        cleanXML();
        //generateXML(txtMsg.Text);
    }
    public void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSort.SelectedValue == "1")
        {
             type = StackType.SeqStack;
        }
        if (ddlSort.SelectedValue == "2")
        {
             type = StackType.LinkStack;
        }
    }

    public void ddlNum_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNum.SelectedValue == "3")
        {
            n = 3;
            t4.Visible = false;
            t5.Visible = false;
            t6.Visible = false;
            t7.Visible = false;
            t8.Visible = false;
            t9.Visible = false;
            p1 = new int[n];
        }
        if (ddlNum.SelectedValue == "4")
        {
            n = 4;
            t4.Visible = true;
            t5.Visible = false;
            t6.Visible = false;
            t7.Visible = false;
            t8.Visible = false;
            t9.Visible = false;
            p1 = new int[n];
        }
        if (ddlNum.SelectedValue == "5")
        {
            n = 5;
            t4.Visible = true;
            t5.Visible = true;
            t6.Visible = false;
            t7.Visible = false;
            t8.Visible = false;
            t9.Visible = false;
            p1 = new int[n];
        }
        if (ddlNum.SelectedValue == "6")
        {
            n = 6;
            t4.Visible = true;
            t5.Visible = true;
            t6.Visible = true;
            t7.Visible = false;
            t8.Visible = false;
            t9.Visible = false;
            p1 = new int[n];
        }
        if (ddlNum.SelectedValue == "7")
        {
            n = 7;
            t4.Visible = true;
            t5.Visible = true;
            t6.Visible = true;
            t7.Visible = true;
            t8.Visible = false;
            t9.Visible = false;
            p1 = new int[n];
        }
        if (ddlNum.SelectedValue == "8")
        {
            n = 8;
            t4.Visible = true;
            t5.Visible = true;
            t6.Visible = true;
            t7.Visible = true;
            t8.Visible = true;
            t9.Visible = false;
            p1 = new int[n];
        }
        if (ddlNum.SelectedValue == "9")
        {
            n = 9;
            t4.Visible = true;
            t5.Visible = true;
            t6.Visible = true;
            t7.Visible = true; 
            t8.Visible = true;
            t9.Visible = true;
            t1.Text = "3"; t2.Text = "6"; t3.Text = "9"; t4.Text = "2"; t5.Text = "4"; t6.Text = "7"; t7.Text = "1"; t8.Text = "8"; t9.Text = "5";
            p1 = new int[n];
        }
    }

       
    public void btnConfirm_Click(object sender, EventArgs e)
    {
        k = Convert.ToInt32(txtTrackNum.Text);
        TrainArrange ta = new TrainArrange(k, p1, type);
        bool result;
        
        result = ta.Railroad(p1, p1.Length, k);
        if (result == false)
        {
            if (txtAdd.Text != null)
            {
                k += Convert.ToInt32(txtAdd.Text);
                TrainArrange ta1 = new TrainArrange(k, p1, type); 
                result = ta1.Railroad(p1, p1.Length, k);          
                terminal = ta1.ShowMsg();
                txtMsg.Text = ta1.ShowMsg();
                generateXML(terminal);
            }
        }
        else 
        {
            terminal = ta.ShowMsg();
            txtMsg.Text = ta.ShowMsg();
            generateXML(terminal);
        }

    }


   
    protected void getArrayEachTime(int n)
    {
        string id = "";
        for (int i = 0; i < n; i++)
        {
            id = "t" + (i + 1).ToString();
            TextBox tb = this.Page.FindControl(id) as TextBox;
            p1[i] = Convert.ToInt32(tb.Text);
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (n == 9 && t1.Text != null && t2.Text != null && t3.Text != null && t4.Text != null && t5.Text != null && t6.Text != null && t7.Text != null && t8.Text != null && t9.Text != null)
        {
            getArrayEachTime(n);
        }
        if (n == 8 && t1.Text != null && t2.Text != null && t3.Text != null && t4.Text != null && t5.Text != null && t6.Text != null && t7.Text != null && t8.Text != null)
        {
            getArrayEachTime(n);
        }
        if (n == 7 && t1.Text != null && t2.Text != null && t3.Text != null && t4.Text != null && t5.Text != null && t6.Text != null && t7.Text != null)
        {
           getArrayEachTime(n);
        }
        if (n == 6 && t1.Text != null && t2.Text != null && t3.Text != null && t4.Text != null && t5.Text != null && t6.Text != null)
        {
            getArrayEachTime(n);
        }
        if (n == 5 && t1.Text != null && t2.Text != null && t3.Text != null && t4.Text != null && t5.Text != null)
        {
            getArrayEachTime(n);
        }
        if (n == 4 && t1.Text != null && t2.Text != null && t3.Text != null && t4.Text != null)
        {
            getArrayEachTime(n);
        }
        if (n == 3 && t1.Text != null && t2.Text != null && t3.Text != null)
        {
            getArrayEachTime(n);
        }

        k = Convert.ToInt32(txtTrackNum.Text);       
        TrainArrange ta = new TrainArrange(k, p1, type);
        bool result = ta.Railroad(p1, p1.Length, k);
        if (result == false)
        {
            lblAdd.Visible = true;
            txtAdd.Visible = true;
        }
        else 
        {
            RegisterClientScriptBlock("", "<script>alert('Run successfully！')</script>");
            
        }
    }

    //生成XML文件
    /*
        Move Car3 from input to holding track1
        Move Car4 from input to holding track2
        Move Car1 from input to output
        Move Car2 from input to output
        Move Car3 from holding track1 to output
        Move Car4 from holding track2 to output

     */
    protected void generateXML(String terminal)  
    {
        System.Xml.XmlTextWriter xmlWriter = new XmlTextWriter(Server.MapPath("./1234.xml"), System.Text.Encoding.UTF8);
        //System.Xml.XmlTextWriter xmlWriter = new XmlTextWriter(System.IO.Directory.GetCurrentDirectory() + "\\123.xml", System.Text.Encoding.UTF8);
        xmlWriter.Formatting = Formatting.Indented;
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("数据");

       String[] sArray = terminal.Split(new Char[] { '\n' });  
       int firstNum = 0;
       int secondNum = 0;
       int thirdNum = 1;
       int a, b, c;
       foreach (String i in sArray)
       {
            a = i.IndexOf('r');
            if (a != -1)    
            { 
                firstNum = Convert.ToInt32(i.Substring(a + 1, 1));  
            }

            b = i.IndexOf('k');
            c = i.IndexOf('h'); 
            secondNum = -1;
            if(b != -1)   
            {
               secondNum = Convert.ToInt32(i.Substring(b + 1, 1));
            }
            thirdNum = 1;
            if (c <= 15)    
            {
                thirdNum = -1;
            }
           
            xmlWriter.WriteStartElement("单次");
            xmlWriter.WriteAttributeString("车厢", firstNum.ToString());
            xmlWriter.WriteAttributeString("铁轨", secondNum.ToString());
            xmlWriter.WriteAttributeString("出入", thirdNum.ToString());   //出(-1)入(1)
            xmlWriter.WriteEndElement();
       }
       //写文档结束，调用WriteEndDocument方法
       xmlWriter.WriteEndDocument();
       //关闭textWriter
       xmlWriter.Close();
    }

    protected void cleanXML()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Server.MapPath("./1234.xml"));
        XmlElement xmlEle = xmlDoc.DocumentElement;
        xmlEle.RemoveAll();
        xmlDoc.Save(Server.MapPath("./1234.xml"));
        
    }
}
