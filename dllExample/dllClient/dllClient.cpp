
#include "dllExample.h"
#include <iostream>

using namespace std;
#pragma comment(lib, "dllExample.lib")

int main()
{
	int a = 1;
	int b = 2;
	int c = add(a, b);
	cout << "1 + 2 = " << c << endl;
	return 0;
}