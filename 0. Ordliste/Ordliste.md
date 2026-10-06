# Ordliste – HYDACs komme-gå-system

Ordlisten er projektets røde tråd. Hvert begreb har ét navn, og det navn bruges i alle artefakter fra use case til kode. Står et ord i kolonnen "Brug ikke", skal det skiftes ud med begrebet til venstre.

Når I skriver noget nyt, så slå ordet op her først. Mangler det, så tilføj det her, før I bruger det.

## Begreber

| Begreb | Betydning | Analyse (UC, domænemodel, SSD, SOC) | Design og kode (DCD, C#) | Brug ikke |
| :---- | :---- | :---- | :---- | :---- |
| Komme-gå-system | Det system, vi udvikler. | "HYDACs komme-gå-system" (virkefelt i alle UC) | `namespace Hydac`, menutitel "HYDAC Komme-gå-system" | gæstebogssystem |
| Medarbejder | HYDAC-ansat, der er oprettet i systemet. Primær aktør i alle use cases og ansvarlig for besøg. | Aktør `Medarbejder`, klassen `Medarbejder` | `class Medarbejder` | bruger, ansat |
| Brugernavn | Medarbejderens navn i systemet. Bruges til at logge ind og til at angive den ansvarlige. | `Medarbejder.brugernavn` | `Medarbejder.Brugernavn` | navn (om en medarbejder) |
| Kode | Medarbejderens personlige login-kode. Vises aldrig på lister. | `Medarbejder.kode` | `Medarbejder.kode` (privat), `TjekKode(kode)` | adgangskode, password |
| Logge ind / logge ud | Medarbejderen identificerer sig med brugernavn og kode. | "Medarbejderen er logget ind" (før-tilstand) | `Menu.LogInd()`, `Menu.LogUd()`, `erLoggetInd`, `aktivMedarbejder` | login, log on |
| Medarbejderliste | Listen over alle oprettede medarbejdere. | UC03 Vis medarbejderliste | `Menu.medarbejderliste`, `Menu.VisMedarbejderliste()` | MedarbejderListe, medarbejdere, "Liste af medarbejder" |
| Gæst | Ekstern person, der besøger HYDAC. | Klassen `Gæst` | Foldet ind i `Besøg` (se nedenfor) | besøgende |
| Navn | Gæstens fulde navn. | `Gæst.navn`, parameteren `navn` | `Besøg.GæstNavn` | Gæst (som attribut), Navn (på Besøg) |
| Firma | Det firma, gæsten kommer fra. | `Gæst.firma` | `Besøg.Firma` | virksomhed |
| Besøg | Ét aftalt besøg fra én gæst på én dato. | Klassen `Besøg` | `class Besøg` | gæstebesøg |
| Ansvarlig | Den medarbejder, der har ansvaret for gæsten under besøget. | Associationen "Medarbejder ansvarlig for Besøg", parameteren `ansvarlig` | `Besøg.Ansvarlig : Medarbejder` | vært, kontaktperson |
| Dato | Den dag, besøget finder sted. | `Besøg.dato` | `Besøg.Dato` | Date |
| Forventet ankomsttid | Det klokkeslæt, gæsten forventes at ankomme. | `Besøg.forventet ankomsttid`, parameteren `forventetAnkomsttid` | `Besøg.ForventetAnkomsttid` | ankomst, ankomst tid, ank/afg tidspunkt, ForventetAnkomst |
| Forventet afgangstid | Det klokkeslæt, gæsten forventes at gå. | `Besøg.forventet afgangstid`, parameteren `forventetAfgangstid` | `Besøg.ForventetAfgangstid` | sluttid, afrejse, afgang, afgangs tid, ForventetAfgang |
| Lokale | Det lokale, besøget foregår i. | `Besøg.lokale` | `Besøg.Lokale` | rum |
| Indtjekningskode | 8-cifret kode, som systemet giver besøget, når det oprettes. Bruges ved tjek ind og tjek ud. | `Besøg.indtjekningskode` | `Besøg.Indtjekningskode : int`, `Menu.GenererIndtjekningskode()` | gæstID, kode (om besøget), indtjekning kode, IndtjekningsKode |
| Status | Hvor langt besøget er nået. Kan kun have de tre værdier nedenfor. | `Besøg.status` | `Besøg.Status` | Besøgs_Status |
| Tjek ind / indtjekning | Gæsten registreres som ankommet. | UC05 Tjek gæst ind, klassen `Indtjekning` | `Besøg.TjekInd(sikkerhedsfolderModtaget)`, `Menu.TjekInd()` | check ind, indtjek |
| Indtjekningstid | Det faktiske tidspunkt, gæsten blev tjekket ind. | `Indtjekning.indtjekningstid` | `Besøg.Indtjekningstid : DateTime?` | indtjeknings tid, indtjektid, IndTjekTid, tjekketIndTidspunkt, ankomsttidspunkt |
| Sikkerhedsfolder | Folder med sikkerhedsinformation, som gæsten får ved indtjekning. | "sikkerhedsfolderen" | – | folder (alene) |
| Sikkerhedsfolder modtaget | Om gæsten har modtaget sikkerhedsfolderen (ja/nej). | `Indtjekning.sikkerhedsfolder modtaget` | `Besøg.SikkerhedsfolderModtaget : bool` | sikkerhedsfolder modtagelse, Sikkerhedsfolder (som bool), SF |
| Tjek ud / udtjekning | Gæsten registreres som gået. | UC06 Tjek gæst ud, klassen `Udtjekning` | `Besøg.TjekUd()`, `Menu.TjekUd()` | check ud, udtjek |
| Udtjekningstid | Det faktiske tidspunkt, gæsten blev tjekket ud. | `Udtjekning.udtjekningstid` | `Besøg.Udtjekningstid : DateTime?` | udtjeknings tid, udtjektid, UdTjekTid, tjekketUdTidspunkt |
| Gæsteliste | Listen over alle oprettede besøg. Vises i UC04. | UC04 Vis gæsteliste | `Menu.gæsteliste : List<Besøg>`, `Menu.VisGæsteliste()` | BesøgListe, besøgsListe, "Liste Besøg", "Vis besøg" |
| Personer i huset | Gæster, hvis besøg har status "Tjekket Ind". | UC05, UC06 | Besøg på gæstelisten med `Status == Besøg.TjekketInd` | – |
| Reception, Beredskab/AMO | Interessenter i use cases. De er ikke aktører; det er altid en medarbejder, der bruger systemet. | Interessenter | – | – |

## Status

Et besøg går altid igennem de samme tre statusværdier i denne rækkefølge. Værdierne skrives præcis sådan, også med store bogstaver.

| Status | Sættes af | Konstant i koden |
| :---- | :---- | :---- |
| "Ikke Tjekket Ind" | UC02 Opret besøg | `Besøg.IkkeTjekketInd` |
| "Tjekket Ind" | UC05 Tjek gæst ind | `Besøg.TjekketInd` |
| "Tjekket Ud" | UC06 Tjek gæst ud | `Besøg.TjekketUd` |

## Fra domænemodel til design

Domænemodellen har fem klasser: Medarbejder, Besøg, Gæst, Indtjekning og Udtjekning. Designet har kun to domæneklasser: Medarbejder og Besøg. Gæst, Indtjekning og Udtjekning har ingen identitet uden for ét besøg, så de er foldet ind i Besøg som attributter:

| Domænemodel | Design og kode |
| :---- | :---- |
| `Gæst.navn` | `Besøg.GæstNavn` |
| `Gæst.firma` | `Besøg.Firma` |
| `Indtjekning.indtjekningstid` | `Besøg.Indtjekningstid` |
| `Indtjekning.sikkerhedsfolder modtaget` | `Besøg.SikkerhedsfolderModtaget` |
| `Udtjekning.udtjekningstid` | `Besøg.Udtjekningstid` |

Associationen "Medarbejder ansvarlig for Besøg" bliver til `Besøg.Ansvarlig : Medarbejder`. `Menu` er controller og UI og findes kun i designet.

## Fra use case til kode

| Use case | Systemoperation (SSD og SOC) | Menupunkt | Menu-metode | Domænemetode |
| :---- | :---- | :---- | :---- | :---- |
| UC01 Opret medarbejder | `opretMedarbejder(brugernavn, kode)` | 2. Opret medarbejder | `OpretMedarbejder()` | `new Medarbejder(brugernavn, kode)` |
| UC02 Opret besøg | `opretBesøg(navn, firma, dato, forventetAnkomsttid, forventetAfgangstid, lokale, ansvarlig)` (CO1) | 3. Opret besøg | `OpretBesøg()` | `new Besøg(...)` |
| UC03 Vis medarbejderliste | `visMedarbejderliste(brugernavn)` | 4. Vis medarbejderliste | `VisMedarbejderliste()` | – |
| UC04 Vis gæsteliste | `visGæsteliste(dato)` | 5. Vis gæsteliste | `VisGæsteliste()` | – |
| UC05 Tjek gæst ind | `tjekInd(indtjekningskode)`, `angivSikkerhedsfolderModtaget(ja/nej)` | 6. Tjek gæst ind | `TjekInd()` | `Besøg.TjekInd(sikkerhedsfolderModtaget)` |
| UC06 Tjek gæst ud | `tjekUd(indtjekningskode)` | 7. Tjek gæst ud | `TjekUd()` | `Besøg.TjekUd()` |

Log ind er en før-tilstand og ikke en use case (den består ikke Boss-testen), men den findes som menupunkt 1 og `Menu.LogInd()`.

## Skrivemåde

- **Analyse** (use cases, domænemodel, objektmodel, SOC-tekst): almindelige danske ord med små bogstaver. Sammensatte ord skrives i ét ord: indtjekningskode, ankomsttid, gæsteliste.
- **Systemoperationer** (SSD og SOC): camelCase og starter med et udsagnsord, fx `opretBesøg(...)`. SSD og SOC bruger præcis samme navn og parametre.
- **C#**: klasser, properties og metoder i PascalCase, felter, parametre og lokale variabler i camelCase. Navnet er det samme ord som i analysen: forventet ankomsttid → `ForventetAnkomsttid`.
- **Use case-navne** er de samme i filnavne, diagramtitler og tekst: "UC02 Opret besøg", "UC05 Tjek gæst ind". Filen til den use case, synopsen fokuserer på, har præfikset `Aktiv_`.
- **Dato og tid** indtastes som `dd-MM-yyyy` (fx 30-09-2026) og `HH:mm` (fx 12:00).

## Mappestruktur

Mapperne følger processen fra analyse over design til kode:

| Mappe | Indhold | Fase |
| :---- | :---- | :---- |
| 0. Ordliste | Denne ordliste | – |
| 1. Use Case | UC01–UC06 | Analyse |
| 2. Domænemodel | Konceptuelle klasser | Analyse |
| 3. Objekt Model | Øjebliksbillede af domænemodellen | Analyse |
| 4. System Sekvens Diagram | Ét SSD pr. use case | Analyse |
| 5. Systemoperationskontrakt | CO1 opretBesøg | Analyse |
| 6. Sekvens Diagram | SD for UC02 Opret besøg | Design |
| 7. Design Class Diagram | DCD | Design |
| 8. Program | C#-kode og unit tests | Kode |
| 9. Synopsis | Synopsen | – |
