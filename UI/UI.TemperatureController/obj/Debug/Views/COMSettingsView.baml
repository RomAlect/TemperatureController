   M S B A M L   `   `   `  ����S  OUI.TemperatureController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:UI.TemperatureController.ViewsUI.TemperatureController.Views  5      4    .UI.TemperatureController.Views.COMSettingsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:UI.TemperatureController.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          �Name$
  Self��5       � Title$ COM Port Settings��5	      $	��300��5
      $	��280��5       � DataContext 5      �� *COMVM+   Locator �� Source# [   � 	Resources 5       �� 
TargetType �� Property �� Value��%=  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 25��6'   �� 5       � ��$
 10,5q�6'   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Right=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 14(�6)   5      5      .��5      � 
����İ� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   	 � RowDefinitions	 5!   
   �� 5"      $��* �6   �� 5#      $��* �6   �� 5$      $��* �6   �� 5%      $��* �6   �� 5&      $��* �6   �� 5'      $��* �6   .+�5)   
   �� $��0��5*      $��5q�5+      $��Port:��5,      
 � ToolTip$
 	Baud Rate��5-      �� 5.   
   $��1��5/      $��5q�50      $��Bits per second:��51      $
 	Baud Rate��52      �� 53   
   $��2��54      $��5q�55      $��
Data bits:��56      �� 57   
   $��3��58      $��5q�59      $��Parity:��5:      �� 5;   
   $��4��5<      $��5q�5=      $��
Stop bits:��5>      �� 5@   
   $��0��5A      $��1��5B      ��5C      �� *ListOfCOMPorts+ �� SelectedItem 5D      �� *CurrentCOMPortName+�� 5E   
   $��1��5F      $��1��5G      ��5H      �� *	BaudRates+ 5I      �� *
BaudRate+�� 5J   
   $��2��5K      $��1��5L      ��5M      �� *ListOfDataBits+ 5N      �� *
DataBits+�� 5O   
   $��3��5P      $��1��5Q      ��5R      �� *
Parities+ �� SelectedIndex 5S      �� *Parity+�� 5T   
   $��4��5U      $��1��5V      ��5W      �� *ListOfStopBits+ 5X      �� *
StopBits+�� 5Z   
   $��5��5[      $��2��5\      $��0q�5]      $��Right=�5^       �� Orientation$ 
Horizontal=�5_      .+�5`      �� $��80��5a      $��25��5b      $��	5,0,10,10q�5c      $��Right=�5d      $��Bottom=�5e      $��OK��5f      ��5g      �� *	OKCommand+ �� Mode$ OneWay=���5h      ��  �� ElementName$
 Self���� 5i      $��80��5j      $��25��5k      $��	5,0,10,10q�5l      $��Right=�5m      $��Bottom=�5n      $��Cancel��5q      ��5o      �� *CancelCommand+$ OneWay=���5p      �� $
 Self��5q      5r      5t      5u      