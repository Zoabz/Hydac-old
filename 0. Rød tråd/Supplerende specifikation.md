# Supplerende specifikation

Krav, der gælder for hele komme-gå-systemet og ikke hører til én bestemt use case. Opbygget efter FURPS+. Punkter markeret **Åbent** skal gruppen tage stilling til.

## Funktionalitet

- **F1.** Alle funktioner undtagen log ind kræver, at en medarbejder er logget ind.
- **F2.** Indtjekningskoden er unik blandt alle besøg i systemet.
- **F3.** Et besøg slettes ikke, når gæsten er tjekket ud. Det står på gæstelisten med status Tjekket Ud, så HYDAC kan dokumentere besøget bagudrettet.

## Brugervenlighed (Usability)

- **U1.** Al tekst på skærmen er på dansk og bruger ordene fra [`Ordliste.md`](Ordliste.md).
- **U2.** Dato og tid indtastes som `dd-MM-yyyy HH:mm`, fx `08-10-2026 09:00`. Ved forkert format vises fejlen sammen med et eksempel, og der spørges igen.
- **U3.** Tom indtastning (bare Enter) i et vilkårligt felt betyder *fortryd*: handlingen afbrydes, intet gemmes, og menuen vises igen. Det er denne regel, alle use cases henviser til i udvidelsen "Medarbejderen fortryder".
- **U4.** Menupunkterne hedder det samme som use casene (fx "Opret besøg", "Vis gæsteliste", "Tjek gæst ind").
- **U5.** Tjek ind og tjek ud kræver højst to indtastninger hver (indtjekningskode og, ved tjek ind, ja/nej til sikkerhedsfolder).
- **U6.** Fejlbeskeder ordret som i use casenes udvidelser.

## Pålidelighed (Reliability)

- **R1.** Programmet må ikke gå ned på grund af forkert input. Al indtastning valideres, før den bruges.

## Ydeevne (Performance)

- **P1.** Ingen særlige krav. Systemet håndterer under 100 besøg om dagen.

## Vedligeholdbarhed (Supportability)

- **S1.** Navne i koden følger ordlisten, så hver klasse og metode kan spores til en use case eller et diagram.
- **S2.** Klasser og metoder i koden svarer til designklassediagrammet.

## + Designbegrænsninger

- **D1.** Konsolapplikation i C# på .NET 10.
- **D2.** Ingen database.
- **D3. Åbent:** Data ligger i dag kun i hukommelsen og forsvinder, når programmet lukkes. Det er i strid med F3. Vælg én:
  - gem besøg og medarbejdere i en JSON-fil ved hver ændring (anbefalet, `System.Text.Json` er indbygget), eller
  - skriv det som en bevidst afgrænsning i rapporten.

## + Juridiske krav og sikkerhed

- **J1.** GDPR, dataminimering: om gæster gemmes kun navn og firma.
- **J2.** Adgangskoder vises aldrig på skærmen og aldrig på nogen liste.
- **J3. Åbent:** Hvor længe gemmes besøgsdata? GDPR kræver, at persondata ikke gemmes længere end nødvendigt. Forslag: 30 dage efter besøget. Hvis I ikke implementerer sletning, så skriv det som afgrænsning.
- **J4.** Adgangskoder gemmes i klartekst. Det er acceptabelt i en skoleprototype, men skal nævnes som kendt begrænsning. I et rigtigt system ville de være hashet.

## Antagelser

- **A1.** Der er altid én medarbejder ved navn Admin ved opstart, så man kan logge ind første gang.
- **A2.** Systemet køres på én computer i receptionen. Der er ikke flere samtidige brugere.
