   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  E AInterfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-%clr-namespace:DTO;assembly=InterfacesDTO %    PizzaDelivery.Views.CommentView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:PizzaDelivery.Views     :statuses%clr-namespace:DTO;assembly=Interfaces     .��� ����   �� Color$  Black�� �� Opacity$	 0.5Q�.+�� $	��300��$	��350��$��Center=� � ColumnDefinitions �� $
��auto ��� $��* �.+��� $��0��$��15q� �� Padding$ 10q�$��Center=�$��Center=�$��3q� �� CornerRadius$ 10��   BrushPrimary1#��[  
�������._��  � RowDefinitions �� �� �� .+�� $
��5 10q�$��0��
���  �� �� $
��102* ��� $	��43* ��� $
��145* �.+�	� $��18(�$��0��  DTO.DeliveryStatus   	Delivered#��Z $��Доставлено��$��2�� d� 	IsChecked �� *	IsSuccess+ �� Mode$ OneWay=����� *UpdateSuccess+����  
 RadBut	 �� BasedOn#	 [ 
 �� 
TargetType"
 	� �� Triggers ��  �� Binding �� *IsChangeable+ �� Value true.a���  �� Property � y� �� Value$ Visible=���  �� *IsChangeable+	 false.a���  � y�$ 	Collapsed=�	� $��18(�$��2��   NotDelivered#��Z $��Не доставлено�� �� *IsNotSuccess+$ OneWay=����� *UpdateSuccess+���� #	 [ "
 	� ��  �� *IsChangeable+ true.a���  � y�$ Visible=���  �� *IsChangeable+	 false.a���  � y�$ 	Collapsed=��� $
��Auto=�$��Disabled=�$	��300��$��1��$	��300��$��50��$��18(����� *	Comment+.������ "
 �� ��  �� *IsNotSuccess+ true.a���  � y�$ Visible=���  �� *IsNotSuccess+	 false.a���  � y�$ 	Collapsed=���  �� *IsChangeable+ true.a���  �@��
IsReadOnly$ False����  �� *IsChangeable+	 false.a���  �@��
IsReadOnly$
 true��.���� $��2��$��Применить������ *Save+���� "
 ��  BaseButtonStyle#	 [  ��  �� *IsChangeable+ true.a���  � y�$ Visible=���  �� *IsChangeable+	 false.a���  � y�$ 	Collapsed=��� 
������ $
��Left=�$	��Top=�$��1��$��50��$��50��#��[ ���� *ExitCommand+.���� $��/ImagesForProject/out.png��