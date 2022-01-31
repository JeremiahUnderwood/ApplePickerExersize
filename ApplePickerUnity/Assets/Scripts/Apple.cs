/***
 * 
 * Create By: Jeremiah Underwood (following book instructions)
 * Date Created: 1/31/2022
 * 
 * last Edited: N/A
 * Last Edited By: N/A
 * 
 * 
 * Description: Despawns Apples
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private float despawnDistance;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < despawnDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
