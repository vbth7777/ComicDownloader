   M S B A M L   `   `   `  ����J  FComicDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ComicDownloader.MVVM.ViewComicDownloader.MVVM.View  5      O,clr-namespace:ComicDownloader.MVVM.ViewModelComicDownloader.MVVM.ViewModel  5
      3    -ComicDownloader.MVVM.View.MinimalTitleBarView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      3local'clr-namespace:ComicDownloader.MVVM.View  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      <	viewModel,clr-namespace:ComicDownloader.MVVM.ViewModel  5
      -   5        $��titleBar��5      ���#242423  � DataContext  5      =   7ComicDownloader.MVVM.ViewModel.MinimalTitleBarViewModel  5   
   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ 	MouseDown��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *MouseDownCommand+   CommandParameter 6I   ��  �� ElementName$ titleBar��5      .��5      � .+�5   
   '  !MaterialDesignThemes.Wpf.PackIcon  $��40��5      $��25��5      $
��Left=�5      $��Center=�5      
�������   Kind$
 Edit=�5      �� 5    
   -   5         ��Name$ txbTitle��5!      $��Center=�5"      $��Center=�5#      $��15(�5$      $
��Bold"�5%      
���������5'      �� $ titleBar��	 �� Path$		 Tag��� 5(   
   $��Right=�6   
 �� Orientation$
 
Horizontal=�61    � 	Resources 5)         
CloseTheme �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value��%h  &	        '�� �    �� 5*      " ��6+   .�5+      ��  � ��
 ���� 63   �� 5,       � ��$ 40��6.   �� 5-       � ��$ 0q�68   �� 5.       � �� 5/      �� 50      " ��6.   .R�51   "   �� #��z��6)   ._�52   &   �� $��Center=�67   $��Center=�6T   53   #   54      56       57      P� 58       �@J�IsMouseOver$
 True��69   . �59      ��  � ��
 �  ��6;   5:      5<      �� 5=      " ��6   .�5>      ��  � ��
 ���� 63   �� 5?       � ��$ 40��6.   �� 5@       � ��$ 0q�68   �� 5A       � �� 5B      �� 5C      " ��6.   .R�5D   "   �� #��z��6)   ._�5E   &   �� $��Center=�67   $��Center=�6T   5F   #   5G      5I       5J      P� 5K       �@J�IsMouseOver$
 True��69   . �5L      ��  � ��
 �����6;   5M      5O      5P      .+�5Q      �� ��6   �� *MinimizeCommand+��69   �� $ titleBar����5R        5S      $��15��5T      $��15��5U      
�������$ WindowMinimize=�5W      5Y      �� 5c      #��[  5f      ��5d      �� *CloseCommand+��5e      �� $ titleBar����5g        5h      $��15��5i      $��15��5j      
�������$ Close=�5l      5n      5o      5p      5q      