   M S B A M L   `   `   `  ���� H  Dstemwijzer_v2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:stemwijzer_v2stemwijzer_v2  !    stemwijzer_v2.toevoegPagina   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;controls,http://metro.mahapps.com/winfx/xaml/controls  :d2http://schemas.microsoft.com/expression/blend/2008  'localclr-namespace:stemwijzer_v2  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006    � Title$  	Toevoegen��$	��800��$	��450�����#2B2D42 � Icon$ /afbeeldingen/logo.png�� � WindowStartupLocation$ CenterScreen=�.��� .+�� -    �Name$ grid_vragen��$y�	Collapsed=�.+��� $��0,50,0,0q�$��Center=�$	��Top=� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ cmb_vragen_verkiezing��$	��200��$��25��$��0,0,0,0q�$	��Top=�*  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Verkiezing...��$��12(��� -    ��Name$ tb_vragen_vraag��$	��400��$��80��$��20,0,0,0q�$	��Top=�$ Vraag...��$��12(� �� TextWrapping$
 Wrap=��� -   	 ��Name$	 btn_vragen_toevoegen��$	��150��$��40��$��Right=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Voltooien�� -   $	 btn_vragen_annuleren��$	��150��$��40��$
��Left=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Annuleren� -   $ grid_verkiezingen��$y�	Collapsed=�.+��� $��0,50,0,0q�$��Center=�$	��Top=�$ 
Horizontal=�.+��� .+��� $ 
Horizontal=�.+��� -   $  tb_verkiezingen_verkiezing��$	��370��$��25��$��0,0,0,0q�$	��Top=�$ Verkiezing naam...��$��12(��� $ 
Horizontal=�.+�+  %MahApps.Metro.Controls.DateTimePicker  -   
  Name$!
 dtp_verkiezingen_startDatum��$	��175��$��25��$��0,10,0,0q�$	��Top=�$��Center=�$ Start datum...��$��12(�  -	   $ 
 dtp_verkiezingen_eindDatum��$	��175��$��25��$��	20,10,0,0q�$	��Top=�$ Eind datum...��$��12(��� -
   $" tb_verkiezingen_beschrijving��$	��300��$	��150��$��20,0,0,0q�$	��Top=�$ Beschrijving...��$��12(�$
 Wrap=�" �� VerticalScrollBarVisibility$ Visible=��� -   $ 	 btn_verkiezingen_toevoegen��$	��150��$��40��$��Right=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Voltooien�� -   $ 	 btn_verkiezingen_annuleren��$	��150��$��40��$
��Left=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Annuleren� -   $ grid_partijen��$y�	Collapsed=�.+��� $��0,50,0,0q�$��Center=�$	��Top=�$ 
Horizontal=�.+��� .+��� $ 
Horizontal=�.+��� -   $ tb_partijen_partij��$	��320��$��25��$��0,0,10,0q�$	��Top=�$ Partij naam...��$��12(��� $ 
Horizontal=�.+��� -   $ tb_partijen_contact��$	��320��$��37��$��	0,10,10,0q�$	��Top=�$	��Top=�$ 
contact...��$��12(�$ �� HorizontalScrollBarVisibility$ Visible=��� .+��� -    ��Name$ img_partijen_logo��$	��200��$	��150��$��0,0,0,0q�$	��Top=�$y�	Collapsed=��� -   $ tb_partijen_logo��$	��150��$��25��$��0,0,0,0q�$	��Top=�$ Logo naam...��$��12(�$y�	Collapsed=��� $��5,0,0,0q�.+��� -   $	 btn_logo_toevoegen��$	��150��$��20��
��� � �$��12(�$
��Bold"���Z� .��afbeelding toevoegen�� -   $	 btn_logo_verwijderen��$	��150��$��20��$��0,20,0,0q�
���  ��$��12(�$
��Bold"���Z� .��afbeelding verwijderen�� -   $	 btn_partijen_toevoegen��$	��150��$��40��$��Right=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Voltooien�� -   $	 btn_partijen_annuleren��$	��150��$��40��$
��Left=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Annuleren� -   $ 
grid_users��$y�	Collapsed=�.+��� $��0,50,0,0q�$��Center=�$	��Top=�.+��� $ 
Horizontal=�.+��� .+��� -   $ tb_users_gebruikersnaam��$	��200��$��25��$��0,0,0,0q�$	��Top=�$ gebruikersnaam...��$��12(��� .+��� -   $ tb_users_email��$	��200��$��25��$��20,0,0,0q�$	��Top=�$ email...��$��12(��� .+��� -   $ tb_users_wachtwoord��$	��200��$��25��$��20,0,0,0q�$	��Top=�$ wachtwoord...��$��12(��� $��0,20,0,0q�$ 
Horizontal=�.+��� .+��� -   $ cmb_users_machtiging��$	��200��$��25��$��0,0,0,0q�$	��Top=�$��Center=�$ Machtiging...��$��12(� �� SelectedIndex$ 0��.@��� $��	gebruiker���� $��
medewerker���� .+�  -   $
 dtp_users_geboorteDatum��$	��200��$��25��$��20,0,0,0q�$	��Top=�$��Center=�$ geboorte datum...��$��12(��� -   $	 btn_users_toevoegen��$	��150��$��40��$��Right=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Voltooien�� -   $	 btn_users_annuleren��$	��150��$��40��$
��Left=�$��Bottom=�$��20(�$
��Bold"���Z� .��	Annuleren