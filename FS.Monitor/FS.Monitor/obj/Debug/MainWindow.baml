   M S B A M L   `   `   `  ����E  AFS.Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FS.Monitor.Common.LanguageFS.Monitor.Common.Language  5      'clr-namespace:FS.Monitor
FS.Monitor  5      G(clr-namespace:FS.Monitor.Common.ConcoverFS.Monitor.Common.Concover  5	          FS.Monitor.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      3lang(clr-namespace:FS.Monitor.Common.Language  5      $localclr-namespace:FS.Monitor  5      7localTab(clr-namespace:FS.Monitor.Common.Concover  5	      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        $
��1366��5      $	��880��5      ���	#FF141720  � 
ResizeMode$  CanResizeWithGrip=�5         MaterialDesignBody#���   5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � DataContext 5      ��   Locator �� Source# [  �� Path$
 Main�'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ -1q�6    � 	Resources 5      	 �� MergedDictionaries
 �� Source3   -FS.Monitor.Common.Concover.TabToBoolConverter  TabToBoolConverter  NavTabButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius � ColumnDefinitions
 � Tag �� Triggers P� Property P� Value�� 5   
   	 5      �� 5      $#
 ./Template/DefaultStyles.xaml?�6%   %�  &	       &	        5      6*   �� 5       " 	�6.   .�5!      ��  � ��$ 15(�6-   �� 5"       � ��
 �����6/   �� 5#       � ��$
 10,5q�6,   �� 5$       � ��$	 5,0q�6+   �� 5%       � ��
 ���� 6/   �� 5&       � �� 6,   �� *TabChangedCommand+�� 5'       � �� 5(      �� 5)      " 	�6*   .R�5*      �� #��z��6%   $ 5,5,0,0��6O   ._�5+   "   �  5,   &   �� 5-   *   $
��auto �6;   �� 5.   *   .+�50   &   �� $��10,0,0,0q�51   )   $��Center=�52   )   $��Center=�53   )   $��../Fonts/#iconfont)�54   )   $��14(�55   )   #��z 56   )   �� 57   &   $��1��58   )   #��z��59   )   #��z��5:   )   #��z��5;   )   5=   #   5>      5?      5A       5B      P� 5C       �@d�	IsChecked$
 TrueY�63   . �5D      ��  � �� �	#FF4ABAD067   �� 5E       � ��
 ���� 67   5F      5H      5I      .��5K      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ 
RootDialog��6    .��5L   
   �  � RowDefinitions 5M      �� 5N      $
��Auto �6    �� 5O      $
��Auto �6    �� 5P      $��* �6    �� 5Q      $
��Auto �6    .+�5U      (  "MaterialDesignThemes.Wpf.ColorZone  -   5          Name$ 	ColorZone��5V      $��0��5W      $��10q�5X      $	��Top=�5Y      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5Z      ���#141720$��0q�5\         Mode$ 
PrimaryMid=�5]      .��5^      ]� .+�5_      �� $��Center=�6!    �� Orientation$ 
Horizontal=�6<   .+�5i      �� $
��Auto��5j      $
��Left=�5k      $��18(�5l      ���	#FFA9AAAF��5n      �� *%#LongitudinalMonitorManagementSystem+-   'FS.Monitor.Common.Language.LangProvider   Instance# Z 5o      �� 5q      $��Right=�6!   $ 
Horizontal=�6=   .+�5r      �� -   5        
������ 
������ ���	#FF4ABAD0 ! MaterialDesignFlatMidBgButton#��[ 5x      ��5v      ��  �� RelativeSource ��  �� Mode$
 Self=�$ ToolTip� � ToolTip 5y      �� *
Minimize+# Z .��5z      �� $ 
Horizontal=�6)   .+�5{   "   '  !MaterialDesignThemes.Wpf.PackIcon  $��20��5|   %   $��20��5}   %   $��Center=�5~   %      Kind$ WindowMinimize=�5   %   5�      5�      �� 5�      -   5          ��Name$  btnMAx��5�      $	��5,0q�5�      
������ 
������ ���	#FF4ABAD0#��[ 5�      ��5�      ��  �� $
 Self=�$ ToolTip� 5�      �� *
Maximize+# Z .��5�      �� $ 
Horizontal=�6)   .+�5�   "     -   5        !  Name$! btnIcon��5�   %   $��20��5�   %   $��20��5�   %   $��Center=�5�   %   $ WindowMaximize=�5�   %   5�      5�      �� 5�      -   5        $��30��5�      $��Right=�5�      
������ 
������ ���	#FF4ABAD0#��[ 5�      ��5�      ��  �� $
 Self=�$ ToolTip� 5�      �� *
ExitSystem+# Z .��5�        $��20��5�   !   $��20��5�   !   $��Center=�5�   !   $ WindowClose=�5�   !   5�      �� 5�      -   5        $��ButtonConfig��5�      $��1��5�      
������ 
������ ���	#FF4ABAD0#��[ 5�      .��5�        $��20��5�   !   $��20��5�   !   $��Center=�5�   !   $ 
CogOutline=�5�   !   5�      � 5�      -   5        $��PopupConfig��5�      $��1��5�      " � AllowsTransparency" . # � HorizontalOffset$	# -28��5�      $ � 	StaysOpen$ .  % � VerticalOffset$% 6��5�      & � PlacementTarget& 5�      �� ' �� ElementName$' ButtonConfig��.��5�      �� $��16q�6%   
������ ._�5�   "   �� 
������ $ 
Horizontal=�6F   .+�5�   &   �� $��10q�61   $ 
Horizontal=�6=   .+�5�   *   �� -	   5        
������ .+�5�   .   �� 
������ $��0q�5�   1   $ zh-cn��5�   1   .��5�   2   �� $��32��68   $.��(/FS.Monitor;component/Images/Flag/cn.png��6C   5�   /   �� 5�   .   $��0,10,0,0q�5�   1   
������ $��0q�5�   1   $ en-us��5�   1   .��5�   2   �� $��32��68   $.��(/FS.Monitor;component/Images/Flag/en.png��6C   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      ]� 5�      $��1��6   .+�5�      �� $
��auto��5�      
������ ���#EEEFF2._�5�      �� $��1��5�      $��40��5�      $��15,-45,220,0q�5�      $��Right=�5�      $	��Top=�5�      $ 
Horizontal=�5�      .+�5�      	� $
��Auto��5�      $��35��5�      $��Bottom=�5�      $#��FS.Monitor.Views.VideoPreview��5�      $��18(�5�      ( d� 	IsChecked$
( TrueY�5�      #��[ 5�      ��5�      �� *VideoPreview+# Z 5�      	� 5�      $	��120��5�      $��35��5�      $��Bottom=�5�      $#��FS.Monitor.Views.LibertyStudy��5�      $��18(�5�      #��[ 5�      ��5�      �� *
Learning+# Z 5�      	� 5�      $	��123��5�      $��35��5�      $��Bottom=�5�      $$��FS.Monitor.Views.QueryMaintain��5�      $��18(�5�      #��[ 5�      $	 ��5�      ��5�      �� *HistoricalEvents+# Z 5�      	� 5�      $	��120��5      $��35��5     $��Bottom=�5     $$��FS.Monitor.Views.SystemSetting��5     $��18(�5     #��[ 5     $	 ��5     ��5     �� *
Settings+# Z 5     	� 5     $��90��5	     $��35��5
     $��Bottom=�5     $!��FS.Monitor.Views.ControlBox��5     $��18(�5     #��[ 5     ��5     �� *
ControlBox+# Z 5     	� 5     $	��120��5     $��35��5     $��Bottom=�5     $$��FS.Monitor.Views.RunningStatus��5     $��18(�5     #��[ 5     ��5     �� *DeviceRunning+# Z 5     5     5     5     �� 5     -
   5        ) ��Name$) ctSwitch��5     $��2��5     ��5     �� *MainContent+�� 5!     $��3��5"     $��	25,10,0,0q�5#     $
��Left=�5$     $ 
Horizontal=�5%     .+�5&       $��28��5'     $��23��5(     ���	#FF9B9B9B$ BookmarkOutline=�5*     �� 5+     * �� Padding$
* 10,0q�5,     $��16(�5-     ���	#FF419EB1��5/     �� *DepartmentName+# Z �� 50     $��16(�51     ���	#FF58D164��53     �� *Plant+# Z 54     �� 55     $��3��56     $��
320,10,0,0q�57     $
��Left=�58     $ 
Horizontal=�59     .+�5:       $��28��5;     $��23��5<     ���	#FF9B9B9B$ BookmarkOutline=�5>     �� 5?     $
* 10,0q�5@     $��16(�5A     ���	#FF419EB1��5C     �� *
UserName+# Z �� 5D     $��16(�5E     ���	#FF58D164$
��user��5G     5H     �� 5I     $��3��5J     $��
510,10,0,0q�5K     $
��Left=�5L     $ 
Horizontal=�5M     .+�5N       $��28��5O     $��23��5P     ���	#FF9B9B9B$ BookmarkOutline=�5R     �� 5S     $	* 5,0q�5T     $��16(�5U     ���	#FF419EB1��5W     �� *	UserRight+# Z �� 5X     $��16(�5Y     ���	#FF58D164��5[     �� *SystemAdministrator+# Z 5\     �� 5q     $��3��5r     $��
820,10,0,0q�5s     $
��Left=�5t     $ 
Horizontal=�5u     .+�5v       $��28��5w     $��23��5x     ���	#FF9B9B9B$ BookmarkOutline=�5z     �� 5{     $
* 10,0q�5|     $��16(�5}     ���	#FF419EB1��5     �� *SystemRunning+# Z �� 5�     $��16(�5�     ���	#FF58D164��5�     �� *
SystemDate+# Z 5�     5�     5�     5�     