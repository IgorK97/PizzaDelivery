   M S B A M L   `   `   `  ����H  DPizzaDelivery, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PizzaDelivery.ViewsPizzaDelivery.Views  5      C&clr-namespace:PizzaDelivery.ViewModelsPizzaDelivery.ViewModels  5      +    %PizzaDelivery.Views.SelectedPizzaView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      X TXceed.Wpf.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      -local!clr-namespace:PizzaDelivery.Views  5      7
viewmodels&clr-namespace:PizzaDelivery.ViewModels  5        � 	Resources  5         listIngrTemplate �� CornerRadius �� 
TargetType �� Triggers �� Binding �� Value �� Property �� Value J� InputBindings	 d� MouseAction
 �� Command �� Path �� RelativeSource �� AncestorType �� Mode �� CommandParameter �� Mode  listIngrPanelTemplate��%/  &	        &	 �    �� 5   
   .R�5      �� $	��200��6   $	��150��6!   $
��1000��6.   $��5q�6>   $ 10��6I   ��5      �� 5      " ��6    5      �� 5       6*   �� *IsIngredientSelected+	 false6S   .a�5   "   ��  � ��
 �����6?   5      �� 5       6*   �� *IsIngredientSelected+ true6S   .a�5   "   ��  � ��
 � ���6?   5      �� 5       6*   �� *
IsActive+	 false6G   .a�5   "   ��  � ��
 �����6@   �� 5   "    � ��$ 10q�6D   5      �� 5       6*   �� *
IsActive+ true6G   .a�5   "   ��  � ��
 �����6@   �� 5   "    � ��$ 2q�6D   5       5"       5$      d� 5%      $	 	LeftClicke�6#   
 5&      �� $) #DataContext.SelectIngredientCommand� ��  UserControl$ FindAncestor=� 5(      �� *Id+._�5*      �� .+�5+      �� $��50��6B   $��50��6M   $��5q�6Y   ��6   �� *Image+$ OneWay=�6Y   �� 5-      $��Center=�6C   $��16(�6`   $
��Bold"�6n   ��6    �� *Name+$ OneWay=�6n   �� 5.      $��Center=�6C   $��16(�5/      ��5.       �� *Cost+$ OneWay=�5/      �� 50      $��руб��6    $��Center=�6+   $��14(�6H   51      53      54      �� 55   
   .R�56      � 57      58      .��59      � ��5:   
   �� 5;       �� Color$ Black��6    �� Opacity$	 0.5Q�6,   .+�5=   
   � $	��300��6   $	��350��6   $��Center=�6.    � ColumnDefinitions 5>      �� 5?      $
��auto �6#   �� 5@      $��* �6#   .+�5B      �� $��0��6   $��15q�6&    �� Padding$ 10q�62   $��Center=�5C      $��Center=�5D      $��3q�5E      $ 10��6!     BrushPrimary1#��[ 5F      
�������._�5I      �  5J      �� 5K      �� 5L      .+�5O      � $��0��6   .+�5P      � $��Center=�6   $��Center=�6:    � RowDefinitions 5Q      �� 5R   "   �� 5S   "   .+�5U      �� $��UniformToFill=�6$   $	��200��6<   $	��200��6K   $��0��6t   ��6[   �� *Image+6t   � 5V      $
��5 10q�6#   $��1��61    5W   "   �� 5X   &   �� 5Y   &    5\   "   �� 5]   &   �� 5^   &   .+�5a   "   �� $��18(�6,   $��0��6:   $��0��6J   $
��5 10q�6X   $��Center=�6f   $��Center=�5b   (   $��
Вес, г��6C   �� 5c   "   $��18(�6,   $��1��6:   $��0��6J   $
��5 10q�6X   $��Center=�6f   $��Center=�5d      ��6'   �� *FinalWeight+�� 5e   "   $��18(�6,   $��0��6:   $��1��6J   $
��5 10q�6X   $��Center=�6f   $��Center=�5f      $��Цена, руб��68   �� 5g   "   $��18(�6,   $��1��6:   $��1��6J   $
��5 10q�6X   $��Center=�6f   $��Center=�5h      ��6   �� *Price+5i      5j      5k      � 5l      $	��600��6   $
��Auto=�6+   $	��Top=�6[   $��1��6s    5m      �� 5n      $
��auto �6,   �� 5o      $
��auto �6,   �� 5p      $
��auto �6,   �� 5q      $
��auto �6,   �� 5r      $
��auto �6,   �� 5s      $��* �6,   �� 5t      $
��auto �6,   .+�5v      �� $
��5 10q�6$   $��Center=�62   $��30(�6O   $��0��6^   ��6k   �� *Name+�� 5w      $��1��6'   $��Disabled=�64   $
��Auto=�5x   '   .��5y      �� $
��Wrap=�5z   $   $	��500��68   $
��5 10q�6G   $��16(�5{   $   ��63   �� *Description+5|      � 5}      $
��5 10q�6    $��2��6.   
���  �� 5~      �� 5   "   �� 5�   "   �� 5�   "   .+�5�      	� $��18(�6*   $��0��68    
 RadBut#��[ 5�   *   )   #PizzaDelivery.ViewModels.PizzaSizes   Small#��Z 5�   &   $��Маленькая��5�   &    d� 	IsChecked 5�   *   �� *	IsSmall+$ OneWay=���5�   &   �� *UpdatePizzaSizeCommand+5�   &   	� 5�      $��18(�6*   $��1��68   #��[ 5�   *      Medium#��Z 5�      $��Средняя��5�       5�   *   �� *
IsMedium+$ OneWay=���5�      �� *UpdatePizzaSizeCommand+5�      	� 5�      $��18(�6*   $��2��68   #��[ 5�   *      Large#��Z 5�      $��Большая��5�       5�   *   �� *	IsLarge+$ OneWay=���5�      �� *UpdatePizzaSizeCommand+5�      5�      � 5�      $��3��6    5�      �� 5�   "   �� 5�   "   .+�5�      �� $
��5 10q�6(   $��18(�66   $��0��6D   $��Количество��6T   %  Xceed.Wpf.Toolkit.IntegerUpDown  5�      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Minimum 15�   !      Maximum 106-   $��10 10 10 10q�5�   F   $��1��6[   $	��200��6k      Value 6!   �� *Count+$ TwoWay=�6k   5�      �� 5�      $��4��6$   $
��5 10q�61   $��18(�6?   $&�� Добавить по вкусу��6M   � 5�      $	��800��6   $��5��6.   .+�5�      �� $��5��6&   $��Disabled=�63   $��Visible=�5�      #��[  5�      #��[ 5�      ��5�      �� *IngredientCollection+ �� SelectedItem 5�   &   �� *SelectedIngredient+$ TwoWay=�5�      5�      �� 5�      $��6��6!   $��5q�6.   $��Center=�69   $��Center=�5�   !   $��18(�6<     BaseButtonStyle#��[ 5�   "   $��В корзину��5�   "   $
��20,3q�66   ��5�      �� *BuyPizzaCommand+5�   6   5�      5�      5�      �� 5�      
������ $
��Left=�6.   $	��Top=�6I   $��1��5�      $��50��6&   $��50��61   #��[ 5�      ��5�      �� *ExitCommand+.��5�      �� $��/ImagesForProject/out.png��6   5�      5�      5�      5�      