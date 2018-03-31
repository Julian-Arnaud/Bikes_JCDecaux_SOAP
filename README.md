# Bikes_JCDecaux_SOAP

#Application console

5 commandes possibles pour l'utilisateur:
- 3 provenant du web service:
	- 1 appelle GetCities ou regarde dans le cache si la table des villes a déjà été rempli et affiche l'ensemble des villes couvertes par l'api de JC Decaux
	- 2 appelle GetStationsCity et vérifie que la ville donnée en paramètre existe bien et retourne l'ensemble des stations existantes pour cette ville, ne refait pas l'appel si cette requête a déjà été faite pour la ville en question
	- 3 appelle GetBikesTown qui retourne le nombre de vélos disponibles au moment de l'appel pour une ville et une station données, affiche une erreur en cas de mauvaise saisie, affiche le nombre de vélos sinon

- 2 locales:
	- 4 affiche l'aide
	- 5 quitte l'application

#Cache

Pour éviter d'appeler pour rien le web service, une liste stocke les villes existantes et limite à un seul appel celui de GetCities. Le premier appel est donc le plus long, les autres se contentent d'afficher la table locale.

Pour les stations des différentes villes, les informations sont stockées dans un dictionnaire de type <Ville><Liste des stations>.
Après appel de la méthode 2 GetStationsCity, les nouvelles données sont ajoutées réduisant ainsi les appels redondants et limite le trafic.

#Monitoring

L'application affiche des informations au fil des opérations pour donner plus d'informations à l'utilisateur.
