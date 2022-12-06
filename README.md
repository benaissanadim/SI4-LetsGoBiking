# LetsGoBiking

![image](https://user-images.githubusercontent.com/90777897/206019911-1f4eb0c4-98fe-4159-832d-8cf7e39e8c2c.png)


Lancer le projet : 

- Lancer ActiveMQ sur votre console avec la commande : $ activemq start.

- Lancer le serveur :
  - Lancer le fichier executable du Projet "ProxyCacheServer" : LetsGoBiking\RoutingServer\ProxyCacheServer\bin\Debug
  - Lancer le fichier executable du Projet "RountingServer" : LetsGoBiking\RoutingServer\RoutingServer\bin\Debug
  
- Lancer le client : 
  - Lancer le fichier Main.java avec intellij

- Une interface graphique s'affiche lorsque le client est lancé, vous pourrez ainsi saisisir votre adresse de départ et d'arrivée.
- Cliquer sur le bouton "Search", l'itinéraire sera affiché sur la map ainsi que les dix premières steps.
- Pour avoir la suite des steps il suffit d'appuyer sur le bouton "Update Next Steps", répéter cette tâche jusqu'à être arrivé à destination un message "finish" sera affiché.
