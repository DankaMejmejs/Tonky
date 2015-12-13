using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    float maxShakeTime = 0;
    float shakeTime = 0;
    float shakeMax = 0;
    float shakeMin = 0;

    public float transitionLevel = 1;
    float targetTransition = 1;

    FMOD.Studio.EventInstance music;

    void Start () {
        music = FMOD_StudioSystem.instance.GetEvent("event:/Music");
        music.start();
    }
	
	void Update () {
        transitionLevel = targetTransition;
        music.setParameterValue("Transition", transitionLevel);
    }

    public void Shake(float intensity) {
        transform.position += new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), 0);
    }

    public void Shake(float max, float min, float time) {
        shakeMax = max;
        shakeMin = min;
        shakeTime = maxShakeTime = time;
    }

    public void setMusicLevel(int level) {
        // 0 - 0.20
        // 0.55 - 0.81
        // 0.90 - 1
        

        switch (level)
        {
            case 0:
                targetTransition = 0;
                break;
            case 1:
                targetTransition = 0.21f;
                break;
            case 2:
                targetTransition = 0.55f;
                break;
        }
    }

    public void resetMusic()
    {
        targetTransition = 0.91f;
    }
}
