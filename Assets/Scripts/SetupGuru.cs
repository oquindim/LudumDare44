using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGuru : MonoBehaviour
{   
    public AnimatorControllerParameter guruController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateTemple (int guruLevel) {
        GameObject templeAsset  = Resources.Load ("templo" + guruLevel.ToString()) as GameObject;
        GameObject temple = Instantiate(templeAsset,transform) as GameObject;
    }
}
