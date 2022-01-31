/***
 * 
 * Create By: Jeremiah Underwood (following book instructions)
 * Date Created: 1/31/2022
 * 
 * last Edited: N/A
 * Last Edited By: N/A
 * 
 * 
 * Description: Tree Behavior
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] float speed = 1f;
    [SerializeField] float leftAndRightEdge = 10f;
    [SerializeField] float chanceToChangeDirections = 0.1f;
    [SerializeField] float secondsBetwenApples = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetwenApples);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (Mathf.Abs(pos.x) > leftAndRightEdge)
        {
            speed *= -1;
        }
        else if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
