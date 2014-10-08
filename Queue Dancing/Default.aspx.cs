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
using System.Threading;
using QueueDs;
using System.ComponentModel;

public partial class _Default : System.Web.UI.Page 
{
    public static int windowcount = 1;  
    public static string count = null;           
    public Thread[] swt = new Thread[windowcount];
    public static Thread th;
    public static string terminal,terminal2;  

    public static String[] girls = new String[15] { "", "g1", "g2", "g3", "g4", "g5", "g6", "g7", "g8", "g9", "g10", "g11", "g12", "g13", "g14" };
    public static String[] boys = new String[15] { "", "b1", "b2", "bob", "b4", "b5", "b6", "b7", "b8", "b9", "b1", "b2", "bob", "b3", "b4" };
    public static IDancingQueue dancingQueue = new LinkDancingQueue();  
    public static int callnumber = 0;                          
    public System.Xml.XmlTextWriter xmlWriter;                   



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            thread_showSth();  
            txtMsg.Text = "";

            xmlWriter = new XmlTextWriter(Server.MapPath("./1234.xml"), System.Text.Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("队列");
            xmlWriter.WriteStartElement("跳舞");
            xmlWriter.WriteString("boy,girl");
            xmlWriter.WriteEndElement();
            //写文档结束，调用WriteEndDocument方法
            xmlWriter.WriteEndDocument();
            // 关闭textWriter
            xmlWriter.Close();
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        UpdatePanel2.Update();
        UpdatePanel3.Update();

        txtMsg.Text += terminal2;
    }

    public void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSort.SelectedValue == "1")
        {
             Label1.Visible = true;
             TextBox1.Visible = true;
             btnOK.Visible = true;
        }
        if (ddlSort.SelectedValue == "2")
        {
            Label1.Visible = false;
            TextBox1.Visible = false;
            btnOK.Visible = false;
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        int num = Convert.ToInt32(TextBox1.Text);
        dancingQueue = new CSeqDancingQueue(num);
    }

     protected void btnAdd_Click(object sender, EventArgs e)
     {   
        txtMsg.Text += "\nPress the button and get the number:";

        try
        {
                if (!dancingQueue.IsFull())
                {
                    //n++;
                    callnumber = dancingQueue.GetCallnumber();
                    terminal += "\n" + boys[callnumber] + ",hi, " + dancingQueue.GetLength() + " people before you, please wait!\n";
                    terminal += girls[callnumber] + ",hi, " + dancingQueue.GetLength() + " people before you, please wait!\n";
                    txtMsg.Text += "\n" + boys[callnumber] + ",hi, " + dancingQueue.GetLength() + " people before you, please wait!\n";
                    txtMsg.Text += girls[callnumber] + ",hi, " + dancingQueue.GetLength() + " people before you, please wait!\n";
                    dancingQueue.EnQueue(callnumber); 

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Server.MapPath("./1234.xml")); 
                    XmlNode root = xmlDoc.DocumentElement;  
                    XmlElement element = xmlDoc.CreateElement("等待");
                    String str = girls[callnumber] + "，" + boys[callnumber];
                    element.InnerText = str;
                    root.AppendChild(element);
                    xmlDoc.Save(Server.MapPath("./1234.xml"));
                }
                else
                    txtMsg.Text += "It is busy now, please wait!\n";
            
        }
        catch (Exception ex)
        {
            txtMsg.Text += "\n\nWow, everyone have finished dancing！\n";
            dancingQueue.Clear();
        }
    }

    
    private void thread_showSth()
    {
         int i;
         for (i = 0; i < windowcount; i++)
        {
            swt[i] = new Thread(new ThreadStart(Service));
            swt[i].Start();
        }
    }
    private void Service()
    {
        while (true)
        {
            try 
            { 
                Thread.Sleep(6000);
                if (!dancingQueue.IsEmpty())
                {
                    lock (dancingQueue)
                    {
                        int n = dancingQueue.DeQueue();
                        terminal2 = "\n" + boys[n] + " and " + girls[n] + " dancing!\n";

                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Server.MapPath("./1234.xml")); 
                        XmlNode root = xmlDoc.DocumentElement; 

                        XmlNode remove1 = root.ChildNodes[0];
                        remove1.Attributes.RemoveAt(0);
                        root.RemoveChild(remove1);
                        xmlDoc.Save(Server.MapPath("./1234.xml"));

                        XmlNode remove2 = root.ChildNodes[0];
                        remove2.Attributes.RemoveAt(0);
                        root.RemoveChild(remove2);
                        xmlDoc.Save(Server.MapPath("./1234.xml"));

                        XmlElement element = xmlDoc.CreateElement("跳舞");
                        String str = girls[n] + "，" + boys[n];
                        element.InnerText = str;
                        root.InsertBefore(element, xmlDoc.DocumentElement.ChildNodes.Item(0));
                        
                        xmlDoc.Save(Server.MapPath("./1234.xml"));
                    }
                }                            
                else { terminal2 = null; }   
            }
            catch (Exception e) 
            { txtMsg.Text += e.ToString(); }
        }
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
