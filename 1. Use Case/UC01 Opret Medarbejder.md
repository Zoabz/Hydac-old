# **✅**Use case : Opret medarbejder

| Felt | Hvad skriver vi |
| :---- | :---- |
| Nummer | UC01 |
| Use case navn | Opret medarbejder |
| Virkefelt | HYDACs komme-gå-system |
| Niveau | Brugermål |
| Primær aktør | Medarbejder |
| Mål | Medarbejderen opretter en ny kollega med brugernavn og kode, så kollegaen kan logge ind og stå som ansvarlig for besøg. |
| Interessenter | Medarbejder: Vil hurtigt kunne oprette en kollega. <br>Ny medarbejder: Vil kunne logge ind og oprette sine egne besøg. <br>HYDAC: Vil have, at kun oprettede medarbejdere kan bruge systemet. |
| Før-tilstand | Medarbejderen er logget ind. |
| Efter-tilstand | Medarbejderen er gemt med brugernavn og kode og vises på medarbejderlisten. |
| Hovedscenarie | 1. Medarbejderen vælger at oprette en ny medarbejder. <br>2. Systemet beder om brugernavn og kode. <br>3. Medarbejderen indtaster brugernavn og kode. <br>4. Systemet gemmer medarbejderen og viser bekræftelsen. |
| Udvidelser | Brugernavn eller kode er ikke udfyldt <br>- Systemet viser fejlen "Brugernavn og kode skal udfyldes". <br>Brugernavnet findes allerede <br>- Systemet viser fejlen "Brugernavnet findes allerede". |
| Specielle krav | Koden vises aldrig på medarbejderlisten. <br>Systemet gemmer kun de persondata, der er nødvendige for at identificere medarbejderen (GDPR). |
