// idk how to play Blackjack well so my ai is the bad strategy that i use
#include <iostream>
#include <vector>
#include <numeric>

int wins, losses, cardTotal, index;
std::vector <int> hand;

void getInfo() {
    std::cout << "Wins: " << wins << "\n";
    std::cout << "Losses: " << losses << "\n";
}

void dealCards() {
    hand.push_back(rand() % 13 + 1);
    std::cout << "Card " << index << ": " << hand.at(index) << "\n";
    index++;
    hand.push_back(rand() % 13 + 1);
    std::cout << "Card " << index << ": " << hand.at(index) << "\n";
    index++;
}

void hit() {
    hand.push_back(rand() % 13 + 1);
    std::cout << "Card " << index << ": " << hand.at(index) << "\n";
    index++;
}

void getCardTotal() {
    cardTotal = std::accumulate(hand.begin(), hand.end(), 0);
}

void win() {
    if (cardTotal == 21) {
        std::cout << "You reached 21!\n";
        wins++;
    }
    else if (cardTotal > 21) {
        std::cout << "You busted.\n";
        losses++;
    }
    else {
        std::cout << "You didn't bust. You win!\n";
        wins++;
    }
}

void reset() {
    hand.clear();
    cardTotal = 0;
    index = 0;
}

void stay() {
    win();
}

void ai() {
    getCardTotal();
    if (cardTotal < 18) {
        while (cardTotal < 18) {
            hit();
            getCardTotal();
        }
        win();
    }
    else {
        stay();
    }
}

int main()
{
    int x = 0;
    srand(time(NULL));
    while (x < 100) {
        dealCards();
        ai();
        getInfo();
        reset();
        x++;
    }
}