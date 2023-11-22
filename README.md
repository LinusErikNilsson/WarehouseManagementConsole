# WarehouseManagementConsole

This is a .NET console application that allows you to manage a warehouse. It is written in C# and uses a Microsoft SQL database locally via Docker.

### IMPORTANT INFORMATION/Requirements
- To run the application, use Visual Studio 2022 or Visual Studio Code with the nessessary C# Workloads and/or Extensions.
- .NET 8.0 is required to run this application.
- The project contains the SQL-scripts to create the nessessary tables and data. THis is located in the "Setup.sql" file.
- Database connection must be setup manually in the IDE, including connection string and password. Depending on your preference of server provider. 


### Lite kommentarer om Grupparbetet, metod, struktur mm
Vår huvudsakliga metod i grupparbetet har varit parprogramering, där vi har hjälps åt att koda genom att komma med förslag. 
För detta lilla projekt har det fungerat bra, då vi har kunnat sitta tillsammans och diskutera lösningar och problem och på så sätt lärt oss av varandra men även arbetat väldigt lösningsinriktat och direkt löst utmaningar.

Vi har använt oss av github där repot finns, och med git för att synka våra ändringar/commits.

När vi designade databasen använde vi oss först av OneNote, och sedan renskissade vi det i en design-app på webben.
Löpande under projektet har vi byggt applikationen från databasen, och ifall vi upptäckt fel i databas designen så har vi direkt undersökt felet och löst det - för att sedan fortsätta med applikationen.

 I Projektet finns ./Diagram.png är en bild på vår databasen som vi har använt oss av: (https://github.com/LinusErikNilsson/WarehouseManagementConsole/blob/master/Diagram.png) 
 Det finns även en Setup.sql fil där våra SQL-script för att skapa tabeller och data finns. (https://github.com/LinusErikNilsson/WarehouseManagementConsole/blob/master/Setup.sql) Detta var ett bra sätt att dela SQL-kod mellan oss, eftersom vi jobbade i våra lokala databaser och behövde säkerhetställa att vi hade identiska databaser.

 Även om vi hittade en bra metodik för att hantera SQL-scripten för att syncka våra databaser var det inte optimalt - och det hade varit mycket bättre att få till en gemensam databas i antingen en moln/on-premise lösning då momentet att synca databaserna manuellt var väldigt tidskrävande.

 Applikationen vi skrivit är simpel, och använder sig av Switch-satser för UI, och där all logik finns. Dvs finns allt i samma fil (program.cs) men med klasser i separata filer i mappen "Model". Vi valde aktivt att skriva appen så enkelt som möjligt, men i ifall appen ska vara hållbar på sikt bör givetvis UI och logik separeras och struktureras på ett annat sätt.



