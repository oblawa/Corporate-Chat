   M S B A M L   `   `   `  ����H  DCorporateChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CorporateChatCorporateChat  5   	   -clr-namespace:CorporateChatCorporateChat  5   	   A%clr-namespace:CorporateChat.ViewModelCorporateChat.ViewModel  5   	   &     CorporateChat.RegistrationWindow   5   	   Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5CorporateChatclr-namespace:CorporateChat     5   	   -localclr-namespace:CorporateChat     5   	   ;	viewmodel%clr-namespace:CorporateChat.ViewModel     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	   	     � Title$  Регистрация��5   	   $	��550��5   	   $	��450��5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�6+    � WindowStyle$
 None=�6P    � Icon$ /View/Icons/logo.png��6c   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *ConnectToServerCommand+5      	 � 	Resources	 5         FocusVisual
 �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundedButtonKey �� 
TargetType �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%b  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5   
   .�5      �� 
 � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5    
   $ 	#FF707070��67   �� 5!   
   $ 	#FFBEE6FD��6>   �� 5"   
   $ 	#FF3C7FB1��6:   �� 5#   
   $ 	#FFC4E5F6��6<   �� 5$   
   $ 	#FF2C628B��68   �� 5%   
   $ 	#FFF4F4F4��6=   �� 5&   
   $ 	#FFADB2B5��69   �� 5'   
   $ 	#FF838383��6=   �� 5(   
   " ��6)   .�5)      �� 
 �@�FocusVisualStyle8   61   �� 5*      
 � ��8  6+   �� 5+      
 � ��8  6,   �� 5,      
 � ��# � ��6+   �� 5-      
 � ��$ 0q�60   �� 5.      
 � ��$ Center=�6;   �� 5/      
 � ��$ Center=�69   �� 50      
 � ��$ 1q�6(   �� 51      
 � �� 52      �� 53      " ��6&   .R�54      �� $ border��6!   $ 11��61   #��z��6C   #��z��6m   #��z��6�    . ._�55      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  56       57      P� 58       �@��IsDefaulted . . �59   "   �� $ border��6@   # � ��6T   
 � ��5:      P� 5;       �@J�IsMouseOver . . �5<   "   �� $ border��6?   
 � �� �#746FAE6S   �� 5=   "   $ border��6@   
 � �� �#746FAE6T   5>      P� 5?       � �� . . �5@   "   �� $ border��6?   
 � �� �#8D89B56S   �� 5A   "   $ border��6@   
 � �� �#8D89B56T   5B      P� 5C       � {� .  . �5D   "   �� $ border��6?   8  
 � ��6S   �� 5E   "   $ border��6@   8  
 � ��6T   �� 5F   "   $ contentPresenter��6K   8  
 � ��6i   5G      5I      5K      5L      5N       � DataContext 5O      *  $CorporateChat.ViewModel.RegViewModel  5P   
   .��5R      � $	��450��6   ���#B89C99$	��550��60   $	��450��6=    � RowDefinitions 5S   
   �� 5T      $��20 �6   �� 5U      $	��530 �6   .+�5W   
   ��  �� Orientation$ 
Horizontal=�6   $��Right=�6.   .+�5X      �� -   5         ��Name$ buttonMinimize��5X   B   $��0q�6   
������ .��5Y      �� -   5         ��Name$ imageMinimize��5Y      $+��%Icons/window_minimize_icon_194428.png��6/   $��13��6^   6l   5Z      �� 5[      -   5        $ 
buttonExit��5[   B   $��0q�6   
������ .��5\      �� -   5        $ 	imageExit��5\      $'��!Icons/close_cross_icon_128690.png��6-   6Z   5]      5^      �� 5_   
   $��2��6   $	��NaN��6&   .+�5`      �� $&�� Добро пожаловать!��6    �� TextAlignment$ Center=�61   $��26(�6H   $��1��6V   $��	0,40,0,23q�6c   $	��NaN��6v   $	��NaN��6�   6�   �� 5a      $	��326��6R   $��37��6^   $��0 0 0 13q�6j     NameBox#��[ 6|   ��6   �� *name+ �� UpdateSourceTrigger$ PropertyChanged=�6|   �� 5b      $	��326��6U   $��37��6a   $��0 0 0 13q�6m     
SurnameBox#��[ 6   ��6   �� *	surname+$ PropertyChanged=�6   �� 5c      -   5         ��Name$ loginTb��5c      $	��326��6f   $��37��6r   $��0 0 0 13q�6~     	LoginBox1#��[ 6�   ��6'   �� *
username+$ PropertyChanged=�6�   G� 5d      -   5          G�Name$  
passwordTb��5d      $	��326��6R   $��37��6^   $��0 0 0 13q�6j     PasswordBox1#��[ 6|   G� 5e      $	��326��6   $��37��6'   $��0 0 0 13q�63     PasswordBox2#��[ 6E   �� 5f      $	��326��6Q   $��37��6]   $��0 0 0 13q�6i     MailTextbox#��[ 6{   ��6   �� *mail+$ PropertyChanged=�6{   �� 5g      $	��326��6Q   $��37��6]   $��0 0 0 30q�6i     PostBox#��[ 6{   ��6   �� *post+$ PropertyChanged=�6{   �� 5h      -   5        $ buttonRegister��5h      #��� 
 6]   ���#655FA6
�������$��Регистрация��6�   $	��149��6�   $��34��6�   $��19(�6�   $��0 0 0 10q�6�   ��6-   �� *SendRegistrationDataCommand+6�   5l      5n      5o      