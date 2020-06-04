#pragma once

#include "PluginSettings.h"
#include "FileManager.h"

#ifdef __cplusplus
extern "C"
{
#endif

	// Put your functions here

	PLUGIN_API void SavePosition(float posX, float posY, float posZ, float id);

	PLUGIN_API Vec3* LoadPosition();

	PLUGIN_API float getX();
	PLUGIN_API float getY();
	PLUGIN_API float getZ();


#ifdef __cplusplus
}
#endif