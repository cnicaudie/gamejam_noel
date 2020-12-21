using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //==========// METHODS //==========//

    private void Update()
    {
        // Press space to turn on/off a light ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Light();
        }
    }

    private void Light()
    {
        //Debug.Log("SEARCHING FOR A LIGHT...");

        // Gets all colliders within a radius
        Collider[] lights = Physics.OverlapSphere(transform.position, 5);

        // We go through each found colliders
        foreach (Collider c in lights)
        {
            // If one of them is a Light Orb
            if (c.gameObject.CompareTag("LightOrb"))
            {
                //Debug.Log("FOUND THE LIGHT !");

                // We go through the children to find the light to turn on/off
                foreach (Transform child in c.gameObject.GetComponentsInChildren<Transform>(true))
                {
                    GameObject obj = child.gameObject;
                    //Debug.Log(g.name);

                    if (obj.name == "Point Light")
                    {
                        if (obj.activeSelf)
                        {
                            obj.SetActive(false);
                        } else
                        {
                            obj.SetActive(true);
                        }
                    }                
                }
            }
        }
    }
}
