#include <iostream>
#include <vector>
#include <map>
#include <string>

//using namespace std;







int getNum(int sm1, int sm2, int x, int y, int m) {
	int res = (sm2 * x + sm1 * y) % m;
	return res;
}

int main()
{
	//Prva vrstica
	int n;  //število elementov
	int k; //Zadnjih k pojavitev


	std::cin >> n >> k;

	//druga vrstrica
	int s1, s2, x, y, m;

	std::cin >> s1 >> s2 >> x >> y >> m;


	//Tretja vrstica
	int a, b;
	std::cin >> a >> b;



	//std::vector<int> arr(n);

	//arr[0] = s1;
	//arr[1] = s2;

	//Generiranje seznama
	//Iskanje števil
	std::vector<int> finalArr;
	std::map<int, int> numbers;


	/*for (size_t i = 2; i < n; i++)
	{
		arr[i] = getNum(arr[i - 1], arr[i - 2], x, y, m);
	}*/

	int i1 = s1;
	int i2 = s2;
	finalArr.push_back(s1);
	finalArr.push_back(s2);
	int next;
	std::map<int, std::vector<int>> indexes;
	for (size_t i = 0; i < n; i++)
	{
		next = getNum(i2, i1, x, y, m);
		//std::cout << next;

		if (numbers.find(next) == numbers.end())
		{
			numbers.insert(std::pair<int, int>(next, 1));
		}
		else
		{
			for (size_t j = 0; j < finalArr.size(); j++)
			{
				if (finalArr[j] == next)
				{
					if (numbers[next] >= k)
					{
						finalArr.erase(finalArr.begin() + j);
						break;
					}
					else {
						numbers[next]++;
						break;
					}
				}
			}
		}

		finalArr.push_back(next);
		i1 = i2;
		i2 = next;

	}



	/*for (size_t i = 0; i < finalArr.size(); i++)
	{
		std::cout << finalArr[i] << " ";
	}*/
	for (size_t i = a; i <= b; i++)
	{
		std::cout << finalArr[i] << " ";
	}
}

	/*std::map<int, std::vector<int>> firsts;

	for (size_t i = 0; i < arr.size(); i++)
	{
		if (numbers.find(arr[i]) == numbers.end())
		{
			numbers.insert(std::pair<int, int>(arr[i], 1));
			std::vector<int> temp;
			temp.push_back(i);
			firsts.insert(std::pair<int, std::vector<int>>(arr[i], i));
		}
		else
		{

			for (size_t j = 0; j < finalArr.size(); j++)
			{
				if (finalArr[j] == arr[i])
				{
					if (numbers[arr[i]] >= k)
					{
						finalArr.erase(finalArr.begin() + j);
						break;
					}
					else {
						numbers[arr[i]]++;
					}
				}
			}
		}

		finalArr.push_back(arr[i]);
	}*/


