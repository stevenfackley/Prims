using System;
using System.Collections.Generic;

namespace PrimsAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a graph with 5 vertices and 7 edges
            int numVertices = 5;
            int numEdges = 7;
            int[,] graph = new int[numVertices, numVertices]
            {
                { 0, 2, 0, 6, 0 },
                { 2, 0, 3, 8, 5 },
                { 0, 3, 0, 0, 7 },
                { 6, 8, 0, 0, 9 },
                { 0, 5, 7, 9, 0 }
            };

            // Run Prim's algorithm
            PrimsAlgorithm(graph, numVertices);
        }

        static void PrimsAlgorithm(int[,] graph, int numVertices)
        {
            // Create an array to store the minimum distances from each vertex to the MST
            int[] distances = new int[numVertices];

            // Create an array to store the parent nodes of each vertex in the MST
            int[] parents = new int[numVertices];

            // Create a boolean array to track which vertices have been included in the MST
            bool[] included = new bool[numVertices];

            // Initialize all distances to infinity and set all nodes as not included in the MST
            for (int i = 0; i < numVertices; i++)
            {
                distances[i] = int.MaxValue;
                included[i] = false;
            }

            // Set the distance of the first vertex to 0 and include it in the MST
            distances[0] = 0;
            parents[0] = -1;

            // Repeat the following steps for numVertices - 1 times
            for (int i = 0; i < numVertices - 1; i++)
            {
                // Find the vertex with the minimum distance that has not yet been included in the MST
                int minIndex = FindMinVertex(distances, included, numVertices);

                // Include the vertex in the MST
                included[minIndex] = true;

                // Update the distances of the neighboring vertices
                for (int j = 0; j < numVertices; j++)
                {
                    // Check if the edge between the two vertices exists and the destination vertex has not yet been included in the MST
                    if (graph[minIndex, j] != 0 && !included[j])
                    {
                        // Check if the distance to the destination vertex through the current vertex is less than the current distance
                        if (distances[j] > graph[minIndex, j])
                        {
                            // Update the distance and set the current vertex as the parent of the destination vertex
                            distances[j] = graph[minIndex, j];
                            parents[j] = minIndex;
                        }
                    }
                }
            }

            // Print the MST
            Console.WriteLine("Minimum Spanning Tree:");
            for (int i = 1; i < numVertices; i++)
            {
                Console.WriteLine(parents[i] + " - " + i + ": " + distances[i]);
}
}
		  static int FindMinVertex(int[] distances, bool[] included, int numVertices)
  {
      // Initialize the minimum distance to infinity
      int minDistance = int.MaxValue;
      int minIndex = -1;

      // Find the vertex with the minimum distance that has not yet been included in the MST
      for (int i = 0; i < numVertices; i++)
      {
          if (!included[i] && distances[i] < minDistance)
          {
              minDistance = distances[i];
              minIndex = i;
          }
      }

      return minIndex;
  }

		
	}
}
