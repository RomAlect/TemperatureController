   M S B A M L   `   `   `  ����S  OUI.TemperatureController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:UI.TemperatureController.Converters#UI.TemperatureController.Converters  5      O,clr-namespace:UI.TemperatureController.ViewsUI.TemperatureController.Views  5      V RLogic.TemperatureController, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullnNclr-namespace:Logic.TemperatureController;assembly=Logic.TemperatureControllerLogic.TemperatureController 5      ;    5UI.TemperatureController.Views.TemperatureHistoryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      H
Converters1clr-namespace:UI.TemperatureController.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:UI.TemperatureController.Views     5      `logicNclr-namespace:Logic.TemperatureController;assembly=Logic.TemperatureController     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	      q mNationalInstruments.Controls.Booleans, Version=15.0.45.3898, Culture=neutral, PublicKeyToken=4febd62461bf11a4q mNationalInstruments.Controls.Numerics, Version=15.0.45.3898, Culture=neutral, PublicKeyToken=4febd62461bf11a4h	 dNationalInstruments.Controls, Version=15.0.45.3898, Culture=neutral, PublicKeyToken=4febd62461bf11a4o
 kNationalInstruments.Controls.Graphs, Version=15.0.45.3898, Culture=neutral, PublicKeyToken=4febd62461bf11a4Dni5http://schemas.ni.com/controls/2009/xaml/presentation   	 
 5
      -   5          >�Name$
  Self��5       � DataContext 5      �� *TemperatureVM+   Locator �� Source# [   � 	Resources 5      D   >UI.TemperatureController.Converters.BooleanToAdjusterConverter  BooleanToAdjusterConverter��%   &	         5   
   60   5      .��5      �� 
�������  panelBorder#��[ 6#   ._�5   
   � $��0,0,0,20q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $��* �6    �� 5!      $
��Auto �6    �� 5#      $
��Auto �6    �� 5%      $
��Auto �6    .+�5(      � $��Center=�6   .+�5)      �� $��20��6   $:��4pack://application:,,,/Views/ViewsImages/history.ico��6$   �� 5*      $��0q�5+      $
��Bold"�5-      ��5,      �� *
PanelTitle+ �� ElementName$
 Self��5-      5.      0 
 *NationalInstruments.Controls.WritableGraph  51      $��2��52      $��5q�53      7 
 1NationalInstruments.Controls.Primitives.GraphBase   
DataSource 54      �� *TemperatureData+( 
 "NationalInstruments.Controls.Graph   Axes 55      - 
 'NationalInstruments.Controls.AxisDouble  56      � 
 �NationalInstruments.Controls.Axis`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Adjuster� 	 �NationalInstruments.Controls.Converters.EnumObjectConverter`1[[NationalInstruments.Controls.RangeAdjuster, NationalInstruments.Controls, Version=15.0.45.3898, Culture=neutral, PublicKeyToken=4febd62461bf11a4]]$ ContinuousChart 57      3 	 -NationalInstruments.Controls.Primitives.Scale	   Label$	 Time, s��58      
   Orientation$
 
Horizontal=�59         Range<	 	 6NationalInstruments.Controls.Converters.RangeConverter$ 0, 100	 5:        5;      $	 Temperature, K��5=      $
 Vertical=�5>       5<      �� $ isYAxisManual�� �� Path$ 	IsChecked� �� 	Converter# [  5?      `� 5@        MultiRangeConverter `� 	Converter# [ 6+   .1�5A   "   �� $ yAxisMin��6*   $ Value�6A   �� 5B   "   $ yAxisMax��6*   $ Value�6A   5C      5E      5G      � 5J      $��1��6    � ColumnDefinitions 5K      �� 5L      $��* �6'   �� 5M      $��* �6'   �� 5N      $��* �6'   .+�5P      ��  �� Orientation$ 
Horizontal=�6   .+�5Q      �� -   5        $��isYAxisManual��5R      $
��10,5q�5S      $��Center=�5T      $��Y Axis Scale��5U      $��SemiBold"�5V      5X      �� 5Z      $��1��5[      $��Right=�5\      $ 
Horizontal=�5]      .+�5^      �� $��10,5,5,5q�5_      $	��Min��5`      {�5a      �� $ isYAxisManual��$ 	IsChecked�7
  1NationalInstruments.Controls.NumericTextBoxDouble
  5b      -   5        $��yAxisMin��5c      $��70��5d      $��25��5e        ErrorTemplate =� ErrorTemplate# [ 5g      {�5f      �� $ isYAxisManual��$ 	IsChecked���5h      �� 5i       �� 
TargetType" 
 6$    �� Triggers 5j   "   P� 5k   &    P� Property �@=�HasError P� Value . . �5l   *   ��  �� Property �@�ToolTip �� Value 6D   �� *.,(Validation.Errors).CurrentItem.ErrorContent+ �� Self �� RelativeSource# Z 5m   '   5o      �  �NationalInstruments.Controls.Primitives.NumericControl`2[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5q      �� 5r       �� Mode$ TwoWay=�5s   !   $
 Ymin�5t   !    �� StringFormat$ {0:F2}��5u   !    �� ValidatesOnDataErrors .  �� ValidationRules 5w   "   5  /System.Windows.Controls.ExceptionValidationRule  5x   &   5z      5|      5}      �� 5~      $��2��5      $��Right=�5�      $ 
Horizontal=�5�      .+�5�      �� $��10,5,0,5q�5�      $	��Max��5�      {�5�      �� $ isYAxisManual��$ 	IsChecked�
  5�      -   5        $��yAxisMax��5�      $��70��5�      $��25��5�      $��1,5,10,5q�5�      # [ 5�      {�5�      �� $ isYAxisManual��$ 	IsChecked���5�      �� 5�      " 
 6$    5�   "   P� 5�   &    �@=�HasError . . �5�   *   ��  �@�ToolTip 6D   �� *.,(Validation.Errors).CurrentItem.ErrorContent+# Z 5�   '   5�       5�      �� 5�      $ TwoWay=�5�   !   $
 Ymax�5�   !   $ {0:F2}��5�   !    .  5�   "     5�   &   5�      5�      5�      5�      � 5�      $��3��6   $��Right=�6%   .+�5�      �� $
��10,5q�6   $��Current Temperature, K:��6&   �� 5�      $��1��5�      $	��120��5�      $��5q�5�      $��Right=�5�      $��Center=�5�      
���  �� �� TextAlignment$ Center=�5�      ��5�      �� *CurrentTemperature+$ {0:F2}��5�      5�      � 5�      $��4��6   $��Right=�6%   .+�5�      �� $��0��5�      $
��10,5q�5�      $��Center=�5�      $��Desired Temperature, K:��5�      �� 5�      $��1��5�      $	��120��5�      $��Right=�5�      
����  �  validatableTextBox#��[ 5�        �� TextAlignment$  Center=�5�      ! � ToolTip$;! 5Insert here the value of the desired temperature in K��5�      .��6U   ��5�      �� 5�      $ TwoWay=�5�      $ DesiredTemperature�5�      $ {0:F2}��5�      " �� UpdateSourceTrigger$" 	LostFocus=�5�       .  5�        5�   "   5�      .��5�   $   5�      5�      �� 5�      $��5��5�      $	��120��5�      $��27��5�      $��5q�5�      $��Right=�5�      $��Set Temperature��5�      ��5�      �� *SetTemperatureCommand+5�      5�      5�      