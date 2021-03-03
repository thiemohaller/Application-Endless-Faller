# Project Review

## Thiemo Haller

The first big obstacle which I somewhat anticipated, but not estimated it to be as big of a problem, was the implementation of the moving platforms. I am still not completly happy with it, but feel like the solution I came up with is okay for now. While I found some solutions for spawning split platforms on the internet, I didn't really understand what they did, so I did not feel comfortable using them. In the end I stuck with the first solution I came up with and created about 10 prefabs, using boxes as triggers for scoring. I even created some more prefabs, however during test playing I figured out that the added variety did not really add much. By flipping the platforms every other time, some more unpredictability can be introduced:
``` C#
if (random.Next(0, 2) == 0) {
    currentPlatform.transform.RotateAround(currentPlatform.transform.position, transform.right, 180);            
}
```
Looking over the code once more, I would have removed the `MovingPlatform` script, since I already loop over the spawned platforms, so it could be included in the `Spawner` script. I loop over the spawned objects in order to adjust the speed, since otherwise the faster platforms would pass through the slower ones.

I also hit a wall with the automated testing, which I sadly did not manage to find a way around. I manually tested everything I could think of, however I think it would have been neat to add some automated tests. My takeaway from this experience is to keep testing more in mind and structure the code more around it. This will also help with decoupling and better structuring the code. For example, I tried implementing the Humble Object Pattern in order to better test my code, however I ran into quite some issues and would have had to rewrite almost all my scripts. 

Another minor issue I ran into was the fact that the score kept increasing after game over. I was using Cubes as Triggers in the empty space between the two halves of the platforms, this resulted in the player falling through score triggers, after the platforms despawned (can be seen in the editor when playing). This kept adding to the score even though the game was over. I fixed it by introducing a bool, which locks the score once the player has hit one of the bounds triggers. Other than that, scoring was rather simple and I spent a lot less time on it than I anticipated. A small text label is shown if the high score is broken for the first time.

Overall I had a lot of fun working on the project and learned quite a few valuable lessons, not only about testing in Unity, but also some more in-depth knowledge about features of the Unity Editor, such as post processing. I got kind of carried away at the end and decided that a neon post processing look would work quite well with the game, so I quickly created some maps in a photo editor and used them to mask the emission. I also added a music player which starts in the `Home` scene on load and is preserved throughout the games duration. 