using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateProbe : MonoBehaviour
{
    private ReflectionProbe probe;

    // Start is called before the first frame update
    void Awake()
    {
        probe = GetComponent<ReflectionProbe>();
        probe.RenderProbe();
    }

    public void RefreshProbe()
    {
        probe.RenderProbe();
    }
}
