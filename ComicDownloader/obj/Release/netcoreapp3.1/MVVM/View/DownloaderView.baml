   M S B A M L   `   `   `  ���� J  FComicDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ComicDownloader.MVVM.ViewComicDownloader.MVVM.View  O,clr-namespace:ComicDownloader.MVVM.ViewModelComicDownloader.MVVM.ViewModel  .    (ComicDownloader.MVVM.View.DownloaderView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  3local'clr-namespace:ComicDownloader.MVVM.View  _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  <	viewModel,clr-namespace:ComicDownloader.MVVM.ViewModel  $��15(�  � DataContext  8   2ComicDownloader.MVVM.ViewModel.DownloaderViewModel  .����  � 	Resources  �� 
TargetType �� Property �� Value��%   '��       �� " ��.���  � ��$ 	0,0,10,24q���  � ��$ Center=���  � ��$ Right=���  � ��
 �����.+��� $��Center=�y��� *DownloadingInputVisibility+.+���  �� Orientation$ 
Horizontal=�.+��� .+��� $��
0,10,10,24q�$��Websites���� $
��Type���� $	��Url���� $
��Path���� .+��� $��40��$��0,0,0,10q�$ 
Horizontal=�.+��� -    ��Name$ 
cbWebsites��$	��200��$��20��$��5q�$
��Left=�.  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$ Inverted=�
������� �� DisplayMemberPath$	 Url��
������� "  MaterialDesignOutlinedComboBox#��[  ���� *
Websites+	 �� SelectedValue	 �� *SelectedWebsite+*  $Microsoft.Xaml.Behaviors.Interaction
   Triggers
 +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ SelectionChanged��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *SelectedWebsiteCommand+  $ Loaded��.    �� *WebsitesComboBoxLoadedCommand+�� $��50��$��	10,0,10,0q�$	��Add��  ModernButtonTheme#��[ ���� *SelectorsAdderDisplayCommand+����  �� ElementName$ 
cbWebsites���� $	��120��$��40��$��Edit Selectors��#��[ ���� *SelectorsEditorDisplayCommand+���� $ 
cbWebsites��{��� *IsEditSelectorsButtonEnable+�� -   $ cbType��$	��200��$��20��$��5q�$
��Left=�$
��Left=�$ Inverted=�
�������
�������#��[   �� SelectedItem �� *SelectedType+
   $ Loaded��.    �� *TypeComboBoxLoadedCommand+   CommandParameter �� $ cbType���� $	��200��$��0,10,0,0q�$
��Left=�  ModernTextBoxTheme#��[ ���� *	UrlText+�� $	��200��$��0,10,0,0q�$
��Left=�#��[ ���� *Path+�� $��
120,20,0,0q�$
��Left=�$ 
Horizontal=�.+��� $	��100��$��30��$��Download��#��[ ���� *DownloadCommand+{��� *IsDownloadButtonEnable+�� $	��700��y��� *DownloadingProgressVisibility+.+��� $��0,0,0,10q�$��Center=�$��18(� �� TextAlignment$ Center=�$
��Wrap=����� *DownloadingComicName+�� $��0,0,0,15q�$��Center=�$��18(�$ Center=�$
��Wrap=����� *DownloadingChapterName+�� $��Center=�$ 
Horizontal=�.+��� .+��� $��	0,5,10,17q�$��Comics of page��y��� *+)DownloadingProgressComicsOfPageVisibility+�� $��0,0,10,0q�$��Comic���� .+�� $��0,0,0,10q�y��� *+)DownloadingProgressComicsOfPageVisibility+.+�� -    �Name$ pbDownloading1��$	��300��$��30��
�������
������ 
������� � Value �� *(&DownloadingProgressComicsOfPagePercent+ �� UpdateSourceTrigger$ PropertyChanged=��� $��0q�$��Center=�$��Center=�$
��Bold"�
����������� $ pbDownloading1�� �� Path$ Value� �� StringFormat$ {0:N1}%��� .+�� -   $ pbDownloading2��$	��300��$��30��
�������
������ 
������� �� *!DownloadingProgressComicPercent+$ PropertyChanged=��� $��0q�$��Center=�$��Center=�$
��Bold"�
����������� $ pbDownloading2��$ Value�$ {0:N1}%���� $��70��$��0,15,0,0q�$��Cancel��#��[ ���� *CancelingDownloadingCommand+