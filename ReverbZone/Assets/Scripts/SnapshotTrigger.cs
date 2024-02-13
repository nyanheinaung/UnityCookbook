using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotTrigger : MonoBehaviour
{
    public AudioMixerSnapshot snapshot;
    public float crossfade;

    private void OnTriggerEnter(Collider other)
    {
        snapshot.TransitionTo(crossfade);
    }
}
