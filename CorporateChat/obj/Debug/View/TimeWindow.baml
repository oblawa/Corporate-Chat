   M S B A M L   `   `   `  ����H  DCorporateChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CorporateChat.ViewCorporateChat.View  5   	   #    CorporateChat.View.TimeWindow   5   	   Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CorporateChat.View     5   	     � Title$  
TimeWindow��5   	   $	��200��6   $	��300��6)    � 	Resources 5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundedButtonKey �� 
TargetType �� 
TargetType	 ��Name
 �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6)   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 0q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � ��$	 120��6&   �� 5&       � ��$ 20(�6)   �� 5'       � ��$ 5q�6'   �� 5(       � �� 5)      �� 5*      " ��6&   .R�5+      �� $	 border��6!   $
 11��61   #��z��6C   #��z��6m   #��z��6�    . ._�5,      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5-       5.      P� 5/       �@��IsDefaulted . . �50   "   �� $ border��6@   # � ��6T    � ��51      P� 52       �@J�IsMouseOver . . �53   "   �� $ border��6?    � �� �#746FAE6S   �� 54   "   $ border��6@    � �� �#746FAE6T   55      P� 56       � �� . . �57   "   �� $ border��6?    � �� �#8D89B56S   �� 58   "   $ border��6@    � �� �#8D89B56T   59      P� 5:       � {� .  . �5;   "   �� $ border��6?   8   � ��6S   �� 5<   "   $ border��6@   8   � ��6T   �� 5=   "   $ contentPresenter��6K   8   � ��6i   5>      5@      5B      5C      5E      .��5F      � ���#B89C99.+�5G   
   ��  �� Orientation$ Vertical=�6   $��Center=�6,   .+�5H      �� $ ��Выбрать время:��6   $��20(�6.   �� 5I      $	��250��6   ��6#   �� *destroyTime+.@�5J      �� $��1��6   �� 5K      $��2��6   �� 5L      $��3��6   �� 5M      $��4��6   �� 5N      $��5��6   5O      �� 5P      $ 
Horizontal=�6   $��Center=�62   .+�5Q      �� $��Готово��6   #��� 
 6>    �� 	IsDefault . ��6*   �� 6|   �� 5R      $��Отмена��6    �� IsCancel . #��� 
 6:   6g   5S      5T      5U      5V      