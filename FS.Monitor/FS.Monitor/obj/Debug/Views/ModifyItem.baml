   M S B A M L   `   `   `  ����E  AFS.Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FS.Monitor.Common.LanguageFS.Monitor.Common.Language  5      3clr-namespace:FS.Monitor.ViewsFS.Monitor.Views  5      !    FS.Monitor.Views.ModifyItem   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9lang(clr-namespace:FS.Monitor.Common.Language     5      0localclr-namespace:FS.Monitor.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      ���	#FF0B0D11  � DataContext  5      ��    Locator �� Source# [   �� Path$ Setting� � 	Resources 5        CheckBoxStyle �� 
TargetType �� Property �� Value  CheckBoxFocusVisual �� 
TargetType �Name	 � ColumnDefinitions
 ��Name J� Opacity �� RadiusX �� RadiusY J� SnapsToDevicePixels �� Angle �� CenterX �� CenterY �� Triggers P� Property P� Value �� 
TargetName :� RoutedEvent �� HandoffBehavior �� TargetProperty �� 
TargetName W� From	 W� To g� Duration��%�  &	       �� 5   
   CheckBoxStyle��" ��5      .�5      ��  �@J�SnapsToDevicePixels . 64   �� 5       �@�OverridesDefaultStyle .  66   �� 5       �@�FocusVisualStyle# �  61   �� 5       � ��$ 35��6'   �� 5       � ��$ 35��6&   �� 5       �@d�	IsChecked 6*   �� *	IsChecked+�� 5       � ��$
 0,20q�6'   �� 5       � �� 5      �� 5      " ��6&   .R�5      � $
 aaaa��6   	 5      �� 5    "   $
��Auto �63   �� 5!   "   $��* �63   .+�5#      � #��z��6#   #��z��6D   .+�5$   "   �� $
 CheckBoxRectangle��5%   %   
����·�$	 0.3Q�5'   %   $ 5��5(   %   $ 5��5)   %   �� 5*   "   $
 CheckBoxRectangleOut��5+   %   $ 5��5,   %   $ 5��5-   %   ���	#FF06DAD1$��1��5/   %   � 50   "   $ CheckedMark��51   %   $��20��52   %   $��20��53   %   $y�	Collapsed=�54   %   .+�55   &   F� ����@B @T� р�� @f	 .  
�������$��3��59   )   F� 5:   &   ���� z @f� -1 	= 	 .  
�������$��3��5>   )   z�5?   &   �� 5@   *   CheckBoxTransform��$ 0Q�6U   $ 10Q�6_   $ 10Q�6l   5B   #   5C      �� 5D      $��1��5E   !   $��14,0,0,0q�5F   !   $��Center=�5G   !   $��18(�5H   !   
���������5J   !   �� *Name+5K       5L      P� 5M       �@d�	IsChecked$
 TrueY�6;   . �5N   "   �� $ CheckedMark��6)    � y�$ Visible=�6X   �� 5O   "   $ CheckBoxRectangle��6)    � �� �	#FF00A8E06X   �� 5P   "   $ CheckBoxRectangle��6)    �@J�Opacity$ 1Q�6[   �� 5Q   "   $ CheckBoxRectangleOut��6)    � ��
 ���� 6]   5R      :� 5S      $ Click��6+   .[�5T   "   �� $ SnapshotAndReplace=�62   .��5U   &   �� $ Angle�61   $ CheckBoxTransform��6H   .��5V   *   W� $ 0X�5W   -   $	 360X�5X   -   $ 0:0:0.1D�5Y   -   5Z   '   5[   #   5\      5^      5`      5a      5b      .��5c      )  #MaterialDesignThemes.Wpf.DialogHost     
Identifier$ 
ModifyItem��6    .��5d   
   � .+�5e      �� $	��610��5f      $	��500��5g      $��20,5,0,0q�5h      $
��Left=�5i      ���	#FF012B34
�������$��1q�5l       �� CornerRadius$ 10��5m      ._�5n      �  � RowDefinitions 5o      �� 5p      $
��Auto �6(   �� 5q      $
��Auto �6(   �� 5r      $
��Auto �6(   �� 5s      $
��Auto �6(   �� 5t      $��* �6(   �� 5u      $
��Auto �6(   �� 5v      $��* �6(   �� 5w      $
��Auto �6(   .+�5y      ]� $��0��6    $��0,20,0,0q�6-   .+�5z      �� $
��35,5q�5{      $
��Left=�5|      $��26(�5}      
���������5      �� *
ModifyItem+-   'FS.Monitor.Common.Language.LangProvider    Instance# Z  �� 5�      $��80��5�      $
��Auto��5�      $��0,0,30,0q�5�      $��Right=�5�      
������ !   CloseDialogCommand#��Z! 5�        MaterialDesignFlatButton#��[ 5�      ��5�      �� " �� RelativeSource" �� # �� Mode$
# Self=�$ ToolTip�$ � ToolTip$ 5�      �� *Close+# Z  .��5�      '  !MaterialDesignThemes.Wpf.PackIcon  $��40��5�   !   $��40��5�   !   
�������%   Kind$% 
CloseThick=�5�   !   5�      5�      �� 5�      $��3��5�      $
��Left=�5�      & �� Orientation$& 
Horizontal=�5�      .+�5�      �� $��	20,30,0,0q�5�      $��24(�5�      
���������5�      �� *Line_Number+# Z  �� 5�      -   5        ' ��Name$' txtUserName2��5�      $��2��5�      $	��400��5�      $
��auto��5�      $
��5,20q�5�      )  #MaterialDesignThemes.Wpf.HintAssist(   
Background( �	#FF012B34)   
Foreground
) �����* �� AcceptsReturn* . 
�������$��24(�5�      
������� ! MaterialDesignOutlinedTextBox#��[ 5�      + �� TextWrapping$
+ Wrap=�5�      ", �� VerticalScrollBarVisibility$
, Auto=�5�      -   Hint- 5�      �� *PleaseEnterLineNumber+# Z  ��5�      �� *Monitor.ProjectName+. �� UpdateSourceTrigger$. PropertyChanged=�/ �� Mode$/ TwoWay=�5�      5�      �� 5�      $��1��5�      $��0,10,0,0q�5�      
�������$	��0.5q�5�      �� 5�      $��2��5�      $
��0,15q�5�      $
��Left=�5�      $& 
Horizontal=�5�      .+�5�      �� $��	20,30,0,0q�5�      $��24(�5�      
���������5�      �� *Project_Name+# Z  �� 5�      -   5        $' txtProjectName��5�      $��2��5�      $	��400��5�      $
��auto��5�      $
��0,20q�5�      ( �	#FF012B34
) �����* . 
�������$��24(�5�      
�������#��[ 5�      $
+ Wrap=�5�      $
, Auto=�5�      - 5�      �� *PleaseEnterProjectName+# Z  ��5�      �� *SelectedRow.ProjectName+$. PropertyChanged=�$/ TwoWay=�5�      5�      �� 5�      $��4��6!   $& 
Horizontal=�6.   .+�5�      �� $��20,5,0,0q�5�      $��24(�5�      
���������5�      �� *	EnableNow+# Z  �� 5�      -   5        0 ��Name$0 chbYse��5�      $	��104��5�      $��
30,-50,0,0q�5�      
�������
�������$��0q�5�      $��24(�5�      
���������5�      �� *Yes+# Z  1 d� 	IsChecked1 5�      �� *SelectedRow.NotEnable+$/ TwoWay=�$. PropertyChanged=��� 5�      $��
30,-50,0,0q�5�      
�������
�������$��0q�5�      $��24(�5�      
���������5�      �� *No+# Z  5�      5�      �� 5�      $��6��5�      $
��50,0q�5�      $
��Left=�5�      $& 
Horizontal=�5�      .+�5�      �� -   5        2 ��Name$2 btnModifyMonitor��5�      $	��240��5�      $��45��5�      +  %MaterialDesignThemes.Wpf.ButtonAssist3   CornerRadius$3 5��5�      ���	#FF4ABAD0
������ #��Z! 5�        MaterialDesignRaisedButton#��[ 5�      $ 5�      �� *	Confirm+# Z  .��5�      �� $��20(�6(   ��66   �� *	Confirm+# Z  5�      �� 5�      $	��240��5�      $��45��5�      $
��20,0q�5�      $3 5��5�      ���	#FFF2F2F2
������ #��Z! 5      #��[ 5     $ 5     �� *Cancel+# Z  .��5     �� $��20(�5  !   
���   ���5  !   �� *Cancel+# Z  5     5     5	     5
     5     5     5     