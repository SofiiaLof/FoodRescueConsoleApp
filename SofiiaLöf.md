
# Rapport
## Planering
Vi försökte att börja med planeringen tidigt för att kunna bestämma vad kan vi göra i projektet
och hur kan vi implementera detta. Jag skapade en grupp-chat på Discord och la till alla gruppmedlemmar för bättre kommunikation i mellan oss.
Vi kunde prata redan på tisdag (24/11) för att diskutera och planera hur projektet ska utvecklas, men tyvärr kunde inte alla delta.
Vi skapade issues där vi kort beskrev de krav som ställs på detta projektarbete samt assignade vi de till varje gruppmedlem.
 Därefter skapade vi en [Kanaban projekt](https://github.com/Nettan86/Datalagring-Projektarbete/projects/1) för att tydlig se vart befinner vi oss i processen
och hur mycket kvar har vi att göra. Vi bestämde att vi först implementerar de issues som står som krav för att kunna få godkänd för detta arbete,
men vi har varit överens om att det kan göras extra features om det finns en tid över för detta.

Redan i planeringsfasen kunde vi bestämma vem gör vad, och då landade vi på att tre personer gör varsin frontend-del och den fjärde personen ska 
implementera en login-system. Det planerades också att varje person gör minst ett test, men alla hade frihet att göra hur många tester vi vill.

### Vad kan göras bättre
- Kommunikationen i mellan oss kunde fungera lite bättre samt att vi kunde ha flera tillfällen än bara ett där alla fyra kunde vara med på mötet. 
- Kommunikationen i chatten kunde fungera lite bättre också, där alla kunde skriva i fall det finns något hinder för att träffas.
- För att undvika ovannämnda kunde vi redan i början (planeringsfasen) bestämma vilka tider passar bäst för alla att sitta med projektarbetet och vilken kommunikatonform alla föredrar.

## Implementering 
Vi bestämde att vi implementerar våra frontend-delar som Console App och jag har varit ansvarig för `CustomerClient`. 
För min lösning skapade jag en meny där användare kunde välja vad den vill göra. Jag bestämde att ha hjälp-funktioner som anropas beroende på användarens val.
Exempel på sådana funktioner är :`PurchaseHistory(user)`, `BuyFoodPackage(user)` och  `SeePackagesList()`. Från dessa funktioner skedde ett metodanrop för respektive 
hjälp-metoden som ligger i `CustomerBackend` för att hämta referens till önskade rekords i vår databas. 

Jag har också skapat ett ny test-suite som heter `CustomerBackendTests`. Där har jag implementerat två tester: den ena testet testar metoden för osålda matlådor och den andra 
testar metoden för att köpa en matlåda. Jag önskar att jag kunde hitta bättre lösning för att testa listor med matlådeobjekt, detta skulle jag undersöka vidare.

Jag fick även hjälpa mina gruppmedlemmar med deras del av arbete när de kände att de har stött på problem, detta hjälpte mig att bli bättre på att förklara 
kod-relaterad information samt kunde jag träna på att lösa problem.


### Vad kan göras bättre
- Det vore bra att kunna implementera våra frontend delar med hjälp av t.ex. WinForms eller något liknande.
- Vi var överens att det vore bra att skapa två olika databaser om vi hade tid över: den ena som är avsedd för tester och den andra som är vår live-databasen.
- Om vi hade tid över så tycker jag att vi kunde förbättra våra lösningar med extra features som t.ex se en total förtjänst för en specifik restaurang eller 
skapa en inloggning på `AdminClient` så admin kunde också logga in från sin vy.


### Egen reflektion
Jag tycker att överlag fungerade vårat samarbete bra, alla gjorde sin del och kunde bidra så vi har hunnit att göra klart vårat projektet i tid. :)
