   M S B A M L   `   `   `  ����J  FWPFDemoPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WPFDemoPractice.UserControlsWPFDemoPractice.UserControls  5      E'clr-namespace:WPFDemoPractice.ViewModelWPFDemoPractice.ViewModel  5      E'clr-namespace:WPFDemoPractice.ConverterWPFDemoPractice.Converter  5      =#clr-namespace:WPFDemoPractice.ModelWPFDemoPractice.Model  5	      ,    &WPFDemoPractice.UserControls.DashBoard   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:WPFDemoPractice.UserControls     5      6vm'clr-namespace:WPFDemoPractice.ViewModel     5      <conveter'clr-namespace:WPFDemoPractice.Converter     5      5model#clr-namespace:WPFDemoPractice.Model     5	        � 	Resources  5      4  .WPFDemoPractice.Converter.RadioButtonConverter   RadioButtonConverter)  #WPFDemoPractice.Model.StudentsModel  StudentModel��%:   &	        &	        5   
   6G     5   
   65   5      .��5      �� $
��Auto=�6   $
��Auto=�66   .��5   
   ��  �� Orientation$ Vertical=�6   $��0,0,0,5q�6,   .+�5      �� $��Student Form��6   $
��14px(�6-   
���   �$��2q�6Q   $��10q�6f   .��5      � $	��390��6    � RowDefinitions 5      �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(   �� 5      $��1* �6(    � ColumnDefinitions 5!      �� 5"      $	��100 �6+   �� 5#      $��* �6+   .+�5&      �� $��StudentName��6   $
��Left=�62   $��Center=�5'      $��0��6:   $��0��6J   �� 5(      -   5         ��Name$ TextBoxStudentName��5(   �   $��0��6�   $��1��6�   $��27��6  $��5q�5)      $	��300��6#   $
��Left=�60    � ToolTip 5(      ��  �� RelativeSource �� *Self+ �� Path$&  (Validation.Errors)/ErrorContent���6~   �� *StudentName+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� ValidatesOnDataErrors$
	 True��5)   0   �� 5+      $��Surname��6   $
��Left=�6.   $��Center=�6I   $��0��6k   $��1��6{   �� 5,      -   5        $ TextBoxSurname��5,   �   $��1��6   $��1��6�   $��27��6  $��5q�6  $	��300��6)  $
��Left=�65   6+   ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6�   �� *	Surname+$ PropertyChanged=�$
	 True��65  �� 5.      $��
FatherName��6   $
��Left=�61   $��Center=�6L   $��0��6n   $��2��6~   �� 5/      -   5        $ TextBoxFatherName��5/   �   $��2��6�   $��1��6�   $��27��6  $��5q�6"  $	��300��6.  $
��Left=�6:   6   ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6~   �� *
FatherName+$ PropertyChanged=�$
	 True��6:  �� 51      $	��DOB��6   $
��Left=�6*   $��Center=�6E   $��3��6h   $��0��6u   (  "System.Windows.Controls.DatePicker  52      -   5        
  Name$
 DoBDatePicker��52   Y  $��3��6L  $��1��53      $
��Left=�6&   $��5q�6A   $��Center=�6L   $	��300��6g      SelectedDate 52   !   �� *Dob+   DisplayDateEnd 6>   �� *Today+ �� StringFormat$ 
dd-MM-yyyy�� 6y   ��  �� *Self+$&  (Validation.Errors)/ErrorContent�   Text 6�   �� *Dob+$ PropertyChanged=� �� TargetNullValue$  �� �� Mode$ TwoWay=�$ 
dd/MM/yyyy��53   g   �� 55      $	��Age��6   $
��Left=�6*   $��Center=�6E   $��4��56      $��0��6%   �� 57      -   5        $ 
TextBoxAge��57   �   $��4��6�   $��1��6�   $��27��6  $��5q�58      $��70��6#   $
��Left=�6.    57      ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6~   �� *Age+$ PropertyChanged=�$
	 True��58   .   �� 5:      $��Gender��6   $
��Left=�6-   $��Center=�6H   $��5��6j   $��0��6w   �� 5;      $��5��6!   $��1��6.   $ 
Horizontal=�6>   .+�5<      	� $��10,5,0,0q�6�    	� 	GroupName$ MCSites��6�    d� 	IsChecked 6'   �� *Gender+ �� 	Converter# [   �� ConverterParameter$
 Male��.��6�   Male6�   	� 5=      $��10,5,0,0q�6�   $ MCSites��6�    6'   �� *Gender+# [  $ Female��.��6�   Female6�   	� 5>      $��10,5,0,0q�6�   $ MCSites��6�    6'   �� *Gender+# [  $ Other��.��6�   Other6�   5?      �� 5A      $��Address��6   $
��Left=�6.   $��Center=�6I   $��6��5B      $��0��6%   �� 5C      -   5        $ TextBoxAddress��5C   �   $��6��6�   $��1��6�   $��27��6  $��6q�5D      $	��300��6"   $
��Left=�6.    5C      ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6~   �� *	Address+$ PropertyChanged=�$
	 True��5D   .   �� 5F      $��	ContactNo��6   $
��Left=�60   $��Center=�6K   $��7��5G      $��0��6%   �� 5H      -   5        $ TextBoxContact��5H   �   $��7��6�   $��1��6�   $��27��6  $��5q�5I      $	��300��6#   $
��Left=�6/    5H      ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6~   �� *	ContactNo+$ PropertyChanged=�$
	 True��5I   /   �� 5K      $��Standard��6   $
��Left=�6/   $��Center=�6J   $��8��6m   $��0��6z   �� 5L      -   5        $ TextBoxStandard��5L   �   $��8��6�   $��1��6�   $��27��6  $��5q�6  $	��300��6&  $
��Left=�62   6   ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6~   �� *
Standard+$ PropertyChanged=�$
	 True��62  �� 5N      -	   5         ��Name$ TextBlockId��5N   Q   $��9��6    $y�Hidden=�6-   $��1��6A   ��6g   �� $ 	StudentId�$ TwoWay=�5P      5Q      �� 5R      $��40��6   $ 
Horizontal=�6%   $��Right=�6>   .+�5S      �� -
   5         ��Name$ 
ButtonSave��5S      $
��Save��6-   $��30��6<   $��80��6H     ButtonStyle#���  6S   ��5T      �� *AddStudentCommand+6<   �� 5U      -   5        $ ButtonCancel��5U      $��Cancel��6/   $��30��6@   $��80��6L   $��5,0,10,0q�6�   ��6W   �� *ClearCommand+6�   �� 5V      -   5        $ MultipleDelete��5V      $��Delete��61   $��30��6B   $��80��6N   $��5,0,10,0q�6�   ��6Y   �� *MultipleDeleteCommand+6�   5W      �� 5X      $	��400��6   .+�5Y      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridStudents��5Y         SelectionMode$ Single=�65      AutoGenerateColumns$ False��6z      CanUserAddRows$ False��5Z   ;   $	��400��6R   $��10q�6_    �� SelectedItem 5Y   L   �� *	Student+$ TwoWay=���5Z      �� *StudentList+   RowStyle 5[      �� 5\       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    .�5]      ��  �� Property � �� �� Value
 ��ح�6;   �� 5^       � ��$ 20(�69   6F   5_        5a      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        �� 5b      "  6    .�5c      ��  � ��
 ��  �6;   �� 5d       � ��
 �����6;   �� 5e       � ��$ 20(�69   6F   5f      5g          Columns  5h      4  .System.Windows.Controls.DataGridTemplateColumn  5i      ,  &System.Windows.Controls.DataGridColumn!   Header$! Select��61   "   HeaderTemplate" 5j      �� 5k   "   .R�5l   &   �� $��
Select All��6/   
������� 6W   �� $ IsSelectAll�$ PropertyChanged=�$ TwoWay=�5m   #   #   CellTemplate# 5o      �� 5p   "   .R�5q   &   ��  6/   �� $ 	IsChecked�$ PropertyChanged=�$ TwoWay=�5r   #   5t      0	  *System.Windows.Controls.DataGridTextColumn	  5u      $! Id��6-   $   Width5
  /System.Windows.Controls.DataGridLengthConverter$	$ 100
 6\   %   
IsReadOnly$
% True��6i   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 69   �� $ 	StudentId�6i   	  5v      $! StudentName��6-   $	$ 100
 6g   $
% True��6t   & 6B   �� $ StudentName�6t   	  5w      $! Surname��6-   $	$ 100
 6_   $
% True��6l   & 6>   �� $ Surname�6l   	  5x      $! 
FatherName��6-   $	$ 100
 6e   $
% True��6r   & 6A   �� $ 
FatherName�6r   	  5y      $	! DOB��6-   $	$ 100
 6W   $
% True��6d   & 6:   �� $	 Dob�6d   	  5z      $	! Age��6-   $	$ 125
 6W   $
% True��6c   & 6:   �� $	 Age�6c   	  5{      $! Standard��6-   $	$ 125
 6a   $
% True��6m   & 6?   �� $ Standard�6m   	  5|      $! Gender��6-   $	$ 125
 6]   $
% True��6i   & 6=   �� $ Gender�6i   	  5}      $! Contact��6-   $	$ 125
 6a   $
% True��6m   & 6>   �� $ 	ContactNo�6m   	  5~      $! Address��6-   $	$ 180
 6_   $
% True��6k   & 6>   �� $ Address�6k     5      $	$ 100
 61   # 5�      �� 5�   "   .R�5�   &   �� $ 
ButtonEdit��6>   $��Update��6-   ��6R   �� *DataContext.UpdateCommand+' �� ElementName$' DataGridStudents��5�   #   5�        5�      $	$ 100
 61   # 5�      �� 5�   "   .R�5�   &   �� $ ButtonDelete��6>   $��Delete��6-   ��5�   )   �� *DataContext.DeleteCommand+$' DataGridStudents��5�   #   5�      5�      5�      5�      5�      5�      