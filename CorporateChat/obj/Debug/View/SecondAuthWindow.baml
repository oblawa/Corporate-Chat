   M S B A M L   `   `   `  ����H  DCorporateChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CorporateChat.ViewCorporateChat.View  5   	   A%clr-namespace:CorporateChat.ViewModelCorporateChat.ViewModel  5   	   )    #CorporateChat.View.SecondAuthWindow   5   	   Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CorporateChat.View     5   	   4vm%clr-namespace:CorporateChat.ViewModel     5   	     � Title$  SecondAuthWindow��5	   	   $	��200��6"   $	��400��6/    � Icon$ /View/Icons/logo.png��6;    � WindowStyle$
 None=�6W    � 	Resources 5
         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundedButtonKey	 �� 
TargetType
 �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   "	 ��6)   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 0q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � ��$ 16(�6)   �� 5'       � ��$	 150��6&   �� 5(       � ��$ 30��6'   �� 5)       � �� 5*      �� 5+      "
 ��6&   .R�5,      �� $ border��6!   $ 11��61   #��z��6C   #��z��6m   #��z��6�    . ._�5-      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5.       5/      P� 50       �@��IsDefaulted . . �51   "   �� $ border��6@   # � ��6T    � ��52      P� 53       �@J�IsMouseOver . . �54   "   �� $ border��6?    � �� �#746FAE6S   �� 55   "   $ border��6@    � �� �#746FAE6T   56      P� 57       � �� . . �58   "   �� $ border��6?    � �� �#8D89B56S   �� 59   "   $ border��6@    � �� �#8D89B56T   5:      P� 5;       � {� .  . �5<   "   �� $ border��6?   8   � ��6S   �� 5=   "   $ border��6@   8   � ��6T   �� 5>   "   $ contentPresenter��6K   8   � ��6i   5?      5A      5C      5D      5E      .��5F      � ���#B89C99.+�5G   
   ��  �� Orientation$ Vertical=�6   .+�5H      �� $��0��6   $ 
Horizontal=�6&   $��Right=�6?   .+�5I      �� -   5         ��Name$ buttonMinimize��5I   F   $��0q�6   
������ .��5J      �� -   5         ��Name$ imageMinimize��5J      $+��%Icons/window_minimize_icon_194428.png��63   $��13��6b   6p   5L      �� 5M      -   5        $ 
buttonExit��5M   F   $��0q�6   
������ .��5N      �� -   5        $ 	imageExit��5N      $'��!Icons/close_cross_icon_128690.png��61   $��18��6\   6j   5O      5P      �� 5Q      $ Vertical=�6   $��Center=�60   $��0 10 0 0q�6K   .+�5R      �� $O��IМы отправили вам на почту письмо с кодом��6   $��16(�6L   $��Center=�6Z   $��10 10 10 15q�6w   $
��Bold"�6�   �� 5S       
 OTPBox#���  6/   ��6   �� *OTP+6R   �� 5T      $��Подтвердить��6   #��� 
 6R   $��25q�6}   ��6/   �� *SendOtpCommand+6�   5U      5W      5X      5Y      