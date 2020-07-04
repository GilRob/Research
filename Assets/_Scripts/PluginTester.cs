using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

/*public class WebDownloadHelper
{
    // Source: http://stackoverflow.com/a/27284736/1607924
    static string scriptTemplate = @"
             var link = document.createElement(""a"");
             link.download = '{0}';
             link.href = 'data:application/octet-stream;charset=utf-8;base64,{1}';
             document.body.appendChild(link);
             link.click();
             document.body.removeChild(link);
             delete link;
         ";

    public static void InitiateDownload(string aName, byte[] aData)
    {
        string base64 = System.Convert.ToBase64String(aData);
        string script = string.Format(scriptTemplate, aName, base64);
        Application.ExternalEval(script);
    }
    public static void InitiateDownload(string aName, string aData)
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes(aData);
        InitiateDownload(aName, data);
    }
}*/

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

    public string numJumps = "0";
    //public int numJumps = 0;

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

        if (Input.GetKeyUp(KeyCode.O))
        {
            WebDownloadHelper.InitiateDownload("Save.csv", numJumps + ", 'Test'");
        }
    }

    public void Save()
    {
        Debug.Log("Saving Jumps...");

        Debug.Log(numJumps);

        //Call the SavePosition function in the DLL
        //SavePosition(pX, pY, pZ);
        //increaseJumps(numJumps);
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
