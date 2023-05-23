In order to make my structure building game, i needed to learn some skills. I used a mix of written tutorials and youtube videos to learn various systems such as a grid system, and placing mechanics.

First was the grid system. Luckily, i found a very useful tutorial series by Code Monkey on Youtube. This helped me to get the grid working, and I also made a few tweaks such as a cursor that could have a reference to an individual cell.
https://www.youtube.com/watch?v=waEsGu--9P8&list=PLzDRvYVwl53uhO8yhqxcyjDImRjO9W722

The generation of the map was also quite difficult. I opted to use a generation technique called Perlin Noise, which put each tile through a function in order to create a semi-random, yet still coherent noise.
`The noise does not contain a completely random value at each point, but rather consists of "waves" whose values gradually increase and decrease across the pattern.`
![[Pasted image 20230515101543.png]]
https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html
![[Pasted image 20230515120301.png]]
I also added multiple layers of perlin noise. This was so that the Wind stat, the Daylight stat, and the Cost stat are all different.
This was quite difficult to implement, as I had to learn how the Mathf.PerlinNoise() function worked. My finished code for this looks like:
```
//for each tile, upon creation, this code runs
//offset is used so that each generation is different, and each of the 3 stats are
//different as well
int offset1 = Random.Range(0, 256);
//x and y are the current location of the tile being run through this
float x1 = (float)x / gridArray.GetLength(0);
float y1 = (float)y / gridArray.GetLength(1);
float n1 = Mathf.PerlinNoise(x1 * 2 + offset1, y1 * 2 + offset1);
c.buildCost = n1;
```
Of course i had to copy this 2 more times, as I started with 3 statistics per tile.
Then, I had to add buttons to change which stat was visualised, as well as altering the colour of the underlying tile to make it easier to parse.
```
public void ChangeInfoOverlay(float info)
    {
		//Change the text of the tile to a truncated version of the stat 
		//the real statistic has around 8 decimal places, so we need to simplify it
		//for readability
        this.info.text = info.ToString().Substring(0, 3);
        this.info.color = Color.white;
        this.info.fontStyle = FontStyle.Bold;

		//Smoothly blend between start and end colour (green and red) depending on
		//the "info" float (the stat)
        Color32 start = new(0, 255, 0, 255);
        Color32 end = new(255, 0, 0, 255);
        cube.material.color = Color.Lerp(start, end, info);
    }
```
![[2023-05-23 09-45-30.mkv]]

For visual interest, I also 3D Modelled my own props.
This was fairly simple, as I'm used to working in blender. I decided to use lo-poly as it creates quite a nice, simple vibe and was much less time-consuming than creating realistic assets.
![[Pasted image 20230523095643.png]]