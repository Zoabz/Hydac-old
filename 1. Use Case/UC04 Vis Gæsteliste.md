# **✅**Use case : Vis gæsteliste

| Felt | Hvad skriver vi |
| :---- | :---- |
| Nummer | UC04 |
| Use case navn | Vis gæsteliste |
| Virkefelt | HYDACs komme-gå-system |
| Niveau | Brugermål |
| Primær aktør | Medarbejder (typisk receptionen) |
| Mål | Medarbejderen får vist de registrerede besøg, så dagens gæster og personer i huset kan overskues. |
| Interessenter | Reception: Vil have en korrekt og læsbar liste over dagens forventede gæster. <br>Beredskab/AMO: Vil kunne se, hvem der er i huset, ved en evakuering. <br>Medarbejder: Vil kunne kontrollere, at sit eget besøg er registreret rigtigt. <br>HYDAC: Vil kunne dokumentere besøg bagudrettet. |
| Før-tilstand | Medarbejderen er logget ind. <br>Der er oprettet mindst ét besøg i systemet (UC02). |
| Efter-tilstand | Gæstelisten er vist. |
| Hovedscenarie | 1. Medarbejderen vælger at se gæstelisten og angiver en dato. <br>2. Systemet finder besøgene på datoen. <br>3. Systemet viser gæstelisten med indtjekningskode, navn, firma, dato, forventet ankomsttid, forventet afgangstid, lokale, ansvarlig, status, indtjekningstid, udtjekningstid og om sikkerhedsfolderen er modtaget. |
| Udvidelser | Medarbejderen fortryder <br>- Systemet vender tilbage til menuen uden at vise listen. <br>Der angives ingen dato <br>- Systemet viser alle besøg. <br>Der er ingen besøg på den valgte dato <br>- Systemet viser beskeden "Ingen forventede gæster". <br>Datoen har forkert format <br>- Systemet viser fejlen og et eksempel på korrekt format. |
| Specielle krav | Listen skal læses hurtigt ved en evakuering. <br>Systemet viser kun de persondata, der er nødvendige for besøget (GDPR). |
