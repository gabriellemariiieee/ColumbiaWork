#include<iostream>
#include<string>
#include<vector>

using namespace std;

vector<string> suits{ "Spades", "Diamonds", "Hearts", "Clubs" };
vector<string> faces{ "8", "9", "10", "J", "Q", "K", "A" };
vector<int> value{ 8, 9, 10, 11, 12, 13, 14 };
string trumpSuit = "";
string currentSuit = "";

class Card {
public:
	string suit, face;
	int value;
	bool isTrumpSuit = false;

	Card() {

	}

	Card(string s, string f, int v) {
		suit = s;
		face = f;
		value = v;
	}
};

void createDeck(vector<Card> &d) {
	for (int x = 0; x < 4; x++) {
		for (int y = 0; y < 7; y++) {
			Card card(suits[x], faces[y], value[y]);
			d.push_back(card);
		}
	}
}

void shuffleDeck(vector<Card>& d) {
	srand(time(0));
	for (int x = 0; x < 28; x++) {
		int r = x + (rand() % (28 - x));

		swap(d[x], d[r]);
	}
}

void setTrumpSuit(Card& c) {
	trumpSuit = c.suit;
	c.isTrumpSuit = true;
}

string getTrumpSuit() {
	return trumpSuit;
}

bool IsTrumpSuit(Card& c) {
	if (c.isTrumpSuit == true) {
		return true;
	}
	else {
		return false;
	}
}

class Player {
public:
	string name;
	int score, position, team;
	vector<Card> hand;
	bool isDealer = false;
	bool hasPlayed = false;

	Player() {

	}

	Player(string n, int p, int t, int s) {
		name = n;
		position = p;
		team = t;
		score = s;
	}

	Player(string n, int p, int t, int s, vector<Card> h) {
		name = n;
		position = p;
		team = t;
		score = s;
		hand = h;
	}
};

void setDealer(Player &p) {
	p.isDealer = true;
}

Player getDealer(vector<Player> &p) {
	int temp = 0;
	for (int x = 0; x < p.size(); x++) {
		if (p[x].isDealer == true) {
			temp = x;
		}
	}
	return p[temp];
}

bool dealer(Player &p) {
	if (p.isDealer == true) {
		return true;
	}
	else {
		return false;
	}
}

void createPlayers(vector<Player>& p) {
	for (int x = 0; x < 4; x++) {
		if (x % 2 == 0) {
			Player player("Player #" + to_string(x + 1), x + 1, 1, 0);
			p.push_back(player);
		}
		else {
			Player player("Player #" + to_string(x + 1), x + 1, 2, 0);
			p.push_back(player);
		}
	}
}

void deal(vector<Card>& d, vector<Player>& p) {
	for (int x = 0; x < p.size(); x++) {
		for (int y = 0; y < 2; y++) {
			p[x].hand.push_back(d[0]);
			d.erase(d.begin());
		}
	}
	for (int x = 0; x < p.size(); x++) {
		for (int y = 0; y < 3; y++) {
			p[x].hand.push_back(d[0]);
			d.erase(d.begin());
		}
	}
}

string getBestSuit(Player& p) {
	int h = 0, d = 0, c = 0, s = 0;
	for (int x = 0; x < p.hand.size(); x++) {
		if (p.hand[x].suit == "Hearts") {
			h++;
			if (p.hand[x].face == "J") {
				h++;
			}
		} else if (p.hand[x].suit == "Diamonds") {
			d++;
			if (p.hand[x].face == "J") {
				d++;
			}
		} else if (p.hand[x].suit == "Clubs") {
			c++;
			if (p.hand[x].face == "J") {
				c++;
			}
		} else if (p.hand[x].suit == "Spades") {
			s++;
			if (p.hand[x].face == "J") {
				s++;
			}
		}
	}

	if (h >= d && h >= c && h >= s) {
		return "Hearts";
	} else if (d >= h && d >= c && d >= s) {
		return "Diamonds";
	} else if (c >= d && c >= h && c >= s) {
		return "Clubs";
	} else {
		return "Spades";
	}
}

void setTrump(vector<Card> &deck, vector<Player> &p) {
	Player currentDealer = getDealer(p);
	p.erase(p.begin());
	p.push_back(currentDealer);
	for (int x = 0; x < p.size(); x++) {
		if (getBestSuit(p[x]) == deck[0].suit) {
			setTrumpSuit(deck[0]);
			p[3].hand.push_back(deck[0]);
			deck.erase(deck.begin());
			string dealerSuit = getBestSuit(currentDealer);
			for (int x = 0; x < currentDealer.hand.size(); x++) {
				if (IsTrumpSuit(currentDealer.hand[x]) == false && currentDealer.hand[x].suit != dealerSuit) {
					deck.push_back(currentDealer.hand[x]);
					int y = x - 1;
					p[3].hand.erase(p[3].hand.begin() + y);
					break;
				}
			}
			break;
		}
	}

	if (trumpSuit == "") {
		string suit = getBestSuit(p[0]);
		int temp = 0;
		for (int x = 0; x < p[0].hand.size(); x++) {
			if (p[0].hand[x].suit == suit) {
				setTrumpSuit(p[0].hand[x]);
				break;
			}
		}
	}
	cout << getTrumpSuit() << endl;
}

void setCardValues(vector<Card>& d) {
	for (int x = 0; x < d.size(); x++) {
		if (d[x].suit == trumpSuit && d[x].face == "J") {
			d[x].value = 5 * d[x].value;
		}
		else if (trumpSuit == "Spades" && d[x].suit == "Clubs" && d[x].face == "J") {
			d[x].value = 4 * d[x].value;
		}
		else if (trumpSuit == "Clubs" && d[x].suit == "Spades" && d[x].face == "J") {
			d[x].value = 4 * d[x].value;
		}
		else if (trumpSuit == "Diamonds" && d[x].suit == "Hearts" && d[x].face == "J") {
			d[x].value = 4 * d[x].value;
		}
		else if (trumpSuit == "Hearts" && d[x].suit == "Diamonds" && d[x].face == "J") {
			d[x].value = 4 * d[x].value;
		}
		else if (d[x].suit == trumpSuit) {
			d[x].value = 2.5 * d[x].value;
		}
		else if (d[x].suit == currentSuit) {
			d[x].value = 1.5 * d[x].value;
		}
	}
}

void play(vector<Player> &p) {
	Card playerOne, playerTwo, playerThree, playerFour;
	vector<Card> plays;
	string suit = getBestSuit(p[0]);
	for (int x = 0; x < p[0].hand.size(); x++) {
		if (p[0].hand[x].suit == suit) {
			currentSuit = suit;
			playerOne = p[0].hand[x];
			p[0].hasPlayed = true;
			plays.push_back(playerOne);
			p[0].hand.erase(p[0].hand.begin() + x);
			break;
		}
	}
	if (p[0].hasPlayed == true) {
		cout << p[0].name + " has played a " + playerOne.face + " of " + playerOne.suit << endl;
	}
	else {
		srand(time(0));
		if (p[0].hand.size() != 1) {
			int r = rand() % (p[0].hand.size() - 1);
			cout << p[0].name + " played a " + p[0].hand[r].face + " of " + p[0].hand[r].suit << endl;
			playerOne = p[0].hand[r];
			plays.push_back(playerOne);
			p[0].hand.erase(p[0].hand.begin() + r);
		}
		else {
			cout << p[0].name + " played a " + p[0].hand[0].face + " of " + p[0].hand[0].suit << endl;
			playerOne = p[0].hand[0];
			plays.push_back(playerOne);
			p[0].hand.erase(p[0].hand.begin());
		}
	}

	for (int x = 0; x < p[1].hand.size(); x++) {
		if (p[1].hand[x].suit == currentSuit) {
			playerTwo = p[1].hand[x];
			p[1].hasPlayed = true;
			plays.push_back(playerTwo);
			p[1].hand.erase(p[1].hand.begin() + x);
			break;
		}
	}
	if (p[1].hasPlayed == true) {
		cout << p[1].name + " has played a " + playerTwo.face + " of " + playerTwo.suit << endl;
	}
	else {
		srand(time(0));
		if (p[1].hand.size() != 1) {
			int r = rand() % (p[1].hand.size() - 1);
			cout << p[1].name + " played a " + p[1].hand[r].face + " of " + p[1].hand[r].suit << endl;
			playerTwo = p[1].hand[r];
			plays.push_back(playerTwo);
			p[1].hand.erase(p[1].hand.begin() + r);
		}
		else {
			cout << p[1].name + " played a " + p[1].hand[0].face + " of " + p[1].hand[0].suit << endl;
			playerTwo = p[1].hand[0];
			plays.push_back(playerTwo);
			p[1].hand.erase(p[1].hand.begin());
		}
		
	}

	for (int x = 0; x < p[2].hand.size(); x++) {
		if (p[2].hand[x].suit == currentSuit) {
			playerThree = p[2].hand[x];
			p[2].hasPlayed = true;
			plays.push_back(playerThree);
			p[2].hand.erase(p[2].hand.begin() + x);
			break;
		}
	}
	if (p[2].hasPlayed == true) {
		cout << p[2].name + " has played a " + playerThree.face + " of " + playerThree.suit << endl;
	}
	else {
		srand(time(0));
		if (p[2].hand.size() != 2) {
			int r = rand() % (p[2].hand.size() - 2);
			cout << p[2].name + " played a " + p[2].hand[r].face + " of " + p[2].hand[r].suit << endl;
			playerThree = p[2].hand[r];
			plays.push_back(playerThree);
			p[2].hand.erase(p[2].hand.begin() + r);
		}
		else {
			cout << p[2].name + " played a " + p[2].hand[0].face + " of " + p[2].hand[0].suit << endl;
			playerThree = p[2].hand[0];
			plays.push_back(playerThree);
			p[1].hand.erase(p[2].hand.begin());
		}
	}

	for (int x = 0; x < p[3].hand.size(); x++) {
		if (p[3].hand[x].suit == currentSuit) {
			playerFour = p[3].hand[x];
			p[3].hasPlayed = true;
			plays.push_back(playerFour);
			p[3].hand.erase(p[3].hand.begin() + x);
			break;
		}
	}
	if (p[3].hasPlayed == true) {
		cout << p[3].name + " has played a " + playerFour.face + " of " + playerFour.suit << endl;
	}
	else {
		srand(time(0));
		if (p[3].hand.size() != 1) {
			int r = rand() % (p[3].hand.size() - 1);
			cout << p[3].name + " played a " + p[3].hand[r].face + " of " + p[3].hand[r].suit << endl;
			playerFour = p[3].hand[r];
			plays.push_back(playerFour);
			p[3].hand.erase(p[3].hand.begin() + r);
		}
		else {
			cout << p[3].name + " played a " + p[3].hand[0].face + " of " + p[3].hand[0].suit << endl;
			playerFour = p[3].hand[0];
			plays.push_back(playerFour);
			p[3].hand.erase(p[3].hand.begin());
		}
	}

	for (int x = 0; x < p.size(); x++) {
		setCardValues(p[x].hand);
	}
	setCardValues(plays);
	
	if (playerOne.value >= playerTwo.value && playerOne.value >= playerThree.value && playerOne.value >= playerFour.value) {
		cout << p[0].name + " took the trick." << endl;
		p[0].score++;
	} else if (playerTwo.value >= playerOne.value && playerTwo.value >= playerThree.value && playerTwo.value >= playerFour.value) {
		cout << p[1].name + " took the trick." << endl;
		p[1].score++;
	} else if (playerThree.value >= playerTwo.value && playerThree.value >= playerOne.value && playerThree.value >= playerFour.value) {
		cout << p[2].name + " took the trick." << endl;
		p[2].score++;
	} else if (playerFour.value >= playerTwo.value && playerFour.value >= playerThree.value && playerFour.value >= playerOne.value) {
		cout << p[3].name + " took the trick." << endl;
		p[3].score++;
	}
}

int main() {
	vector<Card> newDeck;
	vector<Player> newPlayers;
	createDeck(newDeck);
	createPlayers(newPlayers);
	shuffleDeck(newDeck);
	deal(newDeck, newPlayers);
	setDealer(newPlayers[0]);
	setTrump(newDeck, newPlayers);
	for (int x = 0; x < 4; x++) {
		for (int y = 0; y < newPlayers.size(); y++) {
			newPlayers[y].hasPlayed == false;
		}
		play(newPlayers);		
	}
}