# BoVoyage
Projet Entity Framework de Laura V. et Anne P.

Nous avons essayé de travailler en mode "Database First" (sans générer les entités par Visual Studio bien évidemment !), l'une travaillant sur la création de la base de données pendant que l'autre s'occupait de créer les classes et de les implémenter simultanément.

Nous avons ensuite échangé les rôles pour essayer chacune de manipuler la base de données :).

Afin de vous éviter de nombreux clics inutiles vers des liens morts, les items de menu qui aboutissent sont les suivants : 
--Menu principal : vous pouvez accéder à tous les sous menus
--Menu gestion clientèle : vous pouvez accéder à tout
--Menu de gestion des participants : vous pouvez accéder à tout
--Menu gestion des voyages : seul lister est disponible 
--Menu gestion des dossiers de réservation : lister, créer disponibles
--Menu destination : seul lister est disponible

Ce qu'il reste à faire (entre autres !) : gérer les états des dossiers, gérer les annulations, en base de données créer des tables intermédiaires (relations many to many entre participant et dossier de réservation, et entre dossier de réservation et assurance)


NB: 
1-Nous partons du principe que les prix en base de données sont les prix déjà discountés.
2-Au moment de la réservation, le commercial a déjà rentré dans la base les clients et les participants. On imagine qu’il a en premier lieu créé le client (et ou le participant).
3-Nous sommes conscientes des problèmes de cascading au niveau des participants au niveau de la création des dossiers de réservation (quand on crée un dossier, un nouveau participant rattaché est automatiquement créé)
