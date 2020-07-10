using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebDownloadHelper
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
}

public class UserMetricsCapture : MonoBehaviour
{
    //Timer to keep track of how long it takes to complete
    private float mainTimer = 0.0f;
    //Timer to keep track of how long it takes to complete each task
    public float taskTimer = 0.0f;
    public float[] taskSplits;
    //Timer to keep track of how long it takes to get to each guide sound when finding your seat
    public float guideTimer = 0.0f;
    //public float[] guideSplits;
    public List<float> guideSplits = new List<float>();

    //Used to access data
    public GuideSounds guide;

    //String arrays to hold all the data
    private List<string> guideTimeStrings = new List<string>();
    private string[] taskTimeStrings;

    private bool downloadTime;
    private bool notDownloaded;

    //List to hold key presses and timestamps
    private List<string> keyStamps = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        downloadTime = false;
        notDownloaded = true;

        taskTimeStrings = new string[3];
    }

    // Update is called once per frame
    void Update()
    {
        //Keep track of key presses
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey))
            {
                keyStamps.Add(vKey.ToString() + ", " + System.DateTime.Now.ToLongTimeString() + "\n");
                Debug.Log(vKey);
            }
        }

        //Total timer
        if (!guide.completed)
        {
            mainTimer += Time.deltaTime;
            taskTimer += Time.deltaTime;
        }
        else if (guide.completed && !downloadTime)
        {
            mainTimer.ToString();
            Debug.Log(mainTimer);

            //Go through the splits and convert them to strings
            for (int i = 0; i < taskTimeStrings.Length; i++)
            {
                taskTimeStrings[i] = taskSplits[i].ToString();
                Debug.Log(taskTimeStrings[i]);
            }

            downloadTime = true;
        }

        if (!guide.guidesCompleted && guide.guideSection)
        {
            guideTimer += Time.deltaTime;
        }
        else if (guide.guidesCompleted && guide.guideSection)
        {
            //Go through the splits and convert them to strings
            for (int i = 0; i < guideSplits.Count; i++)
            {
                guideTimeStrings.Add("Guide " + (i + 1) + ":, " + guideSplits[i].ToString() + "\n");
                Debug.Log(guideTimeStrings[i]);
            }
            guide.guideSection = false;
        }

        //Put together information for download
        if (downloadTime && notDownloaded)
        {
            string downloadText = 
                "Completion Time:, " + mainTimer + "\n" +
                "Time to each sound guide to find seat:\n";

            for (int i = 0; i < guideTimeStrings.Count; i++)
            {
                downloadText += guideTimeStrings[i];
            }

            downloadText +=
                "Time to complete each task:" + "\n" +
                "Registration:, " + taskTimeStrings[0] + "\n" +
                "Seat:, " + taskTimeStrings[1] + "\n" +
                "Podium:, " + taskTimeStrings[2] + "\n" +
                "Key Press:, Time Stamp:\n";

            for (int i = 0; i < keyStamps.Count; i++)
            {
                downloadText += keyStamps[i];
            }

            Debug.Log(downloadText);

            WebDownloadHelper.InitiateDownload("User Metrics.csv", downloadText);              

            notDownloaded = false;
        }

    }
}
