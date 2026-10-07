# **✅**Use case : Vis medarbejderliste

| Felt | Hvad skriver vi |
| :---- | :---- |
| Nummer | UC03 |
| Use case navn | Vis medarbejderliste |
| Virkefelt | HYDACs komme-gå-system |
| Niveau | Subfunktion (delmål – indgår i UC02) |
| Primær aktør | Medarbejder |
| Mål | Medarbejderen får vist de oprettede medarbejdere, fx for at finde den ansvarlige til et besøg. |
| Interessenter | HYDAC: Vil have overblik over, hvem der er oprettet i systemet. |
| Før-tilstand | Medarbejderen er logget ind. <br>Der er oprettet mindst én medarbejder i systemet (UC01). |
| Efter-tilstand | Medarbejderlisten er vist. |
| Hovedscenarie | 1. Medarbejderen vælger at se medarbejderlisten og angiver evt. et brugernavn at søge efter. <br>2. Systemet finder de medarbejdere, der er oprettet. <br>3. Systemet viser medarbejderlisten med brugernavn. |
| Udvidelser | Medarbejderen fortryder <br>- Systemet vender tilbage til menuen uden at vise listen. <br>Der angives intet brugernavn <br>- Systemet viser alle oprettede medarbejdere. <br>Ingen medarbejdere matcher søgningen <br>- Systemet viser beskeden "Ingen medarbejdere fundet". <br>Der er ingen medarbejdere i systemet <br>- Systemet viser beskeden "Der er endnu ikke oprettet nogen medarbejdere". |
| Specielle krav | Koder vises aldrig på listen. <br>Listen viser kun de oplysninger, der er nødvendige for at identificere den ansvarlige (GDPR). |
