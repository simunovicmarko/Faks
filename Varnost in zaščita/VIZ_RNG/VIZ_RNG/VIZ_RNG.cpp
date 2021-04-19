// VIZ_RNG.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <chrono>
#include <math.h>


using namespace std::chrono;


class Random {
public:
	Random() {

	}


	int Range(int from, int to) {
		int res = 0;
		int neki = ms.count();
		res = (int)sin((double)(neki * from)) % to;

		return 0;
	}
private:
	milliseconds getCurrentTime() {
		return duration_cast<milliseconds>(system_clock::now().time_since_epoch());
	}
	milliseconds ms = getCurrentTime();
};

int main()
{
	//std::cout << "Hello World!\n";
	Random rng;
	int res = rng.Range(5, 6);
}