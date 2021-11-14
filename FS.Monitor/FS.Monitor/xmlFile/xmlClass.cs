using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FS.Monitor.xmlFile
{
    public class xmlClass
    {
        ///创建xml 实例化XmlDocument
        XmlDocument xdoc = new XmlDocument();

        /// <summary>
        /// 新建xml文档
        /// </summary>
        /// <param name="path">文档的路径</param>
        /// <param name="name">文档的名称（不包括后缀名）</param>
        /// <param name="root">根目录的名称</param>
        public void NewXml(string path, string name, string root)
        {
            ///创建一个声明xml文档所需要语法的变量
            XmlDeclaration xdec = xdoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xdoc.AppendChild(xdec);
            //创建根节点
            XmlElement elem = xdoc.CreateElement(root);
            //放入节点
            xdoc.AppendChild(elem);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            xdoc.Save(path + "\\" + name + ".xml");
        }
        /// <summary>
        /// 添加xml数据
        /// </summary>
        /// <param name="path">xml文件路径(含文件名、后缀)</param>
        /// <param name="rootName">根节点名</param>
        /// <param name="nodename">子节点名</param>
        /// <param name="attributeName">内容名(等号前面的文字)</param>
        /// <param name="attributeValue">值(等号后面的文字)</param>
        public void AddXmlData(string path, string rootName, string nodename,string attributeName, string attributeValue)
        {
            xdoc.Load(path);
            XmlNode root = xdoc.SelectSingleNode(rootName);
            XmlElement xe = xdoc.CreateElement(nodename);
            //xe.SetAttribute("Corol", "255,23,203,100");
            xe.SetAttribute(attributeName, attributeValue);
            //xe.InnerText = attributeText;
            root.AppendChild(xe);
            xdoc.Save(path);
        }

        /// <summary>
        /// 删除属性值等于“AttributeValue”的节点
        /// </summary>
        /// <param name="xmlFileName">XML文档完全文件名(包含物理路径)</param>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <param name="xmlAttributeName">要删除包含xmlAttributeName属性的节点的名称</param>
        /// <param name="AttributeValue"></param>
        public void DeleteXmlData(string xmlFileName, string xpath, string xmlAttributeName, string AttributeValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFileName);
            XmlNodeList xNodes = xmlDoc.SelectSingleNode(xpath).ChildNodes;
            for (int i = xNodes.Count - 1; i >= 0; i--)
            {
                XmlElement xe = (XmlElement)xNodes[i];
                if (xe.GetAttribute(xmlAttributeName) == AttributeValue)
                {
                    xNodes[i].ParentNode.RemoveChild(xNodes[i]);
                }
            }
            xmlDoc.Save(xmlFileName);
        }
        /// <summary>
        /// 修改xml数据
        /// </summary>
        /// <param name="path">xml文件路径(含文件名、后缀)</param>
        /// <param name="nodeAndUp">要修改的节点名称和值,如name='小梦科技'</param>
        /// <param name="up">修改后的文字</param>
        public void UpdateXmlData(string path, string nodeAndUp, string up)
        {
            try
            {
                // 获取文档对象
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                //获取根节点
                XmlElement order = doc.DocumentElement;
                // 获取单个节点
                //XmlNode xn = order.SelectSingleNode(@"/Order/Items/OrderItem[@Name='码表']");
                XmlNode xn = order.SelectSingleNode(@"/MonitorManage/Node[@" + nodeAndUp + "]");
                xn.Attributes.Item(0).Value = up; // 修改
                doc.Save(path);
            }
            catch
            {
                //MessageBox.Show("异常：无法修改，查看是否符合修改要求",
                //    "提醒", MessageBoxButtons.OKCancel);
            }
        }
        /// <summary>
        /// 查询或获取xml数据
        /// </summary>
        public DataSet SelectXmlData(string path)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("节点");
            dt.Columns.Add("名称");
            if (File.Exists(path))
            {
                xdoc.Load(path);
                // 获取根节点
                XmlElement orderElement = xdoc.DocumentElement;
                XmlNodeList orderChildr = orderElement.ChildNodes;
                foreach (XmlNode item in orderChildr)
                {
                    //s.Add(item.Attributes.Item(0).LocalName + "=" + item.Attributes.Item(0).Value);
                    //Console.WriteLine(item.Attributes.Item(0).LocalName + ",节点名称：" + item.Attributes.Item(0).Value);

                    DataRow drs = dt.NewRow();
                    drs[0] = item.Attributes.Item(0).LocalName;
                    drs[1] = item.Attributes.Item(0).Value;
                    dt.Rows.Add(drs);
                }
                ds.Tables.Add(dt);
            }
            else
            {
                //MessageBox.Show("异常：查看是否缺少" + Application.StartupPath + "\\stock\\basicData.xml" + "文件",
                //    "提醒", MessageBoxButtons.OKCancel);
            }
            return ds;
        }
    }
}