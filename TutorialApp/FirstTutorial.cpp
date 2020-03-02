#include "FirstTutorial.h"
#include <iostream>

#define FIRST_TUTORIAL_EXPECTED_VALUE 50

bool FirstTutorial::Check_Internal()
{
	return ChangeMe == FIRST_TUTORIAL_EXPECTED_VALUE;
}

void FirstTutorial::OnActivation()
{
	std::cout << "Starting first tutorial. Variable address is: " << &ChangeMe << "  - The expected value is: " << FIRST_TUTORIAL_EXPECTED_VALUE << "\n";
}

#undef FIRST_TUTORIAL_EXPECTED_VALUE
