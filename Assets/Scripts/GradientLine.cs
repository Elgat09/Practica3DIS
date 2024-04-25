using UnityEngine;

public class GrandientLine : MonoBehaviour
{
    public Color startColor, endColor;
    public GameObject linePrefab;
    public float lineWidth;

    void Start()
    {
        CreateVerticalGradientLines();
    }

    void CreateVerticalGradientLines()
    {
        Camera cam = Camera.main;

        float screenHeight = 2f * cam.orthographicSize;
        float screenWidth = screenHeight * cam.aspect;

        int numberOfLines = Mathf.CeilToInt(screenHeight / lineWidth);

        float lineHeight = screenHeight / numberOfLines;

        for (int i = 0; i < numberOfLines; i++)
        {
            float yPosition = i * lineHeight - screenHeight / 2f + lineHeight / 2f;

            GameObject lineObject = Instantiate(linePrefab, transform);
            LineRenderer lineRenderer = lineObject.GetComponent<LineRenderer>();
            if (lineRenderer == null)
            {
                lineRenderer = lineObject.AddComponent<LineRenderer>();
            }

            lineRenderer.positionCount = 2;

            lineRenderer.startWidth = lineWidth;
            lineRenderer.endWidth = lineWidth;

            float normalizedGradientValue = i / (float)(numberOfLines - 1);

            Color interpolatedColor = Color.Lerp(startColor, endColor, normalizedGradientValue);
            lineRenderer.startColor = interpolatedColor;
            lineRenderer.endColor = interpolatedColor;

            lineRenderer.SetPosition(0, new Vector3(screenWidth / 2f, yPosition, 0f));
            lineRenderer.SetPosition(1, new Vector3(-screenWidth / 2f, yPosition, 0f));
        }
    }
}
