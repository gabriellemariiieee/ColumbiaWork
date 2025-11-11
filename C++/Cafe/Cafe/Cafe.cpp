// Cafe.cpp : Defines the entry point for the application.
//

#include "Cafe.h"
#include<map>
#include<string>
#include<list>

using namespace std;

map<string, double> menu;
string order;
int payment;
double bill;
list<string> change;

void createMenu(map<string, double> &m) {
	m["Coffee"] = 2.30;
	m["Tea"] = 2.00;
	m["Muffin"] = 3.00;
	m["Croissant"] = 2.15;
	m["Crepe"] = 3.10;
}

void printMenu(map<string, double> &m) {
	map<string, double>::iterator i;
	for (i = m.begin(); i != m.end(); i++) {
		cout << (*i).first << " $" << (*i).second << endl;
	}
}

string getOrder() {
	string o, i;
	cout << "What would you like to order?" << endl;
	cin >> o;
	return o;
}

double getPrice(string &o, map<string, double>& m) {
	double b = 0;
	map<string, double>::iterator i;
	for (i = m.begin(); i != m.end(); i++) {
		if ((*i).first == o) {
			b = (*i).second;
		}
	}

	cout << "Your total is $" << b << endl;

	return b;
}

void getPayment(int &p) {
	cout << "Only accepting bills. Please pay now." << endl;
	cin >> p;
}

void getChange(double& b, int& p, list<string> &c) {
	double change;
	change = p - b;
	cout << "Your change is $" << change << endl;
	while (change > 0) {
		if (change >= 1) {
			c.push_back("1 dollar");
			change = change - 1;
		}
		else if (change >= .25) {
			c.push_back("1 quarter");
			change = change - .25;
		}
		else if (change >= .10) {
			c.push_back("1 dime");
			change = change - .1;
		}
		else if (change >= .5) {
			c.push_back("1 nickel");
			change = change - .5;
		}
		else {
			change = 0;
		}
	}
}

void printChange(list<string>& c) {
	list<string>::iterator i;
	for (i = c.begin(); i != c.end(); i++) {
		cout << (*i) << ", ";
	}
}

int main()
{
	createMenu(menu);
	printMenu(menu);
	order = getOrder();
	bill = getPrice(order, menu);
	getPayment(payment);
	getChange(bill, payment, change);
	printChange(change);
	return 0;
}
