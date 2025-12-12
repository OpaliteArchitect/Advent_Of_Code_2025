namespace Advent_Of_Code_2025.Day8
{
    internal partial class Day8Puzzles
    {
        public static long SolvePuzzle2(string[] boxesRaw)
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

            Pair[] allPairsOrdered = allPairsUnordered
                .OrderBy(e => e.DistanceSquared)
                .ToArray();

            DisjointSet circuits = new(boxes.ToList());
            foreach (Pair pair in allPairsOrdered)
            {
                if (circuits.UnionTrackLast(pair.A, pair.B))
                {
                    return pair.A.X * pair.B.X;
                }
            }

            throw new Exception("It will never reach here");
        }
    }
}