# **✅**Use case : Tjek gæst ind

| Felt | Hvad skriver vi |
| :---- | :---- |
| Nummer | UC05 |
| Use case navn | Tjek gæst ind |
| Virkefelt | HYDACs komme-gå-system |
| Niveau | Brugermål |
| Primær aktør | Medarbejder |
| Mål | Medarbejderen registrerer, at gæsten er ankommet og har modtaget sikkerhedsfolderen, så besøgets status bliver "Tjekket Ind" og listen over personer i huset er korrekt. |
| Interessenter | Gæst: Vil tages hurtigt imod og vide, hvordan der skal forholdes ved en alarm. <br>Reception: Vil kunne se, hvem der rent faktisk er ankommet. <br>Beredskab/AMO: Vil have, at kun faktisk ankomne personer står på listen over personer i huset, og at det er dokumenteret, at sikkerhedsfolderen er udleveret. <br>HYDAC: Vil kunne dokumentere indtjekningstid og udlevering af sikkerhedsfolderen. |
| Før-tilstand | Besøget er oprettet (UC02) og har status "Ikke Tjekket Ind". <br>Gæsten er ankommet til receptionen. |
| Efter-tilstand | Besøget har status "Tjekket Ind", og indtjekningstiden er registreret. <br>Det er registreret, om gæsten har modtaget sikkerhedsfolderen. <br>Gæsten indgår i listen over personer i huset. |
| Hovedscenarie | 1. Medarbejderen indtaster besøgets indtjekningskode. <br>2. Systemet finder besøget og spørger, om sikkerhedsfolderen er modtaget (ja/nej). <br>3. Medarbejderen svarer, om sikkerhedsfolderen er modtaget. <br>4. Systemet gemmer svaret og indtjekningstiden, ændrer besøgets status til "Tjekket Ind" og viser bekræftelsen. |
| Udvidelser | Medarbejderen fortryder <br>- Systemet ændrer ikke status og vender tilbage til menuen. <br>Indtjekningskoden findes ikke <br>- Systemet viser fejlen "Besøget blev ikke fundet". <br>Besøget er allerede tjekket ind <br>- Systemet viser beskeden "Gæsten er allerede tjekket ind" og ændrer ikke status. <br>Besøget er allerede tjekket ud <br>- Systemet viser beskeden "Besøget er afsluttet". <br>Gæsten har ikke modtaget sikkerhedsfolderen <br>- Systemet registrerer "nej" og gør medarbejderen opmærksom på, at sikkerhedsfolderen skal udleveres. |
| Specielle krav | Indtjekning skal kunne gennemføres hurtigt i receptionen. <br>Systemet gemmer kun de persondata, der er nødvendige for besøget (GDPR). |
