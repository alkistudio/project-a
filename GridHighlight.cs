using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHighlight : MonoBehaviour
{
    Grid grid;
    [SerializeField] GameObject highlightPoint;
    List<GameObject> highlightPointGOs;
    [SerializeField] GameObject container;


    // Start is called before the first frame update
    void Awake()
    {
        grid = GetComponentInParent<Grid>();
        highlightPointGOs = new List<GameObject>();
        //Highlight(testTargetPosition);
    }

    private GameObject CreatePointHighlightObject()
    {
        GameObject go = Instantiate(highlightPoint);
        highlightPointGOs.Add(go);
        go.transform.SetParent(container.transform);
        return go;
    }

    public void Highlight(List<Vector2Int> positions)
    {
        for (int i = 0; i < positions.Count; i++)
        {
            Highlight(positions[i].x, positions[i].y, GetHighlightPointGO(i));
        }
    }

    public void Highlight(List<PathNode> positions)
    {
        for (int i = 0; i < positions.Count; i++)
        {
            Highlight(positions[i].pos_x, positions[i].pos_y, GetHighlightPointGO(i));
        }
    }

    internal void Hide()
    {
        for (int i = 0; i < highlightPointGOs.Count; i++)
        {
            highlightPointGOs[i].SetActive(false);
        }
    }

    private GameObject GetHighlightPointGO(int i)
    {
        if (highlightPointGOs.Count > i)
        {
            return highlightPointGOs[i];
        }

        GameObject newHighlightObject = CreatePointHighlightObject();
        return newHighlightObject;
    }
    
    public void Highlight(int posX, int posY, GameObject highlightObject)
    {
        highlightObject.SetActive(true);
        Vector3 position = grid.GetWorldPosition(posX, posY, true);
        position += Vector3.up * 0.2f;
        highlightObject.transform.position = position;
    }
}
