#pragma once

#define DLLEXAMPLE_EXPORT_API __declspec(dllexport)

extern "C" DLLEXAMPLE_EXPORT_API int add(int a, int b);