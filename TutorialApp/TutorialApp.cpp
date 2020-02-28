// TutorialApp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <csignal>
#include <chrono>
#include <thread>

bool bTerminationRequest = false;
int number = 12345;


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

	printf("address of number is: %p \n", &number);

	while (number != 50 || bTerminationRequest)
	{
		std::this_thread::sleep_for(std::chrono::milliseconds(10));
	}

	return 0;
}

