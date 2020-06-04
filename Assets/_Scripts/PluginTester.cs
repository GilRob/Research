using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PluginTester : MonoBehaviour
{
    //Variable to hole the name of my DLL
    const string DLL_NAME = "Tutorial2";

    //Initialize the DLL functions
    [DllImport(DLL_NAME)]
    private static extern void SavePosition(float posX, float posY, float posZ);
    [DllImport(DLL_NAME)]
    private static extern void LoadPosition();
    [DllImport(DLL_NAME)]
    private static extern float getX();
    [DllImport(DLL_NAME)]
    private static extern float getY();
    [DllImport(DLL_NAME)]
    private static extern float getZ();
    [DllImport(DLL_NAME)]
    private static extern void increaseJumps(int jumps);

    //Float values to hold the current position of the player
    float pX = 0.0f;
    float pY = 0.0f;
    float pZ = 0.0f;

    public int numJumps = 0;

    void Update()
    {
        //Update the values of the players position into the variables
        /*pX = transform.position.x;
        pY = transform.position.y;
        pZ = transform.position.z;*/

        if (Input.GetKeyUp(KeyCode.P))
        {
            Save();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            Load();
        }
    }

    public void Save()
    {
        Debug.Log("Saving Jumps...");

        Debug.Log(numJumps);

        //Call the SavePosition function in the DLL
        //SavePosition(pX, pY, pZ);
        increaseJumps(numJumps);
    }

    public void Load()
    {
        Debug.Log("Loading Position...");

        //Call the LoadPosition function in the DLL
        LoadPosition();

        //Call the getters in the DLL to get the values of the saved position
        float x = getX();
        float y = getY();
        float z = getZ();

        //Move the player back to the saved position
        transform.position = new Vector3(x, y, z);
    }
}
