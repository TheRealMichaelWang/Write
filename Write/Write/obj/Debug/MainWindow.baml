   M S B A M L   `   `   `  ����@  <Write, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WriteWrite  5   	       Write.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Write     5   	   -   5          �Name$  Write_MainWindow��5   	    � Title$ Write��5   	   $	��350��6   $��704.85��6$   .��5	      � -   5        $��MainGrid��5	      .+�5
   
   �� -   5         ��Name$
 Text��5
      $
��Left=�6$   $	��260��6?   $	��Top=�6L   $	��700��6d   $��0,85,0,-22.2q�6p    �� 
AcceptsTab . . �5      /� .T�5      J� 5      5      �� 5   
   -   5         ��Name$ 
FileButton��5      $
��File��6%   $
��Left=�64   $	��Top=�6O   $��95��6g   $��85��6r   
����  �
�������6�   �� 5   
   -   5         ��Name$ 
tabControl��5      $
��Left=�6)   $��85��6D   $��95,0,0,0q�6P   $	��Top=�6b   $	��605��6z   ��. .@�5      �� -   5         ��Name$
 Home��5      $
��Bold"�6$   
 � Tag$
 Home��66   $
��Home��6A   .��5      � -   5        $��HomeGrid��5      .+�5      �� -   5         ��Name$ FontNameInput��5      $
��Left=�66   $��20��6Q   $	��Top=�6]   $	��140��6u   �� 5      -	   5        $ FontSizeInput��5      $
��Left=�66   $��	140,0,0,0q�6Q   $	��Top=�6d   $��50��6|   $��20��6�   �� 5      -
   5        $ 
BoldButton��5      $
��Bold��61   $��0,25,0,-0.2q�6@   $��50��6U   $
��Left=�6`   6{   �� 5      -   5        $ ItalicsButton��5      $��	Italilics��64   $��55,25,0,-0.2q�6H   $��50��6^   $
��Left=�6i   6�   �� 5      -   5        $ UnderLineButton��5      $��	UnderLine��66   $��66��6J   $
��Left=�6U   $��110,25,0,-0.2q�6p   6�   �� 5      -   5        $ LineHeightInput��5      $
��Left=�68   $	��Top=�6S   $	��130��6k   $��20��6w   $��	190,0,0,0q�6�   �� 5      -   5        $ AlignmentInput��5      $��190,26,0,8.8q�67   $
��Left=�6r   $	��130��6�   5      5      �� 5      -   5        $ 
SpellCheck��5      $��
SpellCheck��6*   .��5      � -   5        	 �Name$	 SpellCheckGrid��5      .+�5      �� -   5        $ SpellCheckButton��5      $��
SpellCheck��67   $
��Left=�6L   $	��Top=�6g   $��75��6   6�   �� 5      -   5        $ DictionaryInput��5      $
��Left=�68   $��80,0,0,0q�6S   $	��Top=�6e   $	��147��6}   �� 5       -   5        
 ��Name$
 SpellCheckOutput��5        �� TextWrapping$
 Wrap=�68   $1��+Press spell check to detect spelling errors��6L   $��2,22,-0.2,-0.2q�6   �� 5!      -   5        $ AddToDictionary��5!      $��AddToDictionary��66   $
��Left=�6P   $	��Top=�6k   $	��127��6�   $��	232,0,0,0q�6�   $��Center=�6�   5"      5#      �� 5$      -   5        $ VocablularyTab��5$      $��
Vocabulary��6.   .��5%      � -   5        $	 VocabularyGrid��5%      .+�5&      �� -   5        $ DoVocabularyButton��5&      $��DoVocab��69   $
��Left=�6K   $	��Top=�6f   $��75��6~   $��1,2,0,0q�6�   �� 5'      -   5        $ VocabBookSelection��5'      $��81,0,397.8,34.8q�6;   6T   5(      5)      5*      5+      5,      