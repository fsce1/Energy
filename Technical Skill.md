In order to make my structure building game, i needed to learn some skills. I used a mix of written tutorials and youtube videos to learn various systems such as a grid system, and placing mechanics.

First was the grid system. Luckily, i found a very useful tutorial series by Code Monkey on Youtube. This helped me to get the grid working, and I also made a few tweaks such as a cursor that could have a reference to an individual cell.
https://www.youtube.com/watch?v=waEsGu--9P8&list=PLzDRvYVwl53uhO8yhqxcyjDImRjO9W722

The generation of the map was also quite difficult. I opted to use a generation technique called Perlin Noise, which put each tile through a function in order to create a semi-random, yet still coherent noise.
`The noise does not contain a completely random value at each point, but rather consists of "waves" whose values gradually increase and decrease across the pattern.`
![[Pasted image 20230515101543.png]]
https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html
![[Pasted image 20230515120301.png]]