# Proiect-final_ShoeStore

Aplicaţia ShoeControl a fost concepută, în primă fază, în ideea de a satisfice nevoile de bază ale unui lanţ de magazine de încălţăminte pe partea de gestiune.
Funcţionalităţile acesteia sunt setate diferit, în funcţie de natura user-ului:
 Admin-ul poate introduce noi date, poate aduce modificări şi poate sterge date din stocul magazinelor şi din categoriile de produse. De asemenea poate gestiona conturile de acces (creare, modificare parolă sau rol), având restricţionată doar stergerea propriului cont.
 User-ul are restricţionate majoritatea operaţiunilor CRUD. El poate sa vizualizeze şi să caute produse în funcţie de doi parametri setaţi. El nu are nici un fel de acces în partea de Manage Accounts.
Atunci când unul dintre utilizatori introduce date neconforme sau apar bug-uri în aplicaţie, acesta va fi redirecţionat către o pagină special creată cu un mesaj general de eroare. Detaliile despre tipul de erori, data şi ora etc., sunt logate într-un fişier local.
Tehnologii folosite:
Pentru realizarea aplicaţiei au fost folosite noțiunile de programare orientată obiect (OOP) și a noțiunilor de programare .NET acumulate pe parcursul orelor desfășurate în cadrul Academiei de IT Wantsome. Aplicaţia este de tip Client-Server, iar comunicarea datelor se face după modelul request-service, prin intermediul unei interfețe. De asemenea se utilizează și o componentă de stocare de date pe server (persistence layer), prin intermediul Microsoft SQL Server Management.
Pentru organizarea codului s-a folosit modelul arhitectural Three Layer Architecture:
 data-layer: conţine conexiunea cu baza de date și operațiuni CRUD;
 business-logic: conţine entitățile de bază;
 presentation layer: este implementată interfața grafică pentru utilizator.
Conexiunea la baza de date se realizeză în mare parte cu ajutorul tehnologiei ADO Net. Pentru partea de Identity user s-a folosit Entity Framework, urmând ca pe viitor aplicaţia să fie în întregime costruită pe baza tehnologiei Entity Framework.
În ceea ce priveşte partea de ADO Net, s-a folosit pattern-ul de design SingleTon, pentru asigurarea unei singure conexiuni cu baza de date. Pentru a realiza operațiile CRUD sunt folosite pattern-ul Repository Design Pattern, procedurile stocate create în baza de date şi LINQ (Language-Integrated Query).
Pentru dezvoltarea interfeței web cu utilizatorul a fost utilizată tehnologia ASP.Net-MVC, care se bazează pe modelul Model-View-Controller, utilizat în dezvoltarea de aplicații web şi Bootstrap, un Framework CSS.
