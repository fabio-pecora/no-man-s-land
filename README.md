# no-man-s-land
This 3D game immerses players in a maze as a Robot character on a quest to find four keys, guided by dynamic 3D sound. Initially, in a third-person view, players can run and shoot while avoiding enemies using intelligent NavMesh pathfinding. Finding the keys unlocks a teleporter, progressing to a parkour-based second level with a first-person perspective and a timed challenge. The game features victory and defeat scenes, an options menu, and a main menu. To optimize efficiency, object-pooling handles shooting, a singleton audio manager controls sound, and the observer pattern governs enemy behavior. The game is enriched with captivating sound effects to enhance immersion, delivering an engaging experience
# Structure of the maze seen from the top:
![image](https://user-images.githubusercontent.com/79877216/170742902-294c9620-a67f-4985-a8ec-1f94ff1e7423.png)
# Here is the attack of one of our enemies (we have also two other enemies). We can also see the pickup of one power-up.
https://user-images.githubusercontent.com/79877216/170750651-e0799558-3ccb-499c-8e39-dfe6025fbb16.mp4
# Here is the AI of the enemies (they will look for a path to reach our player avoiding the obstacles and they will always choose the shortest path).
https://user-images.githubusercontent.com/79877216/170751479-707d7733-bd8c-4bc0-bc5f-bb019891b223.mp4
# Here is the teleporter's generation and the new scene's loading.
https://user-images.githubusercontent.com/79877216/170752801-83ae801d-f045-4df5-9d1f-45615e90f009.mp4
# These are all the complementary scenes (victory, losing, and the menus).
https://user-images.githubusercontent.com/79877216/170753648-aee2663f-12c3-4dff-9d64-80080f21c46e.mp4
