   M S B A M L   `   `   `  ���� J  FComicDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ComicDownloader.MVVM.ViewComicDownloader.MVVM.View  E'clr-namespace:ComicDownloader.MVVM.ViewComicDownloader.MVVM.View  O,clr-namespace:ComicDownloader.MVVM.ViewModelComicDownloader.MVVM.ViewModel  4    .ComicDownloader.MVVM.View.SelectorsEditorWView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     9local'clr-namespace:ComicDownloader.MVVM.View     _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  2view'clr-namespace:ComicDownloader.MVVM.View  <	viewModel,clr-namespace:ComicDownloader.MVVM.ViewModel    � Title$  SelectorsEditorWView��$	��500��$	��330�� � AllowsTransparency$
 True�� � WindowStyle$
 None=�.���� ���#363635$��2q�._��  � RowDefinitions �� $��30 ��� .+�,   &ComicDownloader.MVVM.View.TitleBarView  ���#242423
 � Tag$ Selectors Editor��� $��1�� � 	Resources  �� 
TargetType �� Property �� Value��%{   '��       �� " ��.���  � ��$ 15(���  � ��
 �������  � ��$ 	0,5,10,15q���  � ��$ Right=�.+�#  MaterialDesignThemes.Wpf.Card  
������ .���� .  (MaterialDesignThemes.Wpf.ColorZoneAssist	   Mode$
	 Dark=� "  MaterialDesignFilledTabControl#��[  .@��� $��Comics��.��� .+��� .+��� $��10q�$
��left=�
���  ��$9��3* Comic tab and chapter tab selectors are required.���� $��20q�$��Center=�$��Bottom=�
 �� Orientation$
 
Horizontal=�.+��� .+��� $��Urls Selector���� $��Next Page Selector���� $	��300��.+���   ModernTextBoxTheme#��[ ���� *UrlComicsSelector+ �� UpdateSourceTrigger$ PropertyChanged=��� $��0,10,0,0q�#��[ ���� *NextPageButtonSelector+$ PropertyChanged=�'  !MaterialDesignThemes.Wpf.PackIcon  $��30��$��30��$��10q�$��Right=�
�������   Kind$ About=��� $��Comic��.��� .+��� .+��� $��10q�$
��Left=�
���  ��$+��%* Chapter tab selectors are required.���� $��20q�$��Center=�$��Bottom=�$
 
Horizontal=�.+��� .+��� $��Name Selector���� $��Chapters Selector���� $	��300��.+��� #��[ ���� *NameComicSelector+$ PropertyChanged=��� $��0,10,0,0q�#��[ ���� *ChaptersComicSelector+$ PropertyChanged=�  $��30��$��30��$��10q�$��Right=�
�������$ About=��� $��Chapter��.��� .+��� $��20q�$��Center=�$��Center=�$
 
Horizontal=�.+��� .+��� $��Images Selector���� $	��300��.+��� #��[ ���� *ImagesChapterSelector+$ PropertyChanged=�  $��30��$��30��$��10q�$��Right=�
�������$ About=��� $��Bottom=�.+��� $��Center=�$
 
Horizontal=�.+��� .+��� $��	0,5,10,15q�$��Website���� $	��250��.+��� $��0,0,0,10q�#��[ ���� *	Website+$ PropertyChanged=��� $	��100��$��40��$��0,0,0,10q�$��Confirm��  ModernButtonTheme#��[ ���� *ConfirmCommand+����  �� RelativeSource �� *Self+