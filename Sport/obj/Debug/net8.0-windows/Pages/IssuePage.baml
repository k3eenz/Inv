   M S B A M L   `   `   `  ����	  Sport    Sport.Pages.IssuePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     N� Title$)  #Выбор пользователя��5   	   $	��300��6$   $	��400��61   .��5      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5
   
   �� -   5         ��Name$ UserListView��5
      $��10q�6G   ��6)   �� *Users+ �� View 5      �� 5      .P�5      �� $��ФИО��6%    �� Width$	 150��62    �� DisplayMemberBinding 6>   �� *
FullName+�� 5      $��
Логин��6%   $	 100��64    6@   �� *Login+�� 5      $��Телефон��6%   $	 100��66    6B   �� *PhoneNumber+5      5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��10q�6W   .+�5      �� -   5         ��Name$ PickBtn��5      $��Выбрать��6&   $	��100��68   $��5q�6D   6O   �� 5      -   5        $ 	CancelBtn��5      $��Отмена��6(   $	��100��69   $��5q�6E   6P   5      5      5      