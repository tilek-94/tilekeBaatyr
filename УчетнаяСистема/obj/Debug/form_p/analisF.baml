   M S B A M L   `   `   `  ����W  SУчетнаяСистема, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:УчетнаяСистема.form_p#УчетнаяСистема.form_p  5      1    +УчетнаяСистема.form_p.analisF   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:УчетнаяСистема.form_p     5      -   5          N� Title$  analisF��5	      .��5      � .+�5   
   �� $��1��6    �� Padding$ 5q�6!   ���#F4F4F4._�5      �� 
�������.+�5      ]� $��Stretch=�6   ���#F4F4F4.+�5      �� $#��KG Group Компаниясы��6   $��16(�6:   ���#00C3FF6`   �� 5      $��14(�6      placeHolder#���   6-   
 � Tag$  Поиск данные��6S   $��25��6g   $	��200��6s   $��5q�6   $��Right=�6�   .��6�   5      5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGridView1��5      $��12(�5        grid_xml#���  6*      AutoGenerateColumns .     HeadersVisibility$ Column=�5        
hederstyle   ColumnHeaderStyle# �  5         CanUserAddRows .  $   HorizontalScrollBarVisibility$ Hidden=�5      ��5      �� 	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 30 6.      Header$	 №��69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� *id+  5       $	
 170 6.   $* $Туракжай комплекси ��6:    6W   �� *name+  5!      $
 50 6-   $! Номер квартира��68    6P   �� *
number_f+  5"      $	
 190 6-   $ Клиент��69    6I   �� *	name_cl+  5#      $
 60 6-   $ Договор��68    6I   �� *
contract+  5$      $ Машина марка��6-    6C   �� *marka+  5%      $
 80 6-   $! $ (Сумма машина)��69    6S   �� *	prih_summ+  5&      $
 90 6-   $ Метр квартира��69    6P   �� *kvm+  5'      $
 90 6.   $ Цена за 1 кв. м.��6:    6T   �� *	price_kvm+  5(      $
 90 6-   $ Курс валюта��68    6M   �� *kurs+  5)      $
 90 6-   $ Цена Сомах��68    6L   �� *som+  5*      $
 90 6-   $! Сумма Долларах��68    6P   �� *kurs+  5+      $ Сумма Суммах��6-    6C   �� *summa+5-      5.      5/      50      51      