   M S B A M L   `   `   `  ����I  ECinemaDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:CinemaDatabase;assembly=CinemaDatabaseCinemaDatabase  5      I EAdminCinemaApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AdminCinemaAppAdminCinemaApp 5         AdminCinemaApp.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      OCinemaDatabase4clr-namespace:CinemaDatabase;assembly=CinemaDatabase     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:AdminCinemaApp     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      Cdxpdf1http://schemas.devexpress.com/winfx/2008/xaml/pdf     5      YCollectionViewSourcex9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5	      -   5        $	��800��5      $	��450��5        � Title$  
MainWindow��5       � 
ResizeMode$ NoResize=�5       � 	Resources 5         filmViewSource  filmShowViewSource  ticketViewSource  roomViewSource  priceViewSource  userViewSource��%�   &	        &	      &	 &     &	 9     &	 L     &	 _     �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6   �� 5   
   6   5      .��5      �  � DataContext# [  6   .+�5   
   �� .@�5      �� $��Current films��6   $
��Auto��6-   .��5      �  � ColumnDefinitions 5      �� 5       $	��59* �6+   �� 5!      $	��11* �6+   .+�5%      &   System.Windows.Controls.DataGrid  -   5          Name$ filmDataGrid��5&      $��10,85,98.6,10.4q�5'         AutoGenerateColumns .     EnableRowVirtualization .    RowDetailsVisibilityMode$ VisibleWhenSelected=�5+      $��2��6D   	   
IsReadOnly	 . ��5*      �� 
   Columns
 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      -   5        idColumn��,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ SizeToHeader 5/         Header$ Id��51      1  +System.Windows.Controls.DataGridBoundColumn   Binding 50      �� *Id+51        52      -   5        titleColumn��$	 150 54      $ Title��56       55      �� *Title+56        57      -   5        age_LimitColumn��$ SizeToHeader 59      $ 	Age Limit��5;       5:      �� *	Age_Limit+5;        5<      -   5        durationColumn��$ SizeToHeader 5>      $ Duration��5@       5?      �� *
Duration+5@        5A      -   5        descriptionColumn��$
 Auto 5C      $ Description��5E       5D      �� *Description+5E      5G      �� 5H      -   5        $��Add new film��5H      $
��Left=�64   $��	10,43,0,0q�6O   $	��Top=�6b   $	��146��6z   $��35��6�   6�   �� 5I      -	   5        $��Delete choosen film��5I      $
��Left=�6;   $��
161,43,0,0q�6V   $	��Top=�6j   $	��146��6�   $��35��6�   6�   5J      5K      �� 5L      $��	Filmshows��6   $
��Auto��6)   .��5M      � .+�5O        -
   5        $ filmShowDataGrid��5O      $��10,85,99.6,10.4q�69    .  $��2��6�   	 . ��6R   ��  �� Source# [ 
 5P        5Q      -   5        idFilmShowColumn��$
 Auto 5S      $ Id��5U       5T      �� *Id+5U        5V      -   5        timeOfFilmShow��$
 auto 5X      $ Time of film show��5Z       5Y      �� *Time+5Z        5[      -   5        
nameOfRoom��$
 Auto 5]      $ 	Room name��5_       5^      �� *
RoomName+5_        5`      -   5        titleOfFilm��$
 Auto 5b      $ Title of film��5d       5c      �� *
Film.Title+5d        5e      -   5        numberOfSeats��$
 auto 5g      $ Number of Seats��5i       5h      �� *NumberOfSeats+5i      5k      �� 5n      -   5        $��Add new film show��5n      $
��Left=�69   $��	10,45,0,0q�6T   $	��Top=�6g   $	��146��6   $��35��6�   6�   �� 5o      -   5         ��Name$ DeleteFilmShow��5o      $��Delete choosen film show��65   $
��Left=�6X   $��
161,45,0,0q�6s   $	��Top=�6�   $	��165��6�   $��35��6�   $��2��6�   5q      5r      �� 5s      $��Tickets��6   $
��Auto��6'   .��5t      � .+�5u        -   5        $ ticketsDataGrid��5u      $��10,41,100,10.2q�68    .  	 . ��6P   �� # [ 
 5v        5w      -   5        filmTitleOnTicket��$
 Auto 5y      $ Title of film��5{       5z      �� *FilmShow.Film.Title+5{        5|      -   5        typeOfTicket��$
 auto 5~      $ Type of ticket��5�       5      �� *Type+5�        5�      -   5        	price��$
 Auto 5�      $ Price of ticket��5�       5�      �� *Price+5�        5�      -   5        RoomNameOnTicket��$
 Auto 5�      $ Name of room��5�       5�      �� *FilmShow.RoomName+5�        5�      -   5        filmTimeOnTicket��$
 Auto 5�      $ Time of filmshow��5�       5�      �� *FilmShow.Time+5�        5�      -   5        
seatNumber��$
 Auto 5�      $ Seat number��5�       5�      �� *
SeatNumber+5�        5�      -   5        
isFree��$
 Auto 5�      $ Is seat free?��5�       5�      �� *IsFree+5�        5�      -   5        filmIsBoughtTicket��$
 Auto 5�      $ Is seat bought?��5�       5�      �� *
IsBought+5�        5�      -   5        emailOnTicket��$
 Auto 5�      $ 
User email��5�       5�      �� *	UserEmail+5�        5�      -   5        isUsedTicket��$
 Auto 5�      $ Is used?��5�       5�      �� *IsUsed+5�      5�      5�      5�      �� 5�      $��Price and rooms��6   $
��Auto��6/   .��5�      �  5�      �� 5�      �� 5�      .+�5�        -   5        $ priceDataGrid��5�      $��10,85,9.8,10.4q�66   $��0��6N    .  	 . ��6^   �� # [ 
 5�        5�      -   5        
ticketType��$
 Auto 5�      $ Type of ticket��5�       5�      �� *TypeOfTicket+5�        5�      -   5        ticketPrice��$
 auto 5�      $ Price of ticket��5�       5�      �� *Cost+5�      5�        5�      -    5        $ roomDataGrid��5�      $��10,85,9.8,10.4q�65   $��1��6M    .  	 . ��6]   �� # [ 
 5�        5�      -!   5        roomName��$
 Auto 5�      $ Name of room��5�       5�      �� *Name+5�        5�      -"   5        seatsNumber��$
 auto 5�      $ Number of seats��5�       5�      �� *NumberOfSeats+5�        5�      -#   5        
rowsNumber��$
 auto 5�      $
 Rows��5�       5�      �� *NumberOfRows+5�        5�      -$   5        columnssNumber��$
 auto 5�      $ Columns��5�       5�      �� *NumberOfColumns+5�      5�      �� 5�      -%   5        $��0��5�      $��Add new ticket type��6-   $
��Left=�6K   $��	10,46,0,0q�6f   $	��Top=�6y   $	��146��6�   $��35��6�   6�   �� 5�      -&   5        $��0��5�      $��Delete ticket type��6-   $
��Left=�6J   $��
161,46,0,0q�6e   $	��Top=�6y   $	��151��6�   $��35��6�   6�   �� 5�      -'   5        $��1��5�      $��Add new room��6-   $
��Left=�6D   $��	10,46,0,0q�6_   $	��Top=�6r   $	��146��6�   $��35��6�   6�   �� 5�      -(   5        $��1��5�      $��Delete room��6-   $
��Left=�6C   $��161.2,46,0,0q�6^   $	��Top=�6t   $	��146��6�   $��35��6�   6�   5�      5�      �� 5�      $��	Employees��6   $
��Auto��6)   .��5�      � .+�5�        -)   5        $ employeeDataGrid��5�      $��10,85,99.6,10.4q�69    .  	 . ��6�   �� # [ 
 5�        5�      -*   5        
employeeId��$
 Auto 5�      $ Employee ID��5�       5�      �� *Id+5�        5�      -+   5        employeeName��$
 auto 5�      $
 Name��5�       5�      �� *Name+5�        5�      -,   5        employeeSurname��$
 Auto 5�      $ Surname��5�       5�      �� *	Surname+5�        5�      --   5        employeeEmail��$
 Auto 5�      $ Employee email��5�       5�      �� *Email+5�      5�      �� 5�      -.   5        $��Add employee��5�      $
��Left=�64   $��	10,45,0,0q�6O   $	��Top=�6b   $	��146��6z   $��35��6�   6�   �� 5�      -/   5        $��Delete employee��5�      $
��Left=�67   $��
161,45,0,0q�6R   $	��Top=�6f   $	��152��6~   $��35��6�   6�   5      5     5     5     5     