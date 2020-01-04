#pragma once
#ifdef GAUSSJORDANELIMINATION_EXPORTS
#define GAUSSJORDANELIMINATION_API __declspec(dllexport)
#else
#define GAUSSJORDANELIMINATION_API __declspec(dllimport)
#endif


extern "C" GAUSSJORDANELIMINATION_API void chooseIdxOfFundamentalElement(int size, int step, double** matrixA, int* idx);

extern "C" GAUSSJORDANELIMINATION_API void swapColumnsUsingChosenFundamentalElement(int* idxOfFundamentalElem, int size, int step, double** matrixA, double* vectorB, int* changingColumnsInVectorX);

extern "C" GAUSSJORDANELIMINATION_API void reducingMatrix(int* idxOfFundamentalElem, int step, int size, double** matrixA, double* vectorB, double* vectorX, int* changingColumnsInVectorX);

extern "C" GAUSSJORDANELIMINATION_API void specifyVectorX(int size, double** matrixA, double* vectorB, double* vectorX);

extern "C" GAUSSJORDANELIMINATION_API void sortColumnsInVectorXByIncIdx(int size, double* vectorX, int* changingColumnsInVectorX);
