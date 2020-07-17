using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScript : MonoBehaviour
{
    public bool vrEnabled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VREnabled()
    {
        vrEnabled = true;
        LoadScene();
    }

    public void VRDisabled()
    {
        vrEnabled = false;
        LoadScene();
    }

    private void LoadScene()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.LoadScene(1);
    }
}
