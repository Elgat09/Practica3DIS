using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolygonDrawer : MonoBehaviour
{
   
    public int sides = 3; 
    public float radius = 1f;
    public Vector3 center = Vector3.zero;

    public Color startColor = Color.red;
    public Color endColor = Color.blue;
    public Color midColor = Color.black;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DrawPolygon();
    }

    void DrawPolygon()
    {
       
        Vector3[] vertexPositions = new Vector3[sides];
        float angleIncrement = 360f / sides;

        for (int i = 0; i < sides; i++)
        {
            float angle = i * angleIncrement;
            Vector3 vertexPosition = center + Quaternion.Euler(0f, angle, 0f) * Vector3.forward * radius;
            vertexPositions[i] = vertexPosition;
        }

        
        lineRenderer.positionCount = sides;
        lineRenderer.SetPositions(vertexPositions);
        lineRenderer.loop = true;

        Gradient gradient = new Gradient();
        gradient.colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(startColor, 0f), 
            new GradientColorKey(endColor, 1f),
            new GradientColorKey(midColor, 0.5f)
        };

        lineRenderer.colorGradient = gradient;


    }
}



