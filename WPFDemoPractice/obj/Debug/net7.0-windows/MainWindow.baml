   M S B A M L   `   `   `  ����J  FWPFDemoPractice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:WPFDemoPractice.UserControlsWPFDemoPractice.UserControls  5   	        WPFDemoPractice.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:WPFDemoPractice.UserControls     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ StudentManagementSystem��5	   	   $	��450��6)   $	��800��66    � Icon$R LC:\Users\pca63\Desktop\WPF\WPFDemoPractice\WPFDemoPractice\Icons\AppLogo.ico��6B    � 	Resources 5
         backGroudColor �� Color  gridBackGroundColor  HoverBackGroundColor  PressedBackGroundColor  DisabledBackGroundColor  DisabledForeGroundColor  ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType	 �� CornerRadius
 �� Triggers P� Property P� Value��%�  &	        &	 (     &	 P     &	 o     &	 �     &	 �     &	 �     7  7  7  7  �� 5   
   $ 	SteelBlue��61   6E   �� 5   
   $ 	LightPink��66   6J   �� 5   
   $ Olive��67   �� 5   
   $ DarkOliveGreen��69   �� 5   
   $ #C5E0B4��6:   �� 5   
   $ #AFABAB��6:   �� 5   
   " ��6$   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6"   #��z��6L   #��z��6x   $	 5��6�   ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      �� 5       � ��$
 Bold"�6+   �� 5        � ��
 �#�k�6+   �� 5!       � �� �#FFFFFF6,   
 5"      P� 5#       �@J�IsMouseOver$
 True��61   . �5$      ��  � ��8   63   5%      P� 5&       � ��$
 True��6/   . �5'      ��  � ��8  63   5(      P� 5)       � {�$ False��6/   . �5*      ��  � ��8  63   �� 5+       � ��8  63   5,      5.      50      .��5?      �� -   5         ��Name$ mainContent��5?      5A      5C      