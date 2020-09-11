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


#pragma pack(push, 1)
class TransDataItem
{
public:
	int IntValue;
	double DoubleValue;
	char  StringValue[128];
	bool BoolValue;

	TransDataItem(int ivalue, double dvalue, char* svalue, bool bvalue)
	{
		IntValue = ivalue;
		DoubleValue = dvalue;
		strcpy_s(StringValue, 128, svalue);
		BoolValue = bvalue;
	}
};
#pragma pack(pop)


enum class eError
{
	eNONE = 0,
	eNULLED = 1,
};
