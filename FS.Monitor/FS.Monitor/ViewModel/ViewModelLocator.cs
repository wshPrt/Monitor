using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace FS.Monitor.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MaintainViewModel>();
            SimpleIoc.Default.Register<SettingViewModel>();
            SimpleIoc.Default.Register<ControlBoxViewModel>();
            SimpleIoc.Default.Register<RunningViewModel>();
            SimpleIoc.Default.Register<StudyViewModel>();
        }

        public MainViewModel Main //主页
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public LoginViewModel Login //登陆
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
        
        public MaintainViewModel Maintain  //查询维护
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MaintainViewModel>();
            }
        }
        public SettingViewModel Setting  //系统设置
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingViewModel>();
            }
        }
        public ControlBoxViewModel Control //控制箱
        {
            get 
            {
                return ServiceLocator.Current.GetInstance<ControlBoxViewModel>();
            }
        }
        public RunningViewModel Run  //运行状态
        {
            get 
            {
                return ServiceLocator.Current.GetInstance<RunningViewModel>();
            }
        }
        public StudyViewModel Study  //自主学习
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudyViewModel>();
            }
        }
        public static void Cleanup()
        {
        
        }
    }
}