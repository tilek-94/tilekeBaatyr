   M S B A M L   `   `   `  ����W  SУчетнаяСистема, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:УчетнаяСистема.form_p#УчетнаяСистема.form_p  5      0    *УчетнаяСистема.form_p.analis   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:УчетнаяСистема.form_p     5      -   5          N� Title$  analis��5	      .��5      � 
�������.+�5   
   �� $��1��6    �� Padding$ 5q�6!   ���#F4F4F4._�5      �� 
�������.+�5      ]� $��Stretch=�6   ���#F4F4F4.+�5      �� $#��KG Group Компаниясы��6   $��16(�6:   ���#00C3FF6`   �� 5      $��14(�6      placeHolder#���   6-   
 � Tag$  Поиск данные��6S   $��25��6g   $	��200��6s   $��5q�6   $��Right=�6�   .��6�   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGridView1��5      $��12(�5        grid_xml#���  6*      AutoGenerateColumns .     HeadersVisibility$ Column=�5        
hederstyle   ColumnHeaderStyle# �  5         CanUserAddRows .  ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 40 6-   
   Header$	
 №��68   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *id+  5!      $	 70 6-   $
 № Квартира��68    6L   �� *
number_f+  5"      $	 70 6-   $
 Этаж��68    6F   �� *floor+  5#      $	 70 6-   $	
 м2��68    6D   �� *kvm+  5$      $	 90 6-   $
 № Договор��69    6L   �� *
contract+  5%      $		 180 6-   $
 Ф.И.О клиент��69    6O   �� *name+  5&      $		 100 6-   $
 Макрка машина��69    6P   �� *marka+  5'      $	 90 6-   $
 Курс валюта��68    6M   �� *kurs+  5(      $		 100 6-   $
 Цен доллор м2��69    6P   �� *	price_kvm+  5)      $		 100 6.   $
 Цена сом м2��6:    6O   �� *som+  5*      $		 100 6-   $"
 Сумма на доллар��69    6R   �� *us+  5+      $		 130 6-   $
 Сумма на сом��69    6O   �� *kg+52      53      54      57      58      