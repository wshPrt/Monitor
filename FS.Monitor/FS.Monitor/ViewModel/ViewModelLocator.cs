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

        public MainViewModel Main //��ҳ
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public LoginViewModel Login //��½
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
        
        public MaintainViewModel Maintain  //��ѯά��
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MaintainViewModel>();
            }
        }
        public SettingViewModel Setting  //ϵͳ����
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingViewModel>();
            }
        }
        public ControlBoxViewModel Control //������
        {
            get 
            {
                return ServiceLocator.Current.GetInstance<ControlBoxViewModel>();
            }
        }
        public RunningViewModel Run  //����״̬
        {
            get 
            {
                return ServiceLocator.Current.GetInstance<RunningViewModel>();
            }
        }
        public StudyViewModel Study  //����ѧϰ
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