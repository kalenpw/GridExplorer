   M S B A M L   `   `   `  ����G  CDeliverable6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Deliverable6Deliverable6  5   	       Deliverable6.frmMonster   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Deliverable6     5   	   -   5          � Title$  
A monster!��5   	   $��343.948��6   $	��331��6-   .��5
      �  � RowDefinitions 5   
   �� 5      $
��241* �6   �� 5      $	��30* �6   .+�5   
   �� -   5         ��Name$ 	btnAttack��5      $��Attack��6$   $��0,0.333,146.333,-0.333q�65   $	��Top=�6U   $��30��6m   $��1��6�   �� 5   
   -   5        $ 
btnRunAway��5      $��Run away��6%   $��
161,0,-1,0q�68   $	��Top=�6L   $��30��6d   $��1��6�   �� 5   
   ���	#FF04AFFF$
��Left=�6%   $	��269��6@   
���   �$	��Top=�6\   $	��162��6t    J� Opacity$	 0.5Q�6�   $��
161,0,-1,0q�6�   �� 5   
   ���	#FFFF1616$
��Left=�6%   $	��269��6@   
���   �$	��Top=�6\   $	��162��6t   $	 0.5Q�6�   �� 5   
   -   5         ��Name$ 
lblMonster��5      $��Monster��6$   $
��Left=�66   $��10,0,0,0q�6Q   $	��Top=�6c   $	��131��6{   �� 5   
   -   5        $ lblHero��5      $��Player��6!   $
��Left=�62   $��	158,0,0,0q�6M   $	��Top=�6`   $��54��6x   �� 5   
   -   5         ��Name$ tbMonsterDisplay��5      $
��Left=�6.   $��	10,31,0,0q�6I   $
��Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��205��6�   $	��131��6�   �� 5   
   -   5        $ tbPlayerDisplay��5      $
��Left=�6-   $��
182,31,0,0q�6H   $
��Wrap=�6\   $�� ��6p   $	��Top=�6x   $	��205��6�   $	��131��6�   �� 5   
   -   5        $ lblDisplayMessage��5      $E��?You encountered a monster.           What would you like to do?��6+   $
��Left=�6u   $��0,241,-14,0q�6�   $	��Top=�6�   $	��337��6�   $��11(�6�   5      5      