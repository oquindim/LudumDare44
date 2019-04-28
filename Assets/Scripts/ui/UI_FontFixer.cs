﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FontFixer : MonoBehaviour
{
	// Start is called before the first frame update
	public Font[] fonts;
	void Start()
	{
		for (int i = 0; i < fonts.Length; i++)
		{
			fonts[i].material.mainTexture.filterMode = FilterMode.Point;
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
