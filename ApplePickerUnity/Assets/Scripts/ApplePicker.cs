/***
 * 
 * Create By: Jeremiah Underwood (following book instructions)
 * Date Created: 2/5/2022
 * 
 * last Edited: 2/6/2022
 * Last Edited By: N/A
 * 
 * 
 * Description: game manager
 ***/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{

    [SerializeField] private GameObject basketPrefab;
    [SerializeField] private int numBaskets = 3;
    [SerializeField] private float basketBottomY = -14f;
    [SerializeField] private float basketSpacingY = 2f;
    [SerializeField] private List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppleDestroyed()
    {
        //clear field
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count - 1; //1 less since index's start from 0
        GameObject tBasketGO = basketList[basketIndex]; //get reference to basket
        basketList.RemoveAt(basketIndex); //remove one basket from list
        Destroy(tBasketGO); //destroy removed basket

        if (basketList.Count == 0) //game over
        {
            SceneManager.LoadScene("Default Scene");
        }
    }
}
