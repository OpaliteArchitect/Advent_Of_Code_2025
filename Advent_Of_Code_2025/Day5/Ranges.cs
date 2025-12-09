namespace Advent_Of_Code_2025.Day5
{
    internal record Ranges(long _start, long _end)
    {
        public long Start { get; set; } = _start;
        public long End { get; set; } = _end;
    }
}
