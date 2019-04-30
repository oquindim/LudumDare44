using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGuru : MonoBehaviour
{   
    public AnimatorControllerParameter guruController;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateGuru ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateGuru () {
        int guruSetup = PlayerPrefs.GetInt("GuruType");
        GameObject templeAsset  = Resources.Load ("guru" + guruSetup.ToString()) as GameObject;
        GameObject temple = Instantiate(templeAsset,transform) as GameObject;
    }
}
