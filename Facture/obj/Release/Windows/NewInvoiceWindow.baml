   M S B A M L   `   `   `  ���� B  >Facture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Facture.WindowsFacture.Windows  &     Facture.Windows.NewInvoiceWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:Facture.Windows       � Icon$  FactureIcon.ico�� � WindowStartupLocation$ CenterScreen=� � Title$ New Invoice��$	��700��$
��1100��.���  � ColumnDefinitions �� $��* ��� $��* ��� $��2* � � RowDefinitions �� $��* ��� $��2* ��� $��3* ��� $
��auto �.+��� $��0��$��3��$��Center=�$��Center=�$��New Invoice��$��35(�$��Arial Black)��� $��1��$��2��
�������$��2 2 0 2q� �� Padding$ 0q�._�� $��1��$��2�� �� $��* ��� $��10 ��� $��* � �� $��* ��� $��3* �.+��� $��4��$��Bill To��$��Stretch=� �� TextAlignment$ Center=�$	��Top=�$��27(�$��Arial Black)�$��	Underline{����#A9A9A9�� $��1��.+���  �� Orientation$ 
Horizontal=�$��Right=�$��0 0 0 10q�.+��� $��Name:��$��15(�$��Arial)��� -    ��Name$ invoiceNameBox��$	��150��$��17(��� $ 
Horizontal=�$��Right=�.+��� $��Phone:��$��15(�$��Arial)��� -   $ invoicePhoneBox��$	��150��$��17(��� $��1��$��2��$
��Left=�.+��� $ 
Horizontal=�$��Right=�$��0 0 0 10q�.+��� $��Address:��$��15(�$��Arial)��� -   $ invoiceAddressBox��$	��150��$��12(�$��Center=��� $ 
Horizontal=�$��Right=�$��0 0 0 10q�.+��� $��City:��$��15(�$��Arial)��� -   $ invoiceCityBox��$	��150��$��17(��� $ 
Horizontal=�$��Right=�.+��� $��State:��$��15(�$��Arial)��� -   $ invoiceStateBox��$	��150��$��17(�$��Massachusetts���� $��1��$��2��$��2��
�������$��2q�$ 0q�._�� $��1��$��2��$��2�����#A9A9A9 �� $
��auto ��� $��* �.+��� $6��0Pick items from this list to add to the invoice.��$��Center=�$��18(�$��Arial Black)�$��0q�$��	Underline{�$
��Wrap=�$ Center=�&   System.Windows.Controls.DataGrid  -   	  Name$	 itemGridView��
   AutoGenerateColumns
 .     CanUserAddRows .  $��1��$��0 10 0 0q�   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 3*    CellTemplate �� .R��� $��15(����� *Name+  $ Price�� . $ *  �� .R��� $��15(�$��Center=�����  �� Path$ Price� �� StringFormat$ {0:c}��  $
 Unit�� . $ *  �� .R��� $��15(�$��Center=����� *Unit+�� $��2��$��2��
�������$��2 0 0 2q�$ 0q�._�� ���#A9A9A9 �� $
��auto ��� $��* �.+��� $��Invoice Items��$��Center=�$��25(�$��Arial Black)�$��8 4 8 4q�$��	Underline{�$
��Wrap=�$ Center=�  -   $	 invoiceItemGridView��
 .   .  $��1��$��0 10 0 0q�   $
 Name�� . $ 3*  �� .R��� $��15(����� *	Item.Name+ �� Mode$ TwoWay=�  $ Price�� . $ *  �� .R��� $��15(�$
��Left=����� $ 
Item.Price�$ {0:c}��  $
 Unit�� . $ *  �� .R��� $��15(�$
��Left=����� *	Item.Unit+  $ Quantity�� . $ *  �� .R��� $��15(�$
��Left=����� *
Quantity+  $ Total�� . $ *  �� .R��� $��15(�$
��Left=����� $ Total�$ {0:c}���� -    ��Name$ createInvoiceButton��$��3��$��3��$��40��$��Create Invoice�����#4BB543
�������$��25(�$	��Top=�$��Center=�