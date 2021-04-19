// Periode.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <vector>
#include <cmath>

using namespace std;

int main()
{
	string input;
	getline(cin, input);

	int celiDel;
	int decimalDel;
	int periodaDel;
	string celiDelStr = "";
	string decimalDelStr = "";
	string periodalDelStr = "";
	int pikaIndex = -1;
	int oklepajIndex = -1;

	//Get whole part
	for (size_t i = 0; i < input.size(); i++)
	{
		if (input[i] != '.')
		{
			celiDelStr.push_back(input[i]);
		}
		else {
			pikaIndex = i;
			break;
		}
	}


	if (pikaIndex > -1)
	{
		for (size_t i = pikaIndex + 1; i < input.size(); i++)
		{
			if (input[i] != '(')
			{
				decimalDelStr.push_back(input[i]);
			}
			else {
				oklepajIndex = i;
				break;
			}
		}
	}

	if (oklepajIndex > -1)
	{
		for (size_t i = oklepajIndex + 1; i < input.size(); i++)
		{
			if (input[i] != ')')
			{
				periodalDelStr.push_back(input[i]);
			}
			else {
				break;
			}
		}
	}


	string combined;
	if (decimalDelStr != "")
	{
		combined = celiDelStr + "." + decimalDelStr;
	}

	if (periodalDelStr != "")
	{
		for (size_t i = combined.size(); i < 18; i++)
		{
			combined += periodalDelStr;
		}
	}

	float x = stof(combined);


	if (periodalDelStr != "")
	{
		float tenX = x * 10;
		float previous = -1;
		int stevec;
		if (decimalDelStr.length() == 0)
		{
			decimalDelStr += periodalDelStr + periodalDelStr;
		}
		for (size_t i = 0; i < decimalDelStr.size(); i++)
		{
			stevec = i + 2;
			previous = tenX;
			tenX *= 10;
		}


		float nineX;
		nineX = tenX - previous;


		int imenovalec = pow(10, stevec) - pow(10, stevec - 1);
		int skupniImenovalec;
		for (size_t i = 1; i < imenovalec; i++)
		{
			if ((int)nineX % i == 0 && imenovalec % i == 0)
			{
				skupniImenovalec = i;
			}
		}

		stevec = nineX / skupniImenovalec;
		imenovalec = imenovalec / skupniImenovalec;
	}




	//float nineX;
	//if (previous != -1)
	//{
	//	nineX = tenX - previous;
	//}
	//else
	//	nineX = tenX;

	//
	//int imenovalec = pow(10, stevec) - pow(10, stevec - 1);


	//int skupniImenovalec;
	//for (size_t i = 1; i < imenovalec; i++)
	//{
	//	if ((int)nineX % i == 0 && imenovalec % i == 0)
	//	{
	//		skupniImenovalec = i;
	//	}
	//}

	//stevec = nineX / skupniImenovalec;
	//imenovalec = imenovalec / skupniImenovalec;



	cout << "Marko";


}
