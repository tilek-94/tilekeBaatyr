   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections  5   	   W SУчетнаяСистема, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:УчетнаяСистемаУчетнаяСистема 5   	   3   -УчетнаяСистема.form_p.view_year   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	   <local*clr-namespace:УчетнаяСистема     5   	   -   5          N� Title$  	view_year��5	   	   $	��650��6   $	��680��5
   	    N� 
Background 5   
   Z� .��5      � 
������� J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$	 270Q�6      
BlurRadius$ 10Q�6/      ShadowDepth$ 0Q�6?      Opacity$
 0.45Q�6O    � RowDefinitions 5   
   �� 5      $��15 �6   �� 5      .+�5   
   �� ���#F4F4F45      �� 5   
   $��1��6    �� Padding$ 5q�6   ���#F4F4F4._�5      �� 
�������.+�5      ]� $��Stretch=�6   ���#F4F4F4.+�5      �� $#��KG Group Компаниясы��6   $��16(�6:   ���#00C3FF6`   �� 5      $��14(�6      placeHolder#���   6-   
	 � Tag$	  Поиск данные��6S   $��25��6g   $	��200��6s   $��5q�6   $��Right=�6�   .��6�   5      5      &   System.Windows.Controls.DataGrid  5       -   5        
  Name$
 
myDataGrid��5       $��12(�5!        grid_xml#���  5"         CanUserAddRows .     HeadersVisibility$ Column=�5$        
hederstyle   ColumnHeaderStyle# �  66    �� 
GroupStyle 5%      (  "System.Windows.Controls.GroupStyle  5&         ContainerStyle 5'      �� 5(   "    �� 
TargetType" ��6(   .�5)   &   ��  �� Property � �� �� Value 5*   *   �� 5+   &    �� 
TargetType" ��66   .R�5,   2   9�  9�Name$	 exp��6;    9� 
IsExpanded . ���	#3F10B3FF
���   �$��0,-2,0,0q�5.   E   ��5/   6   �� 50   ;   $��Center=�6[   ��6E   �� *Name+6[   .��52   6   �� 53   3   56   '   58   '   59   #   5;      5>      5?      5@      5C      5D      