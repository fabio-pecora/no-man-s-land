# no-man-s-land
This is a 3D game, our character is a Robot who has to find 4 keys following the 3D sound of them inside of a maze. This first level movement is based on a 3rd person point of view where the character can run and shoot. After the player finds the keys he will be able to generate a teleporter to move to the next level. While the player looks for the keys there are enemies looking for him through the maze looking for the shortest path through the maze (NavMesh). The secon level is a parkour level with a timer and a first person view. There are a lot of scenes such as a victory scene, a loosing scene, an option menu and a main menu. The game is full of sounds to make the game better and more interesting. In order to maximize the efficiency of this game I used three game design pattern (object-pooling for the shooting, singleton for the audio manager and observer patter for the enemies).
# Structure of the maze seen from the top:
![image](https://user-images.githubusercontent.com/79877216/170742902-294c9620-a67f-4985-a8ec-1f94ff1e7423.png)
# Here is the attack of one of our enemies (we have also two other enemies). We can also see the pickup of one power up.
https://user-images.githubusercontent.com/79877216/170750651-e0799558-3ccb-499c-8e39-dfe6025fbb16.mp4
# Here is the AI of the enemies (they will look for a path to reach our player avoiding the obstacles).
https://user-images.githubusercontent.com/79877216/170751479-707d7733-bd8c-4bc0-bc5f-bb019891b223.mp4
# Here is the generation of the teleporter and the loading of the new scene.
https://user-images.githubusercontent.com/79877216/170752801-83ae801d-f045-4df5-9d1f-45615e90f009.mp4
# These are all the complementary scenes (victory, loosing and the menues).
https://user-images.githubusercontent.com/79877216/170753648-aee2663f-12c3-4dff-9d64-80080f21c46e.mp4
