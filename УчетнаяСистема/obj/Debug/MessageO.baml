   M S B A M L   `   `   `  ����W  SУчетнаяСистема, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:УчетнаяСистемаУчетнаяСистема  5   	   +    %УчетнаяСистема.MessageO   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:УчетнаяСистема     5   	     � Title$  MessageO��5   	   $	��150��6   $	��400��6'    � WindowStartupLocation$ CenterScreen=�63    � AllowsTransparency .  � WindowStyle$
 None=�5
   	   ��6   Z� .��5      � $��10q�6   
������� � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $
��178* �6    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6      	Direction$	 270Q�6/      Opacity$	 0.5Q�6?   	   ShadowDepth$	 0Q�6M   .+�5   
   � $��0��6   .+�5      �� ���#0A6E9E$��10��6+   $	��Top=�67   5      �� 5   
   $��1��6   .+�5      �� $��18(�6   ���#0A6E9E$��Center=�5      $��Center=�65   64Вы уверренно хотите удалить?6n   �� 5      
 �� Orientation$
 
Horizontal=�6   $��Center=�62   .+�5      �� -   5         ��Name$ button��5          Button_blue#���   5      $��0,30,0,0q�6@   $
��Да��5      $	��168��5    '   $��26��63   �� 5!      -   5        $ button2��5#        Button_White#���  5!      $��	20,30,0,0q�5"      $��НЕТ��6,   $	��168��5#   &   $��25��62   5$      5%      5&      5'      