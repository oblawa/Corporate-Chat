   M S B A M L   `   `   `  ����H  DCorporateChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CorporateChat.ViewCorporateChat.View  5   	   A%clr-namespace:CorporateChat.ViewModelCorporateChat.ViewModel  5   	   &     CorporateChat.View.NewChatDialog   5   	   Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:CorporateChat.View     5   	   4vm%clr-namespace:CorporateChat.ViewModel     5   	     � Title$  NewMessageDialog��5	   	   $	��450��6"   $	��450��6/    � WindowStyle$
 None=�6;    � 	Resources 5
         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundedButtonKey �� 
TargetType	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6)   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5        � ��8  6,   �� 5!       � ��# � ��6+   �� 5"       � ��$ 0q�60   �� 5#       � ��$ Center=�6;   �� 5$       � ��$ Center=�69   �� 5%       � ��$ 1q�6(   �� 5&       � ��$	 100��6&   �� 5'       � ��$ 20(�6)   �� 5(       � ��$ 5q�6'   �� 5)       � �� 5*      �� 5+      "	 ��6&   .R�5,      �� $
 border��6!   $ 11��61   #��z��6C   #��z��6m   #��z��6�    . ._�5-      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5.       5/      P� 50       �@��IsDefaulted . . �51   "   �� $ border��6@   # � ��6T    � ��52      P� 53       �@J�IsMouseOver . . �54   "   �� $ border��6?    � �� �#746FAE6S   �� 55   "   $ border��6@    � �� �#746FAE6T   56      P� 57       � �� . . �58   "   �� $ border��6?    � �� �#8D89B56S   �� 59   "   $ border��6@    � �� �#8D89B56T   5:      P� 5;       � {� .  . �5<   "   �� $ border��6?   8   � ��6S   �� 5=   "   $ border��6@   8   � ��6T   �� 5>   "   $ contentPresenter��6K   8   � ��6i   5?      5A      5C      5D      5F      .��5G      � ���#B89C99.+�5H   
   �� $��1q�6   
���   �._�5I      �� .+�5J      ��  �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�5L      �� -   5         ��Name$ 
buttonExit��5L   Z   $��0q�6    �� IsCancel . 
������ .��5M      �� -   5         ��Name$ 	imageExit��5M   !   $'��!Icons/close_cross_icon_128690.png��65   $��18��6`   6n   5N      5O      �� 5P      $��Новый чат��6   $��25(�6-   $��Center=�6;   $��	0 10 0 10q�6X   �� 5R      $	��326��6Y   $��37��6e   $��0 0 0 13q�6q     
NewChatBox#��[ 6�   ��6   �� *
chatName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5S      $��Участники:��6   $��16(�6.   $��20 0 0 0q�6<   �� 5T      -   5         �� SelectionMode$ Multiple=�5T   `   ��6   �� *
AllUsers+��5U      �� 5V      " ��6    .�5W      ��  � ��$ 0q�6@   �� 5X       � ��$ 10q�67   �� 5Y       � �� 5Z   "   �� 5[   &   "	 ��66   .R�5\   *   �� $
 border��6E   $��0q�61   ._�5]   .   �� $ 
Horizontal=�69   $
��Left=�6R   .+�5^   2   �� $��Icons/user.png��68   $��15��6P   $��15��6[   $��5 0 5 5q�6g   6z   �� 5_   2   ��6<   �� *Name+�� 5`   2   $�� ��6<   �� 5a   2   ��6<   �� *	Surname+5b   /   5c   +    5d   *   P� 5e   .    �@��
IsSelected . . �5f   2   �� $ border��69    � ��
 ��ح�6c   5g   /   5i   '   5k      5l      5n      �� 5o      $ 
Horizontal=�6   $��Center=�66   .+�5p      �� $��Создать��6   #��� 
 6X    �� 	IsDefault . ��6/   �� *CreateNewChatCommand+6�   �� 5q      $��Отмена��6    . #��� 
 6>   6k   5r      5t      5u      5v      5w      