   M S B A M L   `   `   `  ����S  OUI.TemperatureController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:UI.TemperatureController.ViewsUI.TemperatureController.Views  5      8    2UI.TemperatureController.Views.SynchronizationView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:UI.TemperatureController.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          >�Name$
  Self��5      $	��300��5	      $	��150��5
       � DataContext 5      �� *SyncVM+   Locator �� Source# [   � 	Resources 5      ��%    .��5      �� $��2��5   	   
�������  panelBorder#��[ 5   	   ._�5   
   � $��0,0,0,20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5       $��* �6#   �� 5"      $��* �6#   �� 5$      $��* �6#   �� 5&      $��* �6#   .+�5*      � $��4��5+      $��0q�5,      $��Center=�5-      .+�5.      �� $��20��6   $B��<pack://application:,,,/Views/ViewsImages/synchronization.ico��6$   �� 5/      $��0q�50      $
��Bold"�52      ��51      �� *
PanelTitle+ �� ElementName$
 Self��52      53      �� 56      $��1��57      $��0��58      $��2��59      $	��0,5q�5:      $��Center=�5;      $��Center=�5<      $��Voltage Range, V��5=      $��SemiBold"�5>      �� 5@      $��1��5A      $��2��5B      $��2��5C      .+�5E      	� -   5         	�Name$ rbtnTempRange��5F      $��0,5,0,2q�5G      $
��Left=�5H      $��Center=�5I      $��Temperature Range, K��5J      $��SemiBold"�5K       d� 	IsChecked 5L      �� 	 �� Path$	 IsTempRange�
 �� Mode$
 TwoWay=�	� 5N      -   5        $ rbtnResistanceRange��5O      $��0,2,0,5q�5P      $
��Left=�5Q      $��Center=�5R      $��Resistance Range, Ohm��5S      $��SemiBold"�5T       5U      �� $	 IsResistanceRange�$
 TwoWay=�5V      �� 5Z      $��2��5[      $��0��5\      $��5q�5]      $��Center=�5^      $��Center=�5_      $
��Min:��5`      �� 5a      $��2��5b      $��1��5c        validatableTextBox#��[ 5d      .��6=   ��5e      �� 5f      $
 TwoWay=�5g      $
	 Vmin�5h       �� StringFormat$ {0:F2}��5i       �� UpdateSourceTrigger$ 	LostFocus=�5j       �� ValidatesOnDataErrors .  �� ValidationRules 5l      5  /System.Windows.Controls.ExceptionValidationRule  5m      5o      .��5p       5q      �� 5t      $��2��5u      $��2��5v      $��5q�5w      $��Center=�5x      $��Center=�5y      $
��Min:��5z      �� 5{      $��2��5|      $��3��5}      #��[ 5~      y�5      �� $ rbtnTempRange��$	 	IsChecked�   BooleanToVisibilityConverter �� 	Converter# [ .��6�   ��5�      �� 5�      $
 TwoWay=�5�      $
	 Tmin�5�      $ {0:F2}��5�      $ 	LostFocus=�5�       .  5�        5�      5�      .��5�       5�      �� 5�      $��2��5�      $��3��5�      #��[ 5�      y�5�      �� $ rbtnResistanceRange��$	 	IsChecked�# [ .��6�   ��5�      �� 5�      $
 TwoWay=�5�      $
	 Rmin�5�      $ {0:F2}��5�      $ 	LostFocus=�5�       .  5�        5�      5�      .��5�       5�      �� 5�      $��3��5�      $��0��5�      $��5q�5�      $��Center=�5�      $
��Max:��5�      �� 5�      $��3��5�      $��1��5�      #��[ 5�      .��6=   ��5�      �� 5�      $
 TwoWay=�5�      $
	 Vmax�5�      $ {0:F2}��5�      $ 	LostFocus=�5�       .  5�        5�      5�      .��5�       5�      �� 5�      $��3��5�      $��2��5�      $��5q�5�      $��Center=�5�      $
��Max:��5�      �� 5�      $��3��5�      $��3��5�      #��[ 5�      y�5�      �� $ rbtnTempRange��$	 	IsChecked�# [ .��6�   ��5�      �� 5�      $
 TwoWay=�5�      $
	 Tmax�5�      $ {0:F2}��5�      $ 	LostFocus=�5�       .  5�        5�      5�      .��5�       5�      �� 5�      $��3��5�      $��3��5�      #��[ 5�      y�5�      �� $ rbtnResistanceRange��$	 	IsChecked�# [ .��6�   ��5�      �� 5�      $
 TwoWay=�5�      $
	 Rmax�5�      $ {0:F2}��5�      $ 	LostFocus=�5�       .  5�        5�      5�      .��5�       5�      5�      5�      5�      