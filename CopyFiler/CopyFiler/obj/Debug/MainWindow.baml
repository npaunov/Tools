   M S B A M L   `   `   `  ����D  @CopyFiler, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CopyFiler	CopyFiler  5   	       CopyFiler.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CopyFiler     5   	     � Icon$  Images\Copy-icon.png��5   	    � Title$ 	CopyFiler��5	   	   $	��350��6   $	��550��6(    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Styles\ButtonStyle.xaml?�6%   �� 5      $ Styles\TextBoxStyle.xaml?�6%   %    5      .��5      � -   5        $��grid1��5       5   
    �� 
TargetType �� BasedOn �� Property �� Value��%�  '��       7��'�� �     �� 5      " ��6   8   .�5      ��  � ��$ 10q�6+   �� 5       � ��$	 150��6*   �� 5       � ��$ 40��6+   5      �� 5      " ��6   .�5      ��  � ��$ 5q�6+   �� 5       �@��Padding$ 5q�6,   �� 5       � ��
 �����6/   �� 5       � ��
 ���F�60   �� 5       �@��CornerRadius$ 3��61   �� 5        � ��$ 2,4,2,4q�64   �� 5!       � ��$	 Top=�66   5"      5#      	 � RowDefinitions	 5%   
   �� 5&      $��65 �6   �� 5'      $��* �6   �� 5(      $��30 �6   .+�5+   
   �� -   5        $��buttonStack��5+   :   $��0��6   $	��Top=�6"   
 �� Orientation$
 
Horizontal=�6M   .+�5,      �� -   5        $
��Copy��5,      $
��Auto��6$   61   �� 5-      -   5        $��Button_DefaultAddres��5-   5   $.��(Адрес по Подразбиране��6   6Q   �� 5.      $��5q�6    �� Padding$ 0q�6    ._�5/      �� -   5        $��txBlock_DAdress��52       �� 
IsReadOnly . $��1q�51      $��40��6    $	��180��53      $��12(�54       �� TextWrapping$
 Wrap=�55      ��56      �� *DAdress_text+57      58      �� 5:   
   $��1��6   $��Stretch=�6   ._�5D      � -   5        $��Grid_Addresses��5D      
������� J� 	AllowDrop .  � ColumnDefinitions 5J      �� 5K      $��52 �6'   �� 5L      $��3* �6'   �� 5M      $��4* �6'   �� 5N      $��2* �6'   5P      5Q      �� 5S   
   -   5        $��Btn_ClearAllFiles��5S      $	��5,2q�5T      $��15��5U      $��2��5V      $
��Left=�5W      $0��*Изчисти Всички Файлове��5X      5Y      5[      5\      