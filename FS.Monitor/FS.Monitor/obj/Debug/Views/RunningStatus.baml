   M S B A M L   `   `   `  ����E  AFS.Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:FS.Monitor.ViewsFS.Monitor.Views  5      $    FS.Monitor.Views.RunningStatus   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:FS.Monitor.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5        � DataContext  5      ��    Locator �� Source# [   �� Path$	 Run�.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ txtMsg��5      $��0��5      $	��730��5      $	��Top=�5       �� AcceptsReturn . 
�������$��26(�5       ! MaterialDesignOutlinedTextBox#��[ 5       �� TextWrapping$
 Wrap=�5      " �� VerticalScrollBarVisibility$
 Auto=�5      {�5      �� $ 	IsChecked� �� ElementName$2 ,MaterialDesignOutlinedTextBoxEnabledComboBox����5      �� *ControlInfo.Msg+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=�5      �� 5   
   $��1��5       $��Center=�5!       �� Orientation$ 
Horizontal=�5"      .+�5#      �� $	��240��5$      $��45��5%      $��Center=�5&      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5'      ���	#FF4ABAD0
������   MaterialDesignRaisedButton#��[ 5+       � ToolTip$ 扫描��5,      ��5*      �� *ScanCommand+$
 TwoWay=�$	 PropertyChanged=�.��5-      �� $��20(�6   $��扫描��6*   5.      �� 5/      $	��240��50      $��45��51      $��100,0q�52      $ 5��53      ���	#FFF2F2F2
������ #��[ 57      $ 运行��58      ��56      �� *RunningCommand+$	 PropertyChanged=�$
 TwoWay=�.��59      �� $��20(�5:      
���   �$��运行��5<      5=      5>      5?      5@      