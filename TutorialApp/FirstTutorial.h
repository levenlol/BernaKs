#pragma once

#include "BaseTutorial.h"

class FirstTutorial : public BaseTutorial
{
public:
	int ChangeMe = 12345;

protected:
	virtual void OnActivation() override;

	virtual bool Check_Internal() override;

private:
};

