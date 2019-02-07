#include <stdio.h>
#include <cstring>
#include "Comm.h"

double test1 = 0;

typedef void(*pLoggingFunc)(MessageItemData, bool);

static pLoggingFunc pFunc;

MessageItemData item;



//�ܺ� �Լ�
extern "C" __declspec(dllexport) bool Send(MessageItemData* pItemsData)
{
	bool bRet = false;

	printf("---------- C++ ----------\n");
	printf("%d\n", pItemsData->_num);
	printf("%lf\n", pItemsData->_dnum);
	for (int i = 0; i < 5; i++) {
		printf("%lf \t", pItemsData->_todo[i]);
	}

	printf("\n");

	printf("%s", pItemsData->strTest);

	printf("\n");

	printf("%s", pItemsData->isRun ? "true" : "false");

	item._num = pItemsData->_num;
	item._dnum = pItemsData->_dnum;
	item._todo[0] = pItemsData->_todo[0];
	item._todo[1] = pItemsData->_todo[1];
	item._todo[2] = pItemsData->_todo[2];

	/*for (int i = 0; i < sizeof(pItemsData->strTest); i++) {
		item.strTest[i] = *(pItemsData->strTest + i);
	}*/

	//strncpy_s(item.strTest, pItemsData->strTest, strlen(pItemsData->strTest) + 1);

	strcpy_s(item.strTest, strlen(pItemsData->strTest) + 1, pItemsData->strTest);

	item.isRun = pItemsData->isRun;

	item._num = item._num + 5;
	item._dnum = item._dnum + 5;
	item._todo[0] = item._todo[0] + 5;
	item._todo[1] = item._todo[1] + 5;
	item._todo[2] = item._todo[2] + 5;
	item.isRun = !item.isRun;



	bRet = true;


	return bRet;
}

extern "C" __declspec(dllexport) bool Init(pLoggingFunc del)
{
	bool bRet = false;

	/*MessageItemData pData;
	memset(&pData, 0x00, sizeof(MessageItemData));

	pData._num = 3;
	pData._dnum = 5.5;
	for (int i = 0; i < 3; i++) {
		pData._todo[i] = i * 2;
	}

	*(pData.strTest) = 'a';

	pData.isRun = false;*/



	pFunc = del;

	pFunc(item, true);

	bRet = true;

	return bRet;
}