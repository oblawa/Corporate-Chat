   M S B A M L   `   `   `  ����H  DCorporateChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CorporateChatCorporateChat  5   	   A%clr-namespace:CorporateChat.ViewModelCorporateChat.ViewModel  5   	   '    !CorporateChat.AuthotizationWindow   5   	   Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CorporateChat     5   	   ;	viewmodel%clr-namespace:CorporateChat.ViewModel     5   	   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5   	     � Title$  Авторизация��5
   	   $	��292��5   	   $	��418��5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�6+    � WindowStyle$
 None=�6P    � Icon$ /View/Icons/logo.png��6c   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ Loaded��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *ConnectToServerCommand+5      	 � 	Resources	 5         FocusVisual
 �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 RoundedButtonKey �� 
TargetType �� 
TargetType ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%b  &	        &	 �     &	 �     &	 �     &	     &	 6    &	 Y    &	 |    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5   
   .�5      �� 
 � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E    . $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5    
   $ 	#FF3C7FB1��6:   �� 5!   
   $ 	#FFC4E5F6��6<   �� 5"   
   $ 	#FF2C628B��68   �� 5#   
   $ 	#FFF4F4F4��6=   �� 5$   
   $ 	#FFADB2B5��69   �� 5%   
   $ 	#FF838383��6=   �� 5&   
   " ��6)   .�5'      �� 
 �@�FocusVisualStyle8   61   �� 5(      
 � ��8  6+   �� 5)      
 � ��8  6,   �� 5*      
 � ��# � ��6+   �� 5+      
 � ��$ 0q�60   �� 5,      
 � ��$ Center=�6;   �� 5-      
 � ��$ Center=�69   �� 5.      
 � ��$ 1q�6(   �� 5/      
 � �� 50      �� 51      " ��6&   .R�52      �� $ border��6!   $ 11��61   #��z��6C   #��z��6m   #��z��6�    . ._�53      �� $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  54       55      P� 56       �@��IsDefaulted . . �57   "   �� $ border��6@   # � ��6T   
 � ��58      P� 59       �@J�IsMouseOver . . �5:   "   �� $ border��6?   
 � �� �#746FAE6S   �� 5;   "   $ border��6@   
 � �� �#746FAE6T   5<      P� 5=       � �� . . �5>   "   �� $ border��6?   
 � �� �#8D89B56S   �� 5?   "   $ border��6@   
 � �� �#8D89B56T   5@      P� 5A       � {� .  . �5B   "   �� $ border��6?   8  
 � ��6S   �� 5C   "   $ border��6@   8  
 � ��6T   �� 5D   "   $ contentPresenter��6K   8  
 � ��6i   5E      5G      5I      5J      5K       � DataContext 5L      +  %CorporateChat.ViewModel.AuthViewModel  5M   
   .��5O      � ���#B89C99$	��292��6!   $	��418��6.    � RowDefinitions 5P   
   �� 5Q      $��20 �6   �� 5R      $	��272 �6   .+�5T   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5U      �� -   5         ��Name$ buttonMinimize��5U   B   $��0q�6   
������ .��5V      �� -   5         ��Name$ imageMinimize��5V      $+��%Icons/window_minimize_icon_194428.png��6/   $��13��6^   6l   5X      �� 5Y      -   5        $ 
buttonExit��5Y   B   $��0q�6   
������ .��5Z      �� -   5        $ 	imageExit��5Z      $'��!Icons/close_cross_icon_128690.png��6-   6Z   5[      5\      �� 5]   
   $��0��6   $	��NaN��6"   $��2��6/   $	��NaN��6@   .+�5^      �� $��Авторизация��6    �� TextAlignment$ Center=�6+   $��26(�6B   $��1��6P   $��	0,36,0,26q�6]   $	��NaN��6p   $	��NaN��6}   6�   �� 5_      -   5         ��Name$ loginTb��5_      $	��326��6f   $��37��6r   $��0 0 0 13q�6~     	LoginBox1#��[ 6�   ��6'   �� *
username+ �� UpdateSourceTrigger$ PropertyChanged=�6�   G� 5b      -   5          G�Name$  
passwordTb��5b      $	��326��6R   $��37��6^   $��0 0 0 26q�6j     PasswordBox1#��[ 6|   �� 5d      -   5        $ buttonLogIn��5d   h   #��� 
 6   ���#655FA6
�������$��
Войти��6�   $	��118��6�   $��34��6�   $��19(�6�   $��0 0 0 8q�6�   ��6@   �� *SendAuthDataCommand+6�   �� 5e      -   5        $ buttonFirstTime��5e   g     TransparentText#��[ 6   $��0q�6�   $	��105��6�   $��30��6�   
������ $��0q�6�   ��6>   �� *OpenRegWindowCommand+.��6�   �� $��WrapWithOverflow=�6�   $��0q�6�   $��13(�6	  6  5g      5i      5j      