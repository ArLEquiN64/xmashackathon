﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasol : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if (other.tag == "Snow") {
            Debug.Log("Snow hit on Parasol.");
            Destroy(other.gameObject);
        }
        if (other.tag == "PresentBox") {
            Debug.Log("PresentBox hit on Parasol.");
        }
        if (other.tag == "Item") {
            Debug.Log("Item hit on Parasol.");
        }
    }
}