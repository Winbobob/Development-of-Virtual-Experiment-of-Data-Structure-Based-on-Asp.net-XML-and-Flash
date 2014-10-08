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
using System.Text;


public partial class _Default : System.Web.UI.Page 
{
    public static int[] items;
    public static int n;     
    public static string originalNum = "";  
    public static string lastNum = "";  
    public static string terminal = "";  
    public static string detail = "";  
    public static string selectColor = ""; 
    protected void Page_Load(object sender, EventArgs e)
    {
        cleanXML();   
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
            items = new int[n];
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
            items = new int[n];
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
            items = new int[n];
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
            items = new int[n];
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
            items = new int[n];
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
            items = new int[n];
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
            t1.Text = "312"; t2.Text = "666"; t3.Text = "998"; t4.Text = "213"; t5.Text = "43"; t6.Text = "7"; t7.Text = "135"; t8.Text = "87"; t9.Text = "5";
            items = new int[n];
        }
    }

    protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlColor.SelectedValue == "r")
        {
            selectColor = "red";
        }
        if (ddlColor.SelectedValue == "g")
        {
            selectColor = "green";
        }
        if (ddlColor.SelectedValue == "b")
        {
            selectColor = "blue";
        }
    }    

    protected void getArrayEachTime(int n)
    {
        string id = "";
        for (int i = 0; i < n; i++)
        {
            id = "t" + (i + 1).ToString();
            TextBox tb = this.Page.FindControl(id) as TextBox;
            items[i] = Convert.ToInt32(tb.Text);
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        terminal = "";
        detail = "";
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

            int i, j, over,p;
            terminal += "\nBefore sort：   ";
            for (int k = 0; k < items.Length; k++)        
            {
                terminal += string.Format("{0,8}", items[k]);   
                if (k < items.Length - 1) originalNum = originalNum + items[k] + ",";
                else originalNum = originalNum + items[k];
            }

            for (i = 1; i < items.Length; i++)       
            {
                over = 1;
                for (j = 0; j < items.Length - i; j++)    
                { 
                   if (items[j] > items[j + 1])
                    {
                        p = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = p;
                        detail += string.Format("{0,6}↔{1}\n", items[j + 1], items[j]); 
                        over = 0;
                    }
                }

                if (over!=0)   
                    break;

                terminal += "\nNo." + i.ToString() + " exchange：";
                for (int r = 0; r < items.Length; r++)
                    terminal += string.Format("{0,8}", items[r]);  

            }

            terminal += "\nAfter sort：   ";
           for (i = 0; i < items.Length; i++)
           {
               terminal += string.Format("{0,8}", items[i]);   
               if (i < items.Length - 1) lastNum += items[i] + ",";
               else lastNum += items[i];
           }
              
            txtMsg.Text = terminal;
            txtDetail.Text = detail;
            generateXML(terminal);
            originalNum = "";
            lastNum = "";
        }
        

    //生成XML文件
    /*
           998↔213
           998↔43
           998↔7
           998↔135
           998↔87
           998↔5
     */
    protected void generateXML(String terminal)  
    {
        System.Xml.XmlTextWriter xmlWriter = new XmlTextWriter(Server.MapPath("./1234.xml"), System.Text.Encoding.UTF8);
        xmlWriter.Formatting = Formatting.Indented;
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("排序");

        xmlWriter.WriteStartElement("颜色");
        xmlWriter.WriteString(selectColor);
        xmlWriter.WriteEndElement();

        xmlWriter.WriteStartElement("原始");
        xmlWriter.WriteString(originalNum);
        xmlWriter.WriteEndElement();
       
       String[] sArray = detail.Split(new Char[] { '\n' }); 
       string firstNum = "";
       string secondNum = "";
       int a;
       foreach (String i in sArray)
       {
           string m;
           m = i.Trim();       
           a = m.IndexOf("↔");
            if (a != -1)    
            { 
                firstNum = m.Substring(0, a);  
                secondNum = m.Substring(a + 1, (m.Length - a - 1));  
            }

            xmlWriter.WriteStartElement("单次");
            xmlWriter.WriteAttributeString("数字1", firstNum);
            xmlWriter.WriteAttributeString("数字2", secondNum);
            xmlWriter.WriteEndElement();
       }

        xmlWriter.WriteStartElement("最终");
        xmlWriter.WriteString(lastNum);
        xmlWriter.WriteEndElement();

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
