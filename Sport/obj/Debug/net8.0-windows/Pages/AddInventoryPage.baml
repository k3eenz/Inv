   M S B A M L   `   `   `  ����	  Sport"    Sport.Pages.AddInventoryPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  AddInventoryPage��5      $	��428��6    $	��550��6,   .��5      � 
�������.+�5   
   �� 
�������$��	0,20,0,20q�6$   ���#E0E0E0$��1q�6M   ._�5	      � $��20q�6    � RowDefinitions 5
      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   .+�5      �� -   5         ��Name$ TitleTextBlock��5      $��0��64   $-��'Добавление инвентаря��6A   $��24(�6]   $
��Bold"�6k   $��Center=�6}   $��0,0,0,20q�6�   �� 5      $��1��6   $��Название��6)   $��14(�69   $��0,0,0,5q�6G   �� 5      -   5         ��Name$ NameTextBox��5      $��2��6/   $��14(�6_   $��5q�6m   $��0,0,0,15q�6y   ��6<   �� *newInventory.Name+6y   �� 5      $��3��6   $��Тип��6)   $��14(�64   $��0,0,0,5q�6B   �� 5      -   5        $ TypeTextBox��5      $��4��6/   $��14(�6_   $��5q�6m   $��0,0,0,15q�6y   ��6<   �� *newInventory.Type+6y   �� 5       $��5��6   $��Описание��6)   $��14(�69   $��0,0,0,5q�6G   �� 5!      -   5        $ DescriptionTextBox��5!      $��6��66   $��14(�6m   $��5q�6{   $��60��6�   $��0,0,0,15q�6�   ��6C   �� *newInventory.Description+6�   �� 5#      $��7��6   $��Дата выпуска��6)   $��14(�6=   $��0,0,0,5q�6K   (  "System.Windows.Controls.DatePicker  5$      -   5          Name$ ReleaseDatePicker��5$      $��8��68   $��14(�6w   $��0,0,0,15q�6�      SelectedDate 6E   �� *newInventory.ReleaseDate+6�   �� 5&      $��9��6   $��Статус��6)   $��14(�67   $��0,0,0,5q�6E   �� 5'      -   5         ��Name$ StatusComboBox��5'      $��10��63   $��14(�6n   $��0,0,0,15q�6|    �� SelectedItem 6A   �� *newInventory.Status+6|   �� 5)      $��11��6    �� Orientation$ 
Horizontal=�6+   $��Center=�6D   $��40��6a   .+�5*      �� -   5        	 ��Name$	 	CancelBtn��5*      $��Отмена��60   $	��130��6A   $��5q�6M   ���#FF4444
�������6�   �� 5+      -   5        $	 SaveBtn��5+      $��Сохранить��6.   $	��130��6B   $��5q�6N   ���#4CAF50
�������6�   5,      5-      5.      5/      50      