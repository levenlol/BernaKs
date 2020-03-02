#include "BaseTutorial.h"

bool BaseTutorial::Check()
{
	if (!bActive)
	{
		bActive = true;
		OnActivation();
	}

	return Check_Internal();
}

void BaseTutorial::OnActivation()
{

}

bool BaseTutorial::Check_Internal()
{
	return false;
}
