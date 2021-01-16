using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] public int Point;
    

    void Start()
    {
        GetComponent<SaveLoad>().Load();
        score.text = Point.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Point += 10;
            score.text = Point.ToString();

            GetComponent<SaveLoad>().Save();
        }
      
    }
    
}