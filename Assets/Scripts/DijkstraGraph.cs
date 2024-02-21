using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijkstraGraph : MonoBehaviour
{
    [SerializeField] private int fromShorted, toShorted;
    [SerializeField] private Transform[] pointsPos;

    private LineRenderer _lineRenderer;
    
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        
        List<int> shortedPath = Graph.Draw(fromShorted, toShorted);
        
        GetComponent<LineRenderer>().positionCount = (shortedPath.Count);
        
     
      
        for (int i = 0; i < shortedPath.Count; i++)
        {
            Vector3 pos = pointsPos[shortedPath[i] - 1].position;
            _lineRenderer.SetPosition(i,pos);
        }
    }
}