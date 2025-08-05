# **Osiris.Toyota.Core - Dokumentace**

## **Základní rozhraní**

### **IAuthStrategy**
- **Účel:** Přidává autorizaci do HTTP požadavků  
- **Použití:**  
  ```csharp
  await _authStrategy.ApplyAuthorizationAsync(request, system);
  ```

### **IEventDispatcher**
- **Účel:** Odesílá notifikační události  
- **Příklad:**  
  ```csharp
  await _dispatcher.Dispatch(new NotificationEvent(...));
  ```

### **IEventSubscriber**
- **Funkce:**  
  - `SubscribeAsync` - Přidá odběr událostí  
  - `UnsubscribeAsync` - Zruší odběr  
  - `NotifyAsync` - Ruční notifikace  

### **IExternalSystemRegistry**
- **Správa externích systémů:**  
  ```csharp
  _registry.GetByName("Toyota"); // Získá konfiguraci
  _registry.AddOrUpdate(system); // Aktualizuje registr
  ```

### **IGenericMapper**
- **Mapování objektů:**  
  ```csharp
  var dto = _mapper.Map<Entity, Dto>(entity);
  ```

### **IExternalSystemConnector**
- **Komunikace s API:**  
  ```csharp
  var response = await _connector.SendRequestAsync<Response>(HttpMethod.Get, "/api/data");
  ```

---

## **Jak přidat nový systém?**
1. Vytvořte connector (implementuje `IExternalSystemConnector`)
2. Zaregistrujte v `ExternalSystemRegistry`:
   ```csharp
   registry.AddOrUpdate(new ExternalSystem { 
     Name = "Ford", 
     AuthType = AuthType.OAuth2 
   });
   ```

---

## **Konfigurace**
Nastavení systémů lze načíst z:
```json
// appsettings.json
{
  "ExternalSystems": {
    "Toyota": {
      "AuthType": "OAuth2",
      "BaseUrl": "https://api.toyota.com"
    }
  }
}
```

---

## **Testování**
```csharp
// Unit test pro auth strategii
[Test]
public void AuthStrategy_Adds_Correct_Headers()
{
    var request = new HttpRequestMessage();
    await _strategy.ApplyAuthorizationAsync(request, system);
    Assert.NotNull(request.Headers.Authorization);
}
```

---

**Stručné, jasné, bez zbytečností.**  
Potřebujete doplnit konkrétní část?
