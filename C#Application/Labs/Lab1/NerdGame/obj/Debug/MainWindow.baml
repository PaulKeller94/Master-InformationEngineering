   M S B A M L   `   `   `  ����C  ?NerdGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:NerdGameNerdGame  5   	       NerdGame.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:NerdGame     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   d� -   5         d�Name$ 
NewGameBtn��5
      $��50��6,   $	��150��68   $��New Game��6D   $��14(�6W   $��Medium"�6e   $	��Top=�6y   $��Right=�6�   $��	0,49,25,0q�6�   6�   �� 5   
   $��
0,119,30,0q�6   $��Right=�6)   $	��Top=�6E   .+�5      	� -   5         	�Name$ NormalTimer��5      $��14(�6/   $
��Bold"�6=   $��7q�6O    d� 	IsChecked$
 TrueY�6Z   .��6�   NormalTimer6�   	� 5      -   5        $ FastedTimer��5      $��14(�6/   $
��Bold"�6=   $��7q�6O   $ FalseY�6Z   .��6�   FastedTimer6�   5      �� 5   
   -   5         ��Name$
 Time��5      $
��10 s��6   $��24(�6.   $��Medium"�6<   $��365,169,305,160q�6P   $��Center=�6i   $��Center=�6�   �� 5   
   -   5        $ RandomNumber��5      $
��0x00��6'   $	��100��66   $	��100��6B   $��24(�6O   $��Medium"�6]   $��Right=�6r   $��0,219,65,115q�6�   $��Center=�6�   $��Center=�6�   6�   �� 5   
   -   5        $ GameStateLabel��5      $��Ready for new Game!��6(   $��24(�6F   $��Medium"�6T   $��Center=�6h   $��Center=�6�   $
��Left=�6�   $��50q�6�   $	��Top=�6�   6�   �� 5   
   $��50q�6   $
��Left=�6!   $��Center=�6<   .+�5      	� -   5        $	 Hex��5      $��14(�6'   $
��Bold"�65   $��7q�6G   $
 TrueY�6R   .��6|   Hex6�   	� 5      -   5        $ Decimal��5      $��14(�6+   $
��Bold"�69   $��7q�6K   $ FalseY�6V   .��6�   	Decimal6�   5      %   NerdGame.UserControlBianryInput  5   
   -	   5          Name$
 Data��5   '   %   NerdGame.UserControlBianryInput   changeValue$( "UserControlBianryInput_changeValue��6�      DataByte$ 23��65   $��42��6C   $	��Top=�6O   $��106,311,0,0q�6g   $
��Left=�6|   $	��642��6�   6�   5      5      