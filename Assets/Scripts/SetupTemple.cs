using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class SetupTemple : MonoBehaviour
{
    
    public DataController scriptExt;
    private int[] levelArray = new int[]{100,500,2000,5000};
    private int levelAtual;

    // Start is called before the first frame update

    void Start() {
        levelAtual = 0;
        InstantiateTemple(levelAtual);
    }
    // void Update() {
    //     if (scriptExt.getFollowers() > levelArray[levelAtual]) {
    //         print(scriptExt.getFollowers());
    //         levelAtual = levelAtual + 1;
    //         ReplaceTempleGo (levelAtual);
    //         Debug.Log("trocouLevel");
    //     }
    // }

    public void ReplaceTempleGo (int templeLevel) {
        
        Destroy (transform.Find("templo"+(templeLevel-1).ToString()+"(Clone)").gameObject);

        InstantiateTemple(templeLevel);
    }

    void InstantiateTemple (int templeLevel) {
        GameObject templeAsset  = Resources.Load ("templo" + templeLevel.ToString()) as GameObject;
        GameObject temple = Instantiate(templeAsset,transform) as GameObject;
    }




}
