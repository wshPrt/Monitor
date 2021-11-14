using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.ObjectModel;
using FS.Monitor.Model;

namespace FS.Monitor.xmlFile
{
    public class xmlHandleClass
    {
        xmlClass xc = new xmlClass();
        string path = Application.StartupPath + "\\Config\\monitor.xml";
        /// <summary>
        /// 新增xml
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ProjectName"></param>
        /// <param name="LineNumber"></param>
        /// <param name="NotEnable"></param>
        /// <param name="StartTime"></param>
        public void newXml(string id, string ProjectName, string LineNumber, string NotEnable, string StartTime)
        {
            if (!File.Exists(path))
            {
                xc.NewXml(Application.StartupPath + "\\Config\\", "monitor", "MonitorManage");

                xc.AddXmlData(path, "MonitorManage", "Node",
                    "Id", id);
                xc.AddXmlData(path, "MonitorManage", "Node",
                    "ProjectName", ProjectName);
                xc.AddXmlData(path, "MonitorManage", "Node",
                    "LineNumber", LineNumber);
                xc.AddXmlData(path, "MonitorManage", "Node",
                   "NotEnable", NotEnable);
                xc.AddXmlData(path, "MonitorManage", "Node",
                    "StartTime", StartTime);
            }
            else
            {
                xc.AddXmlData(path, "MonitorManage", "Node",
                     "Id", id);
                xc.AddXmlData(path, "MonitorManage", "Node",
                    "ProjectName", ProjectName);
                xc.AddXmlData(path, "MonitorManage", "Node",
                    "LineNumber", LineNumber);
                xc.AddXmlData(path, "MonitorManage", "Node",
                   "NotEnable", NotEnable);
                xc.AddXmlData(path, "MonitorManage", "Node",
                    "StartTime", StartTime);
            }

        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataSet Query()
        {
            return xc.SelectXmlData(path);
        }

        public string Id;
        public string ProjectName;
        public string LineNumber;
        public string NotEnable;
        public string StartTime;
        public void GetInitData()
        {
            for (int i = 0; i < Query().Tables[0].Rows.Count; i++)
            {
                string s = Query().Tables[0].Rows[i][1].ToString();
                string s1 = Query().Tables[0].Rows[i][0].ToString();
                if (s1 == "Id")
                {
                    Id = s;
                }
                if (s1 == "ProjectName")
                {
                    ProjectName = s;
                }
                if (s1 == "LineNumber")
                {
                    LineNumber = s;
                }
                if (s1 == "NotEnable")
                {
                    NotEnable = s;
                }
                if (s1 == "StartTime")
                {
                    StartTime = s;
                }


            }
            //foreach (DataRow item in Query().Tables[0].Rows)
            //{
            //    MonitorModel model = new MonitorModel(); 
            //    if (int.TryParse(item.Table.Select()[0].ItemArray[1]?.ToString(), out int id))
            //    {
            //        model.Id = id;
            //    };

            //    model.ProjectName = item.Table.Select()[1].ItemArray[1]?.ToString();//item["ProjectName"]?.ToString();
            //    model.LineNumber = item.Table.Select()[2].ItemArray[1]?.ToString();// item["LineNumber"]?.ToString();

            //    MonitorList.Add(model);
            //}
        }
        private List<MonitorModel> _monitorList =new List<MonitorModel>();
        public List<MonitorModel> MonitorList
        {
            get { return _monitorList; }
            set { _monitorList = value;}
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="data"></param>
        public void Modify(string[] data)
        {
            GetInitData();
            xc.UpdateXmlData(path, "Id='" + Id + "'", data[0].ToString());
            xc.UpdateXmlData(path, "ProjectName='" + ProjectName + "'", data[1].ToString());
            xc.UpdateXmlData(path, "LineNumber='" + LineNumber + "'", data[2].ToString());
            xc.UpdateXmlData(path, "NotEnable='" + NotEnable + "'", data[3].ToString());
            xc.UpdateXmlData(path, "StartTime='" + StartTime + "'", data[4].ToString());
        }

        public void DeleteXml() 
        {
            //xc.DeleteXmlData(path,);
        }
    }
}
