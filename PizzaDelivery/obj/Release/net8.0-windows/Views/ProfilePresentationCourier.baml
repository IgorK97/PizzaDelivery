   M S B A M L   `   `   `  ���� H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  4    .PizzaDelivery.Views.ProfilePresentationCourier   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:PizzaDelivery.Views     $��24(�.��� .+�� -     �Name$  Overlay1�� K� ZIndex$
 1000������  �� 
TargetType" � �� Triggers ��  �� Binding �� *Notification+ �� Value	 false.a���  �� Property � y� �� Value$ 	Collapsed=���  �� *Notification+ true.a���  � y�$ Visible=�����  �� Color$ Black��	 �� Opacity$		 0.5Q�.+�� $��Center=�$��Center=�
�������
 � RowDefinitions
 �� $
��auto ��� $
��auto �.+��� $��20(�$��10q�$��0������ *	Message+��    BaseButtonStyle#��[  $��Закрыть��$��10q�$��1��$��Center=����� *Close+� $��Center=�$��Center=�$��10q�
 �� $
��Auto ��� $
��Auto �.+�� $��0�� � ColumnDefinitions �� $
��auto ��� $	��300 �
 �� �� �� �� �� �� �� �� .+��� $��0 10 0 0q�$��Имя��$��0��$��0���� $��	10 10 0 0q�$��1��$��0������ *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=��� $��0 10 0 0q�$��Фамилия��$��0��$��1���� $��	10 10 0 0q�$��1��$��1������ *
LastName+$ PropertyChanged=��� $��0 10 0 0q�$��Отчество��$��0��$��2���� $��	10 10 0 0q�$��1��$��2������ *	Surname+$ PropertyChanged=��� $��0 10 0 0q�$��
Логин��$��0��$��3���� $��	10 10 0 0q�$��1��$��3������ *Login+$ PropertyChanged=��� $��0 10 0 0q�$��Пароль��$��0��$��4��G� -    G�Name$ pbPasswordBox��$��	10 10 0 0q�$��1��$��4���� $��0 10 0 0q�$)��#Подтвердите пароль��$��0��$��5��G� -   $ pbRepPasswordBox��$��	10 10 0 0q�$��1��$��5���� $��0 10 0 0q�$��Телефон��$��0��$��6���� $��	10 10 0 0q�$��1��$��6������ *Phone+$ PropertyChanged=��� $��0 10 0 0q�$��
Почта��$��0��$��7���� $��	10 10 0 0q�$��1��$��7������ *Email+$ PropertyChanged=��� $��0 10 0 0q�$��1��$��Сохранить��#��[  $��Center=����� *SaveProfileChangesCommand+