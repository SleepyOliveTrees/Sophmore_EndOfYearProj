using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float assignedTime;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on Note prefab!");
        }
    }

    void Update()
    {
        float songTime = (float)SongManager.GetAudioSourceTime();
        float timeToHit = assignedTime - songTime;
        float totalTravelTime = SongManager.Instance.noteTime;

        // Calculate t and clamp between 0 and 1 for safety
        float t = Mathf.Clamp01(1f - (timeToHit / totalTravelTime));

        if (t >= 1f)
        {
            print(t);
            Destroy(gameObject);
        }
        else
        {
            // Only update the Y position, keep X/Z from the lane
            Vector3 pos = transform.localPosition;
            pos.y = Mathf.Lerp(SongManager.Instance.noteSpawnY, SongManager.Instance.noteDespawnY, t);
            transform.localPosition = pos;

            if (spriteRenderer != null)
                spriteRenderer.enabled = true;
        }
    }
}
