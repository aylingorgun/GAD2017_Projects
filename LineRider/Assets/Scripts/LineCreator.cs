using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreator : MonoBehaviour
{
    public GameObject LinePrefab;
    Line activeLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineGo = Instantiate(LinePrefab);
            activeLine = lineGo.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
             activeLine = null;
        }
        if(activeLine != null) { 
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }
}
