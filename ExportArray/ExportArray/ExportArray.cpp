// ExportArray.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

extern "C" void OutputArray(LPWSTR* array);
extern "C" void OutputArrayIntPtr(LPWSTR* array);
extern "C" void OutputArrayIntPtrNoSubType(LPWSTR* array);

int _tmain(int argc, _TCHAR* argv[])
{
  auto array = new LPWSTR[3];

  array[0] = _wcsdup(L"One");
  array[1] = _wcsdup(L"Two");
  array[2] = _wcsdup(L"Three");

  OutputArray(array);
  OutputArrayIntPtr(array);
  OutputArrayIntPtrNoSubType(array);

  for (size_t i = 0; i < 3; i++)
  {
    free(array[i]);
  }

  delete[] array;
  return 0;
}

