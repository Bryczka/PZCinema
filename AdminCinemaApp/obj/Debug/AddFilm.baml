   M S B A M L   `   `   `  ����I  EAdminCinemaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AdminCinemaAppAdminCinemaApp  5   	       AdminCinemaApp.AddFilm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AdminCinemaApp     5   	   -   5          �Name$  AddFilmWindow��5   4    � Title$ AddFilm��6	   $��458.4��6   $	��440��6(    � WindowStartupLocation$ CenterScreen=�6K   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      .+�5   
   �� $��5,0,0,0q�6   .+�5      �� $
��Wrap=�6   $��Title:��6,   $��18(�6:   $
��Bold"�6H   $��0,15,0,5q�6Z    �� TextAlignment$ Center=�6l   �� 5      -   5         ��Name$ Title��5      $��23��6%    �� TextWrapping$
 Wrap=�61   $�� ��6E   $��15(�6M   �� 5      $
��Wrap=�6   $��
Age limit:��6,   $��18(�6>   $
��Bold"�6L   $��0,5,0,5q�6^   $ Center=�6o   �� 5      -   5         ��Name$ 	Age_limit��5      $��23��6*    �� Text$  ��66   $��15(�6>   $��Center=�6L   $��Center=�6n   �� 5      $
��Wrap=�6   $��	Duration:��6,   $��18(�6=   $
��Bold"�6K   $��0,5,0,5q�6]   $ Center=�6n   �� 5      -   5        $ Duration��5      $��23��6(   $
 Wrap=�64   $�� ��6H   $��15(�6P   �� 5      $
��Wrap=�6   $��Description:��6,   $��18(�6@   $
��Bold"�6N   $��0,5,0,5q�6`   $ Center=�6q   �� 5      -   5        $ Description��5      $	��136��6+   $
 Wrap=�68   $�� ��6L   $��15(�6T   $��
0,0,-0.2,0q�6b   5      �� 5   
   $��1��6   .+�5      �� $
��Wrap=�6   $��Selected poster:��6,   $��18(�6D   $
��Bold"�6R   $��0,5,0,5q�6d   $ Center=�6u   �� 5      -   5        	 ��Name$	 FilmPosterImage��5      $
��Left=�6-   $	��280��6H   $��10,5,0,0q�6U   $	��Top=�6g   $	��197��6   �� 5      -   5        $��Browse for image��5      $��
10,10,10,0q�60   $��32��6D   6P   5      �� 5   
   -   5        
 ��Name$
 Save_Button��5      $
��Save��6&   $��
0,373,0,10q�65   $��36��6I   $��18(�6U   $
��Bold"�6c   $��2��6�   5      5       