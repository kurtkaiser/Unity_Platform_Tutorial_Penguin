﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private float upSpeed = 2.5f;
    private Rigidbody2D groundRigid;
    private float xStart;
    public GameObject rewardPrefab;
    private GameObject tempPrefab;

    void Start()
    {
        groundRigid = GetComponent<Rigidbody2D>();
        xStart = groundRigid.position.x;
    }

    void Update()
    {
        groundRigid.velocity = new Vector2(0, upSpeed);
        Respawn();
    }

    void Respawn()
    {
        if (transform.position.y > 6)
        {
            float xPos = Random.Range(xStart - 2f, xStart + 2f);
            float yPos = Random.Range(-8.0f, -5.0f);
            transform.position = new Vector2(xPos, yPos);
            SpawnReward(xPos, yPos);
        }
    }

    void SpawnReward(float xPos, float yPos)
    {
        Destroy(tempPrefab);
        int fishChance = Random.Range(1, 6);
        if (fishChance > 4)
        {
            tempPrefab = Instantiate(rewardPrefab, new Vector3
            (xPos, yPos + 0.5f, 0), Quaternion.identity);
            Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
            // apply it on current object's material
            tempPrefab.GetComponent<Renderer>().material.color = newColor;
        }
    }
}