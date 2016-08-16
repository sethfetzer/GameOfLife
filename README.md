# GameOfLife
Code solution to the following problem:

Write some code that evolves generations through the "game of
life". The input will be a game board of cells, either alive (1) or dead
(0).
https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

The code should take this board and create a new board for the
next generation based on the following rules:
1) Any live cell with fewer than two live neighbours dies (underpopulation)
2) Any live cell with two or three live neighbours lives on to
the next generation (survival)
3) Any live cell with more than three live neighbours dies (overcrowding)
4) Any dead cell with exactly three live neighbours becomes a
live cell (reproduction)

As an example, this game board as input:

0 1 0 0 0

1 0 0 1 1

1 1 0 0 1

0 1 0 0 0

1 0 0 0 1

Will have a subsequent generation of:

0 0 0 0 0

1 0 1 1 1

1 1 1 1 1

0 1 0 0 0

0 0 0 0 0

This solution can be run through the GameOfLife project.  
It has 3 options in the operator console: 
start with a pre-canned setup (example above included), 
generate a random 5x5 pattern, or generate your own pattern of any size.

Please note when generating your own pattern, any integer above 1 will be 
converted to 1, so 01230 => 01110
