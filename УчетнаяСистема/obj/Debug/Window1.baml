   M S B A M L   `   `   `  ����W  SУчетнаяСистема, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:УчетнаяСистемаУчетнаяСистема  5   	   *    $УчетнаяСистема.Window1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:УчетнаяСистема     5   	   -   5          � Title$  Window1��5   	   $	��200��6   $	��600��6&    � WindowStartupLocation$ CenterOwner=�62    � AllowsTransparency .  � WindowStyle$
 None=�6q    � 
ResizeMode$ NoResize=�6�   ��6�   Z� .��5	      � $��10q�6   
������� J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         	Direction$	 265Q�6      Opacity$	 0.5Q�6/      ShadowDepth$ 0Q�6=   	   
BlurRadius$	 10Q�6M   .+�5   
   � 
 � RowDefinitions
 5      �� 5      $��15 �6    6.   �� 5      6"   .+�5      �� ���#0A6E9E5      �� 5      $��1��6   .+�5      �� -   5         ��Name$ 
LogTextBox��5      $��14(�6.      styleLog#���   6=   
 � Tag$  Login��6`   $��24��6m   $	��340��6y   $��Right=�6�    �� Left$	 131��6�   
 �� Top$ 32��6�   �� 5      -   5        $ PassTextBox��5      $��14(�6/     	stylePass#���  6>   $ 	 Password��6b   $��24��6r   $	��340��6~   $��Right=�6�   $	 131��6�   $ 65��6�   �� 5      -   5         ��Name$ button_2��5       � Cursor$
 Hand��6B   $��
Выход��6P   $��25��6a   $	��155��6m   
�������$��2q�6�   ���#0A6E9E$	 139��6�   $ 99��6�   ��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value �#0A6E9E6;   5        � 	Resources 5"      ��%d   '��       �� 5#      " ��6    .�5$      ��  �@��CornerRadius$ 5,0,0,5��6=   5%      5&      5'      �� 5(      -   5        $ button_1��5(   6   $
 Hand��6   $��Вход��6'   $��25��6`   $	��164��6l   ���#0A6E9E
�������$��0q�6�   $	 294��6�   $ 99��6�    5)      ��%d   '��       �� 5*      " ��6    .�5+      ��  �@��CornerRadius$ 0,5,5,0��6=   5,      5-      5.      50      51      52      53      