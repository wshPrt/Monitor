using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FS.Monitor.Common
{
        /// <summary>
        /// XmlHelper 的摘要说明
        /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// xml文件信息
        /// </summary>
        public XmlDocument xmlDoc;

        /// <summary>
        /// xml文件地址
        /// </summary>
        public string fileName { get; private set; }

        /// <summary>
        /// 加载xml数据（若文件不存在，则自动建立一个xml文件）
        /// </summary>
        /// <param name="fileName">xml文件地址</param>
        /// <param name="rootName">根结点名称</param>
        /// <param name="encoding">编码</param>
        public XmlHelper(string fileName, string rootName, string encoding = "utf-8")
        {
            xmlDoc = new XmlDocument();
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentOutOfRangeException("fileName");

            if (!File.Exists(fileName))
                CreatexmlDocument(fileName, rootName, encoding);
            else
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
            }

            if (!XmlHasFile())
                throw new NullReferenceException("Xml数据信息为空！");

            this.fileName = fileName;
        }

        #region 公共方法

        /// <summary>
        /// 重新加载新的Xml文件
        /// </summary>
        /// <param name="fileName">xml文件地址</param>
        public void ReLoadFile(string fileName)
        {
            this.xmlDoc = new XmlDocument();
            this.xmlDoc.Load(fileName);
            this.fileName = fileName;
        }

        /// <summary>
        /// 释放xml文件
        /// </summary>
        /// <param name="save">释放前是否保持文件信息</param>
        public void Dispose(bool save = false)
        {
            if (save)
                xmlDoc.Save(fileName);
            xmlDoc = null;
            fileName = string.Empty;
        }
        #endregion

        #region 增删改
        /// <summary>
        /// 插入一个节点和它的若干子节点
        /// </summary>
        /// <param name="NewNodeName">插入的节点名称</param>
        /// <param name="HasAttributes">此节点是否具有属性，True为有，False为无</param>
        /// <param name="fatherNode">此插入节点的父节点,要匹配的XPath表达式(例如:"//节点名//子节点名)</param>
        /// <param name="htAtt">此节点的属性，Key为属性名，Value为属性值</param>
        /// <param name="htSubNode">子节点的属性，Key为Name,Value为InnerText</param>
        /// <returns>返回真为更新成功，否则失败</returns>
        public bool InsertNode(string NewNodeName, bool HasAttributes, string fatherNode, Hashtable htAtt, Hashtable htSubNode)
        {
            try
            {
                if (!XmlHasFile())
                    throw new NullReferenceException("Xml Files Is Null");

                XmlNode root = xmlDoc.SelectSingleNode(fatherNode);
                var xmlelem = xmlDoc.CreateElement(NewNodeName);
                if (htAtt != null && HasAttributes)//若此节点有属性，则先添加属性
                {
                    SetAttributes(xmlelem, htAtt);
                    SetNodes(xmlelem.Name, xmlDoc, xmlelem, htSubNode);//添加完此节点属性后，再添加它的子节点和它们的InnerText
                }
                else
                {
                    SetNodes(xmlelem.Name, xmlDoc, xmlelem, htSubNode);//若此节点无属性，那么直接添加它的子节点
                }
                
                root.AppendChild(xmlelem);
                xmlDoc.Save(this.fileName);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 更新节点
        /// </summary>
        /// <param name="fatherNode">需要更新节点的上级节点,要匹配的XPath表达式(例如:"//节点名//子节点名)</param>
        /// <param name="htAtt">需要更新的属性表，Key代表需要更新的属性，Value代表更新后的值</param>
        /// <param name="htSubNode">需要更新的子节点的属性表，Key代表需要更新的子节点名字Name,Value代表更新后的值InnerText</param>
        /// <returns>返回真为更新成功，否则失败</returns>
        public bool UpdateNode(string fatherNode, Hashtable htAtt, Hashtable htSubNode)
        {
            try
            {
                if (!XmlHasFile())
                    throw new NullReferenceException("Xml Files Is Null");

                XmlNodeList root = xmlDoc.SelectSingleNode(fatherNode).ChildNodes;
                UpdateNodes(root, htAtt, htSubNode);
                xmlDoc.Save(fileName);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 删除指定节点下的子节点
        /// </summary>
        /// <param name="fatherNode">制定节点,要匹配的XPath表达式(例如:"//节点名//子节点名)</param>
        /// <returns>返回真为更新成功，否则失败</returns>
        public bool DeleteNodes(string fatherNode)
        {
            try
            {
                if (!XmlHasFile())
                    throw new NullReferenceException("Xml Files Is Null");

                var xmlnode = xmlDoc.SelectSingleNode(fatherNode);
                xmlnode.RemoveAll();
                xmlDoc.Save(fileName);
                return true;
            }
            catch (XmlException xe)
            {
                throw new XmlException(xe.Message);
            }
        }
        /*ｋｅｌｅｙｉ*/
        /// <summary>
        /// 删除匹配XPath表达式的第一个节点(节点中的子元素同时会被删除)
        /// </summary>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool DeleteXmlNodeByXPath(string xpath)
        {
            bool isSuccess = false;
            try
            {
                if (!XmlHasFile())
                    throw new NullReferenceException("Xml Files Is Null");

                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //删除节点
                    xmlDoc.ParentNode.RemoveChild(xmlNode);
                }
                xmlDoc.Save(fileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        /// <summary>
        /// 删除匹配XPath表达式的第一个节点中的匹配参数xmlAttributeName的属性
        /// </summary>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <param name="xmlAttributeName">要删除的xmlAttributeName的属性名称</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool DeleteXmlAttributeByXPath(string xpath, string xmlAttributeName)
        {
            bool isSuccess = false;
            bool isExistsAttribute = false;
            try
            {
                if (!XmlHasFile())
                    throw new NullReferenceException("Xml Files Is Null");

                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                XmlAttribute xmlAttribute = null;
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    foreach (XmlAttribute attribute in xmlNode.Attributes)
                    {
                        if (attribute.Name.ToLower() == xmlAttributeName.ToLower())
                        {
                            //节点中存在此属性
                            xmlAttribute = attribute;
                            isExistsAttribute = true;
                            break;
                        }
                    }
                    if (isExistsAttribute)
                    {
                        //删除节点中的属性
                        xmlNode.Attributes.Remove(xmlAttribute);
                    }
                }
                xmlDoc.Save(fileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }

        /// <summary>
        /// 删除匹配XPath表达式的第一个节点中的所有属性
        /// </summary>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool DeleteAllXmlAttributeByXPath(string xpath)
        {
            bool isSuccess = false;
            try
            {
                if (!XmlHasFile())
                    throw new NullReferenceException("Xml Files Is Null");

                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    //遍历xpath节点中的所有属性
                    xmlNode.Attributes.RemoveAll();
                }
                xmlDoc.Save(fileName); //保存到XML文档
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 判断xml文件是否加载数据。
        /// </summary>
        /// <returns>True为加载，False为未加载数据</returns>
        private bool XmlHasFile()
        {
            return null != this.xmlDoc;
        }

        /// <summary>
        /// 创建一个带有根节点的Xml文件
        /// </summary>
        /// <param name="FileName">Xml文件名称</param>
        /// <param name="RootName">根节点名称</param>
        /// <param name="Encode">编码方式:gb2312，UTF-8等常见的</param>
        /// <param name="DirPath">保存的目录路径</param>
        ///<returns></returns>
        public bool CreatexmlDocument(string FileName, string RootName, string Encode)
        {
            try
            {
                xmlDoc = new XmlDocument();
                XmlDeclaration xmldecl;
                xmldecl = xmlDoc.CreateXmlDeclaration("1.0", Encode, null);
                xmlDoc.AppendChild(xmldecl);
                var xmlelem = xmlDoc.CreateElement("", RootName, "");
                xmlDoc.AppendChild(xmlelem);
                xmlDoc.Save(FileName);
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// 设置节点属性
        /// </summary>
        /// <param name="xe">节点所处的Element</param>
        /// <param name="htAttribute">节点属性，Key代表属性名称，Value代表属性值</param>
        private void SetAttributes(XmlElement xe, Hashtable htAttribute)
        {
            foreach (DictionaryEntry de in htAttribute)
            {
                xe.SetAttribute(de.Key.ToString(), de.Value.ToString());
            }
        }
        /// <summary>
        /// 增加子节点到根节点下
        /// </summary>
        /// <param name="rootNode">上级节点名称</param>
        /// <param name="xmlDoc">Xml文档</param>
        /// <param name="rootXe">父根节点所属的Element</param>
        /// <param name="SubNodes">子节点属性，Key为Name值，Value为InnerText值</param>
        private void SetNodes(string rootNode, XmlDocument xmlDoc, XmlElement rootXe, Hashtable SubNodes)
        {
            if (SubNodes == null)
                return;
            foreach (DictionaryEntry de in SubNodes)
            {
                var xmlnode = xmlDoc.SelectSingleNode(rootNode);
                XmlElement subNode = xmlDoc.CreateElement(de.Key.ToString());
                subNode.InnerText = de.Value.ToString();
                rootXe.AppendChild(subNode);
            }
        }
        /// <summary>
        /// 更新节点属性和子节点InnerText值。
        /// </summary>
        /// <param name="root">根节点名字</param>
        /// <param name="htAtt">需要更改的属性名称和值</param>
        /// <param name="htSubNode">需要更改InnerText的子节点名字和值</param>
        private void UpdateNodes(XmlNodeList root, Hashtable htAtt, Hashtable htSubNode)
        {
            foreach (XmlNode xn in root)
            {
                var xmlelem = (XmlElement)xn;
                if (xmlelem.HasAttributes)//如果节点如属性，则先更改它的属性
                {
                    foreach (DictionaryEntry de in htAtt)//遍历属性哈希表
                    {
                        if (xmlelem.HasAttribute(de.Key.ToString()))//如果节点有需要更改的属性
                        {
                            xmlelem.SetAttribute(de.Key.ToString(), de.Value.ToString());//则把哈希表中相应的值Value赋给此属性Key
                        }
                    }
                }
                if (xmlelem.HasChildNodes)//如果有子节点，则修改其子节点的InnerText
                {
                    XmlNodeList xnl = xmlelem.ChildNodes;
                    foreach (XmlNode xn1 in xnl)
                    {
                        XmlElement xe = (XmlElement)xn1;
                        foreach (DictionaryEntry de in htSubNode)
                        {
                            if (xe.Name == de.Key.ToString())//htSubNode中的key存储了需要更改的节点名称，
                            {
                                xe.InnerText = de.Value.ToString();//htSubNode中的Value存储了Key节点更新后的数据
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region XML文档节点查询和读取
        /// <summary>
        /// 选择匹配XPath表达式的第一个节点XmlNode.
        /// </summary>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名")</param>
        /// <returns>返回XmlNode</returns>
        public XmlNode GetXmlNodeByXpath(string xpath)
        {
            try
            {
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                return xmlNode;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex; //这里可以定义你自己的异常处理
            }
        }

        /// <summary>
        /// 选择匹配XPath表达式的节点列表XmlNodeList.
        /// </summary>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名")</param>
        /// <returns>返回XmlNodeList</returns>
        public XmlNodeList GetXmlNodeListByXpath(string xpath)
        {
            try
            {
                XmlNodeList xmlNodeList = xmlDoc.SelectNodes(xpath);
                return xmlNodeList;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex; //这里可以定义你自己的异常处理
            }
        }

        /// <summary>
        /// 选择匹配XPath表达式的第一个节点的匹配xmlAttributeName的属性XmlAttribute. /// </summary>
        /// <param name="xpath">要匹配的XPath表达式(例如:"//节点名//子节点名</param>
        /// <param name="xmlAttributeName">要匹配xmlAttributeName的属性名称</param>
        /// <returns>返回xmlAttributeName</returns>
        public XmlAttribute GetXmlAttribute(string xpath, string xmlAttributeName)
        {
            string content = string.Empty;
            XmlAttribute xmlAttribute = null;
            try
            {
                XmlNode xmlNode = xmlDoc.SelectSingleNode(xpath);
                if (xmlNode != null)
                {
                    if (xmlNode.Attributes.Count > 0)
                    {
                        xmlAttribute = xmlNode.Attributes[xmlAttributeName];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return xmlAttribute;
        }
        #endregion
    }
}
