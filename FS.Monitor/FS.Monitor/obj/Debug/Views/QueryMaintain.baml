   M S B A M L   `   `   `  ����E  AFS.Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FS.Monitor.Common.LanguageFS.Monitor.Common.Language  5      3clr-namespace:FS.Monitor.ViewsFS.Monitor.Views  5      $    FS.Monitor.Views.QueryMaintain   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9lang(clr-namespace:FS.Monitor.Common.Language     5      0localclr-namespace:FS.Monitor.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	        � DataContext  5      ��    Locator �� Source# [   �� Path$ Maintain�.��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5      (  "MaterialDesignThemes.Wpf.ColorZone  -   5          Name$ 	ColorZone��5      $��0��5      $��0��5      $��5,0,5,0q�5       $��10q�5!      $	��Top=�5"      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�5#      ���	#FF212330
�������$	��0.5q�5&         Mode$ 
PrimaryMid=�5'      .��5(      �� $	��360��5)      $��13��5*      $
��Left=�5+       �� Orientation$ Vertical=�5,      .+�5-      �� $��15,-5q�5.      $
��Left=�5/      $��18(�50      ���	#FFA9AAAF��52      �� *ImageManipulation+-   'FS.Monitor.Common.Language.LangProvider	   Instance# Z	 53      55      �� 56      $��1��57      $��5,0,5,0q�58      ���	#FF1A1D26���	#FF8A8C92$	��0.5q�5;      ._�5<      �� $��1��5=      $��0,5,0,25q�5>      $
��Left=�5?      $ 
Horizontal=�5@      .+�5A      �� -   5        
 ��Name$
 btnReadBack��5B      $	��100��5C      $	��100��5D      $��	20,30,0,0q�5E      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5F      ���	#FF1A1D26
�������$	��0.5q�5I      $��16(�5M      ���	#FF4DC3DA  MaterialDesignFlatButton#��[ 5O      ��5K      ��  �� RelativeSource ��  �� Mode$
 Self=�$ ToolTip���5L      �� *
FlipBack+# Z	  � ToolTip 5P      �� *
FlipBack+# Z	 �� 5Q      -   5        $
 btnForwardThrough��5R      $	��100��5S      $	��100��5T      $��	40,30,0,0q�5U      $ 5��5V      ���	#FF1A1D26
�������$	��0.5q�5Y      $��16(�5]      ���	#FF4DC3DA#��[ 5_      ��5[      ��  �� $
 Self=�$ ToolTip���5\      �� *FlipForward+# Z	  5`      �� *FlipForward+# Z	 �� 5a      -   5        $
 btnZoom��5b      $	��100��5c      $	��100��5d      $��	40,30,0,0q�5e      $ 5��5f      ���	#FF1A1D26
�������$	��0.5q�5i      $��16(�5m      ���	#FF4DC3DA#��[ 5o      ��5k      ��  �� $
 Self=�$ ToolTip���5l      �� *	Magnifier+# Z	  5p      �� *
PressEsc+# Z	 5q      5r        5s      -   5        $ ColorZoneTwo��5t      $��2��5u      $��5,30,5,0q�5v      $��10q�5w      $	��Top=�5x      $ Depth0=�5y      ���	#FF212330
�������$��0.5,0.5,0.5,0q�5|      
�������$ 
PrimaryMid=�5~      .��5      �� $	��360��5�      $��13��5�      $
��Left=�5�      $ Vertical=�5�      .+�5�      �� $��15,-5q�5�      $
��Left=�5�      $��18(�5�      ���	#FFA9AAAF��5�      �� *ExceptionRecord+# Z	 5�      5�      &   System.Windows.Controls.DataGrid  5�      -   5          Name$ dgRecord��5�      $��3��5�      $	��5,0q�5�      -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 	4 22 2 15q�5�         ColumnHeaderPadding$ 
12 10 2 22q�5�         CornerRadius$ 0��5�         AutoGenerateColumns .  ���	#FF1A1D26
�������$	��0.5q�5�         CanUserSortColumns . ���	#FFC9C9CD   HeadersVisibility$	 All=�5�         
IsReadOnly .    SelectionMode$ Extended=�5�      ��5�      �� *FlileXyList+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 5�      �� *SelectedRow+   ColumnHeaderStyle 5�      �� 5�       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5�      ��  �� Property � �� �� Value$ 18(�65   �� 5�       � ��$ 40��63   �� 5�       � ��$ 0,10,0,0q�63   �� 5�       � �� �	#FF1A1D2667   �� 5�       � �� �	#FF4ABAD067   �� 5�       � ��
 �����68   �� 5�       � ��$	 0.5q�6<   �� 5�       � ��$ Bottom=�6>   �� 5�       � �� 5�      �� 5�   "    �� 
TargetType"  62   .R�5�   &   �� $
��12,0q�5�   )   
�������$	��0.2q�5�   )     �� CornerRadius$  10��5�   )   ._�5�   *   �� $
��Auto��5�   -   $��Center=�5�   -   $��Center=�5�   -   5�   '   5�   #   5�      5�      !   Columns! 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn" 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$
" Auto
 5�      1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 5�      �� *Time+$ TwoWay=�$ 	  Header$ 5�      �� *Time+# Z	   5�      $
" Auto
 5�      # 5�      �� *	ImageName+$ TwoWay=�$ 5�      �� *Camera+# Z	   5�      $
" Auto
 5�      # 5�      �� *
Location+$ TwoWay=�$ 5�      �� *BeltPosition+# Z	   5�      $
" Auto
 6)   $ 66   �� *BeltPosition+# Z	 5�      �� 5�      $��4��5�      $��5,0,5,0q�5�      ���	#FF1A1D26���	#FF8A8C92$	��0.5q�5�      ._�5�      �� $��4��5�      $
��Left=�5�      $ 
Horizontal=�5�      .+�5�      �� -   5        $
 btIsNotHidden��5�      $
��Auto��5�      $��45��5�      $��20q�5�      $
��Left=�5�      
������ 
�������$	��0.5q�5�      $��22(�5�      ���	#FF4DC3DA  MaterialDesignRaisedButton#��[ 5�      ��5�      �� *SelectedCommand+$ PropertyChanged=�$ TwoWay=���5�      �� *DisplayCoordinate+# Z	  5�      �� *DisplayCoordinate+# Z	 �� 5�      -   5        $
 
btIsHidden��5�      $
��Auto��5�      $��45��5�      $��20q�5�      $��Right=�5�      
������ 
�������$	��0.5q�5�      $��22(�5�      ���	#FF4DC3DA#��[ 5�      ��5�      �� *HideCoordinate+# Z	  5�      �� *HideCoordinate+# Z	 5�      5�      5�      � 5�   
   $��1��6   .+�5�      �� ���	#FF212330
�������$	��0.5q�5�      ._�5�      �� $��100,0q�5�      ���	#FF212330$��1q�5�      ._�5     � % � ShowGridLines% .  5     �� 5     .+�5     �� -	   5        & ��Name$& viewer1��5     $��0��5     $��Hidden=�5     .��5     �� $��0��5  !   $��0��5  !   $��3��5  !   .+�5  "   �� -
   5        ' ��Name$' ltImage��5  -     6>   �� *DataContext.FlileXyList+$ TwoWay=�$ PropertyChanged=� �� $ FindAncestor=�( �� AncestorType$( UserControlL�.+�5  &   �� -   5        ) ��Name$) image��5  )   $
��Auto��5  )   $
��Auto��5   )   $
��None=�5"  )   ��5!  )   �� *RollerImageSource+$ TwoWay=�$ PropertyChanged=�z�5#  *   T� 5$  .   -   5        
translate1��5$  A   5&  '   5'  #   5C     5D     �� 5R     -   5        $' stpBG��5R  %   * J� Opacity$	* 0.4Q�64   .+�5S     �� -   5        + ��Name$	+ ccl��5T  !   $	��300��5U  !   $	��300��5V  !   $��100,50q�5W  !   $
��Left=�5X  !   
���  ��$��1q�5Z  !   5[     �� 5`     -   5        $' stpBGTwo��5a     $��Right=�5b     $��Bottom=�5c     $	* 0.4Q�5d     .+�5e     �� -   5        $	+ cc2��5f  !   $	��300��5g  !   $	��300��5h  !   $��100,50q�5i  !   $
��Left=�5j  !   
���  ��$��1q�5l  !   5m     5n     5p     5q     5r     5s     5t     