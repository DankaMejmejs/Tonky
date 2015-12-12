using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    float maxShakeTime = 0;
    float shakeTime = 0;
    float shakeMax = 0;
    float shakeMin = 0;

    void Start () {
	}
	
	void Update () {
	}

    public void Shake(float intensity) {
        transform.position += new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), 0);
    }

    public void Shake(float max, float min, float time) {
        shakeMax = max;
        shakeMin = min;
        shakeTime = maxShakeTime = time;
    }
}
