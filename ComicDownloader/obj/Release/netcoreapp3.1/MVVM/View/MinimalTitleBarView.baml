   M S B A M L   `   `   `  ���� J  FComicDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ComicDownloader.MVVM.ViewComicDownloader.MVVM.View  O,clr-namespace:ComicDownloader.MVVM.ViewModelComicDownloader.MVVM.ViewModel  3    -ComicDownloader.MVVM.View.MinimalTitleBarView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  3local'clr-namespace:ComicDownloader.MVVM.View  _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  <	viewModel,clr-namespace:ComicDownloader.MVVM.ViewModel  -   $��titleBar��
������   � DataContext  =   7ComicDownloader.MVVM.ViewModel.MinimalTitleBarViewModel  *  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ 	MouseDown��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *MouseDownCommand+   CommandParameter ��  �� ElementName$ titleBar��.��� .+�'  !MaterialDesignThemes.Wpf.PackIcon  $��40��$
��Left=�
�������   Kind$ DownloadBox=����� $ titleBar�� �� Path$ ActualHeight��� -   	 ��Name$	 txbTitle��$��Center=�$��Center=�$��15(�$
��Bold"�
����������� $ titleBar��$	 Tag��� $��Right=�
 �� Orientation$
 
Horizontal=� � 	Resources    
CloseTheme �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%�  &	        '�� �     �� " ��.���  � ��
 ���� ��  � ��$ 40����  � ��$ 0q���  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �  ���� " ��.���  � ��
 ���� ��  � ��$ 40����  � ��$ 0q���  � �� �� " ��.R��� #��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
 True��. ���  � ��
 �����.+��� ���� *MinimizeCommand+���� $ titleBar����  $��15��$��15��
�������$ WindowMinimize=��� ���� *MaximizeCommand+���� $ titleBar����  $��15��$��15��
�������$ WindowMaximize=��� #��[  ���� *CloseCommand+���� $ titleBar����  $��15��$��15��
�������$ Close=�