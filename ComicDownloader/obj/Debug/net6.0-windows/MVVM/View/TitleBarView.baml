   M S B A M L   `   `   `  ����J  FComicDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ComicDownloader.MVVM.ViewComicDownloader.MVVM.View  5      O,clr-namespace:ComicDownloader.MVVM.ViewModelComicDownloader.MVVM.ViewModel  5
      ,    &ComicDownloader.MVVM.View.TitleBarView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      3local'clr-namespace:ComicDownloader.MVVM.View  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      <	viewModel,clr-namespace:ComicDownloader.MVVM.ViewModel  5
      -   5        $��titleBar��5      
������   � DataContext  5      6   0ComicDownloader.MVVM.ViewModel.TitleBarViewModel  5   
   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ 	MouseDown��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *MouseDownCommand+   CommandParameter 6I   ��  �� ElementName$ titleBar��5      .��5      � .+�5   
   '  !MaterialDesignThemes.Wpf.PackIcon  $��40��5      $
��Left=�5      
�������   Kind$ DownloadBox=�5      ��5      �� $ titleBar�� �� Path$ ActualHeight�5      �� 5   
   -   5        	 ��Name$	 txbTitle��5       $��Center=�5!      $��Center=�5"      $��15(�5#      $
��Bold"�5$      
���������5&      �� $ titleBar��$	 Tag��� 5'   
   $��Right=�6   
 �� Orientation$
 
Horizontal=�61    � 	Resources 5(         
CloseTheme �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%h  &	        '�� �    �� 5)      " ��6+   .�5*      ��  � ��
 ���� 63   �� 5+       � ��$ 40��6.   �� 5,       � ��$ 0q�68   �� 5-       � �� 5.      �� 5/      " ��6.   .R�50   "   �� #��z��6)   ._�51   &   �� $��Center=�67   $��Center=�6T   52   #   53      55       56      P� 57       �@J�IsMouseOver$
 True��69   . �58      ��  � ��
 �  ��6;   59      5;      �� 5<      " ��6   .�5=      ��  � ��
 ���� 63   �� 5>       � ��$ 40��6.   �� 5?       � ��$ 0q�68   �� 5@       � �� 5A      �� 5B      " ��6.   .R�5C   "   �� #��z��6)   ._�5D   &   �� $��Center=�67   $��Center=�6T   5E   #   5F      5H       5I      P� 5J       �@J�IsMouseOver$
 True��69   . �5K      ��  � ��
 �����6;   5L      5N      5O      .+�5P      �� ��6   �� *MinimizeCommand+��69   �� $ titleBar����5Q        5R      $��15��5S      $��15��5T      
�������$ WindowMinimize=�5V      5X      �� 5Y      ��6   �� *MaximizeCommand+��69   �� $ titleBar����5Z        5[      $��15��5\      $��15��5]      
�������$ WindowMaximize=�5_      5a      �� 5b      #��[  5e      ��5c      �� *CloseCommand+��5d      �� $ titleBar����5f        5g      $��15��5h      $��15��5i      
�������$ Close=�5k      5m      5n      5o      5p      