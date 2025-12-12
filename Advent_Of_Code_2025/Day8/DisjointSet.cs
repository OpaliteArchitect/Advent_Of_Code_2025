namespace Advent_Of_Code_2025.Day8
{
    internal class DisjointSet
    {
        private readonly int[] _parent;
        private readonly int[] _size;
        private readonly Dictionary<Box, int> _boxToId = [];
        private readonly Dictionary<int, Box> _idToBox = [];
        private readonly int numberOfElements;

        public DisjointSet(List<Box> nodes)
        {
            numberOfElements = nodes.Count;

            _parent = new int[numberOfElements];
            for (int i = 0; i < numberOfElements; i++)
            {
                _parent[i] = i;
                _boxToId.Add(nodes[i], i);
                _idToBox.Add(i, nodes[i]);
            }

            _size = new int[numberOfElements];
            Array.Fill(_size, 1);
        }

        public Box Find(Box box)
        {
            return _idToBox[FindId(_boxToId[box])];
        }

        private int FindId(int id)
        {
            if (_parent[id] == id)
            {
                return id;
            }
            else
            {
                _parent[id] = FindId(_parent[id]);
                return _parent[id];
            }
        }

        public void Union(Box box1, Box box2)
        {
            Box parent1 = Find(box1);
            Box parent2 = Find(box2);

            if (parent1 == parent2)
            {
                return;
            }

            int parent1Id = _boxToId[parent1];
            int parent2Id = _boxToId[parent2];

            if (_size[parent1Id] > _size[parent2Id])
            {
                _parent[parent2Id] = _parent[parent1Id];
                _size[parent1Id] += _size[parent2Id];
            }
            else
            {
                _parent[parent1Id] = _parent[parent2Id];
                _size[parent2Id] += _size[parent1Id];
            }
        }

        public int[] GetTop3Size()
        {
            return _size
                .OrderDescending()
                .Take(3)
                .ToArray();
        }

        public bool UnionTrackLast(Box box1, Box box2)
        {
            Union(box1, box2);
            if (_size[_boxToId[Find(box1)]] == numberOfElements)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
