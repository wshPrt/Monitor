   M S B A M L   `   `   `  ����E  AFS.Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:FS.Monitor.Common.WindowCloseFS.Monitor.Common.WindowClose  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      G(clr-namespace:FS.Monitor.Common.LanguageFS.Monitor.Common.Language  5	      3clr-namespace:FS.Monitor.ViewsFS.Monitor.Views  5
      G(clr-namespace:FS.Monitor.Common.ExtendedFS.Monitor.Common.Extended  5           FS.Monitor.Views.LoginView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      A	behaviors+clr-namespace:FS.Monitor.Common.WindowClose     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      beventPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      3lang(clr-namespace:FS.Monitor.Common.Language  5	      *localclr-namespace:FS.Monitor.Views  5
      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      3pass(clr-namespace:FS.Monitor.Common.Extended  5      $	��480��5      $	��430��5      ���	#FF212330  � WindowStartupLocation$  CenterScreen=�5       � WindowStyle$
 None=�5       � DataContext 5      ��    Locator �� Source# [   �� Path$ Login�.  (System.Windows.Interactivity.Interaction   	Behaviors 5      8   2FS.Monitor.Common.WindowClose.WindowCloseBehaviour  5   
      Close 6)   �� *	ToClose+'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ -1q�6   .��5      )  #MaterialDesignThemes.Wpf.DialogHost  	   
Identifier$
	 Root��6    .��5   
   � 
 +� FocusedElement
 6   ��  �� ElementName$ txtUser��.+�5      � $��20q�6    � RowDefinitions 5      �� 5       �� 5!      �� 5"      �� 5#      .+�5&      �� $��20,0,0,0q�5'      $��Center=�5(      $��35(�5)      $
��Bold"�5*      
���������5,      �� *LongitudinalTearingMonitoring+-   'FS.Monitor.Common.Language.LangProvider   Instance# Z �� 5.      -   5        $��60��5/      $��Right=�50      ���	#FF49B7CE  MaterialDesignFlatButton#��[ 54      ��52      ��  �� RelativeSource ��  �� Mode$
 Self=�$ ToolTip� � ToolTip 55      �� *Close+# Z .��56      '  !MaterialDesignThemes.Wpf.PackIcon  $��50��57      $��50��58         Kind$ Close=�59      5:      �� 5<      -   5         ��Name$ txtUser��5=      $��1��5>      $��	20,0,20,0q�5?      $��Center=�5@      )  #MaterialDesignThemes.Wpf.HintAssist   FloatingScale$	 0.8Q�5A         
Foreground �	#FF49B7CE$��22(�5D      
������� % !MaterialDesignFloatingHintTextBox#��[ 5F         Hint 5C      �� *	Account+# Z ��5G      �� *
UserName+.��6/   .��5J   0   5K      G� 5M      -   5         G�Name$ txtPassWord��5N      $��2��5O      $��	20,0,20,0q�5P      $��Center=�5Q      $	 0.8Q�5R       �	#FF49B7CE$��22(�5V      
������� ) %MaterialDesignFloatingHintPasswordBox#��[ 5X       5T      �� *
Password+# Z 3   -FS.Monitor.Common.Extended.PassWordExtensions   Password 5U      �� *
PassWord+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�*	  $Microsoft.Xaml.Behaviors.Interaction 	  	Behaviors 5Y      4
   .FS.Monitor.Common.Extended.PasswordBoxBehavior
  5Z       J� InputBindings 5\      �� 5]      
 �� Key$ Enter��5^       �� Command 5_      �� *	Execute+ �� CommandParameter 5`      �� $ txtPassWord��5b      �� 5d      $��2��5e      $��2��5f      $	��392��5g      $��
20,80,0,80q�5h      $
��Left=�5i      $��22(�5j      
���  �� �� TextAlignment$ Center=�5m      ��5l      �� *Report+5m      �� 5o      $��3��5p      $��55��5q      $
��20,0q�5r      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist    IndicatorBackground  �	#FF49B7CE!   IndicatorForeground
! ���� "   IsIndicatorVisible" . #   Value$# -1Q�5v      ���	#FF49B7CE
������ $��0q�5y      $��23(�5~        MaterialDesignRaisedButton#��[ 5      ��5z      �� *	Execute+��5{      ��  �� $
 Self=�$ Content���5|      �� *Login+# Z $ � FocusVisualStyle$ 5}      Z� 5      5�      5�      5�      5�      