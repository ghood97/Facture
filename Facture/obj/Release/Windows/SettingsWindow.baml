   M S B A M L   `   `   `  ���� B  >Facture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Facture.PropertiesFacture.Properties  1clr-namespace:Facture.WindowsFacture.Windows  $    Facture.Windows.SettingsWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7
properties clr-namespace:Facture.Properties     /localclr-namespace:Facture.Windows       � Icon$  FactureIcon.ico�� � WindowStartupLocation$ CenterScreen=� � Title$ Settings��$	��400��$	��500��   backgroundGradient#��[   � 	Resources  �� 
TargetType �� Property �� Value  bigTextBoxStyle  phoneTextBoxStyle��%�  '��       &	 ;     &	 �     �� " ��.���  � ��$ 25(���  � ��$
 Bold"��� " ��.���  � ��$	 210����  � ��$ 
7, 7, 7, 2q���  � ��$ 15(���  � ��$ Arial)���  � ��$
 Left=���  � ��$ Center=��� " ��.���  � ��$ 52����  � ��$ 15(���  � ��$ SemiBold"���  � ��$ Center=���  � ��$ Center=�.���  � RowDefinitions �� $
��1.2* ��� $��5* ��� $��10 ��� $��* �.+��� $��Settings��$��Center=�$��30(�$��Arial Black)�$��	Underline{�� $��1��$��2�� �� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* � � ColumnDefinitions �� $
��auto ��� $��* �.+��� $��0��$��0��$��	Business:��$��Right=��� -   	 ��Name$	 businessNameBox��$��1��$��0��#��[ ���� !  Facture.Properties.Settings
   Default �� Source# Z
  �� Path$ BusinessName� �� Mode$ TwoWay=��� $��0��$��2��$��Address:��$��Right=��� -   $	 
addressBox��$��1��$��2��#��[ ���� # Z
 $ Address�$ TwoWay=��� $��0��$��4��$��City:��$��Right=��� -   $	 cityBox��$��1��$��4��#��[ ���� # Z
 $
 City�$ TwoWay=��� $��0��$��6��$��State:��$��Right=��� -   $	 stateBox��$��1��$��6��#��[ ���� # Z
 $ State�$ TwoWay=��� $��0��$��8��$��Phone:��$��Right=���  �� Orientation$ 
Horizontal=�$��1��$��8��.+��� $��(��$��Center=�$��7 2 5 8q��� -   $	 areaCodeBox��#��[ $��	0 5 2.5 5q��� $	��) -��$��Center=�$��	2.5 2 5 8q��� -   $	 	prefixBox��#��[ $��7 5 7 5q��� $��-��$��Center=�$��	2.5 2 5 8q��� -   $	 lineNumberBox��#��[ $��7 5 7 5q��� $��3��
���   �$��1 1 1 1q�$��Right=�$��0 0 5 5q�._��� -    ��Name$ saveSettingsButton��$��3��$��Save Settings��$��15(����#4BB543
�������$��Arial)�$��8q�