   M S B A M L   `   `   `  ????H  DProjectMuziek, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjectMuziek.ViewsProjectMuziek.Views  5      &     ProjectMuziek.Views.LiedjeWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -local!clr-namespace:ProjectMuziek.Views  5      .??5
      ? .+?5   
   ? 
???????$??50q?6&     ? RowDefinitions  5      ?? 5      $??50 ?6    ?? 5      $??50 ?6    ?? 5      $??50 ?6    ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $
??auto ?6    ?? 5      $
??auto ?6     ? ColumnDefinitions 5      ?? 5      ?? 5      ?? 5      ?? 5      .+?5      ?? $??20(?6   $
??15,0q?6"   $
??Bold"?60   $??0??6B   $??0??6R   .??6_   Zoek een nummer:6q   ?? 5      -   5         ??Name$ txtZoekveld??5      
???????$??0??6e   $??4??6u   $??1??6?   $
??15,0q?6?   ??6+   ?? *
Zoekterm+ ?? Mode$ TwoWay=?6?   ?? 5      $??3??6   $??1??6%   $??Right=?62   $	??150??6N   $??Zoeken??6Z   $
??30,0q?6k   
???**??$??0q?6?   ??6?   ?? *ZoekLiedKnop+6?   ?? 5      $??0??6   $??2??6%   $??Filters Wijzigen??6H   $??0q?6c   $
??Left=?6w   
???   ???62   Z? 6?   ?? 5       -   5         ??Name$ cmbGenre??5       $??20,0,0,0q?6)   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Kies een Genre??6;    ?? DisplayMemberPath$
 naam??6?   $??3??6?   $??0??6?   
???????$	??200??6  $
??Left=?6  ??6k   ?? *Genres+ ?? SelectedItem 6?   ?? *SelectedGenre+$ TwoWay=?61  ?? 5!      
?????? $??1??6E   $??3??6U   $??25??6b   $??Reset Filters??6p   $??12(?6?   $
??Left=?6?   
????  ???6.   Z? ??6?   ?? *ResetFiltersKnop+6?   ? 5"      $??4??6   $??7??6(   $	??365??65   .+?5#      &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridLieds??5#   ?   	   
IsReadOnly	 . 
   CanUserReorderColumns
 .     CanUserResizeColumns .  $??0 30 0 0q?6?      CanUserSortColumns .    CanUserAddRows .     AutoGenerateColumns .  $??2??6?   ??6   ?? *Lieds+   Columns 5$      4  .System.Windows.Controls.DataGridTemplateColumn  5%         CellTemplate 5&      ?? 5'   "   .R?5(   &   ?? $??0q?6-   
???**????6T   ?? *DataContext.UitleningCommand+ ?? RelativeSource ??  ?? AncestorType"  ??6?   ?? .??5)   *   ?? .??60   Beluisteren6=   5*   '   5+   #   5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Titel??6H    0  ,MaterialDesignDataGridTextColumnEditingStyle1  +System.Windows.Controls.DataGridBoundColumn   EditingElementStyle# [  6W      Binding 6-   ?? *Titel+6W     5/      $ Zanger??6W   # [  6g    6-   ?? *Zanger.VolledigeNaam+6g     50      $ UitgaveJaar??6N   # [  6c    6-   ?? *UitgaveJaar+6c     51      $ PlatenLabel??6N   # [  6c    6-   ?? *PlatenLabel+6c     52      $ Genre??6M   # [  6\    6-   ?? *
Genre.naam+6\     53      $ Producer??6K   # [  6]    6-   ?? *
Producer+6]   56      57      58      ? 59   
    5:      ?? 5;      ?? 5<        5>      ?? 5?      ?? 5@      5B      5C      5D      