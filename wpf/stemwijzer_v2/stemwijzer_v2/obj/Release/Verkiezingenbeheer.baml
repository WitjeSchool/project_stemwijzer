   M S B A M L   `   `   `  ���� H  Dstemwijzer_v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:stemwijzer_v2stemwijzer_v2  C&clr-namespace:stemwijzer_v2.Convertersstemwijzer_v2.Converters  &     stemwijzer_v2.Verkiezingenbeheer   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;controls,http://metro.mahapps.com/winfx/xaml/controls  :d2http://schemas.microsoft.com/expression/blend/2008  'localclr-namespace:stemwijzer_v2  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  /vc&clr-namespace:stemwijzer_v2.Converters    � Title$  Verkiezingen beheer��$
��1100��$	��450��$
��1100��$	��450�����#2B2D42 � Icon$ /afbeeldingen/logo.png�� � 	Resources 9  3stemwijzer_v2.Converters.ListboxItemLengthConverter   listboxLength�� %   &	          .���  � ColumnDefinitions �� $
��7.5* ��� $
��2.5* � � RowDefinitions �� $
��1.5* ��� $
��8.5* �.+��� -    ��Name$ 
cmb_pagina��$��0��$��1��$��23��$��
35,0,35,10q�$��Center=� �� SelectedIndex$ 2����Z� .@��� -    ��Name$ cmbi_gb��.��Gebruikersbeheer�� -   $ cmbi_pb��.��Partijenbeheer�� -   $ cmbi_vb��.��Verkiezingenbeheer�� -   $ cmbi_vkb��.��Vragenbeheer�� -   $ cmbi_pmb��.��PartijMeningenbeheer�� .��	Uitloggen�� -    ��Name$ btn_toevoegen��$	��100��$��30��$��10q�$
��Left=�$��Center=���Z� .��	Toevoegen�� -   	 ��Name$	 zoekbalk��$��0��$��0��$��30��$��175,0,125,0q�$��Center=�$��Center=�*  $MahApps.Metro.Controls.TextBoxHelper
   	Watermark$
 Zoekveld....��$��18(��� -	    ��Name$ lb_verkiezingen��$��1��$��0��
������ 
������   �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� SnapsToDevicePixels �� ContentStringFormat �� ContentStringFormat �� Triggers ]� 
Conditions �� Property �� Value �� 
TargetName P� Property P� Value C� ResourceKey��%�  '��       �� " ��.���  � �� �� " ��.R��� $��Bd��# z��#��z��#��z��#��z�� . ._��� #��z��#��z��#��z��# z #��z��# z  ]�  ��  �@��IsSelectionActive .  ��  �@��
IsSelected . ./��� $ Bd�� � ��
 ���� �� $ Bd�� � �� ��	#FFDADADA����  � ��
 �����]�  ��  �@��IsSelectionActive . ��  �@��
IsSelected . ./��� $ Bd�� � �� �#2B2D42�� $ Bd�� � �� ��	black����  � ��
 �����P�  �@J�IsMouseOver . . ��� $ Bd�� � ��
 ��İ��� $ Bd�� � �� ��	#A826A0DA��P�  � {� .  . ��� $ Bd�� � �� C� # Z���� $��1��$��1��.+��� $��Center=�$��25(�$
��Bold"�
�������
Filters:�� $��0,10,0,0q�$��Center=�$��15(�$
��Bold"�
�������titel:�� -
   $ filter_titel��$��	35,0,35,0q�$��Center=�$ 0����Z� .@��� .��Geen filter�� .��A-Z�� .��Z-A�� $��0,10,0,0q�$��Center=�$��15(�$
��Bold"�
�������	datums:�� -   $ filter_datum��$��	35,0,35,0q�$��Center=�$ 0����Z� .@��� .��Geen filter�� .��start eerst/laatst�� .��start laatst/eerst�� .��eind eerst/laatst�� .��eind laatst/eerst�� $��1��$��1��$��Bottom=�.+��� -   $ btn_aanpassen��$��40��$��	35,0,35,0q�$��Center=�$��20(���Z� .��	Aanpassen�� -   $ btn_verwijderen��$��40��$��35,20,35,20q�$��Center=�$��20(���Z� .��Verwijderen