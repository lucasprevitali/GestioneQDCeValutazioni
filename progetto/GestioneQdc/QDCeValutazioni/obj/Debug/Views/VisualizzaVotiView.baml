   M S B A M L   `   `   `  ����J  FQDCeValutazioni, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:QDCeValutazioni.ViewsQDCeValutazioni.Views  5      G(clr-namespace:QDCeValutazioni.ViewModelsQDCeValutazioni.ViewModels  5      .    (QDCeValutazioni.Views.VisualizzaVotiView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:QDCeValutazioni.Views     5      >	viewmodel(clr-namespace:QDCeValutazioni.ViewModels     5        � DataContext  5
      8   2QDCeValutazioni.ViewModels.VisualizzaVotiViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��0.5* �6   6,   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��2* �6   6*    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5   
   �� $��1��6   $��0��5      $��	10,30,0,0q�5      $��file voti template:��5      5       �� 5!   
   -   5         ��Name$ PathVotiTemplateTextBox��5%      $��1��5!      $��0��5"      $��2��5#      $��120,25,20,25q�5$      
���������5&      ��  �� Path$ PathVotiTemplate�69   �� 5(   
   $��2��6   $��0��5)      $��	10,30,0,0q�5*      $��file in cui salvare:��5+      5,      �� 5-   
   -   5        $ PathVotiSaveTextBox��51      $��2��5-      $��0��5.      $��2��5/      $��120,25,20,25q�50      
���������52      �� $ PathVotiSave�65   �� 55   
   $��0��56      $��3��6   $��2��6*   $��Center=�57      $��Center=�6)   $��cerca e salva��58      $��100,18q�6%   $��18(�66   ��59      �� $ SaveVoti�5:      �� 5=   
   $��0��5>      $��4��6   $��Center=�5?      $��Center=�6)   $��Visualizza voti��5@      $��20q�6'   $��30(�64   ��5A      �� $ VisualizzaVoti�5B      �� 5E   
   $��1��5F      $��4��6   $��Center=�5G      $��Center=�6)   $��Torna al MENU��5H      $��20q�6%   $��30(�62   ��5I      �� $ MenuCommand�5J      5K      5L      