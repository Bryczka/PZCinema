   M S B A M L   `   `   `  ����I  EAdminCinemaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AdminCinemaAppAdminCinemaApp  5   	       AdminCinemaApp.AddRoom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AdminCinemaApp     5   	     � Title$  AddRoom��5   	   $	��400��6   $	��300��6&    � WindowStartupLocation$ CenterScreen=�62   .��5	      � .+�5
   
   �� .+�5      �� $
��Wrap=�6   $��Name of room:��6,   $��18(�6A   $
��Bold"�6O   $��0,15,0,5q�6a    �� TextAlignment$ Center=�6s   �� 5      -   5         ��Name$
 Name��5      $��23��6$    �� TextWrapping$
 Wrap=�60   $�� ��6D   $��15(�6L   �� 5      $
��Wrap=�6   $��Number of rows:��6,   $��18(�6C   $
��Bold"�6Q   $��0,15,0,5q�6c   $ Center=�6u   �� 5       �� Orientation$ 
Horizontal=�6   $��
0,0,-0.4,0q�62   $	��294��6F   .+�5      �� -   5        $
 Rows��5      $��5,5,0,5q�6(   $	��239��69   $��0��6E   $��18(�6N   $
��Bold"�6\   �� 5      -   5         ��Name$ AddRow��5      $��5,5,0,5q�6)   $��˄��6:   $��20��6F   $��18(�6f   $
��Bold"�6t   �� 5      -   5        $ DelRow��5      $��0,5,0,5q�6)   $��˅��6;   $��20��6G   $��18(�6g   $
��Bold"�6u   5      �� 5      $
��Wrap=�6   $��Number of columns:��6,   $��18(�6F   $
��Bold"�6T   $��0,15,0,5q�6f   $ Center=�6x   �� 5      $ 
Horizontal=�6   .+�5      �� -   5        $ Columns��5      $��5,5,0,5q�6+   $	��239��6<   $��0��6H   $��18(�6Q   $
��Bold"�6_   �� 5      -   5        $ 	AddColumn��5      $��5,5,0,5q�6,   $��˄��6=   $��20��6I   $��18(�6l   $
��Bold"�6z   �� 5      -   5        $ 	DelColumn��5      $��0,5,0,5q�6,   $��˅��6>   $��20��6J   $��18(�6m   $
��Bold"�6{   5      �� 5      $
��Wrap=�6   $��Number of seats:��6,   $��18(�6D   $
��Bold"�6R   $��0,5,0,5q�6d   $ Center=�6u   �� 5      -   5        $ NumberOfSeats��5      $��0��6-   $��23��66   $��18(�6C   {�.  6Q   �� 5      -	   5        $ Save_Button��5      $
��Save��6*   $��0,35,-0.4,0q�69   $��36��6N   $��18(�6Z   $
��Bold"�6h   6z   5      5      5      