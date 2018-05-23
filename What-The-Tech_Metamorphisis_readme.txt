1. Katherine Delgado, kdelgado8@gatech.edu, kdelgado8
   Thomas Ristau, tristau62@gatech.edu, tristau3
   Steve Nkuranga, snkuranga8@gatech.edu , snkuranga8
   Ali Khosravi, alikhosravi1000@gatech.edu, akhosravi7
   Bryce Watson (left due to broken arm)
2. N/A
3. The game consists of a human player trapped in an ancient Mayan temple and they must
   go through doors leading to different levels in which they transform into a different
   animal and must use that animal's abilities to get through each level and reach the
   magical sun/goal. The human can be controlled with W-A-S-D and must walk to a door to
   begin a level, with level completion shown by the door disappearing. The bird can be
   controlled by the mouse, and must navigate through all the rings before it can reach
   the sun/goal. Going through white clouds gives a speed boost, but hitting too many dark
   clouds results in failing to pass the level. The bear can be controlled by W-A-S-D,
   and the level is set up as a huge map similar to a maze. The bear must find the sun/goal
   without dying to wolves located around the map that follow the bear once it's in sight.
   The shark level is a mostly underwater map consisting of various fish that the shark must
   find and eat before it can gain the ability to fly up in the air to reach the sun/goal.
   It is controlled in the same way the bird is, with the mouse, and space speeds it up.
4. Game Feel: Our game is a 3D game with a recurring theme throughout each level - reach the
   objective/sun/goal by using your animal ablities granted by the mystical Mayan temple. In
   the bird level, colliding into too many dark clouds results in failure, while taking too much
   damage from wolves before finding the sun/goal in the bear level results in the bear's death
   and failure. The game is not complete until the player finishes each level.
   Precursors to Fun: The goal of each level is communicated to the player via UI. The player can
   choose from any animal level/door to start with from the human scene. Upon successfully
   completing all the levels, the player is notified throught the UI that they have succesfully
   escaped the Mayan temple. In the bear level, various
   breakable boxes help guide the player towards the sun/goal. As the bear gets closer to the goal,
   there are more wolves in the area to deal with.
   3D Character/Vehicle with Real-Time Control: Human, bird, shark, and bear players can all be
   controlled relatively fluidly with animations that depict walking (human), running (bear),
   flying (bird), swimming (shark), attacking (bear on wolf collision), death (bear on <= 0 health),
   etc. The choice of controls is intuitive - WASD is used, as well mouse direction in different levels,
   both of which are common ways to direct/move characters in most games. Animation is fluid and based
   on how the animal interacts with the current environment (swimming in water, flying in sky, running
   on land, etc). The camera smoothly follows the player in each map, with the map angled in such a way
   in the bear scene to allow the player to have a broader view of their surroundings to better find the
   sun/goal. There is auditory feedback when passing through clouds in the bird scene, when attacking a
   wolf, sad music when the bear dies, growling when a wolf NPC sees the bear and starts following it,
   etc.
   3D World with Physics and Spatial Simulation: The human scene, bear scene, shark scene, and bird scene
   were all developed as unique environements to go with the type of creature and the theme of the game
   (Mayan temple for human, sky for bird, ocean/sea for shark, grassy forest-like area for bear. Physical
   interactions like going through clouds or rings as the bird can be both seen and heard, when the
   bear and wolf collide the bear can be seen attacking/roaring while the wolf is knocked back, and when
   the bear breaks boxes/crates they can be seen/heard breaking into pieces. The player cannot simply fly
   off or leave playable spaces - for example, in the bear level there are invisible colliders that serve
   as "walls" to keep the bear in the playable area. There are also a variety of environmental physical
   interactions, like collectables with the fish in the shark level, blocks/cubes/crates that can be
   destroyed by the bear and guide the player to the goal, the rings and clouds in the bird level, and
   knocking back of wolf NPCs when the much larger bear collides into/attacks them.   
   Real-time NPC Steering Behaviors/Artificial Intelligence: Wolf NPCs in the game have a wandering state
   and a chasing/attacking state. When the bear is in sight of the wolf, determined through raycasts, the
   wolf growls and turns towards the bear and starts running at it, chasing it. Otherwise, the wolves
   simply wander in a small area. There is sensory feedback from the wolf, with a health bar that is updated
   upon registering damage, growling when the bear is first seen, walking when wandering and remaining idle,
   running towards the bear to chase it, and howling upon death. The bear/player can choose to fight wolves,
   but fighting too many will result in too much damage being taken and the bear dying. Since the wolves are
   weaker, smaller, and slower than the bear, but there is a larger number of them, this balances out to be
   relatively fair.
   Polish: Our software is clearly a game from start to finish, with a theme and various interactive levels
   for the user to go through and complete. No debug output is displayed. A menu allows the user to exit the
   game, as well as restart levels. UI elements that give the user an understanding of
   the objective for each level are consistent in style across each level. There are also aesthetic animations
   like the sun/goal glowing/smoldering and the grass waving as if there was a breeze in the bear level.
   Proximity-based events are limited to the wolf growling at and following the bear when it gets within a
   certain distance. Observable game events all have some auditory representation, like the bear/wolf dying,
   travelling through rings/clouds as the bird, etc. The style of each scene is consistent, with each theme
   besides the ominous Mayan temple being relatively bright and calm, which was our goal for the game - not
   to be super hard but still enjoyable. The player should not be able to get stuck, and invisible colliders
   like in the bear scene ensure that the player cannot easily escape the playable level.
   Fun/Engaging/Immersiveness/Emotional Response/Gestalt/"Flow" Achieved: Our game has different, creative
   levels in which the player actually gets to be different animals and use their natural abilities like
   flying (bird), swimming (shark), and strength (bear fighting wolves, breaking crates). While the music is
   kept relaxed and simple to allow the player to enjoy themselves, the sound of howling upon the wolf dying
   and the sad piano music upon the bear dying elicit an emotional response, with the bear's death being more
   meaningful since the player themselves were the bear and the music is far more somber and starts as the bear
   falls and stops moving. Controls also vary based on what we deemed would provide the best experience during
   different scenes - flying is a more fluid task so using a mouse to control direction/movement makes sense.
   However, walking/running on land is typically done with W-A-S-D, controls that most gamers would be
   accustomed to.
5. [TOMMY WRITE THIS IDK WHAT DEFICIENCIES/BUGS THERE ARE maybe mention bryce's shit idk]
6. External resources:
   Low Poly Animated Animals - https://assetstore.unity.com/packages/3d/characters/animals/low-poly-animated-animals-93089
   Low Poly Jungle - https://assetstore.unity.com/packages/3d/environments/low-poly-series-jungle-96747
   The Legend of Zelda: Breath of the Wild - one song & feedback on getting collectable in shark scene
   Heart Icon for Bear Health HUD: https://www.flaticon.com/free-icon/heart_291212
   Wolf growl: https://freesound.org/people/newagesoup/sounds/338674/
7. Ali worked on the human scene and all parts related to it, Steve worked on the bird scene and all parts
   related to it, Bryce worked on the shark scene but he left, Thomas & Katherine worked together on the bear scene
   with Katherine implementing map/terrain, boxes & breaking, wolf health bar, bear health/HUD, wolf AI,
   bear/wolf taking damage, bear dying, wolf dying. Thomas helped with many bug fixes, making the bear attack on collision
   with the wolf, putting all of the scenes together into one build, and the bear movement script.
8. In Unity, the starting scene is the human scene HumanTemple, which contains doors linking to the bear scene Bear,
   bird scene BirdPrototype, and shark scene Shark_Level.