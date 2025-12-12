namespace Advent_Of_Code_2025.Day8
{
    internal partial class Day8Puzzles
    {
        private const int SHORTEST_N_CONNECTIONS = 1000;
        public static async Task<string[]> Read(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Ensure file path is correct");
            }
            return await File.ReadAllLinesAsync(path);
        }

        public static int SolvePuzzle1(string[] boxesRaw)
        {
            Box[] boxes = new Box[boxesRaw.Length];
            for (int i = 0; i < boxes.Length; i++)
            {
                int[] coordinates = boxesRaw[i].Split(',')
                    .Select(int.Parse)
                    .ToArray();
                boxes[i] = new Box(coordinates[0], coordinates[1], coordinates[2]);
            }

            static int NaturalNumbersSeries(int n)
            {
                return (n * (n + 1)) / 2;
            }

            static long EuclideanDistanceSquared(Box a, Box b)
            {
                long dx = a.X - b.X;
                long dy = a.Y - b.Y;
                long dZ = a.Z - b.Z;
                return dx * dx + dy * dy + dZ * dZ;
            }

            Pair[] allPairsUnordered = new Pair[NaturalNumbersSeries(boxes.Length - 1)];
            int pairsIndex = 0;
            for (int i = 0; i < boxes.Length; i++)
            {
                for (int j = i + 1; j < boxes.Length; j++)
                {
                    allPairsUnordered[pairsIndex++] = new Pair(
                        boxes[i],
                        boxes[j],
                        EuclideanDistanceSquared(boxes[i], boxes[j])
                    );
                }
            }

            Pair[] relevantPairsOrdered = allPairsUnordered
                .OrderBy(e => e.DistanceSquared)
                .Take(SHORTEST_N_CONNECTIONS)
                .ToArray();

            HashSet<Box> relevantBoxes = [];
            foreach (Pair pair in relevantPairsOrdered)
            {
                relevantBoxes.Add(pair.A);
                relevantBoxes.Add(pair.B);
            }

            DisjointSet circuits = new(relevantBoxes.ToList());
            foreach (Pair pair in relevantPairsOrdered)
            {
                circuits.Union(pair.A, pair.B);
            }

            return circuits.GetTop3Size()
                .Aggregate((product, multiplier) => product * multiplier);
        }
    }
}