   M S B A M L   `   `   `  ����J  FQDCeValutazioni, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:QDCeValutazioni.ViewsQDCeValutazioni.Views  5      G(clr-namespace:QDCeValutazioni.ViewModelsQDCeValutazioni.ViewModels  5      )    #QDCeValutazioni.Views.SelezionaView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:QDCeValutazioni.Views     5      >	viewmodel(clr-namespace:QDCeValutazioni.ViewModels     5        � DataContext  5
      3   -QDCeValutazioni.ViewModels.SelezionaViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��0��6    $	��Qdc��6-   $��Center=�6;   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ QdcDataGrid��5      $��0��6(   $��1��68      
IsReadOnly . ��5      ��  �� Path$
 Qdcs�5      �� 5   
   $��0��6   $��2��6!   $��Seleziona Qdc��6.   ��5       �� $ SelezionaCommand�5!      5"      