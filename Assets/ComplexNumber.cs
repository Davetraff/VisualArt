using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexNumber : MonoBehaviour
{
    public GameObject myPlotPoint;
    public float numPoints;
    public float turnFraction;
    public Color myColor;
    private float turnFractionMod = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPoints; i++){
            float dst = i / (numPoints - 1f);
            float angle = 2 * Mathf.PI * turnFraction * i;

            float x = dst * Mathf.Cos(angle);
            float y = dst * Mathf.Sin(angle);

            PlotPoint(x, y, i);
        }
    }

    private void PlotPoint(float x, float y, int myIValue)
    {
        GameObject myNewPlotPoint = Instantiate(myPlotPoint, new Vector3(x, y, 0f), transform.rotation, transform);

        myNewPlotPoint.GetComponent<Transform>().name = myNewPlotPoint + myIValue.ToString();
        if (myIValue % 51 == 0)
        {
            myNewPlotPoint.GetComponent<SpriteRenderer>().color = myColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
           
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
                Debug.Log("Child Destroyed");
            }
            if (turnFraction >= 0.1f)
            {
                turnFractionMod = -0.001f;
            
            }
            if (turnFraction <= 0f)
            {
                turnFractionMod = 0.001f;
            }
        
            turnFraction += turnFractionMod;
        numPoints = turnFraction * 1000;

        Start(); 
        }
}
