   M S B A M L   `   `   `  ����J  FWPFDemoPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WPFDemoPractice.UserControlsWPFDemoPractice.UserControls  5      E'clr-namespace:WPFDemoPractice.ViewModelWPFDemoPractice.ViewModel  5      /    )WPFDemoPractice.UserControls.Registration   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:WPFDemoPractice.UserControls     5      6vm'clr-namespace:WPFDemoPractice.ViewModel     5         backGroudColor#���   5	   7     � 	Resources  5
      5  /WPFDemoPractice.ViewModel.RegistrationViewModel  RegistrationVM��%   &	         5   
   6<   5      .��5      �   gridBackGroundColor#���  6   $	��350��6?   $	��700��6L    � ColumnDefinitions 5   
   �� 5      $
��661* �6   �� 5      $	��39* �6   .+�5   
   �� -   5        $��textBlockHeading��5   M   $��23��6   $
��Left=�6    $��10,5,0,0q�6;   $��Registration:��6e   $	��Top=�6z   $	��110��6�   $��17(�6�   $��ExtraCondensed&�6�   �� 5   
   -   5        $��451,5,172,328q�5      $��Login��6(    � Cursor$
 Hand��68   ��5      �� 5       �� 
TargetType" ��6"   .R�5      �� $��	Underline{�6    �� 5      5      5      ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ��  �63    �� Triggers 5       P� 5!       P� Property �@J�IsMouseOver	 P� Value$
	 true��69   . �5"      ��  � ��
 �  ��6;   5#      5%      5'      � 5*   
   $��	118,0,0,0q�6   $	��274��6"   $
��Left=�6/   $��Center=�6J   $��2��6e   
 � RowDefinitions
 5+      �� 5,      $
��252* �6    .+�5/      �� -   5         ��Name$ errormessage��5/   T   $��20��6   $
��Left=�6$   $��183,241,0,0q�6?   $	��Top=�6k   $	��247��6�    J� OpacityMask
 �<�����	#FFE5572C6�   �� 50      -   5        $��textBlockFirstname��50   R   $��23��6   $
��Left=�6$   $��	67,20,0,0q�6?   $��First Name:��6l   $	��Top=�6   $	��110��6�   �� 51      -   5        $��textBlockLastName��51   R   $��23��6   $
��Left=�6$   $��	67,50,0,0q�6?   $��
Last Name:��6k   $	��Top=�6}   $	��110��6�   �� 52      -   5        $��textBlockEmailId��52   R   $��23��6   $
��Left=�6$   $��	67,80,0,0q�6?   $��EmailId��6j   $	��Top=�6y   $	��110��6�   �� 53      -   5        $��textBlockPassword��53   S   $��23��6   $
��Left=�6$   $��
67,107,0,0q�6?   $��	Password:��6l   $	��Top=�6}   $	��110��6�   �� 54      -   5        $��textBlockConfirmPwd��54   S   $��23��6   $
��Left=�6$   $��
67,136,0,0q�6?   $��ConfirmPassword:��6n   $	��Top=�6�   $	��110��6�   $��2��6�   �� 55      -	   5        $��textBlockAddress��55   S   $��23��6   $
��Left=�6$   $��
67,166,0,0q�6?   $��Address��6k   $	��Top=�6z   $	��110��6�   �� 56      -
   5        $��textBoxFirstName��56   >  $��23��6   $��Center=�6�   $
��Left=�6  $��
183,20,0,0q�6*  $	��Top=�6V  $	��222��6n   � ToolTip 6"   ��  �� RelativeSource �� *Self+ �� Path$&  (Validation.Errors)/ErrorContent���6�   �� *	FirstName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidatesOnDataErrors$
 True��6n  �� 57      -   5        $��textBoxLastName��57   ;  $��23��6   $��Center=�6�   $
��Left=�6  $��
183,50,0,0q�6'  $	��Top=�6R  $	��222��6j   6"   ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6�   �� *
LastName+$ TwoWay=�$ PropertyChanged=�$
 True��6j  �� 58      -   5        $��textBoxEmail��58   8  $��23��6   $��Center=�6�   $
��Left=�6	  $��
183,80,0,0q�6$  $	��Top=�6L  $	��222��6d   6"   ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6�   �� *Email+$ TwoWay=�$ PropertyChanged=�$
 True��6d  �� 59      -   5        $��passwordBox1��59     $��23��6   $
��Left=�6�   $��183,107,0,0q�6  $��Center=�6.  $	��Top=�6P  $	��222��6h   6"   ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6�   �� *
Password+$ TwoWay=�$ PropertyChanged=�$
 True��6h  �� 5;      -   5        $��passwordBoxConfirm��5;   !  $��23��6   $
��Left=�6�   $��183,136,0,0q�6  $��Center=�6;  $	��Top=�6]  $	��222��6u   6"   ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6�   �� *ConfirmPassword+$ TwoWay=�$ PropertyChanged=�$
 True��6u  �� 5<      -   5        $��textBoxAddress��5<     $��23��6   $
��Left=�6�   $��
183,0,0,83q�6  $��Bottom=�6.  $��Center=�6I  $	��222��6k   6"   ��  �� *Self+$&  (Validation.Errors)/ErrorContent���6�   �� *	Address+$ TwoWay=�$ PropertyChanged=�$
 True��6k  �� 5=      -   5        $��Submit��5=        ButtonStyle#���  6R   $��23��6x   $
��Left=�6�   $��183,204,0,0q�6�   $	��Top=�6�   $��70��6�   ��6&   �� *AddRegistrationCommand+6�   �� 5>      -   5        $��Reset��5>      #���  6%   $��23��6K   $
��Left=�6W   $��259,204,0,0q�6r   $	��Top=�6�   $��70��6�   6�   �� 5?      -   5        $��Cancel��5?      #���  6&   $��23��6L   $
��Left=�6X   $��335,204,60,0q�6s   $	��Top=�6�   $��70��6�   6�   5@      5A      5B      