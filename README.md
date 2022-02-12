# Popis aplikace
Aplikace slouží k evidenci parametrů laboratorních vyšetření a zařízení, která se k nim používají.

## Serverová část - složka server
Repo obsahuje zdrojový kód pro c# server.
Server má dvě api: "exam" a "device" s CRUD metodami. Nepsala jsem "GetOne" metody, protože v aplikaci nejsou potřeba.
Vycházela jsem z toho, že klienta mám pod kontrolou, takže jsem nedělala validaci vstupu a případné chybové stavy - kdyby to bylo rozhodující, dodělám to.

### TO DO:
Must have:

Nice to have:
- validace vstupu
- chybové hlášky
- sladit pojmenování souborů a repa

## Klient - složka client
### TO DO:
Must have:
- v exams při zadávání vyšetření umožnit vstup hodnot pro typ vyšetření jenom z api /exam/GetExamTypes, a device z api /device/GetDevices aby byla zachovaná integrita v databázi (cizí klíč), nejlépe nějakou roletou
- v devices dodělat date picker pro datum, aby tam nešlo zadat nic jiného nebo null, a aby to bylo pěkné

Nice to have:
- sladit pojmenování souborů a repa

## Databáze
Obsahuje soubor pro sestavení databáze a nějaká ukázková data.



