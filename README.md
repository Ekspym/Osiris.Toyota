# **Osiris.Toyota.Core - Dokumentace k úkolu**

## **Úvod**
Tento projekt představuje **jednotné jádro** pro integraci s externími systémy (T1 a případně další). Vznikl jako řešení problému s duplicitním kódem a nekonzistentními integracemi.

## **Aktuální stav**
✅ **Hotové:**
- Základní rozhraní pro autentizaci, správu systémů a komunikaci
- Implementace pro T1 systém
- Modulární architektura

🛠 **Ve vývoji:**
- Automatická registrace modulů
- Rozšířená konfigurace z appsettings.json

## **Hlavní komponenty**

### **1. Autentizace (`IAuthStrategy`)**
```csharp
// Příklad použití:
await _authStrategy.ApplyAuthorizationAsync(request, system);
```

### **2. Správa externích systémů**
```csharp
// Získání connectoru
var connector = _registry.GetByName("T1");
```

## **Další kroky**
- Dokončit automatickou registraci modulů
- Rozšířit testování
- Doplnit dokumentaci pro vývojáře

**Poslední aktualizace:** 6. 8. 2025
