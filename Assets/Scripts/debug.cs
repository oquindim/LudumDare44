﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{
    // Start is called before the first frame update
    public bool FastAndFurious;
    
    void Start()
    {
        Time.timeScale = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FastAndFurious)
        {
            Time.timeScale = 1;
        } else {
            Time.timeScale = 10;
        }
        
    }
}
