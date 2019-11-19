# Instrukcja uruchomienia aplikacji

Aby móc uruchomić aplikację działającą w oparciu o technologię Docker, należy posiadać silnik Dockera zainstalowany na swojej maszynie. W tym celu konieczne jest pobranie i zainstalowanie Docker Desktop (Windows oraz Mac) - https://www.docker.com/products/docker-desktop . W przypadku instalacji Dockera na Linuxie, można skorzystać z informacji dostępnych pod tym linkiem - https://docs.docker.com/install/ . Z racji tego, iż aplikacja jest wielokontenerowa, konieczne jest zainstalowanie narzędzia Docker Compose. Docker Desktop zawiera już pakiet Docker Compose, natomiast w przypadku Linuxa trzeba go osobno zainstalować.

Po zainstalowaniu niezbędnych narzędzi, można pobrać kod aplikacji do lokalnego repozytorium i uruchomić go za pomocą Docker Compose. W tym celu należy włączyć terminal i przejść pod adres, gdzie znajduje się folder pobranego projektu z plikiem docker-compose.dcproj . Następnie w linii poleceń należy wpisać komendę: 

> docker-compose up 

Docker utworzy kontenery i aplikacja urchomi się na porcie 4433. Należy wówczas otworzyć przeglądarkę i przejść pod adres https://localhost:4433/ gdzie aplikacja będzie działać. 
