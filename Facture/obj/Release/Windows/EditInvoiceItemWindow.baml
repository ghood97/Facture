   M S B A M L   `   `   `  ���� B  >Facture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Facture.WindowsFacture.Windows  +    %Facture.Windows.EditInvoiceItemWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:Facture.Windows       � Icon$  FactureIcon.ico�� � Title$ Edit Invoice Item��$	��400��$	��400��.���  � RowDefinitions �� $
��auto ��� $��* ��� $��* �.+��� $��0��$��Edit Quantity��$��Center=�$��25(�$
��Bold"�$��10q��� $��1��.+�� $��10q� � ColumnDefinitions �� $��* ��� $
��2.9* ��� $��* � �� $��* ��� $��* �.+��� $��0��$��0��$��	Quantity:��$��0 0 0 5q�$��Right=��� -    ��Name$ quantityBox��$��0��$��1��$��0 0 0 5q�$��20(�$��80��$
��Left=����� *
Quantity+ �� Mode$ TwoWay=��� -    ��Name$ updateQuantityButton��$��1��$��1��$��Update Quantity�����#4BB543
�������$��15(�$��0 10 0 0q��� -   $ deleteInvoiceItemButton��$��Delete Item��$��3��
���  ��
�������$��17(�$
��Bold"�$��0 10 0 0q�$��Right=�$��Bottom=�