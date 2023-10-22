﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    public float insideRadarDistance = 20;
    public float blipSizePercentage = 5;

    public GameObject rawImageBlipCube;
    public GameObject rawImageBlipSphere;

    private RawImage rawImageRadarBackground;
    private Transform playerTransform;
    private float radarWidth;
    private float radarHeight;
    private float blipWidth;
    private float blipHeight;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rawImageRadarBackground = GetComponent<RawImage>();

        radarWidth = rawImageRadarBackground.rectTransform.rect.width;
        radarHeight = rawImageRadarBackground.rectTransform.rect.height;

        blipWidth = radarWidth * blipSizePercentage / 100;
        blipHeight = radarHeight * blipSizePercentage / 100;
    }

    // Update is called once per frame
    void Update()
    {
        RemoveAllBlips();
        FindAndDisplayBlipForTag("Cube", rawImageBlipCube);
        FindAndDisplayBlipForTag("Sphere", rawImageBlipSphere);
    }

    private void RemoveAllBlips()
    {
        GameObject[] blips = GameObject.FindGameObjectsWithTag("Blip");
        foreach (GameObject blip in blips)
            Destroy(blip);
    }

    private void FindAndDisplayBlipForTag(string tag, GameObject prefabBlip)
    {
        Vector3 playerPos = playerTransform.position;
        GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);
        foreach(GameObject target in targets)
        {
            Vector3 targetPos = target.transform.position;
            float distanceToTarget = Vector3.Distance(targetPos, playerPos);
            if(distanceToTarget <= insideRadarDistance)
            {
                Vector3 normalisedTargetPosition = NormalisedPosition(playerPos, targetPos);
                Vector2 blipPosition = CalculateBlipPosition(normalisedTargetPosition);
                DrawBlip(blipPosition, prefabBlip);
            }
        }
    }

    private Vector3 NormalisedPosition(Vector3 playerPos, Vector3 targetPos)
    {
        float normalisedTargetX = (targetPos.x - playerPos.x)/insideRadarDistance;
        float normalisedTargetZ = (targetPos.z - playerPos.z) / insideRadarDistance;

        return new Vector3(normalisedTargetX, 0, normalisedTargetZ);
    }

    private Vector2 CalculateBlipPosition(Vector3 targetPos)
    {
        // find angle from player to target
        float angleToTarget = Mathf.Atan2(targetPos.x, targetPos.z) * Mathf.Rad2Deg;

        // direction player is facing
        float anglePlayer = playerTransform.eulerAngles.y;

        // subtract player angle, to get relative angle to object
        // subtract 90
        // (so 0 degrees (same direction as player) is UP)
        float angleRadarDegrees = angleToTarget - anglePlayer - 90;

        // calculate (x, y) position given angle and distance
        float normalisedDistanceToTarget = targetPos.magnitude;
        float angleRadians = angleRadarDegrees * Mathf.Deg2Rad;
        float blipX = normalisedDistanceToTarget * Mathf.Cos(angleRadians);
        float blipY = normalisedDistanceToTarget * Mathf.Sin(angleRadians);

        // scale blip position according to radar size
        blipX *= radarWidth / 2;
        blipY *= radarHeight / 2;

        // offset blip position relative to radar center
        blipX += radarWidth / 2;
        blipY += radarHeight / 2;

        return new Vector2(blipX, blipY);
    }

    private void DrawBlip(Vector2 pos, GameObject blipPrefab)
    {
        GameObject blipGO = (GameObject)Instantiate(blipPrefab);
        blipGO.transform.SetParent(transform.parent);
        RectTransform rt = blipGO.GetComponent<RectTransform>();
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, pos.x, blipWidth);
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, pos.y, blipHeight);
    }
}
