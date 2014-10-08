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
using System.Xml;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using CitySiteLibrary;

public partial class _Default : System.Web.UI.Page 
{

   static ILinearList<City> cityList = new CityList<City>();  
   public static int i = 0;
   public static string message = null;
   public static double distance;
   public static string name = null; 
   public static ArrayList list = new ArrayList(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            loadData();
            CreateDataTable();
           
        }
        
        txtShow.Text = "";
    }


    private double getDistance(double x1,double y1,double x_putin,double y_putin)
    { 
         double rad = 6371;   
         double p1X = x1 / 180 * Math.PI;
         double p1Y = y1 / 180 * Math.PI;
         double p2X = x_putin / 180 * Math.PI;
         double p2Y = y_putin / 180 * Math.PI;
         double D;
         return D = Math.Acos(Math.Sin(p1Y) * Math.Sin(p2Y) + Math.Cos(p1Y) * Math.Cos(p2Y) * Math.Cos(p2X - p1X)) * rad;
    }

    private void loadData() 
    {
        if (i == 0)
        {
            City c1 = new City("慈溪", 30.180135, 121.277815);
            City c2 = new City("厦门", 24.455275, 118.097427);
            City c3 = new City("金华", 29.13402, 119.641364);
            City c4 = new City("北海道", 43.090955, 141.351256);
            cityList.InsertNode(c1);
            cityList.InsertNode(c2);
            cityList.InsertNode(c3);
            cityList.InsertNode(c4);
        }
        i++;
        
    }
    private void CreateDataTable()
    {
        DataTable table = new DataTable();
        DataColumn column;
        DataRow row;
        column = new DataColumn();
        column.DataType = System.Type.GetType("System.String");
        column.ColumnName = "城市";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = Type.GetType("System.Double");
        column.ColumnName = "纬度";
        table.Columns.Add(column);

        column = new DataColumn();
        column.DataType = Type.GetType("System.Double");
        column.ColumnName = "经度";
        table.Columns.Add(column);
        City temp;
        for (int i = 1; i <= cityList.GetLength(); i++)
        {
            temp = cityList.SearchNode(i);
            row = table.NewRow();
            row["城市"] = temp.Name;
            row["纬度"] = temp.X;
            row["经度"] = temp.Y;
            table.Rows.Add(row);
        }

        GridView1.DataSource = table.DefaultView;
        GridView1.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        txtShow.Text = "";
        try
        {
            City temp;
            string name = txtCityName.Text;
            bool judgeExist = false;
            City newnode = new City(txtCityName.Text, Convert.ToDouble(txtAltitude.Text), Convert.ToDouble(txtLongitude.Text));
            for (int i = 1; i <= cityList.GetLength(); i++)
            {
                temp = cityList.SearchNode(i);
                if (temp.Name == name)
                {
                    judgeExist = true;
                }
            }
            if (judgeExist == false)
            {
                cityList.InsertNode(newnode);
            }  
            CreateDataTable();
            generateXML();
            txtCityName.Text = null;
            txtLongitude.Text = null;
            txtAltitude.Text = null;
        }
        catch (Exception e1)
        {

            txtShow.Text += "请输入合适的地名和经纬度！\n" + e1.ToString();
        }
        
    }


    protected void btnDel_Click(object sender, EventArgs e)
    {
        txtShow.Text = "";
        try
        {
            City temp;
            for (int i = 1; i <= cityList.GetLength(); i++)
            {
                name = txtDelCityName.Text;
                temp = cityList.SearchNode(i);
                if (temp.Name == name)
                {
                    cityList.DeleteNode(i);
                    break;
                }
            }
            CreateDataTable();
            generateXML();
            txtDelCityName.Text = null;
        }
        catch (Exception e1)
        {
            txtShow.Text += "请输入列表中存在的地名！\n" + e1.ToString();
        }
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        txtShow.Text = "";
        try
        {
            City temp;
            string name = txtSearchCityName.Text;

            for (int i = 1; i <= cityList.GetLength(); i++)   
            {
                temp = cityList.SearchNode(i);       
                if (temp.Name == name)
                {
                    txtShow.Text = name + " 的坐标为：纬度" + temp.X + "°,经度" + temp.Y + "°";
                    break;
                }
            }
            generateXML1();
        }
        catch (Exception e1)
        {
            txtShow.Text += "请输入列表中存在的地名！\n" + e1.ToString();            
        }
       
    }


    protected void btnSpecSearch_Click(object sender, EventArgs e)
    {
        txtShow.Text = "";
        try
        {
            double x = Convert.ToDouble(txtSpecAltitude.Text);
            double y = Convert.ToDouble(txtSpecLongitude.Text);
            distance = Convert.ToDouble(txtDistance.Text);
            if (distance > 3185) distance = 3185;
            City temp;

            for (int i = 1; i <= cityList.GetLength(); i++)  
            {
                temp = cityList.SearchNode(i);

                if (getDistance(temp.X, temp.Y, x, y) <= distance)
                {
                    message += temp.Name + "的坐标为：纬度" + temp.X + "°,经度" + temp.Y + "°\n";
                }
                txtShow.Text = message;
            }
            generateXML2();
        }
        catch (Exception e1)
        {
            txtShow.Text = e1.ToString();                        
        }
       
    }
    protected void generateXML()
    {
        System.Xml.XmlTextWriter xmlWriter = new XmlTextWriter(Server.MapPath("./1234.xml"), System.Text.Encoding.UTF8);
        xmlWriter.Formatting = Formatting.Indented;
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("数据");

        for (int j = 1; j <= cityList.GetLength(); j++)    
        {
            xmlWriter.WriteStartElement("城市");
            xmlWriter.WriteAttributeString("名称", cityList.SearchNode(j).Name);
            xmlWriter.WriteAttributeString("纬度", cityList.SearchNode(j).X.ToString());
            xmlWriter.WriteAttributeString("经度", cityList.SearchNode(j).Y.ToString());
            xmlWriter.WriteEndElement();
        }

        //写文档结束，调用WriteEndDocument方法
        xmlWriter.WriteEndDocument();
        //关闭textWriter
        xmlWriter.Close();
    }
    protected void generateXML1()
    {
        System.Xml.XmlTextWriter xmlWriter = new XmlTextWriter(Server.MapPath("./1234.xml"), System.Text.Encoding.UTF8);
        xmlWriter.Formatting = Formatting.Indented;
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("数据");

        for (int j = 1; j <= cityList.GetLength(); j++)
        {
            xmlWriter.WriteStartElement("城市");
            xmlWriter.WriteAttributeString("名称", cityList.SearchNode(j).Name);
            xmlWriter.WriteAttributeString("纬度", cityList.SearchNode(j).X.ToString());
            xmlWriter.WriteAttributeString("经度", cityList.SearchNode(j).Y.ToString());
            xmlWriter.WriteEndElement();
        }
        xmlWriter.WriteStartElement("查询");
        xmlWriter.WriteAttributeString("名称", txtSearchCityName.Text);
        xmlWriter.WriteEndElement();
        //写文档结束，调用WriteEndDocument方法
        xmlWriter.WriteEndDocument();
        //关闭textWriter
        xmlWriter.Close();
    }
    protected void generateXML2()
    {
        System.Xml.XmlTextWriter xmlWriter = new XmlTextWriter(Server.MapPath("./1234.xml"), System.Text.Encoding.UTF8);
        xmlWriter.Formatting = Formatting.Indented;
        xmlWriter.WriteStartDocument();
        xmlWriter.WriteStartElement("数据");

        for (int j = 1; j <= cityList.GetLength(); j++)
        {
            xmlWriter.WriteStartElement("城市");
            xmlWriter.WriteAttributeString("名称", cityList.SearchNode(j).Name);
            xmlWriter.WriteAttributeString("纬度", cityList.SearchNode(j).X.ToString());
            xmlWriter.WriteAttributeString("经度", cityList.SearchNode(j).Y.ToString());
            xmlWriter.WriteEndElement();
        }
        xmlWriter.WriteStartElement("特殊查询");
        xmlWriter.WriteAttributeString("纬度", txtSpecAltitude.Text);
        xmlWriter.WriteAttributeString("经度", txtSpecLongitude.Text);
        xmlWriter.WriteAttributeString("距离", distance.ToString());
        xmlWriter.WriteEndElement();
        //写文档结束，调用WriteEndDocument方法
        xmlWriter.WriteEndDocument();
        //关闭textWriter
        xmlWriter.Close();
    }
    protected void readXML()
    {
        list.Clear();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Server.MapPath("./1234.xml")); 
        XmlNodeList nodeList = xmlDoc.GetElementsByTagName("城市");
        foreach (XmlNode node in nodeList)
        {
            string cityName = ((XmlElement)node).GetAttribute("名称");     
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

