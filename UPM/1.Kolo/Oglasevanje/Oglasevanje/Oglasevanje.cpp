// Oglasevanje.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>

using namespace std;


struct Channel
{
	string name;
	int x;
	int t;
	vector<int> costs;
	vector<int> incomes;
};

int main()
{
	int numberOfChannels;
	cin >> numberOfChannels;
	vector<Channel> channels;


	for (size_t i = 0; i < numberOfChannels; i++)
	{
		bool first = true;
		Channel channel;

		string empty;
		cin.ignore();
		getline(cin, empty);


		getline(cin, channel.name);
		cin >> channel.x >> channel.t;

		for (size_t i = 0; i < channel.t; i++)
		{
			int temp;
			cin >> temp;
			channel.costs.push_back(temp);
		}

		for (size_t i = 0; i < channel.t; i++)
		{
			int temp;
			cin >> temp;
			channel.incomes.push_back(temp);
		}
		channels.push_back(channel);
	}

	int totalSum = 0;
	for (Channel channel : channels)
	{
		int sum = 0;
		for (size_t i = 0; i < channel.t; i++)
		{
			if (channel.costs[i] < channel.incomes[i])
			{
				sum += channel.incomes[i] - channel.costs[i];
			}
		}
		sum -= channel.x;
		if (sum > 0)
		{
			totalSum += sum;
		}
	}

	cout << totalSum;
}

