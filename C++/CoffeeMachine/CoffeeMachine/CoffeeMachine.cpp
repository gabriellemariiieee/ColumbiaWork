#include <iostream>
#include <fstream>
#include <vector>
#include <string>

int orderTotal, water;
double grounds;
std::vector <int> orders;

void getOrderList(std::string filename) {
    char a;
    std::ifstream orderList;
    orderList.open(filename);

    while (orderList) {
        a = orderList.get();
        switch (a) {
        case '1':
            orders.push_back(1);
            break;
        case '2':
            orders.push_back(2);
            break;
        case '3':
            orders.push_back(3);
            break;
        case '4':
            orders.push_back(4);
            break;
        case '5':
            orders.push_back(5);
            break;
        case '6':
            orders.push_back(6);
            break;
        case '7':
            orders.push_back(7);
            break;
        case '8':
            orders.push_back(8);
            break;
        case '9':
            orders.push_back(9);
            break;
        }
    }
}

void makeCoffee(std::vector<int> vect) {
    int x = 0;
    while (x < orders.size()) {
        orderTotal = orderTotal + orders.at(x);
        x++;
    }

    water = orderTotal;
    grounds = (orderTotal * 2.0) / 8;

    std::cout << "To complete today's order, " << water << " cups of water and " << grounds << " cups of coffee grounds are needed";
}

int main()
{
    getOrderList("input.txt");
    makeCoffee(orders);
}