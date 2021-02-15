# sawubona-cleaner-robot

At start, the robot should take in its map, its starting position, and its intended route according to the
following format standard:

○ M:MinX,MaxX,MinY,MaxY;S:StartingX,StartingY;[Direction+Length]

○ Example: M:-10,10,-10,10;S:-5,5;[W5,E5,N4,E3,S2,W1]

○ The input has 3 sections, separated by semicolons - the order is not important.

○ M stands for Map, and takes in 4 values representing the limits of the Cartesian coordinate system.

○ S stands for Start, and takes in a coordinate point, which is where the cleaner will start form.

○ Between [ and ] will be an array of values representing Direction and Length, separated by commas.

■ Directions are the representations of the 4 cardinal points: N, E, S, and W

■ Length is how far the robot should travel in that direction

■ The format is Direction+Length, like “N10”, “E2”, “S4”
