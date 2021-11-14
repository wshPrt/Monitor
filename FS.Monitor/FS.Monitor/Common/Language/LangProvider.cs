using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace FS.Monitor.Common.Language
{
    public class LangProvider : INotifyPropertyChanged
    {

        public static LangProvider Instance { get; } = ResourceHelper.GetResourceInternal<LangProvider>("Langs");
        
        private static string CultureInfoStr;

        internal static CultureInfo Culture
        {
            get => Lang.Culture;
            set
            {
                if (value == null) return;
                if (Equals(CultureInfoStr, value.EnglishName)) return;
                Lang.Culture = value;
                CultureInfoStr = value.EnglishName;
                
                Instance.UpdateLangs();
            }
        }

        public static string GetLang(string key) => Lang.ResourceManager.GetString(key, Culture);

        public static void SetLang(DependencyObject dependencyObject, DependencyProperty dependencyProperty, string key) =>
            BindingOperations.SetBinding(dependencyObject, dependencyProperty, new Binding(key)
            {
                Source = Instance,
                Mode = BindingMode.OneWay
            });

        public void UpdateLangs()
        {
            OnPropertyChanged(nameof(LongitudinalMonitorManagementSystem));
            OnPropertyChanged(nameof(LongitudinalTearingMonitoring));
            OnPropertyChanged(nameof(Close));
            OnPropertyChanged(nameof(Account));
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(Login)); 
            OnPropertyChanged(nameof(LightBrightness));
            OnPropertyChanged(nameof(VideoPreview));
            OnPropertyChanged(nameof(Learning ));
            OnPropertyChanged(nameof(PitchAngle));
            OnPropertyChanged(nameof(Chroma));
            OnPropertyChanged(nameof(CloseTag));
            OnPropertyChanged(nameof(Open));
            OnPropertyChanged(nameof(AbnormalWarning));
            OnPropertyChanged(nameof(BeltSpeed));
            OnPropertyChanged(nameof(CPUTemperature));
            OnPropertyChanged(nameof(GraphicsCardTemperature));
            OnPropertyChanged(nameof(EmergencyStop));
            OnPropertyChanged(nameof(Accelerate));
            OnPropertyChanged(nameof(Decelerate));
            OnPropertyChanged(nameof(AutonomyLearning));
            OnPropertyChanged(nameof(StartLearning));
            OnPropertyChanged(nameof(BeingLearning));
            OnPropertyChanged(nameof(Plant)); 
            OnPropertyChanged(nameof(ImageManipulation));
            OnPropertyChanged(nameof(FlipBack)); 
            OnPropertyChanged(nameof(FlipForward));
            OnPropertyChanged(nameof(Magnifier));
            OnPropertyChanged(nameof(PressEsc));
            OnPropertyChanged(nameof(StartTime));
            OnPropertyChanged(nameof(EndTime));
            OnPropertyChanged(nameof(Filter));
            OnPropertyChanged(nameof(MarkOldWound));
            OnPropertyChanged(nameof(Delete));
            OnPropertyChanged(nameof(ExceptionRecord));
            OnPropertyChanged(nameof(SerialNumber));
            OnPropertyChanged(nameof(Time));
            OnPropertyChanged(nameof(Camera));
            OnPropertyChanged(nameof(BeltPosition));
            OnPropertyChanged(nameof(AbnormalLocation));
            OnPropertyChanged(nameof(SelectAll));
            OnPropertyChanged(nameof(SaveSettings)); 
            OnPropertyChanged(nameof(AutonomyLearningCompleted));
            OnPropertyChanged(nameof(StudyAgain));
            OnPropertyChanged(nameof(DisplayCoordinate));
            OnPropertyChanged(nameof(HideCoordinate));
            OnPropertyChanged(nameof(CurrentMonitoringPoint));
            OnPropertyChanged(nameof(A_CoalMine));
            OnPropertyChanged(nameof(B_CoalMine));
            OnPropertyChanged(nameof(PointOne));
            OnPropertyChanged(nameof(PointTwo));
            OnPropertyChanged(nameof(PointThere));
            OnPropertyChanged(nameof(MonitorManage));
            OnPropertyChanged(nameof(AddItem));
            OnPropertyChanged(nameof(ProjectName));
            OnPropertyChanged(nameof(LineNumber));
            OnPropertyChanged(nameof(IsNotEnable));
            OnPropertyChanged(nameof(Operate));
            OnPropertyChanged(nameof(Revise));
            OnPropertyChanged(nameof(Enable_Now));
            OnPropertyChanged(nameof(NewItem));
            OnPropertyChanged(nameof(Project_Name));
            OnPropertyChanged(nameof(Maximize));
            OnPropertyChanged(nameof(Minimize));
            OnPropertyChanged(nameof(ExitSystem));
            OnPropertyChanged(nameof(Line_Number));
            OnPropertyChanged(nameof(PleaseEnterProjectName));
            OnPropertyChanged(nameof(PleaseEnterLineNumber));
            OnPropertyChanged(nameof(EnableNow));
            OnPropertyChanged(nameof(No));
            OnPropertyChanged(nameof(Confirm));
            OnPropertyChanged(nameof(ModifyItem));
            OnPropertyChanged(nameof(DetermineDeleteCurrentEquipment));
            OnPropertyChanged(nameof(delProject));
            OnPropertyChanged(nameof(DeviceManage));
            OnPropertyChanged(nameof(AddDevice));
            OnPropertyChanged(nameof(NewEquipment));
            OnPropertyChanged(nameof(LineSelect));
            OnPropertyChanged(nameof(DeviceName));
            OnPropertyChanged(nameof(DeviceNumber));
            OnPropertyChanged(nameof(IpAddress));
            OnPropertyChanged(nameof(PortNumber));
            OnPropertyChanged(nameof(Line_1));
            OnPropertyChanged(nameof(PleaseEnterDeviceName));
            OnPropertyChanged(nameof(PleaseEnterDeviceNumber));
            OnPropertyChanged(nameof(PleaseEnterIPAddress));
            OnPropertyChanged(nameof(PleaseEnterPort));
            OnPropertyChanged(nameof(Device_Name));
            OnPropertyChanged(nameof(IP_Address));
            OnPropertyChanged(nameof(Port));
            OnPropertyChanged(nameof(DeviceStatus));
            OnPropertyChanged(nameof(OwnedLine));
            OnPropertyChanged(nameof(UserModify));
            OnPropertyChanged(nameof(Modify));
            OnPropertyChanged(nameof(PleaseEnterUserName));
            OnPropertyChanged(nameof(PleaseEnterUserPassword));
            OnPropertyChanged(nameof(PleaseEnterUserPasswordAgain));
            OnPropertyChanged(nameof(ModifyDevice));
            

            OnPropertyChanged(nameof(HistoricalEvents));
            OnPropertyChanged(nameof(Settings));
            OnPropertyChanged(nameof(ControlBox));
            OnPropertyChanged(nameof(DeviceRunning));
            OnPropertyChanged(nameof(OneSignVertex));
            OnPropertyChanged(nameof(DustCoverSpeedAdjustment));
            OnPropertyChanged(nameof(ViewControl));
            OnPropertyChanged(nameof(AlarmToRemind));
            OnPropertyChanged(nameof(Contrast));
            OnPropertyChanged(nameof(Saturation));
            OnPropertyChanged(nameof(Luminance));
            OnPropertyChanged(nameof(ConveyorChoice));
            OnPropertyChanged(nameof(CurrentLineOne));
            OnPropertyChanged(nameof(SprayWash));
            OnPropertyChanged(nameof(HandSpray));
            OnPropertyChanged(nameof(BeltDamageGrade));
            OnPropertyChanged(nameof(SlightlyDamaged));
            OnPropertyChanged(nameof(CleanCoverSpeedAdjustment));
            OnPropertyChanged(nameof(SpeedRegulation));
            OnPropertyChanged(nameof(TurnSpeed));
            OnPropertyChanged(nameof(DepartmentName));
            OnPropertyChanged(nameof(UserName));
            OnPropertyChanged(nameof(UserRight));
            OnPropertyChanged(nameof(SystemAdministrator));
            OnPropertyChanged(nameof(SystemRunning));
            OnPropertyChanged(nameof(SystemDate));
            OnPropertyChanged(nameof(Yes));
            OnPropertyChanged(nameof(ZoomIn));
            OnPropertyChanged(nameof(ZoomOut));
            OnPropertyChanged(nameof(Cancel));
        }
        
        /// <summary>
        /// 查找类似 主页标题 的本地化字符串。
        /// </summary>
        public string LongitudinalMonitorManagementSystem => Lang.LongitudinalMonitorManagementSystem;
        /// <summary>
        /// 查找类似 登陆标题 的本地化字符串。
        /// </summary>
        public string LongitudinalTearingMonitoring => Lang.LongitudinalTearingMonitoring;
        /// <summary>
        /// 查找类似 关闭 的本地化字符串。
        /// </summary>
        public string Close => Lang.Close;
        /// <summary>
        ///   查找类似 账号 的本地化字符串。
        /// </summary>
		public string Account => Lang.Account;

        /// <summary>
        ///   查找类似 密码 的本地化字符串。
        /// </summary>
		public string Password => Lang.Password;

        /// <summary>
        ///   查找类似 登陆 的本地化字符串。
        /// </summary>
		public string Login => Lang.Login;
        /// <summary>
        /// 灯光亮度
        /// </summary>
        public string LightBrightness => Lang.LightBrightness;
        /// <summary>
        ///   查找类似 视频预览 的本地化字符串。LightBrightness
        /// </summary>
		public string VideoPreview => Lang.VideoPreview;

        /// <summary>
        ///   查找类似 历史事件 的本地化字符串。
        /// </summary>
		public string HistoricalEvents => Lang.HistoricalEvents;

        /// <summary>
        ///   查找类似 系统设置 的本地化字符串。
        /// </summary>
		public string Settings => Lang.Settings;

        /// <summary>
        ///   查找类似 控制箱 的本地化字符串。
        /// </summary>
		public string ControlBox => Lang.ControlBox;

        /// <summary>
        ///   查找类似 设备运行 的本地化字符串。
        /// </summary>
		public string DeviceRunning => Lang.DeviceRunning;

        /// <summary>
        ///   查找类似 1号点 的本地化字符串。
        /// </summary>
		public string OneSignVertex => Lang.OneSignVertex;

        /// <summary>
        ///   查找类似 视图控制 的本地化字符串。
        /// </summary>
		public string ViewControl => Lang.ViewControl;

        /// <summary>
        ///   查找类似 报警提醒 的本地化字符串。
        /// </summary>
		public string AlarmToRemind => Lang.AlarmToRemind;

        /// <summary>
        /// 查找类似 加速 的本地化字符串。
        /// </summary>
        public string Accelerate => Lang.Accelerate;

        /// <summary>
        /// 查找类似 减速 的本地化字符串。
        /// </summary>
        public string Decelerate => Lang.Decelerate;

        /// <summary>
        ///   查找类似 对比度 的本地化字符串。
        /// </summary>
        public string Contrast => Lang.Contrast;

        /// <summary>
        ///   查找类似 饱和度 的本地化字符串。
        /// </summary>
		public string Saturation => Lang.Saturation;

        /// <summary>
        ///  查找类似 关 的本地化字符串。
        /// </summary>
        public string CloseTag => Lang.CloseTag;

        /// <summary>
        /// 查找类似 开 的本地化字符串。
        /// </summary>
        public string Open => Lang.Open;

        /// <summary>
        ///   查找类似 亮度 的本地化字符串。
        /// </summary>
        public string Luminance => Lang.Luminance;

        /// <summary>
        ///  查找类似 自主学习 的本地化字符串。
        /// </summary>
        public string Learning => Lang.Learning;

        /// <summary>
        /// 查找类似 自主学习(标题) 的本地化字符串。
        /// </summary>
        public string AutonomyLearning => Lang.AutonomyLearning;

        /// <summary>
        /// 查找类似 开始学习 的本地化字符串。
        /// </summary>
        public string StartLearning => Lang.StartLearning;

        /// <summary>
        /// 查找类似 正在学习中... 的本地化字符串。
        /// </summary>
        public string BeingLearning => Lang.BeingLearning;
        
        /// <summary>
        ///   查找类似 色度 的本地化字符串。
        /// </summary>
        public string Chroma => Lang.Chroma;

        /// <summary>
        /// 俯仰角度
        /// </summary>
        public string PitchAngle => Lang.PitchAngle;

        /// <summary>
        ///   查找类似 输送机选择 的本地化字符串。
        /// </summary>
        public string ConveyorChoice => Lang.ConveyorChoice;

        /// <summary>
        ///   查找类似 当前选择 的本地化字符串。
        /// </summary>
		public string CurrentChoice => Lang.CurrentChoice;

        /// <summary>
        ///   查找类似 当前线路1 的本地化字符串。
        /// </summary>
		public string CurrentLineOne => Lang.CurrentLineOne;

        /// <summary>
        /// 查找类似 防尘罩转速调节 的本地化字符串。
        /// </summary>
        public string DustCoverSpeedAdjustment => Lang.DustCoverSpeedAdjustment;

        /// <summary>
        ///  查找类似 异常告警 的本地化字符串。
        /// </summary>
        public string AbnormalWarning => Lang.AbnormalWarning;

        /// <summary>
        /// 查找类似 皮带速度 的本地化字符串。
        /// </summary>
        public string BeltSpeed => Lang.BeltSpeed;

        /// <summary>
        /// 查找类似 CPU温度 的本地化字符串。
        /// </summary>
        public string CPUTemperature => Lang.CPUTemperature;

        /// <summary>
        ///  查找类似 显卡温度 的本地化字符串。
        /// </summary>
        public string GraphicsCardTemperature => Lang.GraphicsCardTemperature;

        /// <summary>
        /// 查找类似 急停 的本地化字符串。
        /// </summary>
        public string EmergencyStop => Lang.EmergencyStop;

        /// <summary>
        /// 查找类似 xxxx厂 的本地化字符串。
        /// </summary>
        public string Plant => Lang.Plant;

        /// <summary>
        /// 查找类似 图片操作 的本地化字符串。
        /// </summary>
        public string ImageManipulation => Lang.ImageManipulation;

        /// <summary>
        /// 查找类似 向后翻阅 的本地化字符串。
        /// </summary>
        public string FlipBack => Lang.FlipBack;

        /// <summary>
        /// 查找类似 向前翻阅 的本地化字符串。
        /// </summary>
        public string FlipForward => Lang.FlipForward;

        /// <summary>
        /// 查找类似 放大镜 的本地化字符串。
        /// </summary>
        public string Magnifier => Lang.Magnifier;

        /// <summary>
        /// 查找类似 按Esc退出放大镜 的本地化字符串。
        /// </summary>
        public string PressEsc => Lang.PressEsc;

        /// <summary>
        ///  查找类似 开始时间 的本地化字符串。
        /// </summary>
        public string StartTime => Lang.StartTime;

        /// <summary>
        ///  查找类似 结束时间 的本地化字符串。
        /// </summary>
        public string EndTime => Lang.EndTime;

        /// <summary>
        ///  查找类似 筛选 的本地化字符串。
        /// </summary>
        public string Filter => Lang.Filter;

        /// <summary>
        ///  查找类似 标记为旧伤 的本地化字符串。
        /// </summary>
        public string MarkOldWound => Lang.MarkOldWound;

        /// <summary>
        ///  查找类似 删除 的本地化字符串。
        /// </summary>
        public string Delete => Lang.Delete;

        /// <summary>
        ///  查找类似 异常记录 的本地化字符串。
        /// </summary>
        public string ExceptionRecord => Lang.ExceptionRecord;

        /// <summary>
        /// 查找类似 序号 的本地化字符串。
        /// </summary>
        public string SerialNumber => Lang.SerialNumber;

        /// <summary>
        /// 查找类似 时间 的本地化字符串。
        /// </summary>
        public string Time => Lang.Time;

        /// <summary>
        /// 查找类似 相机 的本地化字符串。
        /// </summary>
        public string Camera => Lang.Camera;

        /// <summary>
        /// 查找类似 皮带位置 的本地化字符串。
        /// </summary>
        public string BeltPosition => Lang.BeltPosition;

        /// <summary>
        /// 查找类似 异常位置 的本地化字符串。
        /// </summary>
        public string AbnormalLocation => Lang.AbnormalLocation;

        /// <summary>
        /// 查找类似 全选 的本地化字符串。
        /// </summary>
        public string SelectAll => Lang.SelectAll;
        
        /// <summary>
        /// 查找类似 保存设置 的本地化字符串。
        /// </summary>
        public string SaveSettings => Lang.SaveSettings;

        /// <summary>
        /// 查找类似 自主学习已完成 的本地化字符串。
        /// </summary>
        public string AutonomyLearningCompleted => Lang.AutonomyLearningCompleted;

        /// <summary>
        /// 查找类似 重新学习 的本地化字符串。
        /// </summary>
        public string StudyAgain => Lang.StudyAgain;

        /// <summary>
        /// 查找类似 显示坐标 的本地化字符串。
        /// </summary>
        public string DisplayCoordinate => Lang.DisplayCoordinate;

        /// <summary>
        ///  查找类似 隐藏坐标 的本地化字符串。
        /// </summary>
        public string HideCoordinate => Lang.HideCoordinate;
        
        /// <summary>
        /// 查找类似 当前监测测点 的本地化字符串。
        /// </summary>
        public string CurrentMonitoringPoint => Lang.CurrentMonitoringPoint;

        /// <summary>
        /// 查找类似 A煤矿 的本地化字符串。
        /// </summary>
        public string A_CoalMine => Lang.A_CoalMine;

        /// <summary>
        /// 查找类似 B煤矿 的本地化字符串。
        /// </summary>
        public string B_CoalMine => Lang.B_CoalMine;

        /// <summary>
        /// 查找类似 监测管理 的本地化字符串。
        /// </summary>
        public string MonitorManage => Lang.MonitorManage;

        /// <summary>
        /// 查找类似 添加项目 的本地化字符串。
        /// </summary>
        public string AddItem => Lang.AddItem;

        /// <summary>
        /// 查找类似 项目名称 的本地化字符串。
        /// </summary>
        public string ProjectName => Lang.ProjectName;

        /// <summary>
        /// 查找类似 线路编号 的本地化字符串。
        /// </summary>
        public string LineNumber => Lang.LineNumber;
        
        /// <summary>
        ///   查找类似 喷淋冲洗 的本地化字符串。
        /// </summary>
        public string SprayWash => Lang.SprayWash;

        /// <summary>
        /// 查找类似 1号点 的本地化字符串。
        /// </summary>
        public string PointOne => Lang.PointOne;

        /// <summary>
        /// 查找类似 2号点 的本地化字符串。
        /// </summary>
        public string PointTwo => Lang.PointTwo;

        /// <summary>
        /// 查找类似 3号点 的本地化字符串。
        /// </summary>
        public string PointThere => Lang.PointThere;

        /// <summary>
        /// 查找类似 是否启用 的本地化字符串。
        /// </summary>
        public string IsNotEnable => Lang.IsNotEnable;

        /// <summary>
        /// 查找类似 操作 的本地化字符串。
        /// </summary>
        public string Operate => Lang.Operate;

        /// <summary>
        /// 查找类似 修改 的本地化字符串。
        /// </summary>
        public string Revise => Lang.Revise;

        /// <summary>
        /// 查找类似 立即启用 的本地化字符串。
        /// </summary>
        public string Enable_Now => Lang.Enable_Now;

        /// <summary>
        /// 查找类似 新增项目 的本地化字符串。
        /// </summary>
        public string NewItem => Lang.NewItem;

        /// <summary>
        /// 查找类似 项目名称: 的本地化字符串。
        /// </summary>
        public string Project_Name => Lang.Project_Name;

        /// <summary>
        /// 查找类似 最小化 的本地化字符串。
        /// </summary>
        public string Minimize => Lang.Minimize;

        /// <summary>
        /// 查找类似 最大化 的本地化字符串。
        /// </summary>
        public string Maximize => Lang.Maximize;

        /// <summary>
        /// 查找类似 退出系统 的本地化字符串。
        /// </summary>
        public string ExitSystem => Lang.ExitSystem;

        /// <summary>
        /// 查找类似 线路编号 的本地化字符串。
        /// </summary>
        public string Line_Number => Lang.Line_Number;

        /// <summary>
        /// 查找类似 请输入项目名称 的本地化字符串。
        /// </summary>
        public string PleaseEnterProjectName => Lang.PleaseEnterProjectName;

        /// <summary>
        /// 查找类似 请输入线路编号 的本地化字符串。
        /// </summary>
        public string PleaseEnterLineNumber => Lang.PleaseEnterLineNumber;

        /// <summary>
        /// 查找类似 立即启用 的本地化字符串。
        /// </summary>
        public string EnableNow => Lang.EnableNow;

        /// <summary>
        ///  查找类似 否 的本地化字符串。
        /// </summary>
        public string No => Lang.No;

        /// <summary>
        /// 查找类似 确认 的本地化字符串。
        /// </summary>
        public string Confirm => Lang.Confirm;

        /// <summary>
        /// 查找类似 修改项目 的本地化字符串。
        /// </summary>
        public string ModifyItem => Lang.ModifyItem;

        /// <summary>
        ///  查找类似 确定删除当前设备吗? 的本地化字符串。
        /// </summary>
        public string DetermineDeleteCurrentEquipment => Lang.DetermineDeleteCurrentEquipment;

        /// <summary>
        /// 查找类似 确定删除当前项目? 的本地化字符串。 
        /// </summary>
        public string delProject => Lang.delProject;

        /// <summary>
        ///  查找类似 设备管理 的本地化字符串。 
        /// </summary>
        public string DeviceManage => Lang.DeviceManage;

        /// <summary>
        /// 查找类似 添加设备 的本地化字符串。 
        /// </summary>
        public string AddDevice => Lang.AddDevice;

        /// <summary>
        /// 查找类似 新增设备 的本地化字符串。 
        /// </summary>
        public string NewEquipment => Lang.NewEquipment;

        /// <summary>
        /// 查找类似 线路选择： 的本地化字符串。 
        /// </summary>
        public string LineSelect => Lang.LineSelect;

        /// <summary>
        /// 查找类似 设备名称： 的本地化字符串。
        /// </summary>
        public string DeviceName => Lang.DeviceName;

        /// <summary>
        ///  查找类似 设备编号： 的本地化字符串。
        /// </summary>
        public string DeviceNumber => Lang.DeviceNumber;

        /// <summary>
        /// 查找类似 IpAddress： 的本地化字符串。
        /// </summary>
        public string IpAddress => Lang.IpAddress;

        /// <summary>
        /// 查找类似 PortNumber： 的本地化字符串。
        /// </summary>
        public string PortNumber => Lang.PortNumber;

        /// <summary>
        /// 查找类似 线路1： 的本地化字符串。
        /// </summary>
        public string Line_1 => Lang.Line_1;

        /// <summary>
        /// 查找类似 请输入设备名称 的本地化字符串。
        /// </summary>
        public string PleaseEnterDeviceName => Lang.PleaseEnterDeviceName;

        /// <summary>
        /// 查找类似 请输入设备编号 的本地化字符串。
        /// </summary>
        public string PleaseEnterDeviceNumber => Lang.PleaseEnterDeviceNumber;

        /// <summary>
        ///  查找类似 请输入IP地址 的本地化字符串。
        /// </summary>
        public string PleaseEnterIPAddress => Lang.PleaseEnterIPAddress;

        /// <summary>
        /// 查找类似 请输入端口 的本地化字符串。
        /// </summary>
        public string PleaseEnterPort => Lang.PleaseEnterPort;

        /// <summary>
        /// 查找类似 设备名称 的本地化字符串。
        /// </summary>
        public string Device_Name => Lang.Device_Name;

        /// <summary>
        /// 查找类似 编号 的本地化字符串。
        /// </summary>
        public string Number => Lang.Number;

        /// <summary>
        /// 查找类似 IP地址 的本地化字符串。
        /// </summary>
        public string IP_Address => Lang.IP_Address;

        /// <summary>
        /// 查找类似 端口 的本地化字符串。
        /// </summary>
        public string Port => Lang.Port;

        /// <summary>
        /// 查找类似 设备状态 的本地化字符串。
        /// </summary>
        public string DeviceStatus => Lang.DeviceStatus;

        /// <summary>
        /// 查找类似 所属线路 的本地化字符串。
        /// </summary>
        public string OwnedLine => Lang.OwnedLine;

        /// <summary>
        /// 查找类似 用户修改 的本地化字符串。
        /// </summary>
        public string UserModify => Lang.UserModify;

        /// <summary>
        ///  查找类似 修改 的本地化字符串。
        /// </summary>
        public string Modify => Lang.Modify;

         /// <summary>
         /// 查找类似 请输入用户名称 的本地化字符串。
         /// </summary>
        public string PleaseEnterUserName => Lang.PleaseEnterUserName;

        /// <summary>
        /// 查找类似 请输入用户密码 的本地化字符串。
        /// </summary>
        public string PleaseEnterUserPassword => Lang.PleaseEnterUserPassword;

        /// <summary>
        /// 查找类似 请再次输入用户密码 的本地化字符串。
        /// </summary>
        public string PleaseEnterUserPasswordAgain => Lang.PleaseEnterUserPasswordAgain;

        /// <summary>
        /// 查找类似 修改设备 的本地化字符串。
        /// </summary>
        public string ModifyDevice => Lang.ModifyDevice;
        
        /// <summary>
        ///   查找类似 手动喷淋 的本地化字符串。
        /// </summary>
        public string HandSpray => Lang.HandSpray;

        /// <summary>
        ///   查找类似 皮带损伤等级 的本地化字符串。
        /// </summary>
		public string BeltDamageGrade => Lang.BeltDamageGrade;

        /// <summary>
        ///   查找类似 轻微破损 的本地化字符串。
        /// </summary>
		public string SlightlyDamaged => Lang.SlightlyDamaged;

        /// <summary>
        ///   查找类似 清洁罩转速调节 的本地化字符串。
        /// </summary>
		public string CleanCoverSpeedAdjustment => Lang.CleanCoverSpeedAdjustment;

        /// <summary>
        ///   查找类似 转速调节 的本地化字符串。
        /// </summary>
        public string SpeedRegulation => Lang.SpeedRegulation;

        /// <summary>
        ///   查找类似 当前转速 的本地化字符串。
        /// </summary>
		public string TurnSpeed => Lang.TurnSpeed;

        /// <summary>
        ///   查找类似 部门名称 的本地化字符串。
        /// </summary>
		public string DepartmentName => Lang.DepartmentName;

        /// <summary>
        ///   查找类似 用户名称 的本地化字符串。
        /// </summary>
		public string UserName => Lang.UserName;
        /// <summary>
        ///   查找类似 用户权限 的本地化字符串。
        /// </summary>
        public string UserRight => Lang.UserRight;

        /// <summary>
        ///   查找类似 系统管理员 的本地化字符串。
        /// </summary>
		public string SystemAdministrator => Lang.SystemAdministrator;

        /// <summary>
        ///   查找类似 系统已运行 的本地化字符串。
        /// </summary>
		public string SystemRunning => Lang.SystemRunning;
        /// <summary>
        ///  查找类似 系统日期 的本地化字符串。
        /// </summary>
        public string SystemDate => Lang.SystemDate;
        /// <summary>
        ///   查找类似 是 的本地化字符串。
        /// </summary>
		public string yes => Lang.Yes;

        /// <summary>
        ///   查找类似 放大 的本地化字符串。
        /// </summary>
		public string ZoomIn => Lang.ZoomIn;

        /// <summary>
        ///   查找类似 是 的本地化字符串。
        /// </summary>
		public string Yes => Lang.Yes;

        /// <summary>
        ///   查找类似 缩小 的本地化字符串。
        /// </summary>
		public string ZoomOut => Lang.ZoomOut;

        /// <summary>
        ///   查找类似 取消 的本地化字符串。
        /// </summary>
		public string Cancel => Lang.Cancel;


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class LangKeys
    {
        /// <summary>
        /// 查找类似 主页标题 的本地化字符串。
        /// </summary>
        public string LongitudinalMonitorManagementSystem => Lang.LongitudinalMonitorManagementSystem;
        /// <summary>
        ///   查找类似 账号 的本地化字符串。
        /// </summary>
        public string Account => Lang.Account;

        /// <summary>
        ///   查找类似 密码 的本地化字符串。
        /// </summary>
		public string Password => Lang.Password;

        /// <summary>
        ///   查找类似 登陆 的本地化字符串。
        /// </summary>
		public string Login => Lang.Login;

        /// <summary>
        ///   查找类似 视频预览 的本地化字符串。
        /// </summary>
		public string VideoPreview => Lang.VideoPreview;
        /// <summary>
        /// 查找类似 关 的本地化字符串。
        /// </summary>
        public string CloseTag => Lang.CloseTag;
        /// <summary>
        /// 查找类似 开 的本地化字符串。
        /// </summary>
        public string Open => Lang.Open;
        /// <summary>
        /// 查找类似 异常告警 的本地化字符串。
        /// </summary>
        public string AbnormalWarning => Lang.AbnormalWarning;
        /// <summary>
        /// 查找类似 皮带速度 的本地化字符串。
        /// </summary>
        public string BeltSpeed => Lang.BeltSpeed;
        /// <summary>
        /// 查找类似 CPU温度 的本地化字符串。
        /// </summary>
        public string CPUTemperature => Lang.CPUTemperature;

        /// <summary>
        ///  查找类似 显卡温度 的本地化字符串。
        /// </summary>
        public string GraphicsCardTemperature => Lang.GraphicsCardTemperature;

        /// <summary>
        /// 查找类似 急停 的本地化字符串。
        /// </summary>
        public string EmergencyStop => Lang.EmergencyStop;

        /// <summary>
        /// 查找类似 加速 的本地化字符串。
        /// </summary>
        public string Accelerate => Lang.Accelerate;

        /// <summary>
        /// 查找类似 xxxx厂 的本地化字符串。
        /// </summary>
        public string Plant => Lang.Plant;

        /// <summary>
        /// 查找类似 图片操作 的本地化字符串。
        /// </summary>
        public string ImageManipulation => Lang.ImageManipulation;

        /// <summary>
        /// 查找类似 向后翻阅 的本地化字符串。
        /// </summary>
        public string FlipBack => Lang.FlipBack;

        /// <summary>
        /// 查找类似 向前翻阅 的本地化字符串。
        /// </summary>
        public string FlipForward => Lang.FlipForward;

        /// <summary>
        /// 查找类似 放大镜 的本地化字符串。
        /// </summary>
        public string Magnifier => Lang.Magnifier;

        /// <summary>
        /// 查找类似 按Esc退出放大镜 的本地化字符串。
        /// </summary>
        public string PressEsc => Lang.PressEsc;

        /// <summary>
        ///  查找类似 开始时间 的本地化字符串。
        /// </summary>
        public string StartTime => Lang.StartTime;

        /// <summary>
        ///  查找类似 结束时间 的本地化字符串。
        /// </summary>
        public string EndTime => Lang.EndTime;
        
        /// <summary>
        /// 筛选
        /// </summary>
        public string Filter => Lang.Filter;

        /// <summary>
        ///  查找类似 标记为旧伤 的本地化字符串。
        /// </summary>
        public string MarkOldWound => Lang.MarkOldWound;

        /// <summary>
        ///  查找类似 删除 的本地化字符串。
        /// </summary>
        public string Delete => Lang.Delete;

        /// <summary>
        /// 查找类似 时间 的本地化字符串。
        /// </summary>
        public string Time => Lang.Time;

        /// <summary>
        /// 查找类似 相机 的本地化字符串。
        /// </summary>
        public string Camera => Lang.Camera;

        /// <summary>
        /// 查找类似 皮带位置 的本地化字符串。
        /// </summary>
        public string BeltPosition => Lang.BeltPosition;

        /// <summary>
        /// 查找类似 异常位置 的本地化字符串。
        /// </summary>
        public string AbnormalLocation => Lang.AbnormalLocation;

        /// <summary>
        /// 查找类似 全选 的本地化字符串。
        /// </summary>
        public string SelectAll => Lang.SelectAll;

        /// <summary>
        /// 查找类似 保存设置 的本地化字符串。
        /// </summary>
        public string SaveSettings => Lang.SaveSettings;

        /// <summary>
        ///  查找类似 异常记录 的本地化字符串。
        /// </summary>
        public string ExceptionRecord => Lang.ExceptionRecord;

        /// <summary>
        /// 查找类似 序号 的本地化字符串。
        /// </summary>
        public string SerialNumber => Lang.SerialNumber;

        /// <summary>
        /// 查找类似 减速 的本地化字符串。
        /// </summary>
        public string Decelerate => Lang.Decelerate;

        /// <summary>
        /// 自主学习
        /// </summary>
        public string Learning => Lang.Learning;

        /// <summary>
        /// 查找类似 自主学习(标题) 的本地化字符串。
        /// </summary>
        public string AutonomyLearning => Lang.AutonomyLearning;

        /// <summary>
        /// 查找类似 开始学习 的本地化字符串。
        /// </summary>
        public string StartLearning => Lang.StartLearning;

        /// <summary>
        /// 查找类似 正在学习中... 的本地化字符串。
        /// </summary>
        public string BeingLearning => Lang.BeingLearning;

        /// <summary>
        ///   查找类似 历史事件 的本地化字符串。
        /// </summary>
		public string HistoricalEvents => Lang.HistoricalEvents;

        /// <summary>
        ///   查找类似 系统设置 的本地化字符串。
        /// </summary>
		public string Settings => Lang.Settings;

        /// <summary>
        /// 查找类似 自主学习已完成 的本地化字符串。
        /// </summary>
        public string AutonomyLearningCompleted => Lang.AutonomyLearningCompleted;

        /// <summary>
        /// 查找类似 重新学习 的本地化字符串。
        /// </summary>
        public string StudyAgain => Lang.StudyAgain;

        /// <summary>
        /// 查找类似 显示坐标 的本地化字符串。
        /// </summary>
        public string DisplayCoordinate => Lang.DisplayCoordinate;

        /// <summary>
        ///  查找类似 隐藏坐标 的本地化字符串。
        /// </summary>
        public string HideCoordinate => Lang.HideCoordinate;

        /// <summary>
        /// 查找类似 当前监测测点 的本地化字符串。
        /// </summary>
        public string CurrentMonitoringPoint => Lang.CurrentMonitoringPoint;

        /// <summary>
        /// 查找类似 A煤矿 的本地化字符串。
        /// </summary>
        public string A_CoalMine => Lang.A_CoalMine;

        /// <summary>
        /// 查找类似 B煤矿 的本地化字符串。
        /// </summary>
        public string B_CoalMine => Lang.B_CoalMine;

        /// <summary>
        /// 查找类似 1号点 的本地化字符串。
        /// </summary>
        public string PointOne => Lang.PointOne;

        /// <summary>
        /// 查找类似 2号点 的本地化字符串。
        /// </summary>
        public string PointTwo => Lang.PointTwo;

        /// <summary>
        /// 查找类似 3号点 的本地化字符串。
        /// </summary>
        public string PointThere => Lang.PointThere;

        /// <summary>
        /// 查找类似 监测管理 的本地化字符串。 
        /// </summary>
        public string MonitorManage => Lang.MonitorManage;

        /// <summary>
        /// 查找类似 添加项目 的本地化字符串。 
        /// </summary>
        public string AddItem => Lang.AddItem;

        /// <summary>
        /// 查找类似 项目名称 的本地化字符串。
        /// </summary>
        public string ProjectName => Lang.ProjectName;

        /// <summary>
        /// 查找类似 线路编号 的本地化字符串。
        /// </summary>
        public string LineNumber => Lang.LineNumber;

        /// <summary>
        /// 查找类似 是否启用 的本地化字符串。
        /// </summary>
        public string IsNotEnable => Lang.IsNotEnable;

        /// <summary>
        /// 查找类似 操作 的本地化字符串。
        /// </summary>
        public string Operate => Lang.Operate;

        /// <summary>
        /// 查找类似 修改 的本地化字符串。
        /// </summary>
        public string Revise => Lang.Revise;

        /// <summary>
        /// 查找类似 立即启用 的本地化字符串。
        /// </summary>
        public string Enable_Now => Lang.Enable_Now;

        /// <summary>
        /// 查找类似 新增项目 的本地化字符串。
        /// </summary>
        public string NewItem => Lang.NewItem;

        /// <summary>
        /// 查找类似 项目名称: 的本地化字符串。
        /// </summary>
        public string Project_Name => Lang.Project_Name;

        /// <summary>
        /// 查找类似 最小化 的本地化字符串。
        /// </summary>
        public string Minimize => Lang.Minimize;

        /// <summary>
        /// 查找类似 最大化 的本地化字符串。
        /// </summary>
        public string Maximize => Lang.Maximize;

        /// <summary>
        /// 查找类似 退出系统 的本地化字符串。
        /// </summary>
        public string ExitSystem => Lang.ExitSystem;

        /// <summary>
        /// 查找类似 线路编号 的本地化字符串。
        /// </summary>
        public string Line_Number => Lang.Line_Number;

        /// <summary>
        /// 查找类似 请输入项目名称 的本地化字符串。
        /// </summary>
        public string PleaseEnterProjectName => Lang.PleaseEnterProjectName;

        /// <summary>
        /// 查找类似 请输入线路编号 的本地化字符串。
        /// </summary>
        public string PleaseEnterLineNumber => Lang.PleaseEnterLineNumber;

        /// <summary>
        ///  查找类似 请输入IP地址 的本地化字符串。
        /// </summary>
        public string PleaseEnterIPAddress => Lang.PleaseEnterIPAddress;

        /// <summary>
        /// 查找类似 请输入端口 的本地化字符串。
        /// </summary>
        public string PleaseEnterPort => Lang.PleaseEnterPort;
        
        /// <summary>
        /// 查找类似 立即启用 的本地化字符串。
        /// </summary>
        public string EnableNow => Lang.EnableNow;

        /// <summary>
        ///  查找类似 否 的本地化字符串。
        /// </summary>
        public string No => Lang.No;

        /// <summary>
        /// 查找类似 确认 的本地化字符串。
        /// </summary>
        public string Confirm => Lang.Confirm;

        /// <summary>
        /// 查找类似 修改项目 的本地化字符串。
        /// </summary>
        public string ModifyItem => Lang.ModifyItem;

        /// <summary>
        ///  查找类似 确定删除当前设备吗? 的本地化字符串。
        /// </summary>
        public string DetermineDeleteCurrentEquipment => Lang.DetermineDeleteCurrentEquipment;

        /// <summary>
        /// 查找类似 确定删除当前项目? 的本地化字符串。
        /// </summary>
        public string delProject => Lang.delProject;

        /// <summary>
        ///  查找类似 设备管理 的本地化字符串。 
        /// </summary>
        public string DeviceManage => Lang.DeviceManage;

        /// <summary>
        /// 查找类似 添加设备 的本地化字符串。 
        /// </summary>
        public string AddDevice => Lang.AddDevice;

        /// <summary>
        /// 查找类似 新增设备 的本地化字符串。 
        /// </summary>
        public string NewEquipment => Lang.NewEquipment;

        /// <summary>
        /// 查找类似 线路选择： 的本地化字符串。 
        /// </summary>
        public string LineSelect => Lang.LineSelect;

        /// <summary>
        /// 查找类似 设备名称： 的本地化字符串。
        /// </summary>
        public string DeviceName => Lang.DeviceName;

        /// <summary>
        ///  查找类似 设备编号： 的本地化字符串。
        /// </summary>
        public string DeviceNumber => Lang.DeviceNumber;

        /// <summary>
        /// 查找类似 IpAddress： 的本地化字符串。
        /// </summary>
        public string IpAddress => Lang.IpAddress;

        /// <summary>
        /// 查找类似 PortNumber： 的本地化字符串。
        /// </summary>
        public string PortNumber => Lang.PortNumber;

        /// <summary>
        /// 查找类似 线路1： 的本地化字符串。
        /// </summary>
        public string Line_1 => Lang.Line_1;

        /// <summary>
        /// 查找类似 请输入设备名称 的本地化字符串。
        /// </summary>
        public string PleaseEnterDeviceName => Lang.PleaseEnterDeviceName;

        /// <summary>
        /// 查找类似 请输入设备编号 的本地化字符串。
        /// </summary>
        public string PleaseEnterDeviceNumber => Lang.PleaseEnterDeviceNumber;

        /// <summary>
        /// 查找类似 编号 的本地化字符串。
        /// </summary>
        public string Number => Lang.Number;

        /// <summary>
        /// 查找类似 IP地址 的本地化字符串。
        /// </summary>
        public string IP_Address => Lang.IP_Address;

        /// <summary>
        /// 查找类似 端口 的本地化字符串。
        /// </summary>
        public string Port => Lang.Port;

        /// <summary>
        /// 查找类似 设备状态 的本地化字符串。
        /// </summary>
        public string DeviceStatus => Lang.DeviceStatus;

        /// <summary>
        /// 查找类似 所属线路 的本地化字符串。
        /// </summary>
        public string OwnedLine => Lang.OwnedLine;

        /// <summary>
        /// 查找类似 用户修改 的本地化字符串。
        /// </summary>
        public string UserModify => Lang.UserModify;

        /// <summary>
        ///  查找类似 修改 的本地化字符串。
        /// </summary>
        public string Modify => Lang.Modify;

        /// <summary>
        /// 查找类似 请输入用户名称 的本地化字符串。
        /// </summary>
        public string PleaseEnterUserName => Lang.PleaseEnterUserName;

        /// <summary>
        /// 查找类似 请输入用户密码 的本地化字符串。
        /// </summary>
        public string PleaseEnterUserPassword => Lang.PleaseEnterUserPassword;

        /// <summary>
        /// 查找类似 请再次输入用户密码 的本地化字符串。
        /// </summary>
        public string PleaseEnterUserPasswordAgain => Lang.PleaseEnterUserPasswordAgain;

        /// <summary>
        /// 查找类似 修改设备 的本地化字符串。
        /// </summary>
        public string ModifyDevice => Lang.ModifyDevice;

        /// <summary>
        ///   查找类似 控制箱 的本地化字符串。
        /// </summary>
        public string ControlBox => Lang.ControlBox;

        /// <summary>
        ///   查找类似 设备运行 的本地化字符串。
        /// </summary>
		public string DeviceRunning => Lang.DeviceRunning;

        /// <summary>
        ///   查找类似 1号点 的本地化字符串。
        /// </summary>
		public string OneSignVertex => Lang.OneSignVertex;

        /// <summary>
        ///   查找类似 视图控制 的本地化字符串。
        /// </summary>
		public string ViewControl => Lang.ViewControl;

        /// <summary>
        ///   查找类似 报警提醒 的本地化字符串。
        /// </summary>
		public string AlarmToRemind => Lang.AlarmToRemind;

        /// <summary>
        ///   查找类似 对比度 的本地化字符串。
        /// </summary>
		public string Contrast => Lang.Contrast;

        /// <summary>
        ///   查找类似 饱和度 的本地化字符串。
        /// </summary>
		public string Saturation => Lang.Saturation;

        /// <summary>
        ///   查找类似 亮度 的本地化字符串。
        /// </summary>
		public string Luminance => Lang.Luminance;

        /// <summary>
        ///   查找类似 色度 的本地化字符串。
        /// </summary>
		public string Chrominance => Lang.Chrominance;

        /// <summary>
        ///   查找类似 灯光亮度 的本地化字符串。
        /// </summary>
		public string LightBrightness => Lang.LightBrightness;

        /// <summary>
        /// 查找类似 俯仰角度 的本地化字符串。
        /// </summary>
        public string PitchAngle => Lang.PitchAngle;

        /// <summary>
        ///   查找类似 输送机选择 的本地化字符串。
        /// </summary>
        public string ConveyorChoice => Lang.ConveyorChoice;

        /// <summary>
        ///   查找类似 当前选择 的本地化字符串。
        /// </summary>
		public string CurrentChoice => Lang.CurrentChoice;

        /// <summary>
        ///   查找类似 当前线路1 的本地化字符串。
        /// </summary>
		public string CurrentLineOne => Lang.CurrentLineOne;

        /// <summary>
        ///   查找类似 喷淋冲洗 的本地化字符串。
        /// </summary>
		public string SprayWash => Lang.SprayWash;

        /// <summary>
        ///  查找类似 系统日期 的本地化字符串。
        /// </summary>
        public string SystemDate => Lang.SystemDate;

        /// <summary>
        ///   查找类似 手动喷淋 的本地化字符串。
        /// </summary>
		public string HandSpray => Lang.HandSpray;

        /// <summary>
        ///   查找类似 皮带损伤等级 的本地化字符串。
        /// </summary>
		public string BeltDamageGrade => Lang.BeltDamageGrade;

        /// <summary>
        ///   查找类似 轻微破损 的本地化字符串。
        /// </summary>
		public string SlightlyDamaged => Lang.SlightlyDamaged;

        /// <summary>
        ///   查找类似 清洁罩转速调节 的本地化字符串。
        /// </summary>
		public string CleanCoverSpeedAdjustment => Lang.CleanCoverSpeedAdjustment;

        /// <summary>
        ///   查找类似 转速调节 的本地化字符串。
        /// </summary>
        public string SpeedRegulation => Lang.SpeedRegulation;

        /// <summary>
        /// 查找类似 防尘罩转速调节 的本地化字符串。
        /// </summary>
        public string DustCoverSpeedAdjustment => Lang.DustCoverSpeedAdjustment;

        /// <summary>
        ///   查找类似 当前转速 的本地化字符串。
        /// </summary>
        public string TurnSpeed => Lang.TurnSpeed;

        /// <summary>
        ///   查找类似 部门名称 的本地化字符串。
        /// </summary>
		public string DepartmentName => Lang.DepartmentName;

        /// <summary>
        ///   查找类似 用户名称 的本地化字符串。
        /// </summary>
		public string UserName => Lang.UserName;

        /// <summary>
        ///   查找类似 用户权限 的本地化字符串。
        /// </summary>
		public string UserRight => Lang.UserRight;

        /// <summary>
        ///   查找类似 系统管理员 的本地化字符串。
        /// </summary>
		public string SystemAdministrator => Lang.SystemAdministrator;

        /// <summary>
        ///   查找类似 系统已运行 的本地化字符串。
        /// </summary>
		public string SystemRunning => Lang.SystemRunning;

        /// <summary>
        ///   查找类似 是 的本地化字符串。
        /// </summary>
		public string yes => Lang.Yes;

        /// <summary>
        ///   查找类似 放大 的本地化字符串。
        /// </summary>
		public string ZoomIn => Lang.ZoomIn;

        /// <summary>
        ///   查找类似 是 的本地化字符串。
        /// </summary>
		public string Yes => Lang.Yes;

        /// <summary>
        ///   查找类似 缩小 的本地化字符串。
        /// </summary>
		public string ZoomOut => Lang.ZoomOut;

        /// <summary>
        ///   查找类似 取消 的本地化字符串。
        /// </summary>
		public string Cancel => Lang.Cancel;

        /// <summary>
        /// 查找类似 关闭 的本地化字符串。
        /// </summary>
        public string Close => Lang.Close;
    }
}
