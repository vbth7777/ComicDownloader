   M S B A M L   `   `   `  ����J  FComicDownloader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MVVM.View	MVVM.View  5      %clr-namespace:MVVM.View	MVVM.View  5           MVVM.View.NotifyYesNoWView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:MVVM.View     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      (viewclr-namespace:MVVM.View     5      -   5          �Name$  notification��5	       � Title$ NotifyOKWView��5
      $	��300��5      $	��200��5       � AllowsTransparency$
 True��5      ���#363635
������� � 
ResizeMode$ CanMinimize=�5       � WindowStartupLocation$ CenterOwner=�5       � WindowStyle$
 None=�5      .��5      �� 
�������$��1q�6!   ._�5   
   �  � RowDefinitions 5      �� 5      $��30 �6    �� 5      �� 5      $��50 �6    .+�5      (   "MVVM.View.SuperMinimalTitleBarView  
 � Tag$ Notification��6,   �� 5      $��1��5      $��10q�5      $��Center=�5      $��20(�5       $��Light"�5!       �� TextAlignment$ Center=�5#      $
��Wrap=�5$      ��5"      �� *DisplayText+5$      �� 5%      $��2��5&      $��Center=�5'      $��Center=�5(      	 �� Orientation$	 
Horizontal=�5)      .+�5*      �� $	��100��5+      $	��Yes��5.      $��20(�5/         ModernButtonTheme#��[  50      ��5,      �� *
YesCommand+��5-      �� 
 �� ElementName$
 notification��50      �� 51      $	��100��52      $��40,0,0,0q�53      $��No��56      $��20(�57      #��[  58      ��54      �� *	NoCommand+��55      �� $
 notification��58      59      5:      5<      5=      