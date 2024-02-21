using System;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private Dictionary<int, List<int>> vertices;

    public Graph(Dictionary<int, List<int>> graphVertices)
    {
        vertices = graphVertices;
    }

    public List<int> FindShortestPath(int startVertex, int endVertex)
    {
        Dictionary<int, int> distances = new Dictionary<int, int>();
        Dictionary<int, int> previousVertices = new Dictionary<int, int>();
        List<int> unvisitedVertices = new List<int>();

        foreach (var vertex in vertices.Keys)
        {
            distances[vertex] = int.MaxValue;
            previousVertices[vertex] = -1;
            unvisitedVertices.Add(vertex);
        }

        distances[startVertex] = 0;

        while (unvisitedVertices.Count > 0)
        {
            int currentVertex = -1;
            int minDistance = int.MaxValue;

            foreach (var vertex in unvisitedVertices)
            {
                if (distances[vertex] < minDistance)
                {
                    minDistance = distances[vertex];
                    currentVertex = vertex;
                }
            }

            unvisitedVertices.Remove(currentVertex);

            foreach (var neighbor in vertices[currentVertex])
            {
                int altDistance = distances[currentVertex] + 1; // Assuming all edges have equal weight

                if (altDistance < distances[neighbor])
                {
                    distances[neighbor] = altDistance;
                    previousVertices[neighbor] = currentVertex;
                }
            }
        }

        List<int> shortestPath = new List<int>();
        int current = endVertex;

        while (current != -1)
        {
            shortestPath.Insert(0, current);
            current = previousVertices[current];
        }

        return shortestPath;
    }

    public static  List<int> Draw(int from, int to)
    {
        // Создаем граф с вершинами, как описано в изображении
        Dictionary<int, List<int>> graphVertices = new Dictionary<int, List<int>>
        {
            { 1, new List<int> { 2, 3 } },
            { 2, new List<int> { 1, 4, 6 } },
            { 3, new List<int> { 1, 4, 5 } },
            { 4, new List<int> { 2, 3, 5 } },
            { 5, new List<int> { 3, 4 } },
            { 6, new List<int> { 2 } }
        };

        Graph graph = new Graph(graphVertices);

        // Найдем кратчайший путь от вершины 1 до вершины 6
        List<int> shortestPath = graph.FindShortestPath(from, to);

        // Выведем путь в консоль Unity
        Debug.Log("Кратчайший путь от вершины 1 до вершины 6:");
        foreach (var vertex in shortestPath)
        {
            Debug.Log(vertex + " ");
        }

        return shortestPath;
    }
}