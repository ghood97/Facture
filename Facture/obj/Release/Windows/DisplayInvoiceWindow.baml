   M S B A M L   `   `   `  ���� B  >Facture, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Facture.WindowsFacture.Windows  7 clr-namespace:Facture.PropertiesFacture.Properties  *    $Facture.Windows.DisplayInvoiceWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:Facture.Windows     7
properties clr-namespace:Facture.Properties       � WindowStartupLocation$  CenterScreen=� � Title$ DisplayInvoiceWindow��$	��675��$	��700�� � 	Resources  �� 
TargetType   billToBlocks �� Property �� Value  businessBlocks��%Z   &	        &	 #     �� " ��.���  � ��$ 15(��� " ��.���  � ��$ 15(�.���  � ColumnDefinitions �� $��* ��� $��* ��� $��* � � RowDefinitions �� $��40 ��� $��* ��� $
��2.5* �.+��� -    ��Name$ 	dateBlock��$��0��$��2��$��0��$��15(�$��10q�$
��Bold"��� -   	 ��Name$	 editInvoiceButton��$��0��$��2��$��Edit Invoice��$��12(�
��� ���$��Right=�$��0 5 0 5q��� $��0��$��1��$��10q�.+��� $��Bill To:��$��30(�$��Verdana)�$
��Bold"�$��Italic$�$��	Underline{��� #��[  ���� *BillTo+�� #��[  ���� *	Address+�� #��[  ���� *City+
 �� StringFormat$

 {0},���� #��[  ���� *State+�� -   $ billToPhoneBlock��#��[  �� $��2��$��1��
���   �$��1 1 1 1q� �� Padding$ 10q�._��� .+��� $��20(�$��Verdana)�$
��Bold"�$��Italic$�$
��Wrap=����� !  Facture.Properties.Settings   Default �� Source# Z  �� Path$ BusinessName��� #��[ ���� # Z $ Address��� #��[ ���� # Z $
 City��� #��[ ���� # Z $ State��� -   $ businessPhoneBlock��#��[ &   System.Windows.Controls.DataGrid  -     Name$ invoiceItemGridView��$��0��$��3��$��2��   AutoGenerateColumns .     CanUserAddRows .     CanUserSortColumns .    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Item Name��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 3*    CellTemplate �� .R��� $��15(����� *	Item.Name+  $ Price�� . $ *  �� .R��� $��15(�$��Center=����� $ 
Item.Price�$
 {0:c}��  $ Quantity�� . $ *  �� .R��� $��15(�$��Center=����� *
Quantity+  $ Total�� . $ *  �� .R��� $��15(�$��Center=����� $ Total�$
 {0:c}��