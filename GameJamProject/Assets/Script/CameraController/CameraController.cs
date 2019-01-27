using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Camera[] cameras;

	public void resetAll() {
		if (cameras.Length <= 1) { return; }
		for (int i = 0; i < cameras.Length; i++) {
			cameras[i].depth = -999;
		}
		// mainCamera
		cameras[0].depth = -1;
	}

	public void switchCamera(int value) {
		for (int i = 0; i < cameras.Length; i++)
		{
			cameras[i].depth = -999;
		}
		cameras[value].depth = -1;
	}
}
