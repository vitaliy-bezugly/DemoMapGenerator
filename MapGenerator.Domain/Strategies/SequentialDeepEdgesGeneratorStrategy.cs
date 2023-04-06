using MapGenerator.Domain.Strategies.Abstract;

namespace MapGenerator.Domain.Strategies;

public class SequentialDeepEdgesGeneratorStrategy : IEdgeGeneratorStrategy
{
    public void GenerateEdges(List<Planet> planets)
    {
        for (int i = 0; i < planets.Count; i++)
        {
            if(i + 1 == planets.Count)
                break;
            
            int randomValue = Random.Shared.Next(0, 100);
            // 75%
            if (randomValue < 75)
            {
                if (i + 2 >= planets.Count)
                {
                    continue;
                }
                else
                {
                    /* Connect with planet after next planet */
                    planets[i].Connect(planets[i + 2]);

                    if (i != 0)
                    {
                        planets[i].Connect(planets[i - 1]);
                    }
                }
            }
            
            /* Connect with next planet */
            planets[i].Connect(planets[i + 1]);

            if (i != 0)
            {
                planets[i].Connect(planets[i - 1]);
            }
        }
    }
}