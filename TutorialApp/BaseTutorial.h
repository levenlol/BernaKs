#pragma once

class BaseTutorial
{
public:
	bool Check();

protected:
	virtual void OnActivation();

	virtual bool Check_Internal();
private:

	bool bActive = false;
};

