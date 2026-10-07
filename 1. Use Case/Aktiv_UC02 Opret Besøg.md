# **✅**Use case : Opret besøg

| Felt | Hvad skriver vi |
| :---- | :---- |
| Nummer | UC02 |
| Use case navn | Opret besøg |
| Virkefelt | HYDACs komme-gå-system |
| Niveau | Brugermål |
| Primær aktør | Medarbejder |
| Mål | Medarbejderen registrerer et aftalt besøg, så receptionen ved, hvem der kommer, hvornår, og hvem der har ansvaret for gæsten. |
| Interessenter | Medarbejder: Vil hurtigt kunne oprette besøget uden papirarbejde. <br>Gæst: Vil blive taget imod hurtigt uden at skulle skrive sig ind i en papir gæstebog. <br>Reception: Vil have en korrekt og læsbar liste over dagens forventede gæster. <br>HYDAC: Vil kunne dokumentere, hvem der har besøgt virksomheden, hvornår, og hvem der var ansvarlig. |
| Før-tilstand | Medarbejderen er oprettet i systemet (UC01). <br>Medarbejderen er logget ind. <br>Medarbejderen har aftalt et besøg med gæsten. |
| Efter-tilstand | Besøget er gemt med gæstens navn, firma, dato, forventet ankomsttid, forventet afgangstid, lokale, ansvarlig og en indtjekningskode. <br>Besøget har status "Ikke Tjekket Ind" og vises på gæstelisten for den pågældende dato. |
| Hovedscenarie | 1. Medarbejderen vælger at oprette et nyt besøg. <br>2. Systemet beder om gæstens navn, firma, dato, forventet ankomsttid, forventet afgangstid, lokale samt den ansvarlige. <br>3. Medarbejderen indtaster de efterspurgte oplysninger. <br>4. Systemet gemmer besøget på gæstelisten og viser besøgets indtjekningskode. |
| Udvidelser | Medarbejderen fortryder <br>- Systemet gemmer ikke besøget og vender tilbage til menuen. <br>Navn eller firma er ikke udfyldt <br>- Systemet viser fejlen "Navn og firma skal udfyldes". <br>Dato eller tid har forkert format <br>- Systemet viser fejlen og et eksempel på korrekt format. <br>Datoen ligger i fortiden <br>- Systemet viser fejlen "Datoen må ikke ligge før i dag". <br>Forventet afgangstid ligger før forventet ankomsttid <br>- Systemet viser fejlen "Afgangstid skal være efter ankomsttid". <br>Den ansvarlige findes ikke <br>- Systemet viser fejlen "Vælg en oprettet medarbejder som ansvarlig". |
| Specielle krav | Dato indtastes i formatet dd-mm-åååå og tid i formatet tt:mm. <br>Systemet gemmer kun de persondata, der er nødvendige for besøget (GDPR). |
