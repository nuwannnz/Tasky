   M S B A M L   `   `   `  ����@  <Tasky, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Tasky.ViewsTasky.Views  5   	   3clr-namespace:Tasky.ViewModelsTasky.ViewModels  5   	   /clr-namespace:Tasky.ControlsTasky.Controls  5   	       Tasky.Views.MainPage   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Tasky.Views     5   	   -vmclr-namespace:Tasky.ViewModels     5   	   +cnclr-namespace:Tasky.Controls     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   1    � Title$ Tasky��5
   	   $	��440��6   $	��300��6$    � WindowStyle$
 None=�61    � 
ResizeMode$ NoResize=�6D    � Icon$&  /Tasky;component/Assets/list.png��6Z    � 	Resources 5         MyListViewItemStyle �� 
TargetType �� Property �� Value��%Q   &	        �� 5   
   " ��6,   .�5      ��  � ��$ 0q�6(   5      5      	 � DataContext	 5      (   "Tasky.ViewModels.MainPageViewModel  5   
   -   5        	ViewModel��5      .��5      � -   5        
 �Name$
 RootGrid��5      ���	#FF007ACC � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      .+�5   
   �� -   5         ��Name$ TopShellButtons��5      $��0��5       �� Orientation$ 
Horizontal=�5      $	��Top=�5       $��Right=�6-   .+�5!      �� -   5         ��Name$ ShellMinimizeButton��5!      $	����5"      
������ 
�������$��0q�5&      $��7q�5'        TaskyFontSymbol#��[ 5(        MyShellButtonStyle#��[ 5)      �� 5*      -   5        $ ShellCloseButton��5*      $	����5+      
������ 
�������$��0q�5/      $��7q�50      #��[ 51      #��[ 52      53      �� 54   
   $��0��55      $��Tasky��56      ���	#55ffffff$��5,0,0,0q�58      $��16(�59      $
��Thin"�6   $	��Top=�5:      $
��Left=�6%   �� 5<   
   -   5        $ DayInfoStackPanel��5<      $��0��5=      $ 
Horizontal=�5>      $��Bottom=�5?      $
��Left=�60   $��5,20,0,0q�5@      .+�5A      �� -   5         ��Name$ DayInt��5A      
�������$��60(�5D      $��Light"�6'   ��5B      �� *DayInt+ �� Mode$ OneWay=�5D   '   �� 5F      -	   5        $ 	DayString��5F      
�������$��Bottom=�5H       �� Padding$ 5,0,0,10q�5I      �� 5K      $��19(�6A   $��Light"�6O   �6   �� *DayNameString+$ OneWay=�6O   �� 5L      �� 5M      $��18(�6F   $��Light"�6T   �6   �� *MonthAndYearString+$ OneWay=�6T   5N      5O      �� 5P   
   -
   5        $ SettingsButton��5P      $��Center=�5Q      $��Right=�6,   #��[ 5R      $	����5S      #��[ 5T      $��18(�6?   $��3q�5U      
������ 
�������$��0q�5W      $��	0,-19,2,0q�6%   5X      �� 5[   
   -   5         ��Name$ StatusBlock��5[      $��1��5\   
   $��Stretch=�5]   
   $��Stretch=�6(   ��5^      �� *StatusColorBrush+y�5_      �� *ControlList.Count+  CountToVisibilityConverter �� 	Converter# [ ._�5a      �� -   5        $ RemainingTaskTextBlock��5a      $
��thin"�5b      $ 5,5,5,8q�5c      $��Center=�5d      $��Center=�62   �� 5e      $��30(�6C   
��������6   �� *RemainingTasks+$ OneWay=�6Q    �� 5f      $��19(�6A   
��������6   �� *StatusString+$ OneWay=�6O   5g      5h      � 5j   
   -   5        $
 ControlList��5j      $��2��5k      .+�5l      �� -   5         ��Name$ ControlListListView��5l      $	��250��5m      $	��Top=�5n      ���	#44ffffff$��0q�5r      $��0q�5s      $��Stretch=�6"   #���   6G   ��5o   .   Z� ��5p      �� *ControlList+y�5q      �� *ControlList.Count+# [ 5s   G   �� 5t      -   5        $ NoTaskImage��5t      $��Stretch=�5u      $	��Top=�63   $	��250��5v      y�5w      �� *ControlList.Count+ % !CountToVisibilityInverseConverter# [ ._�5x      �� $ Vertical=�6   .+�5y      �� $��1464950774_office-26.png��6   $	��230��6?   $��	0,0,0,-27q�6L   �� 5z      $��No Tasks��6    $��Center=�5{       $��20(�5|       
�������$
��Thin"�5~       5      5�      5�      � 5�   
   -   5        $
 	BottomBar��5�      $��3��5�      .+�5�      �� -   5        $ AddNewButton��5�      $��Add new task��5�      #��[ 5�      ���	#FF0073C1
�������$��20(�5�      $
��Thin"�6#   $��0q�65   ��5�   ,   Z� y�5�      �� *IsInAddMode+$ OneWay=� $  BoolToVisibilityInverseConverter# [ ��5�      �� *ToggleAddModeCommand+$ OneWay=�� 5�      -   5        $
 AddModeGrid��5�      y�5�      �� *IsInAddMode+$ OneWay=�  BoolToVisibilityConverter# [  � ColumnDefinitions 5�      �� 5�      $��0.75* �6'   �� 5�      $
��Auto �6'   .+�5�      �� -   5         ��Name$ TaskContentTextBox��5�      $	��0.5q�5�      
������ ���	#DAFFFFFF$��Hello��5�      $��19(�5�      $��Center=�5�      �� 5�      $��1��6   $��1,0,0,0q�5�      $ 
Horizontal=�5�      .+�5�      �� -   5        $ 	AddButton��5�      $	����5�      #��[ 5�      #��[ 5�      $��0q�5�      $
��10,8q�5�      
�������
������ ��5�      �� *AddNewCommand+��6?   ��  �� ElementName$ TaskContentTextBox��5�   0   �� 5�      -   5        $ CancelButton��5�      $	����5�      #��[ 5�      #��[ 5�      $��0q�5�      $
��10,8q�5�      
�������
������ ��5�      �� *ToggleAddModeCommand+��6F   �� $ TaskContentTextBox��5�   0   5�      5�      5�      5�      5�      