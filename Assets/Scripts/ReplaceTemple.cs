using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class ReplaceTemple : MonoBehaviour
{




    // Start is called before the first frame update
 

    public void ReplaceTempleInput (int templeLevel) {
        
        GameObject previewTemple = transform.Find("templo"+(templeLevel-1).ToString()+"(Clone)").gameObject;
        Destroy (previewTemple);
        GameObject templeAsset  = Resources.Load ("templo" + templeLevel.ToString()) as GameObject;
        GameObject temple = Instantiate(templeAsset,transform) as GameObject;
    }




}
