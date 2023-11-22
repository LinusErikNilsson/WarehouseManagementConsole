# WarehouseManagementConsole

This is a .NET console application that allows you to manage a warehouse. It is written in C# and uses a Microsoft SQL database locally via Docker.

### IMPORTANT INFORMATION/Requirements
- To run the application, use Visual Studio 2022 or Visual Studio Code with the nessessary C# Workloads and/or Extensions.
- .NET 8.0 is required to run this application.
- The project contains the SQL-scripts to create the nessessary tables and data. THis is located in the "Setup.sql" file.
- Database connection must be setup manually in the IDE, including connection string and password. Depending on your preference of server provider. 


### Lite kommentarer om Grupparbetet, metod, struktur mm
V�r huvudsakliga metod i grupparbetet har varit parprogramering, d�r vi har hj�lps �t att koda genom att komma med f�rslag. 
F�r detta lilla projekt har det fungerat bra, d� vi har kunnat sitta tillsammans och diskutera l�sningar och problem och p� s� s�tt l�rt oss av varandra men �ven arbetat v�ldigt l�sningsinriktat och direkt l�st utmaningar.

Vi har anv�nt oss av github d�r repot finns, och med git f�r att synka v�ra �ndringar/commits.

N�r vi designade databasen anv�nde vi oss f�rst av OneNote, och sedan renskissade vi det i en design-app p� webben.
L�pande under projektet har vi byggt applikationen fr�n databasen, och ifall vi uppt�ckt fel i databas designen s� har vi direkt unders�kt felet och l�st det - f�r att sedan forts�tta med applikationen.

 I Projektet finns ./Diagram.png �r en bild p� v�r databasen som vi har anv�nt oss av: (https://github.com/LinusErikNilsson/WarehouseManagementConsole/blob/master/Diagram.png) 
 Det finns �ven en Setup.sql fil d�r v�ra SQL-script f�r att skapa tabeller och data finns. (https://github.com/LinusErikNilsson/WarehouseManagementConsole/blob/master/Setup.sql) Detta var ett bra s�tt att dela SQL-kod mellan oss, eftersom vi jobbade i v�ra lokala databaser och beh�vde s�kerhetst�lla att vi hade identiska databaser.

 �ven om vi hittade en bra metodik f�r att hantera SQL-scripten f�r att syncka v�ra databaser var det inte optimalt - och det hade varit mycket b�ttre att f� till en gemensam databas i antingen en moln/on-premise l�sning d� momentet att synca databaserna manuellt var v�ldigt tidskr�vande.

 Applikationen vi skrivit �r simpel, och anv�nder sig av Switch-satser f�r UI, och d�r all logik finns. Dvs finns allt i samma fil (program.cs) men med klasser i separata filer i mappen "Model". Vi valde aktivt att skriva appen s� enkelt som m�jligt, men i ifall appen ska vara h�llbar p� sikt b�r givetvis UI och logik separeras och struktureras p� ett annat s�tt.



