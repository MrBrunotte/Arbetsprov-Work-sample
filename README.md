# Gisys - Arbetsprov

## Uppgift

Du ska bygga en applikation som hämtar data från ett externt API och presentera på ett snyggt sätt.

## Vyer

#### Alla anställda

En vy på alla anställda där man ser namnet på varje anställd där man kan klicka för att komma till den anställdes vy.

##### API

[All employees](http://dummy.restapiexample.com/api/v1/employees)
   

#### Specifik anställd

En vy där man ser all information om den anställde

##### API

[One employee (#2)](http://dummy.restapiexample.com/api/v1/employee/2)

**<em>Note:** Ibland behöver man ladda om länken i browsern för att den ska fungera.</em>

## Saker som bör göras

- Error handling bör fixas
- Implementera rätt view för errors (ErrorMessage.cshtml)
- SingleEmployee() bör int vara en List<> eftersom det endast är en person
