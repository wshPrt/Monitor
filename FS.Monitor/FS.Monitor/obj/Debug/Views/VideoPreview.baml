   M S B A M L   `   `   `  ����E  AFS.Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FS.Monitor.Common.LanguageFS.Monitor.Common.Language  5      3clr-namespace:FS.Monitor.ViewsFS.Monitor.Views  5      ;"clr-namespace:FS.Monitor.ViewModelFS.Monitor.ViewModel  5
      #    FS.Monitor.Views.VideoPreview   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9lang(clr-namespace:FS.Monitor.Common.Language     5      0localclr-namespace:FS.Monitor.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      2	viewmodel"clr-namespace:FS.Monitor.ViewModel  5
      ���#14171c  � DataContext  5      ��    Locator �� Source# [   �� Path$ Maintain� � 	Resources 5        DefaultSliderThumbStyle �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers	 P� Property
 P� Value   DefaultLeftRepeatButtonStyle ! DefaultRightRepeatButtonStyle  BaseSliderStyle  BeautifySliderStyle �� BasedOn � RowDefinitions m� Fill m� 	Placement ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton �� 
TargetName �� CornerRadius �� 	ClickMode d� 	IsChecked �� Mode �� RelativeSource J� SnapsToDevicePixels ��Name �� Triggers �� SelectionBoxItem �� SelectionBoxItemTemplate J� IsHitTestVisible ��Name �� 
IsReadOnly  � ActualWidth! � HorizontalOffset" �� IsDropDownOpen# �� Color$ K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation%   DirectionalNavigation  CheckBoxSwitchStyle& T� X' ��Name( N� EnterActions) �� 
TargetName* �� TargetProperty	+ W� To, g� Duration- N� ExitActions  RoundedGelButton. �� 
StartPoint/ �� EndPoint0 � Offset1 � Color��%�!  &	       &	 �    &	 �    &	 w    &	 �    7  7  7  7  '��     &	     &	 �    �� 5   
   " n�60   .�5      ��  � ��$ 15��6&   �� 5       � ��$ 15��6'   �� 5       � �� �	#FF4ABAD06+   �� 5       �@J�SnapsToDevicePixels . 64   �� 5       � �� 5      �� 5      " n�6&   .R�5      A� #��z��5      #��z��5      #��z��5       5      P� 5       	 �@J�IsMouseOver
 . . �5"   "   ��  �@�Cursor$
 Hand��6;   5#      P� 5$      	 �@n�
IsDragging
 . 5&      5(      5*      5+      �� 5,   
   " ��65   .�5-      ��  � �� .  6*   �� 5.       � �� 5/      �� 50      " ��6&   .R�51      �� $��4��6!   ���	#FF4ABAD06,   52      54      55      �� 56   
   " ��66   .�57      ��  � �� .  6*   �� 58       � �� 59      �� 5:      " ��6&   .R�5;      �� 
������ 6!   5<      5>      5?      �� 5@   
   " ��6(   .�5A      ��  � ��$	 500��6&   �� 5B       � ��$ 30��6*   �� 5C       � ��$ 20q�6'   �� 5D       �@�Maximum$	 100Q�6(   �� 5E       �@��IsSnapToTickEnabled . 64   �� 5G       �@��IsMoveToPointEnabled . 65   �� 5P       �@�LargeChange$ 10Q�6,   �� 5Q       �@�SmallChange$ 1Q�6,   �� 5R       � ��
 �����6+   �� 5S       � �� �	#FF7979796+   �� 5T       �@J�SnapsToDevicePixels . 64   �� 5U       �@��IsMoveToPointEnabled . 65   5V      �� 5W   
   8   " ��5Z      .�5[      ��  �@�Maximum$	 100Q�6(   �� 5\       � �� 5]      �� 5^      " ��6&   .R�5_      �  5`      �� 5a   "   $
��Auto �60   �� 5b   "   $
��Auto �60   #��z��6>   �� 5c   "   $
��Auto �60   .+�5e      m� $��TopTick��5f   !   $��0��5g   !   $��4��5h   !   # z��5i   !   $	 Top=�5j   !   $y�	Collapsed=�5k   !   �� 5l      $��TrackBackground��5m   !   $��1��5n   !   $��4��5o   !   #��z��5p   !   ]� 5q      $��
PART_Track��6$   $��1��66    5r   "   �� 5s   &   $��Slider.DecreaseLarge��63   8�� 6R    5u   "   n� 5v   &   8�� 6,    5x   "   �� 5y   &   $��Slider.IncreaseLarge��63   8�� 6R   5{      m� 5|      $��
BottomTick��5}   !   $��2��5~   !   $��4��5   !   # z��5�   !   $ Bottom=�5�   !   $y�	Collapsed=�5�   !   5�       5�      P� 5�      	 �@��TickPlacement$

 Both=�6?   . �5�   "   �� $ TopTick��6)    � y�$ Visible=�6T   �� 5�   "   $ 
BottomTick��6)    � y�$ Visible=�6W   5�      P� 5�      	 �@��TickPlacement$
 BottomRight=�6?   . �5�   "   �� $ 
BottomTick��6)    � y�$ Visible=�6W   5�      P� 5�      	 �@��TickPlacement$
 TopLeft=�6?   . �5�   "   �� $ TopTick��6)    � y�$ Visible=�6T   5�      5�      5�      5�      �� 5�   
   comboxStyle��" ��6%   .�5�      ��  � ��$ 5q�6'   �� 5�       � ��$	 120��6&   �� 5�       � ��$ Stretch=�64   �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� 
������ 
�������$��1q�5�      $ 5��5�      ._�5�      � .+�5�   "   d� $
��Auto��5�   %   $��0��5�   %   $��0��5�   %   $��2q�5�   %   $ Press=�5�   %   |�.   5�   %   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+��5�   &   �� 5�   *   " d�60   .�5�   .   ��  � ��$ 0��6I   �� 5�   .    � ��$ 0��6J   �� 5�   .    � ��$
 Auto��6F   �� 5�   .    � ��$
 Auto��6G   �� 5�   .    � ��
 ���� 6K   �� 5�   .    � �� �	#000000006L   �� 5�   .    � ��$ 2q�6P   �� 5�   .    � �� 5�   2   �� 5�   6   " d�6F   .R�5�   :   ]� #��z��5�   =   ��.   . .+�5�   >   �� $ Border��5�   A   #��z��5�   A   #��z��5�   A   $��Right=�5�   A   ._�5�   B   F� $��Center=�5�   E   $��Center=�5�   E   "����        ��g5  	= ���j     	#��z��5�   E   5�   ?   5�   ;    5�   :   P� 5�   >   	 �@d�	IsChecked$

 TrueY�6[   5�   7   5�   /    5�   .   P� 5�   2   	 � {�
 .  . �5�   6   ��  � ��# � ��6S   5�   3   5�   +   5�   #   �� 5�   "   $��3q�5�   %   $��Stretch=�5�   %   $��Center=�5�   %   #��z 5�   %   #��z 5�   %   #��z��5�   %    .  5�   %   �� 5�   "   $ PART_EditableTextBox��5�   %   $��Stretch=�5�   %   |�.  .  $y�	Collapsed=�5�   %   � 5�   "   #��z  5�   %   |�.  $! -1��5�   %   #��z" 5�   %   $��Slide=�5�   %   .��5�   &   � $��Stretch=�6+    . .+�5�   *   �� $��Stretch=�5�   -   
�������$��1,1,1,1q�5�   -   $ 5��5�   -   ��5�   .   �� 5�   2   $# White��6B   5�   +   �� 5�   *   $��Stretch=�67    . .��5�   .   �� $��Stretch=�5�   1   $ . $% 	Contained=�5�   1   5�   +   5�   '   5�   #   5�      5�      5�      5      5     �� 5  
   " ��6,   .�5     ��  �@d�	IsChecked$ FalseY�6*   �� 5      �@�Cursor$
 Hand��6'   �� 5      � ��$3 -/MESToolIntegration;component/Fonts/#iconfont)�6+   �� 5      � �� �#FFFFFF6+   �� 5      � ��$	 300��6&   �� 5      � �� 5	     �� 5
     " ��6&   .R�5     �� $��CheckTrueBG��5     $��80��5     $��40��5     ���#FFFFFF���#ACACAC$��1q�5     $ 20��5     ._�5     � .+�5  "   �� $ border��5  %   $��32��5  %   $��32��5  %   $��0q�5  %   $
��Left=�5  %   $��Center=�5  %   ���	#FF1A1D26$	��0.5q�5  %   $ 20��5  %   z�5  &   T� 5  *   $& 1Q�6=   5!  #   �� 5"  "   $	' txt��5#  %   $��24,10,0,2.798q�5$  %   $
��Left=�5%  %   $��Stretch=�5&  %   $��iconfont)�5'  %   #��z��5(  %   ���#ACACAC#��z��5*  %   z�5,  &   T� 5-  *   $& 20Q�6=   5/  #   50     51      52     P� 53     	 �@d�	IsChecked$

 trueY�6;   . �54  "   �� $ CheckTrueBG��6)    � �� �	#FF4ABAD06X   �� 55  "   $	 txt��6)    � �� �#FFFFFF6P   �� 56  "   $ border��6)    � �� �#FFFFFF6S   �� 57  "    � ��$	 300��6:   �� 58  "   $	 txt��6)    6J   �� *Tag+ �� *TemplatedParent+ � ��( 59  "   �� 5:  &   .��5;  *   �� .��5<  .   W� $) border��5=  1   $8* 2(UIElement.RenderTransform).(TranslateTransform.X)�5>  1   $+ 44X�5?  1   $, 	00:00:0.2D�5@  1   W� 5A  .   $	) txt��5B  1   $8* 2(UIElement.RenderTransform).(TranslateTransform.X)�5C  1   $	+ -10X�5D  1   $, 	00:00:0.2D�5E  1   5F  +   5G  '   - 5I  "   �� 5J  &   .��5K  *   �� .��5L  .   W� $) border��5M  1   $8* 2(UIElement.RenderTransform).(TranslateTransform.X)�5N  1   $+ 0X�5O  1   $, 	00:00:0.2D�5P  1   W� 5Q  .   $	) txt��5R  1   $8* 2(UIElement.RenderTransform).(TranslateTransform.X)�5S  1   $+ 17X�5T  1   $, 	00:00:0.2D�5U  1   5V  +   5W  '   5Y     P� 5Z     	 �@d�	IsChecked$
 FalseY�6;   . �5[  "   �� $	 txt��6)    6J   �� *	Content+ �� *TemplatedParent+ � ��5\     5^     5`     5a     �� 5b  
   " ��6)   .�5c     ��  � ��$	 200��6&   �� 5d      � ��$	 200��6'   �� 5e      � ��
 �����6+   �� 5f      � ��$ 微软雅黑)�6+   �� 5g      � ��$	 100(�6)   �� 5h      � �� 5i     �� 5j     " ��6&   .R�5k     � .+�5l     A� $��GelBackground��5m  !   
���  ��$	��0.5��5o  !   ��5p  "   �� 5q  &   $	. 0,0&�6:   $	/ 0,1&�6K   .��5r  *   � $0 0Q�67   $1 	#ff7e7e7e��6B   � 5s  *   $0 1Q�67   $	1 Red��6B   5t  '   5v     A� 5w     $��
15,5,15,50q�6&   ��5x  "   �� 5y  &   $	. 0,0&�6:   $	/ 0,1&�6K   .��5z  *   � $0 0Q�67   $1 	#aaffffff��6B   � 5{  *   $0 1Q�67   $1 Transparent��6B   5|  '   5~     �� 5     $��GelButtonContent��5�  !   $��Center=�5�  !   $��Center=�5�  !   #��z��5�  !   5�      5�     P� 5�     	 �@J�IsMouseOver
 . . �5�  "   �� $ GelBackground��6)    � �� 5�  &   
� 5�  *   .��5�  .   � $0 1Q�6;   $1 	#FF4ABAD0��6F   5�  +   5�  #   5�     P� 5�     	 � ��
 . . �5�  "   �� $ GelBackground��6)    � �� 5�  &   
� 5�  *   .��5�  .   � $0 0Q�6;   $1 	#FF4ABAD0��6F   � 5�  .   $0 1Q�6;   $1 	#FF4ABAD0��6F   5�  +   5�  #   �� 5�  "    � ��$ 开始��6<   5�     5�     5�     5�     5�     .��5�     �  5�  
   �� 5�     $	��80* �6   �� 5�     $��40 �6   �� 5�     $
��Auto �6   .+�5�  
   )  #MaterialDesignThemes.Wpf.DrawerHost  -   5        2  Name$2 
DrawerHost��5�     $��Center=�5�     $��Center=�5�       MaterialDesignDivider#���  5�     $��2q�5�     ��5�     �� 5�     # [B 6   "  6V    5�     �� 5�     3 �� Binding3 6&   �� *	IsChecked+4 �� ElementName$4 BackgroundToggle��5 �� Value5 True6b   .a�5�     ��  �@ OverlayBackground 	 PrimaryHueMidBrush# � 	 6B   5�     5�     6   TopDrawerContent6 5�     � 5�     -   5        7 �Name$7 spTop��5�     $��0��5�     $	��250��5�     $��5q�5�     $
��Left=�5�     
�������8 � ColumnDefinitions8 5�     �� 5�     $	��20* �6+   �� 5�     $	��40* �6+   .+�5�     �� $��0��6!   ���	#FFB7B8BC.+�5�     �� $	��500��5�     $	��200��5�     $��/Images/video.png��5�     �� 5�     5�     �� 5�     $��1��5�     $
��Left=�5�     $��Hidden=�5�     $��Hidden=�5�     .��5�     �� $��1��5�     $��5,0,0,0q�5�     $
��Left=�5�     ���	#FFCCCCCC9 �� Orientation$9 
Horizontal=�5�     .+�5�     �� $	��300��5�  !   $	��200��5�  !   $
��20,0q�5�  !   $��/Images/Title.png��5�  !   �� 5�     �� 5�     $	��300��5�  !   $	��200��5�  !   $
��20,0q�5�  !   $��/Images/Title.png��5�  !   �� 5�     �� 5�     $	��300��5�  !   $	��200��5�  !   $
��20,0q�5�  !   $��/Images/Title.png��5�  !   �� 5�     5�     5�     5�     .��5�     ]� $��0��5�     $
��Left=�5�     $	��Top=�5�     .+�5�     �� $��0��6   $9 Vertical=�6*   .+�5�     �� $	��130��5�     $��20,5,0,0q�5�     $
��Left=�5�     ���	#FF4ABAD0
������ $��1q�5�     $ 	10 10 0 0��5�     ._�5�     �� $��Center=�5�     $��16(�5�     
���������5�     �� *OneSignVertex+-   'FS.Monitor.Common.Language.LangProvider:   Instance# Z: 5�     � 5�     $��1��6   8 5�     �� 5      $��* �6/   �� 5     $
��Auto �6/   .+�5     (� $��0��6"   .��5     >� -   5        ; >�Name$; uc��5  !   $
��1500��5  !   $	��505��5  !   .��5  "   �� -   5        $��bdVideo��5	  %   $��0��5
  %   $��0��5  %   $	��5,0q�5  %   
�������$ 5��5  %   ._�5  &   � -   5        $7 Image1��5  +   5  #   5     5     5     5     �� 5     -   5        < ��Name$< 
btnArrowUp��5     $��1��5     $	��150��5     $��44��5     $��-1200,420,0,0q�5     $
��Left=�5     =   OpenDrawerCommand#��Z= 5     "  System.Windows.Controls.Dock
>   Top#��Z> 5     ��5     0  *MaterialDesignThemes.Wpf.PackIconExtension  ?   Kind$? ArrowUp=�5      5!     � 5$  
   $��2��6   8 5%     �� 5&     $��* �6#   �� 5'     $��* �6#   �� 5(     $��* �6#   �� 5)     $
��Auto �6#   �� 5*     $
��Auto �6#   .+�5,     �� $��0��5-     $
��Auto��5.     ���	#FF1A1D26���	#FF8A8C92$��1q�51     ._�52     � $��0��6   8 53     �� 54     $
��Auto �6+   �� 55     $	��25* �6+   �� 56     $
��Auto �6+   .+�58     �� $��0��59     $
��15,0q�5:     $
��Left=�5;     ���	#FF1A1D26$9 Vertical=�5=     .+�5>     �� $��0,15,0,0q�5?     $��16(�5@     ���	#FF797979��5B     �� *
Contrast+# Z: �� 5C     $��0,15,0,0q�5D     $��16(�5E     ���	#FF797979��5G     �� *
Saturation+# Z: �� 5H     $��0,15,0,0q�5I     $��16(�5J     ���	#FF797979��5L     �� *	Luminance+# Z: �� 5M     $��0,15,0,0q�5N     $��16(�5O     ���	#FF797979��5Q     �� *Chroma+# Z: �� 5R     $��0,15,0,0q�5S     $
��Left=�5T     $��Center=�5U     $��16(�5V     ���	#FF797979��5X     �� *LightBrightness+# Z: �� 5Y     $��0,15,0,0q�5Z     $
��Left=�5[     $��Center=�5\     $��16(�5]     ���	#FF797979��5_     �� *
PitchAngle+# Z: 5`     �� 5a     $��1��5b     $
��Auto��5c     $9 Vertical=�5d     .+�5e     �� -   5        @ ��Name$@ Contrast��5f     $	��220��5g     $��0,10,0,0q�5h     A �� IsMoveToPointEnabledA . B �� IsSnapToTickEnabledB . C � Maximum$C 99Q�5k     D � Minimum$D 0Q�5l     #��[ 5n     E � Value$E 25Q�5q     F �� TickFrequencyF 5o     �� *" DiscreteHorizontal.TickFrequency+5q     �� 5r     -   5        $@ 
Saturation��5s     $	��220��5t     $��0,5,0,0q�5u     A . B . $D 0Q�5x     #��[ 5z     $E 25Q�5{     �� 5|     -	   5        $@ 
Brightness��5}     $	��220��5~     $��0,5,0,0q�5     A . $D 0Q�5�     #��[ 5�     $E 25Q�5�     �� 5�     -
   5        $@ Chroma��5�     $	��220��5�     $��0,5,0,0q�5�     A . $	C 200Q�5�     $D 0Q�5�     #��[ 5�     E 5�     �� *SliderValue1+�� 5�     -   5        $
@ Lamp��5�     $	��220��5�     $��0,5,0,0q�5�     $D 0Q�5�     #��[ 5�     $E 25Q�5�     �� 5�     -   5        $@ Pitch��5�     $	��220��5�     $��0,5,0,0q�5�     $D 0Q�5�     #��[ 5�     $E 25Q�5�     5�     �� 5�     $��2��6!   $��
10,10,20,0q�61   .+�5�     �� -   5        $' txtContrast��5�     $��0,5,0,0q�5�     $��16(�5�     ���	#FF797979$��0��5�     �� 5�     -   5        $' txtSaturation��5�     $��0,15,0,0q�5�     $��16(�5�     ���	#FF797979$��0��5�     �� 5�     -   5        $' txtBrightness��5�     $��0,15,0,0q�5�     $��16(�5�     ���	#FF797979$��0��5�     �� 5�     -   5        $' 	txtChroma��5�     $��0,15,0,0q�5�     $��16(�5�     ���	#FF797979$��0��5�     �� 5�     -   5        $' txtLamp��5�     $��0,15,0,0q�5�     $��16(�5�     ���	#FF797979$��0��5�     �� 5�     -   5        $' txtPitch��5�     $��0,15,0,0q�5�     $��16(�5�     ���	#FF797979$	��0°��5�     5�     5�     5�     � 5�     $��1��6   $��1��6     5�     �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   �� 5�     $
��Auto �6$   .+�5�     �� $��0��5�     $
��Auto��5�     $��5,0,0,0q�5�     ���	#FF212330���	#FF797979$��1q�5�     ._�5�     �� $��3��5�     $
��Auto��5�     $��60��5�     $9 
Horizontal=�5�     .+�5�     �� $��3��5�     $
��10,0q�5�     $��Center=�5�     $��16(�5�     ���	#FF797979��5�     �� *ConveyorChoice+# Z: �� 5�     -   5        G ��Name$G cmbConveyor��5�     $��3��5�     $	��150��5�     $��40��5�     $
��10,0q�5�     $
��20,0q�5�     $��Right=�5�     $��1q�5�     $��16(�5�     ���	#FF4ABAD0H �� SelectedIndex$H 0��5�     .@�5�     �� ��6+   �� *CurrentLineOne+# Z: �� 5�     .��6+   
输送机261   �� 5�     .��6+   
输送机361   5�     5�     5�     �� 5�     $��1��5�     $
��Auto��5�     $��5,5,0,0q�5�     ���	#FF212330���	#FF797979$��1q�5�     ._�5�     �� $��3��5�     $
��Auto��5�     $��60��5      $9 
Horizontal=�5     .+�5     �� $��3��5     $��10,0,0,0q�5     $��Center=�5     $��16(�5     ���	#FF797979��5     �� *	SprayWash+# Z: �� 5	     -   5        I ��Name$	I chk��5
     $��80��5     $
��50,0q�5     $
��Left=�5     ���#BDBDBD$��13(�5     
�������#��[ 5     ��5     �� *
CloseTag+# Z: 
J � TagJ 5     �� *Open+# Z: 5     5     �� 5     $��3��5     $��93��5     $��5,5,0,0q�5     ���	#FF212330���	#FF797979$��1q�5     ._�5     �� $
��Left=�6!   $9 Vertical=�6<   .+�5     �� $��3��5     $��20,0,0,0q�5      
�������$��0,0,0,1q�5"     ._�5#     �� $��1��6)   $9 
Horizontal=�66   .+�5$  "   �� $��1��5%  %   $��30��5&  %   $��30��5'  %   $	��0,8q�5(  %   
������ 
�������$��1q�5+  %    
 MaterialDesignFlatButton#��[
 5-  %   ��5,  %   ��  �� K �� Mode$
K Self=�$ ToolTip�L � ToolTipL 5.  %   �� *
Accelerate+# Z: .��5/  &   '  !MaterialDesignThemes.Wpf.PackIcon  $��20��50  )   $��20��51  )   $��-12,0q�52  )   ���	#FF4ABAD0M   Kind$M PlusCircleOutline=�54  )   55  #   �� 56  "   $��2��57  %   $��20,0,0,0q�58  %   $��Center=�59  %   $��16(�5:  %   ���	#FF797979��5<  %   �� *DustCoverSpeedAdjustment+# Z: �� 5=  "   $��2��5>  %   $��30��5?  %   $��30��5@  %   $��30,0,0,0q�5A  %   $��Right=�5B  %   
������ 
�������$��1q�5E  %   #��[
 5G  %   ��5F  %   ��  �� $
K Self=�$ ToolTip�L 5H  %   �� *
Decelerate+# Z: .��5I  &     $��20��5J  )   $��20��5K  )   $��-12,0q�5L  )   ���	#FF4ABAD0$M MinusCircle=�5N  )   5O  #   5P     5Q     �� 5R     $��0,5,0,0q�5S     $
��Left=�5T     $9 
Horizontal=�5U     .+�5V     �� $��4��5W  !   $
��50,0q�5X  !   $��Center=�5Y  !   $��Center=�5Z  !   $��16(�5[  !   ���	#FF797979��5]  !   �� *	TurnSpeed+# Z: �� 5^     $��4��5_  !   $��-30,0q�5`  !   $��16(�5a  !   ���	#FF4ABAD0$��100r/min��5c  !   5d     5e     5f     5g     �� 5i     $��2��5j     $
��Auto��5k     $��5,1,10,1q�5l     ���	#FF212330���	#FF797979$��1q�5o     ._�5p     � $��0,0,60,9q�6   8 5q     �� 5r     �� 5s     .+�5u     �� $��0��5v     $��84��5w     $	��200��5x     $	��0,7q�5y     $
��Left=�5z     $��/Images/lamp.png��5{     �� 5|     $��1��5}     $��0,20,0,0q�5~     $
��Left=�5     $��18(�5�     
���  ����5�     �� *AbnormalWarning+# Z: �� 5�     $��1��5�     $��0,80,0,0q�5�     $
��Left=�5�     $��18(�5�     
���/�����5�     �� *AbnormalWarning+# Z: �� 5�     $��1��5�     $��	0,150,0,0q�5�     $
��Left=�5�     $��18(�5�     
��� �����5�     �� *AbnormalWarning+# Z: 5�     5�     �� 5�     $��4��5�     $
��Auto��5�     $��	5,10,0,31q�5�     ���	#FF212330���	#FF797979$��1q�5�     �� 5�     $��1��5�     $��3��5�     $9 Vertical=�5�     .+�5�     �� $��1��5�     $��3��5�     $
��Auto��5�     $��70��5�     $��0,0,0,0q�5�     $	��Top=�5�     ���	#FF212330���	#FF797979$��1q�5�     ._�5�     �� $
��Left=�6!   $9 
Horizontal=�6<   .+�5�     �� $��52��5�     $��50��5�     $��0,5,0,0q�5�     $
��Left=�5�     $	��Top=�5�     
������ 
�������$��0q�5�     #��[
 5�     $L 音量��5�     ��5�     ��  �� $
K Self=�$ ToolTip�.��5�       $��40��5�  !   $��40��5�  !   $��-12,0q�5�  !   ���	#FF54575E$M 
VolumeHigh=�5�  !   5�     �� 5�     -   5        $	��150��5�     $��	20,20,0,0q�5�     ���	#FF4ABAD0A . $	C 100Q�5�     $D 0Q�5�     #��[ 5�     �� 5�     -   5        $' txtValue��5�     $��	15,21,0,0q�5�     $��16(�5�     ���	#FF797979$��0��5�     5�     5�     �� 5�     $��1��5�     $��3��5�     $
��Auto��5�     $��70��5�     $��0,5,0,0q�5�     $	��Top=�5�     ���	#FF212330���	#FF797979$��1q�5�     ._�5�     �� $
��Left=�6!   $9 
Horizontal=�6<   .+�5�     �� $	��170��5�     $��	20,20,0,0q�5�     $��16(�5�     
���������5�     �� *	BeltSpeed+# Z: �� 5�     $��
-10,20,0,0q�5�     $
��Left=�5�     $��16(�5�     ���	#FF4ABAD0$��5 m/s��5�     5�     5�     �� 5�     $��1��5�     $��3��5�     $	��280��5�     $��75��5�     $��0,5,0,0q�5�     $	��Top=�5�     ���	#FF212330���	#FF797979$��1q�5�     ._�5�     �� $
��Left=�6!   $9 
Horizontal=�6<   .+�5�     �� $��75��5�     $	��Top=�5�     ���	#FF212330���	#FF797979$��0,0,1,0q�5�     ._�5�     �� $9 Vertical=�6)   .+�5�  "   �� $	��100��5�  %   $��	50,10,5,0q�5�  %   $��16(�5�  %   
���������5�  %   �� *CPUTemperature+# Z: �� 5   "   $
��Auto��5  %   $��	50,10,0,0q�5  %   $
��Left=�5  %   $��16(�5  %   ���	#FF4ABAD0$��24 ℃��5  %   5     5     �� 5	     $9 Vertical=�6%   .+�5
     �� $	��100��5  !   $��	10,10,0,0q�5  !   $��16(�5  !   
���������5  !   �� *GraphicsCardTemperature+# Z: �� 5     $��	50,10,0,0q�5  !   $
��Left=�5  !   $��16(�5  !   ���	#FF4ABAD0$��24 ℃��5  !   5     5     5     5     �� 5     $��4��5     $	��220��5     $
��Auto��5     $��5,1,0,1q�5     ���	#FF212330���	#FF797979$��1q�5!     ._�5"     �� $	��180��5#     $	��180��5$     
���  ��
������ $��0q�5'     $��微软雅黑)�5)     $��60(�5*     #��[ 5+     ��5(     �� *EmergencyStop+# Z: 5+     55     56     57     58     