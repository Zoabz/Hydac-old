# Ordliste

Ordlisten er facit for, hvad tingene hedder. Står et ord i "Brug ikke", skal det rettes, hvor det findes. Er I uenige i et valg, så ret ordlisten først og derefter artefakterne, aldrig omvendt.

Konvention for navne på tværs af artefakter:

| Hvor | Form | Eksempel |
| :---- | :---- | :---- |
| Use case-tekst | almindelig dansk, små bogstaver | forventet afgang |
| Domænemodel og objektmodel | samme som use case-tekst | forventet afgang |
| SSD, kontrakter, parametre | camelCase | `forventetAfgang` |
| C# klasser, properties, metoder | PascalCase | `ForventetAfgang` |
| C# private felter, lokale variable | camelCase | `forventetAfgang` |

Det er det samme ord. Kun skrivemåden følger konteksten.

---

## Fagbegreber

| Begreb | Definition | I koden | Brug ikke |
| :---- | :---- | :---- | :---- |
| **Komme-gå-system** | Det system, vi bygger. Registrerer gæsters besøg hos HYDAC fra oprettelse til tjek ud. | `KommeGåSystem` (controller), namespace `Hydac` | "systemet" er fint i løbende tekst |
| **Medarbejder** | En ansat hos HYDAC, der er oprettet i systemet og kan logge ind. Den eneste aktør. | `Medarbejder` | bruger, admin, user |
| **Brugernavn** | Medarbejderens unikke navn. Bruges til log ind og vises som ansvarlig på gæstelisten. | `Medarbejder.Brugernavn` | navn (om medarbejder), medarbejderID, medarbejder (som attribut) |
| **Adgangskode** | Medarbejderens hemmelige kode til log ind. Vises aldrig på skærmen. | `Medarbejder.adgangskode` (private) | kode, password |
| **Ansvarlig** | Den medarbejder, der står for et besøg. En *rolle* en medarbejder har i forhold til et besøg, ikke en selvstændig klasse. | `Besøg.Ansvarlig : Medarbejder` | kontaktperson, vært, ansvarlig som tekststreng |
| **Reception** | Medarbejdere, der tager imod gæster. En rolle, ikke en aktør eller klasse. | findes ikke | |
| **Gæst** | En person udefra, der besøger HYDAC. | `Gæst` | besøgende (som klassenavn), kunde |
| **Navn** | Gæstens navn. Bruges kun om gæster. | `Gæst.Navn` | |
| **Firma** | Det firma, gæsten kommer fra. En tekst, ikke en klasse. | `Gæst.Firma : string` | `Firma` som type |
| **Besøg** | Én gæsts aftalte ophold hos HYDAC på et bestemt tidspunkt, med én ansvarlig medarbejder. | `Besøg` | gæstebesøg, registrering, aftale |
| **Forventet ankomst** | Dato og klokkeslæt, gæsten forventes at ankomme. Ét felt, ikke to. | `Besøg.ForventetAnkomst : DateTime` | ankomsttid, ank tidspunkt, forventet ankomst tid, dato (som separat felt) |
| **Forventet afgang** | Dato og klokkeslæt, gæsten forventes at gå. | `Besøg.ForventetAfgang : DateTime` | sluttid, afgangstid, afrejse, forventet afgangs tid |
| **Faktisk ankomst** | Tidspunktet, gæsten blev tjekket ind. Sættes af systemet. | `Besøg.FaktiskAnkomst : DateTime?` | reél ankomst tid, Indtjekning.tidspunkt |
| **Faktisk afgang** | Tidspunktet, gæsten blev tjekket ud. Sættes af systemet. | `Besøg.FaktiskAfgang : DateTime?` | Udtjekning.tidspunkt |
| **Lokale** | Det mødelokale, besøget foregår i. | `Besøg.Lokale : string` | |
| **Indtjekningskode** | Et unikt tal, systemet laver, når et besøg oprettes. Identificerer besøget ved tjek ind og tjek ud. Hører til besøget, ikke til gæsten. | `Besøg.Indtjekningskode : int` | kode, gæstID, besøgsID, IndtjekningsKode (stort K), indtjekning kode |
| **Sikkerhedsfolder** | Folder med sikkerheds- og evakueringsinformation, som gæsten får udleveret ved tjek ind. | findes kun som attributten nedenfor | |
| **Sikkerhedsfolder modtaget** | Ja/nej: har gæsten fået sikkerhedsfolderen? Registreres ved tjek ind. | `Besøg.SikkerhedsfolderModtaget : bool` | Sikkerhedsfolder (som bool-navn), sikkerhedsfolder modtagelse |
| **Besøgsstatus** | Hvor langt et besøg er. Altid én af tre værdier: **Ikke Tjekket Ind**, **Tjekket Ind**, **Tjekket Ud**. | `enum BesøgsStatus { IkkeTjekketInd, TjekketInd, TjekketUd }` | status som bool eller string, Besøgs_Status |
| **Tjek ind** | Handlingen, hvor en ankommet gæst registreres. Ændrer status fra Ikke Tjekket Ind til Tjekket Ind. | `TjekInd(...)` | indtjekning (som klasse), check in |
| **Tjek ud** | Handlingen, hvor en gæst, der går, registreres. Ændrer status fra Tjekket Ind til Tjekket Ud. | `TjekUd(...)` | udtjekning (som klasse), check out |
| **Gæsteliste** | Visningen af alle besøg med gæst, firma, forventet ankomst og afgang, lokale, ansvarlig og status (UC04). | `HentGæsteliste()`, menupunktet "Vis gæsteliste" | besøgsliste i tekst, "Vis besøg", Liste Besøg, `ListeBesøg` |
| **Besøgsliste** | Kun navnet på den interne liste i koden, som gæstelisten bygges af. Bruges ikke i use cases eller domænemodel. | `KommeGåSystem.besøgsliste` | |
| **Medarbejderliste** | Visningen af alle oprettede medarbejderes brugernavne (UC03). | `HentMedarbejderliste()`, internt `medarbejderliste` | Liste af Medarbejder, `ListeMedarbejder` |
| **Personer i huset** | Gæster med status Tjekket Ind. Det er dem, beredskabet skal finde ved en evakuering. | filter på `Status == TjekketInd` | |
| **Log ind** | Medarbejderen identificerer sig med brugernavn og adgangskode. Kræves for alle andre funktioner. | `LogInd(...)` | login (i dansk tekst) |
| **Aktiv medarbejder** | Den medarbejder, der er logget ind lige nu. | `KommeGåSystem.aktivMedarbejder` | |
| **Fortryd** | Medarbejderen afbryder en handling. Sker ved tom indtastning (Enter). Intet gemmes. | | |
| **Beredskab / AMO** | Interessent. AMO er arbejdsmiljøorganisationen, der har ansvar for evakuering. | findes ikke | |
| **GDPR** | EU's databeskyttelsesforordning. For os betyder den: gem kun navn og firma om gæster, og vis kun det nødvendige. | | |

---

## Metodebegreber

Til rapporten. Brug ordene præcist, censor lægger mærke til det.

| Begreb | Betydning i vores projekt |
| :---- | :---- |
| **Aktør** | En rolle uden for systemet, der bruger det. Vi har én: Medarbejder. |
| **Interessent** | En, der har interesse i systemet uden nødvendigvis at bruge det: gæst, reception, beredskab/AMO, HYDAC. |
| **Use case** | En beskrivelse af, hvordan en aktør når et mål med systemet. Vores er skrevet som "fully dressed". |
| **Brugermål / delfunktion** | Niveau. Brugermål: aktøren vil det for sin egen skyld (opret besøg). Delfunktion: bruges kun som del af en anden use case (vis medarbejderliste, når ansvarlig vælges). |
| **Før-tilstand / efter-tilstand** | Hvad der skal være sandt, før use casen kan starte, og hvad der er sandt, når den er gennemført. |
| **Hovedscenarie** | Den normale, fejlfri vej gennem use casen. |
| **Udvidelse** | En afvigelse fra hovedscenariet, med en betingelse og systemets reaktion. Hver udvidelse knyttes til et trin i hovedscenariet. |
| **Domænemodel** | Model af begreberne i virkeligheden: klasser, attributter, associationer. Ingen datatyper, ingen metoder. |
| **Objektmodel** | Et øjebliksbillede af konkrete instanser af domænemodellens klasser. |
| **SSD (systemsekvensdiagram)** | Viser, hvilke systemoperationer aktøren kalder, og hvad systemet svarer. Systemet er en sort boks. |
| **Systemoperation** | En hændelse fra aktøren til systemet, fx `opretBesøg(...)`. Den røde tråds rygrad. |
| **Kontrakt (SOC)** | Beskriver en systemoperations virkning: forudsætninger og slutbetingelser i form af oprettede instanser, ændrede attributter og dannede associationer. |
| **Sekvensdiagram (SD)** | Viser, hvordan objekterne samarbejder om at udføre én systemoperation. |
| **DCD (designklassediagram)** | Klasserne i softwaren med datatyper, synlighed, metoder og navigerbare associationer. |
| **GRASP** | Principper for at fordele ansvar mellem klasser. Vi bruger Controller, Creator og Information Expert. |
| **Controller** | Klassen, der modtager systemoperationer fra brugergrænsefladen. Hos os `KommeGåSystem`. |
| **Creator** | Klassen, der indeholder eller samler objekter af en type, opretter dem. `KommeGåSystem` opretter `Besøg`, `Besøg` opretter `Gæst`. |
| **Information Expert** | Ansvaret gives til den klasse, der har informationen. `Besøg` ændrer sin egen status. |
| **Sporbarhed** | At man kan følge et krav fra use case til kode og tilbage. Det, "rød tråd" betyder fagligt. |
| **Supplerende specifikation** | Krav, der gælder på tværs af use cases (GDPR, datoformat, platform). |
