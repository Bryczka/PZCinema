   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5   	   I EAdminCinemaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AdminCinemaAppAdminCinemaApp 5   	       AdminCinemaApp.AddFilmShow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5   	   .localclr-namespace:AdminCinemaApp     5   	   -   5          �Name$  AddFilmShowWindow��5	   6    � Title$ AddFilmShow��6	   $	��400��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�6Q   .��5      �� .+�5   
   �� $
��Wrap=�6   $��Time:��6(   $��18(�65   $
��Bold"�6C   $��0,15,0,5q�6U    �� TextAlignment$ Center=�6g   &    Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5          Name$ TimeOfFilmShow��5   !   $��23��69   ,   &Xceed.Wpf.Toolkit.Primitives.InputBase   Text$  ��6E   $��15(�6M   $��
0,0,-0.4,0q�6[   &    Xceed.Wpf.Toolkit.DateTimeUpDown   Format$ Custom=�6o      FormatString$ dd/MM/yyyy hh:mmtt��6�   �� 5   
   $
��Wrap=�6   $��
Room name:��6(   $��18(�6:   $
��Bold"�6H   $��0,5,0,5q�6Z   $ Center=�6k   �� 5   
   -   5         ��Name$ RoomName��5      $��23��6%   $��15(�62   ��5      �� 5      .R�5      � .+�5      �� ��6$   �� 	 �� Path$
	 Name�6A   5      5      5      �� 5   
   $
��Wrap=�6   $��Film Title:��6(   $��18(�6;   $
��Bold"�6I   $��0,5,0,5q�6[   $ Center=�6l   �� 5   
   -   5        $ FilmShowTitle��5      $��23��6*   $��15(�67   ��5      �� 5      .R�5       � .+�5!      �� 
 ��Name$
 aa��6$   ��60   �� $	 Id�6K   �� 5"      $��  ��6$   60   �� 5#      ��6$   �� $	 Title�6B   5$      5%      5'      �� 5)   
   $
��Wrap=�6   $��Number of seats:��6(   $��18(�6@   $
��Bold"�6N   $��0,5,0,5q�6`   $ Center=�6q   �� 5*   
   -   5         ��Name$ NumberOfSeats��5*      $��23��6)    �� TextWrapping$
 Wrap=�65   $�� ��6I   $��15(�6Q   {�.  6_   �� 5+   
   -   5         ��Name$ Save_Button��5+      $
��Save��6&   $��
0,35, 0 ,0q�65   $��36��6I   $��18(�6U   $
��Bold"�6c   6u   �� 5,   
   -   5         ��Name$
 TEST��5,      $��61��6   $��
0,0,-0.4,0q�6*   51      52      