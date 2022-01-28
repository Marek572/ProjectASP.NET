# ProjectASP.NET

1. Utworzyc migracje dla ApplicatinDbContext i AppIdentityDbContext
2. Aplikacja po włączeniu ukazuje stronę główną. 
3. Należy zalogować się na konto Admina (login: "daisy.diaz", haslo: "zaq1@wsxC") klikając w przycisk "Login", aby mieć dostęp do wszystkich funkcji. Admin ma dostęp do:
  - wyświetlenia listy użytkownikow ("User list"), w której widoczne są wszystkie dane zarejerstrowanych użytkowników,
  - edycji poszczególnych użytkowników za pomocą zielonego przycisku edit lub usuwania czerwonym przyciskiem delete,
  
  - wyświetlania listy gier ("Game list"), w której widoczne są wszystkie dane dodanych gier,
  - dodania nowej gry za pomoca "Add Game"
  - edycji poszczególnych gier za pomocą zielonego przycisku edit lub usuwania czerwonym przyciskiem delete.
  
4. Możliwe jest także zalogowanie się na konto zwykłego użytkownika (np. login: "callie.noris", hasło: "zaq1@wsxC"). User ma dostęp do:
  - wyświetlenia listy użytkownikow ("User list"), w której widoczne są cześciowe dane zarejerstrowanych użytkowników,
   
  - wyświetlania listy gier ("Game list"), w której widoczne są wszystkie dane dodanych gier (bez widoczności kto aktualnie posiada grę),

5. Jeśli chcemy utworzyć nowego użytkownika musimy kliknąć w przycisk "Register". Po rejerstracji user bedzie od razu zalogowany.

6. Aby dostać się do api należy przejść pod adres http://localhost:21478/api/games (Filter: login: "Admin", hasło: "zaq1@wsxC")
