using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public double timeInstantiated;
    public double assignedTime;
    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }

    void Update()
    {

        double currentTime = SongManager.GetAudioSourceTime();
        double timeToHit =  currentTime - timeInstantiated;
        float totalTravelTime = SongManager.Instance.noteTime * 2;

        float t = (float)(timeToHit / totalTravelTime);

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            print($"Note {timeInstantiated} - Time to hit: {timeToHit:F3} seconds, t: {t:F3}");
            // Only update the Y position, keep X/Z from the lane
            transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.Instance.noteSpawnY, Vector3.up * SongManager.Instance.noteDespawnY, t);

            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
