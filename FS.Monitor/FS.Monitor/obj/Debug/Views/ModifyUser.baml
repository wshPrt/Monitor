   M S B A M L   `   `   `  ����E  AFS.Monitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FS.Monitor.Common.LanguageFS.Monitor.Common.Language  5      3clr-namespace:FS.Monitor.ViewsFS.Monitor.Views  5      !    FS.Monitor.Views.ModifyUser   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9lang(clr-namespace:FS.Monitor.Common.Language     5      0localclr-namespace:FS.Monitor.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      ���	#FF0B0D11.��5      � .+�5   
   �� $	��610��5      $	��600��5      $��0,5,0,0q�5      $
��Left=�5      ���	#FF012B34
�������$��1q�5        �� CornerRadius$  10��5      ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5       $
��Auto �6$   .+�5#      ]� $��0��6   $��0,20,0,0q�6)   .+�5$      �� $
��35,5q�5%      $
��Left=�5&      $��26(�5'      
���������5)      �� *
UserModify+-   'FS.Monitor.Common.Language.LangProvider   Instance �� Source# Z �� 5*      $��80��5+      $��45��5,      $��0,0,30,0q�5-      $��Right=�5.      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5��5/      
������ )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 51         MaterialDesignFlatButton#��[  53      ��52      ��  �� RelativeSource ��  �� Mode$
 Self=� �� Path$ ToolTip�	 � ToolTip	 54      �� *Close+# Z .��55      '  !MaterialDesignThemes.Wpf.PackIcon  $��40��56      $��40��57      
�������
   Kind$
 
CloseThick=�59      5:      5;      �� 5<      $��1��5=      $��-20,10q�5>      
�������$	��0.5q�5@      �� 5A      -   5         ��Name$ txtUserName��5B      $��2��5C      $	��550��5D      $
��Auto��5E      $
��0,20q�5F      $��Stretch=�5G      )  #MaterialDesignThemes.Wpf.HintAssist   
Background �	#FF012B34   
Foreground
 ����� �� AcceptsReturn . 
�������$��24(�5M      
������� ! MaterialDesignOutlinedTextBox#��[ 5O       �� TextWrapping$
 Wrap=�5P      " �� VerticalScrollBarVisibility$
 Auto=�5Q         Hint 5J      �� *PleaseEnterUserName+# Z 5Q      G� 5S      -   5         G�Name$ txtPassWord��5T      $��3��5U      $	��550��5V      $
��Auto��5W      $	��0,5q�5X      $	��Top=�5Y       �	#FF012B34
 �����
�������$	��0.5q�5^      $��24(�5_      
������� % !MaterialDesignOutlinedPasswordBox#��[ 5a       5\      �� *PleaseEnterUserPassword+# Z 5a      G� 5b      -   5        $ txtPassWordTwo��5c      $��4��5d      $	��550��5e      $
��Auto��5f      $
��0,20q�5g      $	��Top=�5h       �	#FF012B34
 �����
�������$	��0.5q�5m      $��24(�5n      
�������#��[ 5p       5k      �� *PleaseEnterUserPasswordAgain+# Z 5p      �� 5q      $��5��5r      $
��35,0q�5s      $
��Left=�5t       �� Orientation$ 
Horizontal=�5u      .+�5v      �� $	��240��5w      $��45��5x      $ 5��5y      ���	#FF4ABAD0
������   MaterialDesignRaisedButton#��[ 5|      	 5}      �� *	Confirm+# Z .��5~      �� $��20(�6$   ��62   �� *	Confirm+# Z 5      �� 5�      $	��240��5�      $��45��5�      $
��30,0q�5�      $ 5��5�      ���	#FFF2F2F2
������ #��Z 5�      #��[ 5�      	 5�      �� *Cancel+# Z .��5�      �� $��20(�5�      
���   ���5�      �� *Cancel+# Z 5�      5�      5�      5�      5�      5�      