   M S B A M L   `   `   `  ����E  AFS.Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FS.Monitor.ViewsFS.Monitor.Views  5      G(clr-namespace:FS.Monitor.Common.ConcoverFS.Monitor.Common.Concover  5
      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aeHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.WpfMaterialDesignThemes.Wpf 5      !    FS.Monitor.Views.MsgBoxView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:FS.Monitor.Views     5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      9system,http://schemas.microsoft.com/winfx/2009/xaml  5	      1vc(clr-namespace:FS.Monitor.Common.Concover  5
      RwpfHclr-namespace:MaterialDesignThemes.Wpf;assembly=MaterialDesignThemes.Wpf  5      -   5          � Title$  MsgBox��5      $	��400��5      $	��220��5      ���	#FF212330 � 
ResizeMode$ NoResize=�5       � ShowActivated .   � Topmost .  � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5       � 	Resources 5      4   .FS.Monitor.Common.Concover.VisibilityConverter   vis��%   &	          5   
   6!   5      .��5      � .+�5   
   �� ._�5      �  � RowDefinitions 5      �� 5      $��25 �6$   �� 5      �� 5       $��40 �6$   .+�5"      (  "MaterialDesignThemes.Wpf.ColorZone  $��40q�5#      ���	#FF4ABAD0   Mode$ 
PrimaryMid=�5%      �� 5&      $��5,0,0,0q�5'      $
��Left=�5(      $��Center=�5)      $��15(�5*      
�������$��消息窗口��5,      �� 5-      $��1��6   	 �� Orientation$	 
Horizontal=�6*   .+�5/      '  !MaterialDesignThemes.Wpf.PackIcon  $��30��50      $��30��51      $��20,0,0,0q�52      $��Center=�53      
   Kind$
 AccessPoint=�55      ��54      �� *Color+55      �� 57      $��
15,40,0,40q�58      $
��Auto=�59      $
��Auto=�5:      .��5;      �� $	��300��5<      $
��Left=�5=      $��Center=�5>      .+�5?      �� -   5         ��Name$	 msg��5@   !   $
��Left=�5A   !   $��Center=�5B   !   $��幼圆)�5C   !   $��18(�5D   !   ���#737373$
��Wrap=�5G   !   ��5F   !   �� *Msg+5G   !   5H      5I      5J      �� 5K      $��2��5L      $��	0,-20,0,0q�5M      $��Right=�5N      $	��Top=�5O      $	 
Horizontal=�5P      .+�5Q      �� -   5        $	��100��5R      $��	10,0,30,0q�5S      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5T      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IndicatorBackground �	#FF49B7CE   IndicatorForeground
 ����    IsIndicatorVisible .    Value$ -1Q�5X      ���	#FF4ABAD0  MaterialDesignRaisedButton#��[ 5[       � ToolTip$ 确认��5\      .��5]      �� 
�������$��确定��67   5^      �� 5_      -   5        $	��100��5`      $��0,0,10,0q�5a      $ 5��5b      
�������
������ #��[ 5f      .��5g      �� 
�������$��取消��67   5h      5i      5j      5k      5l      5m      