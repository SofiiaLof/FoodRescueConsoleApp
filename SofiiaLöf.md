
# Rapport
## Planering
Vi f�rs�kte att b�rja med planeringen tidigt f�r att kunna best�mma vad kan vi g�ra i projektet
och hur kan vi implementera detta. Jag skapade en grupp-chat p� Discord och la till alla gruppmedlemmar f�r b�ttre kommunikation i mellan oss.
Vi kunde prata redan p� tisdag (24/11) f�r att diskutera och planera hur projektet ska utvecklas, men tyv�rr kunde inte alla delta.
Vi skapade issues d�r vi kort beskrev de krav som st�lls p� detta projektarbete samt assignade vi de till varje gruppmedlem.
 D�refter skapade vi en [Kanaban projekt](https://github.com/Nettan86/Datalagring-Projektarbete/projects/1) f�r att tydlig se vart befinner vi oss i processen
och hur mycket kvar har vi att g�ra. Vi best�mde att vi f�rst implementerar de issues som st�r som krav f�r att kunna f� godk�nd f�r detta arbete,
men vi har varit �verens om att det kan g�ras extra features om det finns en tid �ver f�r detta.

Redan i planeringsfasen kunde vi best�mma vem g�r vad, och d� landade vi p� att tre personer g�r varsin frontend-del och den fj�rde personen ska 
implementera en login-system. Det planerades ocks� att varje person g�r minst ett test, men alla hade frihet att g�ra hur m�nga tester vi vill.

### Vad kan g�ras b�ttre
- Kommunikationen i mellan oss kunde fungera lite b�ttre samt att vi kunde ha flera tillf�llen �n bara ett d�r alla fyra kunde vara med p� m�tet. 
- Kommunikationen i chatten kunde fungera lite b�ttre ocks�, d�r alla kunde skriva i fall det finns n�got hinder f�r att tr�ffas.
- F�r att undvika ovann�mnda kunde vi redan i b�rjan (planeringsfasen) best�mma vilka tider passar b�st f�r alla att sitta med projektarbetet och vilken kommunikatonform alla f�redrar.

## Implementering 
Vi best�mde att vi implementerar v�ra frontend-delar som Console App och jag har varit ansvarig f�r `CustomerClient`. 
F�r min l�sning skapade jag en meny d�r anv�ndare kunde v�lja vad den vill g�ra. Jag best�mde att ha hj�lp-funktioner som anropas beroende p� anv�ndarens val.
Exempel p� s�dana funktioner �r :`PurchaseHistory(user)`, `BuyFoodPackage(user)` och  `SeePackagesList()`. Fr�n dessa funktioner skedde ett metodanrop f�r respektive 
hj�lp-metoden som ligger i `CustomerBackend` f�r att h�mta referens till �nskade rekords i v�r databas. 

Jag har ocks� skapat ett ny test-suite som heter `CustomerBackendTests`. D�r har jag implementerat tv� tester: den ena testet testar metoden f�r os�lda matl�dor och den andra 
testar metoden f�r att k�pa en matl�da. Jag �nskar att jag kunde hitta b�ttre l�sning f�r att testa listor med matl�deobjekt, detta skulle jag unders�ka vidare.

Jag fick �ven hj�lpa mina gruppmedlemmar med deras del av arbete n�r de k�nde att de har st�tt p� problem, detta hj�lpte mig att bli b�ttre p� att f�rklara 
kod-relaterad information samt kunde jag tr�na p� att l�sa problem.


### Vad kan g�ras b�ttre
- Det vore bra att kunna implementera v�ra frontend delar med hj�lp av t.ex. WinForms eller n�got liknande.
- Vi var �verens att det vore bra att skapa tv� olika databaser om vi hade tid �ver: den ena som �r avsedd f�r tester och den andra som �r v�r live-databasen.
- Om vi hade tid �ver s� tycker jag att vi kunde f�rb�ttra v�ra l�sningar med extra features som t.ex se en total f�rtj�nst f�r en specifik restaurang eller 
skapa en inloggning p� `AdminClient` s� admin kunde ocks� logga in fr�n sin vy.


### Egen reflektion
Jag tycker att �verlag fungerade v�rat samarbete bra, alla gjorde sin del och kunde bidra s� vi har hunnit att g�ra klart v�rat projektet i tid. :)
