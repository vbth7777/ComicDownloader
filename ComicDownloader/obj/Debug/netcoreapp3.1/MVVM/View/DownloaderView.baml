   M S B A M L   `   `   `  ����J  FComicDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ComicDownloader.MVVM.ViewComicDownloader.MVVM.View  5      O,clr-namespace:ComicDownloader.MVVM.ViewModelComicDownloader.MVVM.ViewModel  5
      .    (ComicDownloader.MVVM.View.DownloaderView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      3local'clr-namespace:ComicDownloader.MVVM.View  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      <	viewModel,clr-namespace:ComicDownloader.MVVM.ViewModel  5
      $��15(�5        � DataContext  5      8   2ComicDownloader.MVVM.ViewModel.DownloaderViewModel  5   
   .��5      ��  � 	Resources 5   
    �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 	0,0,10,24q�6+   �� 5       � ��$ Center=�66   �� 5       � ��$ Right=�68   �� 5       � ��
 �����6/   5      5      .+�5   
   �� $��Center=�6   y�62   �� *DownloadingInputVisibility+.+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� .+�5      �� $��
0,10,10,24q�6    $��Websites��64   �� 5      $
��Type��6    �� 5      $	��Url��6    �� 5      $
��Path��6    5       �� 5!      .+�5"      �� $��40��5#      $��0,0,0,10q�5$      $ 
Horizontal=�5%      .+�5&      �� -   5         ��Name$ 
cbWebsites��5'      $	��200��5(      $��20��5)      $��5q�5*      $
��Left=�5+      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Inverted=�5,      
������� �� DisplayMemberPath$	 Url��5.      
������� "  MaterialDesignOutlinedComboBox#��[  52      ��50      �� *
Websites+	 �� SelectedValue	 51      �� *SelectedWebsite+*  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 53      +  %Microsoft.Xaml.Behaviors.EventTrigger  54   "      	EventName$ SelectionChanged��61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 55   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6<   �� *SelectedWebsiteCommand+56   #     57   "   $ Loaded��61   . 58   &      6<   �� *WebsitesComboBoxLoadedCommand+59   #   5;      �� 5<      $��50��5=      $��	10,0,10,0q�5>      $	��Add��5A        ModernButtonTheme#��[ 5B      ��5?      �� *SelectorsAdderDisplayCommand+��5@      ��  �� ElementName$ 
cbWebsites��5B      �� 5C      $	��120��5D      $��40��5E      $��Edit Selectors��5H      #��[ 5J      ��5F      �� *SelectorsEditorDisplayCommand+��5G      �� $ 
cbWebsites��{�5I      �� *IsEditSelectorsButtonEnable+5J      5K      �� 5L      -   5        $ cbType��5M      $	��200��5N      $��20��5O      $��5q�5P      $
��Left=�5Q      $
��Left=�5R      $ Inverted=�5S      
�������
�������#��[  5W       �� SelectedItem 5V      �� *SelectedType+
 5X        5Y      $ Loaded��6-   . 5Z   "      68   �� *TypeComboBoxLoadedCommand+   CommandParameter 6f   �� $ cbType��5[      5]      �� 5^      $	��200��5_      $��0,10,0,0q�5`      $
��Left=�5a        ModernTextBoxTheme#��[ 5b      ��5c      �� *	UrlText+�� 5d      $	��200��5e      $��0,10,0,0q�5f      $
��Left=�5g      #��[ 5h      ��5i      �� *Path+5j      5k      �� 5l      $��
120,20,0,0q�5m      $
��Left=�5n      $ 
Horizontal=�5o      .+�5p      �� $	��100��5q      $��30��5r      $��Download��5t      #��[ 5v      ��5s      �� *DownloadCommand+{�5u      �� *IsDownloadButtonEnable+5v      5w      5x      �� 5y   
   $	��700��6   y�6!   �� *DownloadingProgressVisibility+.+�5z      �� $��0,0,0,10q�5{      $��Center=�5|      $��18(�5}       �� TextAlignment$ Center=�5      $
��Wrap=�5�      ��5~      �� *DownloadingComicName+5�      �� 5�      $��0,0,0,15q�5�      $��Center=�5�      $��18(�5�      $ Center=�5�      $
��Wrap=�5�      ��5�      �� *DownloadingChapterName+5�      �� 5�      $��Center=�6   $ 
Horizontal=�66   .+�5�      �� .+�5�      �� $��	0,5,10,17q�5�      $��Comics of page��5�      y�5�      �� *+)DownloadingProgressComicsOfPageVisibility+�� 5�      $��0,0,10,0q�6    $��Comic��62   5�      �� 5�      .+�5�      � $��0,0,0,10q�6   y�6-   �� *+)DownloadingProgressComicsOfPageVisibility+.+�5�      � -   5         �Name$ pbDownloading1��5�      $	��300��5�      $��30��5�      
�������
������ 
������� � Value 5�      �� *(&DownloadingProgressComicsOfPagePercent+ �� UpdateSourceTrigger$ PropertyChanged=��� 5�      $��0q�5�      $��Center=�5�      $��Center=�5�      $
��Bold"�5�      
���������5�      �� $ pbDownloading1�� �� Path$ Value� �� StringFormat$ {0:N1}%��5�      � 5�      .+�5�      � -   5        $ pbDownloading2��5�      $	��300��5�      $��30��5�      
�������
������ 
������� 5�      �� *!DownloadingProgressComicPercent+$ PropertyChanged=��� 5�      $��0q�5�      $��Center=�5�      $��Center=�5�      $
��Bold"�5�      
���������5�      �� $ pbDownloading2��$ Value�$ {0:N1}%��5�      5�      5�      �� 5�      $��70��5�      $��0,15,0,0q�5�      $��Cancel��5�      #��[ 5�      ��5�      �� *CancelingDownloadingCommand+5�      5�      5�      5�      