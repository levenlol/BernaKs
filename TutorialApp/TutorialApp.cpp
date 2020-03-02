// TutorialApp.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <csignal>
#include <chrono>
#include <thread>
#include "BaseTutorial.h"
#include "FirstTutorial.h"

#define TUTORIALS_NUM 1

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

	BaseTutorial* Tutorials[TUTORIALS_NUM]{ new FirstTutorial() };
	int CurrentTutorialIndex = 0;

	while (CurrentTutorialIndex < TUTORIALS_NUM && !bTerminationRequest)
	{
		std::this_thread::sleep_for(std::chrono::milliseconds(10));

		if (Tutorials[CurrentTutorialIndex]->Check())
		{
			CurrentTutorialIndex++;
		}
	}

	for (BaseTutorial* t : Tutorials)
	{
		delete t;
	}

	return 0;
}

#undef TUTORIALS_NUM
