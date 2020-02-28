// TutorialApp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <csignal>

bool bTerminationRequest = false;

void sigHandler(int signum)
{
	std::cout << "Received term signal\n";

	bTerminationRequest = true;
}

// used for debug/tutorial purposes for BernaKs tool.
int main()
{
	signal(SIGTERM, sigHandler);
	signal(SIGINT, sigHandler);


	int number = 12345;
	while (number != 50 || bTerminationRequest)
	{

	}

	return 0;
}

