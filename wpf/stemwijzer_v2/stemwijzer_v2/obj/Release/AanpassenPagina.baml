   M S B A M L   `   `   `  ���� H  Dstemwijzer_v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:stemwijzer_v2stemwijzer_v2  #    stemwijzer_v2.AanpassenPagina   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;controls,http://metro.mahapps.com/winfx/xaml/controls  :d2http://schemas.microsoft.com/expression/blend/2008  'localclr-namespace:stemwijzer_v2  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � Title$  	Aanpassen��$	��800��$	��350��$	��800��$	��350��$	��800��$	��350�����#2B2D42 � Icon$ /afbeeldingen/logo.png�� � WindowStartupLocation$ CenterScreen=�.��� .+�� -    �Name$ grid_vragen��$y�	Collapsed=�.+��� $��0,50,0,0q�$��Center=�$	��Top=� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ tb_vragen_id��$	��100��$��25��$��0,0,0,0q�$	��Top=�$��Center=�*  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Id...��$��12(�{�.  �� -    ��Name$ cmb_vragen_verkiezing��$	��200��$��25��$��20,0,0,0q�$	��Top=�$ Verkiezing...��$��12(��� -   $ tb_vragen_vraag��$	��400��$��80��$��20,0,0,0q�$	��Top=�$ Vraag...��$��12(� �� TextWrapping$
 Wrap=��� -   	 ��Name$	 btn_vragen_aanpassen��$	��150��$��40��$��Right=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Voltooien�� -   $	 btn_vragen_annuleren��$	��150��$��40��$
��Left=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Annuleren� -   $ grid_verkiezingen��$y�	Collapsed=�.+��� $��0,50,0,0q�$��Center=�$	��Top=�$ 
Horizontal=�.+��� .+��� $ 
Horizontal=�.+��� -   $ tb_verkiezingen_id��$	��100��$��25��$��0,0,0,0q�$	��Top=�$��Center=�$ Id...��$��12(�{�.  �� -	   $  tb_verkiezingen_verkiezing��$	��250��$��25��$��20,0,0,0q�$	��Top=�$ Verkiezing naam...��$��12(��� $ 
Horizontal=�.+�+  %MahApps.Metro.Controls.DateTimePicker  -
   
  Name$!
 dtp_verkiezingen_startDatum��$	��175��$��25��$��0,10,0,0q�$	��Top=�$��Center=�$ Start datum...��$��12(�  -   $ 
 dtp_verkiezingen_eindDatum��$	��175��$��25��$��	20,10,0,0q�$	��Top=�$ Eind datum...��$��12(��� -   $" tb_verkiezingen_beschrijving��$	��300��$	��150��$��20,0,0,0q�$	��Top=�$ Beschrijving...��$��12(�$
 Wrap=�" �� VerticalScrollBarVisibility$ Visible=��� -   $ 	 btn_verkiezingen_aanpassen��$	��150��$��40��$��Right=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Voltooien�� -   $ 	 btn_verkiezingen_annuleren��$	��150��$��40��$
��Left=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Annuleren� -   $ grid_partijen��$y�	Collapsed=�.+��� $��0,50,0,0q�$��Center=�$	��Top=�$ 
Horizontal=�.+��� .+��� $ 
Horizontal=�.+��� -   $ tb_partijen_id��$	��100��$��25��$��0,0,0,0q�$	��Top=�$��Center=�$ Id...��$��12(�{�.  �� -   $ tb_partijen_partij��$	��200��$��25��$��20,0,0,0q�$	��Top=�$ Partij naam...��$��12(��� $ 
Horizontal=�.+��� -   $ tb_partijen_contact��$	��320��$��37��$��0,10,0,0q�$	��Top=�$	��Top=�$ 
contact...��$��12(�$ �� HorizontalScrollBarVisibility$ Visible=��� -   $ cmb_partijen_logo��$	��300��$	��140��$��20,0,0,0q�$	��Top=�$��Center=�$	��Top=�$ Logo...��$��30(��� $��5,0,0,0q�.+��� -   $	 btn_logo_toevoegen��
��� � �$��10(���Z� .��	toevoegen�� -   $	 btn_logo_verwijderen��$��	0,106,0,0q�
���  ��$��10(���Z� .��verwijderen�� -   $	 btn_partijen_aanpassen��$	��150��$��40��$��Right=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Voltooien�� -   $	 btn_partijen_annuleren��$	��150��$��40��$
��Left=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Annuleren� -   $ 
grid_users��$y�	Collapsed=�.+��� $��0,50,0,0q�$��Center=�$	��Top=�.+��� $ 
Horizontal=�.+��� .+��� $��0,0,0,0q�
�������Id:�� -   $ tb_users_id��$	��100��$��25��$��0,5,0,0q�$	��Top=�$��Center=�$ Id...��$��12(�{�.  �� .+��� $��20,0,0,0q�
�������Gebruikersnaam:�� -   $ tb_users_gebruikersnaam��$	��200��$��25��$��20,5,0,0q�$	��Top=�$ gebruikersnaam...��$��12(��� .+��� $��20,0,0,0q�
�������Email:�� -   $ tb_users_email��$	��200��$��25��$��20,5,0,0q�$	��Top=�$ email...��$��12(��� .+��� $��20,0,0,0q�
�������Wachtwoord:�� -   $ tb_users_wachtwoord��$	��200��$��25��$��20,5,0,0q�$	��Top=�$ wachtwoord...��$��12(��� $��0,20,0,0q�$ 
Horizontal=�.+��� .+��� $��0,0,0,0q�
�������Machtiging:�� -   $ cmb_users_machtiging��$	��174��$��25��$��0,5,0,0q�$	��Top=�$��Center=�$ Machtiging...��$��12(��� .+��� $��20,0,0,0q�
�������Geboorte datum:  -   $
 dtp_users_geboorteDatum��$	��175��$��25��$��20,5,0,0q�$	��Top=�$��Center=�$ geboorte datum...��$��12(��� .+��� $��20,0,0,0q�
�������Account bijgewerkt datum:  -   $
 dtp_users_bijgewerktDatum��$	��175��$��25��$��20,5,0,0q�$	��Top=�$��Center=�$ bijgewerkt datum...��$��12(�{�.  �� .+��� $��20,0,0,0q�
�������Account gemaakt datum:  -    $
 dtp_users_gemaaktDatum��$	��175��$��25��$��20,5,0,0q�$	��Top=�$��Center=�$ gemaakt datum...��$��12(�{�.  �� -!   $	 btn_users_aanpassen��$	��150��$��40��$��Right=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Voltooien�� -"   $	 btn_users_annuleren��$	��150��$��40��$
��Left=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Annuleren