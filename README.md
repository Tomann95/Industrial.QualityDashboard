#  Industrial Quality Dashboard

Industrial Quality Dashboard to aplikacja webowa, służąca do monitorowania procesów kontroli jakości w środowisku przemysłowym w czasie rzeczywistym. System automatyzuje zbieranie logów z maszyn, analizuje wydajność produkcji oraz zapewnia pełną identyfikowalność produktów i operatorów.


<img width="1919" height="876" alt="image" src="https://github.com/user-attachments/assets/d5ffe9f3-aac5-4c8a-8b6e-8d2cd9c1b804" />





🚀 **Główne Funkcjonalności**


**Monitorowanie w Czasie Rzeczywistym:** Automatyczne wykrywanie nowych logów produkcyjnych dzięki usłudze FileWatcher monitorującej foldery systemowe.

**Analityka Wizualna:** Dynamiczne wykresy kołowe prezentujące stosunek wyników PASS do FAIL oraz automatyczne wyliczanie wskaźnika Yield.

<img width="1919" height="876" alt="image" src="https://github.com/user-attachments/assets/670d2826-d499-4b8c-82f9-974284de15db" />


**Pełna Identyfikowalność:** Rejestracja szczegółowych danych o każdym teście: numer seryjny (S/N), nazwa stacji (np. HV_Test, Vision_Check), czas trwania oraz przypisany operator.

<img width="1424" height="591" alt="image" src="https://github.com/user-attachments/assets/3bdf6d28-6b11-4ef8-ba18-4074eb1a3fa4" />


**Archiwizacja i Zarządzanie Plikami:** Przetworzone logi są automatycznie przenoszone do folderu Processed, a użytkownik ma do nich wgląd bezpośrednio z poziomu przeglądarki.

<img width="1919" height="878" alt="image" src="https://github.com/user-attachments/assets/20ef4263-c2df-4336-a18e-1b381467d131" />


**Raportowanie PDF:** Możliwość wygenerowania i pobrania profesjonalnego raportu technicznego dla każdego zarejestrowanego testu.

<img width="1919" height="872" alt="image" src="https://github.com/user-attachments/assets/c8117889-70f6-4e02-821e-deb2ddd1d94e" />


🛠 **Stos Techniczny (Tech Stack)**
Framework: Blazor Web App (.NET 8).

Baza Danych: Microsoft SQL Server z użyciem Entity Framework Core.

Frontend: Bootstrap 5 

Analityka: Chart.js

Ikony: Bootstrap Icons.

📊 **Struktura Projektu**
Components/Pages: Moduły interfejsu (Home, Statistics, History, Archive).

Services: Logika biznesowa, w tym LogProcessor parsujący dane oraz FileWatcherService.

Models: Definicje struktur danych (TestReport).

📝 **Format Logu Produkcyjnego**
System wspiera logi tekstowe w formacie średnikowym, co pozwala na łatwą integrację z większością sterowników PLC i systemów testowych:
SN:IQD-2026-007;Result:PASS;Station:Main_Assembly;Duration:15.2;Tester:Jan Kowalski.
