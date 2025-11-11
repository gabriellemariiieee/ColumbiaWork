#include <iostream>
#include <cstdlib>
#include <vector>
#include <string>

int grid[16][16];

void initializegrid(int array[16][16]) {
    for (int x = 0; x < 16; x++) {
        for (int y = 0; y < 16; y++) {
            array[x][y] = 0;
        }
    }
}

void placeships(int array[16][16]) {
    int randomRow, randomCol;
    srand(time(NULL));

    for (int x = 0; x < 10; x++) {
        randomRow = rand() % 16 + 1;
        randomCol = rand() % 16 + 1;
        array[randomRow][randomCol] = 1;
    }
}

void findship(int array[16][16]) {
    int z = 0;

    while (z < 10) {
        for (int x = 0; x < 16; x++) {
            for (int y = 0; y < 16; y++) {
                if (array[x][y] == 1) {
                    std::cout << "HIT\n";
                    z++;
                }
                else if (array[x+1][y] == 1 || array[x-1][y] == 1 || array[x][y+1] == 1 || array[x][y-1] == 1 || array[x+1][y+1] == 1 || array[x+1][y-1] == 1 || array[x-1][y+1] == 1 || array[x-1][y-1] == 1) {
                    std::cout << "NEAR MISS\n";
                }
                else {
                    std::cout << "MISS\n";
                }
            }
        }
    }
}

int main()
{
    initializegrid(grid);
    placeships(grid);

    for (int x = 0; x < 16; x++) {
        for (int y = 0; y < 16; y++) {
            std::cout << grid[x][y];
        }
        std::cout << "\n";
    }

    findship(grid);
}