using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSettings : MonoBehaviour {

    

	void Start () {
        this.GetComponent<VideoPlayer>().targetCameraAlpha = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
