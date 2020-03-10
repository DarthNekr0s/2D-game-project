## How to Play & Storyline, Game Progress


When the game first loads, the dialog that pops up gives you a quick rundown on the controls. 


Player Movement:

•	W, A, S, D

•	Up, Left, Down, Right arrows 


You have a follower that walks behind you at all times,  the first party member, who joins you in battle.
You cannot control her.

**Press E** to interact with any objects that look like they might do something. If you're stuck and can't find out where to go look around and see if anything can be used.

**Press R** to talk to NPCs.


At this point in game production, it is still in the prologue. Your village has been sealed off by a fence that will be taken down later on as the game progresses in development and as the plot progresses. Currently, the storyline of the game stops after you get this legendary sword. There are a few different areas to explore, with unique music for different biomes, and battle music as well.

Currently the combat system is not functioning properly. I spent days trying to get it satisfactory but couldn't figure out what the problem was. After you attack or use a spell, the button becomes disabled and you have to wait for a popup that tells you it's the enemy turn. Once clicked, they take their turn and it disappeared and your controls get re-enabled. What this is doing at the moment is not disappearing until you click it two, maybe 3 times, so you can spam click if you want the enemy to keep attacking you, and for some reason you get controls back anyway after just clicking it once.

There is also no notification of a win or exp gaining system in place yet. So as soon as either the enemy or players hitpoints reaches zero, the battle will end.


## Target Demographic


I have aimed this game for all ages, meaning its family friendly as the colourful cartoonish graphics are attractive towards young people. It would also appeal to teenagers or young adults that grew up playing Gameboy games, as the style is reminiscent of early JPRGs that a lot of people grew up with, and the kind of gameplay can be easily addicting.

The graphics of the game make it more appealing towards a wider audience, as not many people would look at it and decide they didn't like it, compared to a game of a specific genre like, scifi, pink and girly or dark styled games, which are just a few examples of games for a more specificly targetted audience.



## Code Structure



In the code for this game, most of the scripts are hooked up to a few main controlling scripts. There is a game manager which a lot of other scripts call from, and gameobjects need to be dropped into. This all comes set up already of course. There is a dialogue manager that controls the dialogue any time it pops up. There is a HUD that has a screen fader on it for switching zones as well as a Canvas that controls all our UI elements for battle, which is currently the only screen its used for.
The music is controlled by trigger points in different zones and set to automatically play.

The script that controls when we get into a battle is a bit complicated. It works similar to pokemon games. You walk in the long grass, and randomly a monster appears to fight you. The monster is chosen based on a % of rarity it has to appear, for instance, finding a rat would be more common than a wolf. The way it works is that an empty game object is instantiated into the battle scene that has the statistics of the monsters programmed into it, and whichever monster is picked, thats what the gameobject appears as. I have run into a few issues using this method, one that I have not resolved, is that since the monsters are not individual gameobjects themselves, the empty object can only appear with a sprite image of the monster, therefore, it does not have accesss to animations. Which is annoying because I had made some nice idle animations for each monster as well as attack animations. So far I have not figured out a way around this other than reworking the random battle script entirely.



## AI Documentation



![gamecode1](https://i.imgur.com/PrcsAbf.png)
 
 
 
This is the system that picks which Monster you battle when you're in long grass.
There isn't much a UML diagram can say about that, so here's this.

Because of issues that are still being worked on, in battle the enemy moves are basically controlled by the player pressing a button.  They were supposed to use a coroutine to attack with, but it doesn't follow its instructions properly so what you see when you play the game was a necessary workaround, even if I am unsatisfied with it.

A portion of how this is run:
 
 

![gamecode2](https://i.imgur.com/iHuI6n0.png)


