   M S B A M L   `   `   `  ����E  AFS.Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:FS.Monitor.Common.WindowCloseFS.Monitor.Common.WindowClose  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      G(clr-namespace:FS.Monitor.Common.LanguageFS.Monitor.Common.Language  5      3clr-namespace:FS.Monitor.ViewsFS.Monitor.Views  5	          FS.Monitor.Views.AddItem   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      A	behaviors+clr-namespace:FS.Monitor.Common.WindowClose     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      beventPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      9lang(clr-namespace:FS.Monitor.Common.Language     5      0localclr-namespace:FS.Monitor.Views     5	      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      -   5        $��AddItem_UserControl��5      ���	#FF0B0D11  � DataContext  5      ��    Locator �� Source# [   �� Path$ Setting�y�5      �� *Monitor.Visibil+ �� Mode$ TwoWay=� � 	Resources 5        CheckBoxStyle �� 
TargetType �� Property �� Value  CheckBoxFocusVisual �� 
TargetType	 �Name
 � ColumnDefinitions ��Name J� Opacity �� RadiusX �� RadiusY J� SnapsToDevicePixels �� Angle �� CenterX �� CenterY �� Triggers P� Property P� Value �� 
TargetName :� RoutedEvent �� HandoffBehavior �� TargetProperty �� 
TargetName W� From	 W� To g� Duration��%�  &	       �� 5   
   CheckBoxStyle��" ��5      .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle .  66   �� 5       �@�FocusVisualStyle# �  61   �� 5       � ��$ 35��6'   �� 5       � ��$ 35��6&   �� 5        �@d�	IsChecked 6*   �� *	IsChecked+�� 5!       � ��$
 0,20q�6'   �� 5"       � �� 5#      �� 5$      " ��6&   .R�5%      � $
	 aaaa��6   
 5&      �� 5'   "   $
��Auto �63   �� 5(   "   $��* �63   .+�5*      � #��z��6#   #��z��6D   .+�5+   "   �� $ CheckBoxRectangle��5,   %   
����·�$	 0.3Q�5.   %   $ 5��5/   %   $ 5��50   %   �� 51   "   $ CheckBoxRectangleOut��52   %   $ 5��53   %   $ 5��54   %   ���	#FF06DAD1$��1��56   %   � 57   "   $	 CheckedMark��58   %   $��20��59   %   $��20��5:   %   $y�	Collapsed=�5;   %   .+�5<   &   F� ����@B @T� р�� @f	 .  
�������$��3��5@   )   F� 5A   &   ���� z @f� -1 	= 	 .  
�������$��3��5E   )   z�5F   &   �� 5G   *   CheckBoxTransform��$ 0Q�6U   $ 10Q�6_   $ 10Q�6l   5I   #   5J      �� 5K      $��1��5L   !   $��14,0,0,0q�5M   !   $��Center=�5N   !   $��18(�5O   !   
���������5Q   !   �� *Name+5R       5S      P� 5T       �@d�	IsChecked$
 TrueY�6;   . �5U   "   �� $ CheckedMark��6)    � y�$ Visible=�6X   �� 5V   "   $ CheckBoxRectangle��6)    � �� �	#FF00A8E06X   �� 5W   "   $ CheckBoxRectangle��6)    �@J�Opacity$ 1Q�6[   �� 5X   "   $ CheckBoxRectangleOut��6)    � ��
 ���� 6]   5Y      :� 5Z      $ Click��6+   .[�5[   "   �� $ SnapshotAndReplace=�62   .��5\   &   �� $ Angle�61   $ CheckBoxTransform��6H   .��5]   *   W� $ 0X�5^   -   $	 360X�5_   -   $ 0:0:0.1D�5`   -   5a   '   5b   #   5c      5e      5g      5h      5i      .��5j      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ AddMonitorDialog��6    .��5k   
   � .+�5l      �� $	��610��5m      $	��500��5n      $��0,5,0,0q�5o      $
��Left=�5p      ���	#FF012B34
�������$��1q�5s       �� CornerRadius$ 10��5t      ._�5u      �   � RowDefinitions  5v      �� 5w      $
��Auto �6(   �� 5x      $
��Auto �6(   �� 5y      $
��Auto �6(   �� 5z      $
��Auto �6(   �� 5{      $��* �6(   �� 5|      $
��Auto �6(   �� 5}      $��* �6(   �� 5~      $
��Auto �6(   .+�5�      ]� $��0��6    $��0,20,0,0q�6-   .+�5�      �� $
��35,5q�5�      $
��Left=�5�      $��26(�5�      
���������5�      �� *	NewItem+-   'FS.Monitor.Common.Language.LangProvider!   Instance# Z! �� 5�      $��80��5�      $
��Auto��5�      $��0,0,30,0q�5�      $��Right=�5�      
������ "   CloseDialogCommand#��Z" 5�        MaterialDesignFlatButton#��[ 5�      ��5�      �� # �� RelativeSource# �� $ �� Mode$
$ Self=�$ ToolTip�% � ToolTip% 5�      �� *Close+# Z! .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  $��40��5�   !   $��40��5�   !   
�������&   Kind$& 
CloseThick=�5�   !   5�      5�      �� 5�      $��1��5�      $��
-12,10,0,0q�5�      
�������$	��0.5q�5�      �� 5�      $��2��5�      $
��0,15q�5�      $
��Left=�5�      ' �� Orientation$' 
Horizontal=�5�      .+�5�      �� $��	20,30,0,0q�5�      $��24(�5�      
���������5�      �� *Project_Name+# Z! �� 5�      -   5        ( ��Name$( txtUserName��5�      $��2��5�      $	��400��5�      $
��auto��5�      $
��0,20q�5�      )  #MaterialDesignThemes.Wpf.HintAssist)   
Background) �	#FF012B34*   
Foreground
* �����+ �� AcceptsReturn+ . 
�������$��24(�5�      
������� ! MaterialDesignOutlinedTextBox#��[ 5�      , �� TextWrapping$
, Wrap=�5�      "- �� VerticalScrollBarVisibility$
- Auto=�5�      .   Hint. 5�      �� *PleaseEnterProjectName+# Z! ��5�      �� *Monitor.ProjectName+/ �� UpdateSourceTrigger$/ PropertyChanged=�$ TwoWay=�5�      5�      �� 5�      $��3��5�      $
��Left=�5�      $' 
Horizontal=�5�      .+�5�      �� $��	20,30,0,0q�5�      $��24(�5�      
���������5�      �� *Line_Number+# Z! �� 5�      -   5        $( txtUserName2��5�      $��2��5�      $	��400��5�      $
��auto��5�      $
��5,20q�5�      ) �	#FF012B34
* �����+ . 
�������$��24(�5�      
�������#��[ 5�      $
, Wrap=�5�      $
- Auto=�5�      . 5�      �� *PleaseEnterLineNumber+# Z! 5�      5�      �� 5�      $��4��6!   $' 
Horizontal=�6.   .+�5�      �� $��20,0,0,0q�5�      $��24(�5�      
���������5�      �� *	EnableNow+# Z! �� 5�      -   5        0 ��Name$0 chkYes��5�      $	��104��5�      $��
30,-50,0,0q�5�      
�������
�������$��0q�5�      $��24(�5�      
���������5�      �� *Yes+# Z! 1 d� 	IsChecked1 5�      �� *Monitor.NotEnable+�� 5�      $��
30,-50,0,0q�5�      
�������
�������$��0q�5�      $��24(�5�      
���������5�      �� *No+# Z! 5�      5�      �� 5�      $��6��5�      $
��50,0q�5�      $
��Left=�5�      $' 
Horizontal=�5�      .+�5�      �� -   5        $	��240��5�      $��45��5�      +  %MaterialDesignThemes.Wpf.ButtonAssist2   CornerRadius$2 5��5�      ���	#FF4ABAD0
������ #��Z" 5�        MaterialDesignRaisedButton#��[ 5�      % 5�      �� *	Confirm+# Z! .��5�      �� $��20(�6(   ��66   �� *	Confirm+# Z! 5�      �� 5     $	��240��5     $��45��5     $
��20,0q�5     $2 5��5     ���	#FFF2F2F2
������ #��Z" 5     #��[ 5	     % 5
     �� *Cancel+# Z! .��5     �� $��20(�5  !   
���   ���5  !   �� *Cancel+# Z! 5     5     5     5     5     5     5     