# **✅**Use case : Tjek gæst ud

| Felt | Hvad skriver vi |
| :---- | :---- |
| Nummer | UC06 |
| Use case navn | Tjek gæst ud |
| Virkefelt | HYDACs komme-gå-system |
| Niveau | Brugermål |
| Primær aktør | Medarbejder |
| Mål | Medarbejderen registrerer, at gæsten har forladt virksomheden, så besøget afsluttes og gæsten ikke længere står som værende i huset. |
| Interessenter | Gæst: Vil kunne gå hjem uden besvær. <br>Reception: Vil have en liste, der kun indeholder de gæster, der faktisk er i huset. <br>Beredskab/AMO: Vil ikke lede efter personer, der for længst er gået hjem. <br>HYDAC: Vil kunne dokumentere udtjekningstiden. |
| Før-tilstand | Besøget har status "Tjekket Ind" (UC05). <br>Gæsten er på vej ud af virksomheden. |
| Efter-tilstand | Besøget har status "Tjekket Ud", og udtjekningstiden er registreret. |
| Hovedscenarie | 1. Medarbejderen indtaster besøgets indtjekningskode. <br>2. Systemet finder besøget, gemmer udtjekningstiden og ændrer status til "Tjekket Ud". <br>3. Systemet viser bekræftelsen. |
| Udvidelser | Medarbejderen fortryder <br>- Systemet ændrer ikke status og vender tilbage til menuen. <br>Indtjekningskoden findes ikke <br>- Systemet viser fejlen "Besøget blev ikke fundet". <br>Besøget er ikke tjekket ind <br>- Systemet viser beskeden "Gæsten er ikke tjekket ind" og ændrer ikke status. <br>Besøget er allerede tjekket ud <br>- Systemet viser beskeden "Gæsten er allerede tjekket ud". <br>Gæsten er ikke tjekket ud ved dagens slutning <br>- Systemet markerer besøget, så receptionen kan følge op. |
| Specielle krav | Udtjekning skal kunne gennemføres hurtigt. <br>Systemet gemmer kun de persondata, der er nødvendige for besøget (GDPR). |
