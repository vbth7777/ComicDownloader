   M S B A M L   `   `   `  ���� J  FComicDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ComicDownloader.MVVM.ViewComicDownloader.MVVM.View  E'clr-namespace:ComicDownloader.MVVM.ViewComicDownloader.MVVM.View  O,clr-namespace:ComicDownloader.MVVM.ViewModelComicDownloader.MVVM.ViewModel  4    .ComicDownloader.MVVM.View.SelectorsEditorWView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  3local'clr-namespace:ComicDownloader.MVVM.View  _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  2view'clr-namespace:ComicDownloader.MVVM.View  <	viewModel,clr-namespace:ComicDownloader.MVVM.ViewModel    � Title$  SelectorsEditorWView��$	��500��$	��330�� � AllowsTransparency$
 True�� � WindowStyle$
 None=�.���� ���#363635$��1q�._��  � RowDefinitions �� $��30 ��� .+�3   -ComicDownloader.MVVM.View.MinimalTitleBarView  
 � Tag$ Selectors Editor��� $��1�� � 	Resources  �� 
TargetType �� Property �� Value��%{   '��       �� " ��.���  � ��$ 15(���  � ��
 �������  � ��$ 	0,5,10,15q���  � ��$ Right=� �� �� $	��100 �.+�#  MaterialDesignThemes.Wpf.Card  
������ .���� .  (MaterialDesignThemes.Wpf.ColorZoneAssist	   Mode$
	 Dark=� "  MaterialDesignFilledTabControl#��[  .@��� $��Comics��.��� .+��� .+��� $��10q�$
��left=�
���  ��$9��3* Comic tab and chapter tab selectors are required.���� $��20q�$��Center=�$��Bottom=�
 �� Orientation$
 
Horizontal=�.+��� .+��� $��Urls Selector���� $��Next Page Selector���� $	��300��.+���   ModernTextBoxTheme#��[ ���� *ComicUrlsSelector+ �� UpdateSourceTrigger$ PropertyChanged=��� $��0,10,0,0q�#��[ ���� *NextPageButtonSelector+$ PropertyChanged=�'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��$��10q�$��Right=�
�������   Kind$ About=��� $��Comic��.��� .+��� .+��� $��10q�$
��Left=�
���  ��$+��%* Chapter tab selectors are required.���� $��20q�$��Center=�$��Bottom=�$
 
Horizontal=�.+��� .+��� $��Name Selector���� $��Chapters Selector���� $	��300��.+��� #��[ ���� *ComicNameSelector+$ PropertyChanged=��� $��0,10,0,0q�#��[ ���� *ComicChaptersSelector+$ PropertyChanged=�  $��30��$��30��$��10q�$��Right=�
�������$ About=��� $��Chapter��.��� .+��� $��20q�$��Center=�$��Center=�$
 
Horizontal=�.+��� .+��� $��Images Selector���� $	��300��.+��� #��[ ���� *ChapterImagesSelector+$ PropertyChanged=�  $��30��$��30��$��10q�$��Right=�
�������$ About=��� $��1��$��Bottom=�.+��� $��Center=�$
 
Horizontal=�.+��� .+��� $��	0,5,10,15q�$��Website���� $	��250��.+��� -    ��Name$ 	tbWebsite��$��0,0,0,10q�#��[ ���� *	Website+$ PropertyChanged=�.��*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ Loaded��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *WebsiteTextLoaded+   CommandParameter ��  �� ElementName$ 	tbWebsite��.���� $��Center=�$
 
Horizontal=�.+��� $	��100��$��40��$��0,0,0,10q�$��Confirm��  ModernButtonTheme#��[ ���� *ConfirmCommand+����  �� RelativeSource �� *Self+�� $	��130��$��40��$��	10,0,0,10q�$��Get Selectors��#��[ ���� *GetSelectorsCommand+