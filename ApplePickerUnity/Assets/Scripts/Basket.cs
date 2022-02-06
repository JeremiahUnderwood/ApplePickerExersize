/***
 * 
 * Create By: Jeremiah Underwood (following book instructions)
 * Date Created: 2/5/2022
 * 
 * last Edited: 2/6/2022
 * Last Edited By: N/A
 * 
 * 
 * Description: controls basket
 ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{

    [SerializeField] private Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");  //find the score counter

        scoreGT = scoreGO.GetComponent<Text>(); //get text component
        scoreGT.text = "0"; //initialize to zero
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    //when colliding with another object
    void OnCollisionEnter(Collision coll)
    {
        //check to see object in collision was basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            int score = int.Parse(scoreGT.text); //find the current score
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
