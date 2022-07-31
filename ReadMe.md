# Funtory Unity3D Test
## Memory Match Game
### Narges Beck
#### Implementation:
  - <b/> Architecture: </b> MVC<br><br>
  - <b/> Scenes: </b> The code of the game has been broken into 3 sections/scenes: MainMenu, LevelsMenu, GamePage. Each Scene has controllers added on UI elements (a.k.a. view), and one object called Model to manage data. Model scripts manipulate View via Controllers.<br><br>
  - <b/> GameManager: </b> is a gameobject on SceneMainMenu. Has 2 components: GameManager.cs and ContentsPool. This object is to be not destroyed throughout the game, regardless of what the current scene is. GameManager is a Singleton, and holds current level. This comes in handy when going from SceneLevelsMenu to SceneGamePage.<br><br>
  - <b/> SceneGamePage: </b> Cards are implemented via sprites, and are set active/deactive due to the number of cards in the current level. Cards are managed with a object pooling script. The visual order of cards gameobjects (if you notice) are not starting from one corner and so on and so forth. This is only to have all levels looking nice, without having the need to rearrenge the activated cards from pool on run-time. <br> <br> To implement singleton design pattern, here we have an script dedicated to it: Linker.cs. <br> <br> There are actions for important events as in level ending, a card being clicked, etc. <br> <br> All used sprites (num: 16) are put in an Atlas file to reduce draw calls.<br><br>
  - <b/> Editor: </b> In order to make and test levels, there is a simple Window Editor (available from the menu "BZdio"), to create levels, assign the time, the number of cards, and the content of cards. This editor is also available from the shortcut Alt + L.
  
#### Packages:
- <b/> DOTween: </b> <br> https://dotween.demigiant.com/<br><br>
- <b/> Animal Cube (Duck Series) - 2D Asset </b> <br> https://assetstore.unity.com/packages/2d/animal-cube-duck-series-2d-asset-222908