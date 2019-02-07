#pragma once

#pragma pack(push, 1)
struct MessageItemData
{
	int _num;
	double _dnum;
	double _todo[3];
	char  strTest[128];
	bool isRun;
};
#pragma pack(pop)