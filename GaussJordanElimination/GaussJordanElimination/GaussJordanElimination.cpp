// GaussJordanElimination.cpp : Defines the exported functions for the DLL application.

#include "stdafx.h"
#include <iostream>
#include <string>
#include <cmath>
#include "GaussJordanElimination.h"
void chooseIdxOfFundamentalElement(int size, int step, double** matrixA, int* idx) {
	idx[0] = step;
	idx[1] = step; 
	double max = fabs(matrixA[step][step]);
	for (int row = step; row < size; row++) {
		for (int column = step; column < size; column++) {
			if (fabs(matrixA[row][column]) > max) {
				max = fabs(matrixA[row][column]);
				idx[0] = row;
				idx[1] = column;
			}
		}
	}
	if (max == 0) {
		idx[0] = -1;
		idx[1] = -1;
	}
}
void swapColumnsUsingChosenFundamentalElement(int* idxOfFundamentalElem, int size, int step, double** matrixA, double* vectorB, int* changingColumnsInVectorX) {

	for (int column = 0; column < size; column++) {
		std::swap(matrixA[step][column], matrixA[idxOfFundamentalElem[0]][column]);
	}
	for (int row = 0; row < size; row++) {
		std::swap(matrixA[row][step], matrixA[row][idxOfFundamentalElem[1]]);
	}
	std::swap(vectorB[step], vectorB[idxOfFundamentalElem[0]]);

	std::swap(changingColumnsInVectorX[step], changingColumnsInVectorX[idxOfFundamentalElem[1]]);
}
void reducingMatrix(int* idxOfFundamentalElem, int step, int size, double** matrixA, double* vectorB, double* vectorX, int* changingColumnsInVectorX) {

		swapColumnsUsingChosenFundamentalElement(idxOfFundamentalElem, size, step, matrixA, vectorB, changingColumnsInVectorX);
		double temp = matrixA[step][step];
		for (int column = step; column < size; column++)
			matrixA[step][column] /= temp;
		vectorB[step] = vectorB[step] / temp;
		for (int row = 0; row < size; row++) {
			if (row != step) {
				double tmp = matrixA[row][step];
				for (int column = step; column < size; column++)
					matrixA[row][column] = matrixA[row][column] - (tmp * matrixA[step][column]);
				vectorB[row] = vectorB[row] - (tmp * vectorB[step]);
			}
		}
		
}
void specifyVectorX(int size, double** matrixA, double* vectorB, double* vectorX) {
if (matrixA[size - 1][size - 1] != 0)
			vectorX[size - 1] = vectorB[size - 1] / matrixA[size - 1][size - 1];
		for (int row = 0; row < size; row++)
			vectorX[row] = vectorB[row];
}
//display xi in order notation e.x.
//4 5 3 2 1 0 <-changingColumns, in vectorX xi values are in this order: x4,x5,x3,x2,x1,x0
//0 1 2 3 4 5 <-compare idx in vectorX to value in vector: changingColumnsInVectorX, because it's necessary to keep this order
void sortColumnsInVectorXByIncIdx(int size, double* vectorX, int* changingColumnsInVectorX) {
	for (int row = 0; row < size; row++) {
		if (row != changingColumnsInVectorX[row]) {
			for (int j = row + 1; j < size; j++) {
				if (row == changingColumnsInVectorX[j]) {
					std::swap(vectorX[row], vectorX[j]);
					std::swap(changingColumnsInVectorX[row], changingColumnsInVectorX[j]);
				}
			}
		}
	}
}
