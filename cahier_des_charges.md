# Cahier des charges

**Objectif de l'Application :** 
L'application vise à calculer les points d'une partie de bowling et à fournir un suivi en temps réel du score.

**Contraintes :**
- **Joueurs illimités :** L'application doit pouvoir gérer un nombre théoriquement illimité de joueurs pour une partie de bowling.
- **Historique non requis :** Il n'est pas nécessaire de conserver un historique des parties jouées.
- **Respect des règles du bowling :** Les règles standard du bowling doivent être respectées, notamment :
    - 10 frames par partie (nombre qui sera dynamique, par default 10)
    - 2 lancers par frame
    - 10 quilles par frame (implique un maximum de 10 points par frame)
    - 2 lancers bonus en cas de strike
    - 1 lancer bonus en cas de spare
    - Pas de gestion nécessaire des règles liées aux fautes
    - *Des détails supplémentaires seront ajoutés au fur et a mesure*

**Affichage du Score :**
- **Première étape :** Le score sera initialement affiché sous forme d'un tableau à la fin de la partie.
- **Évolution :** Par la suite, une fonctionnalité sera ajoutée pour afficher le score en temps réel au fur et à mesure de la partie.