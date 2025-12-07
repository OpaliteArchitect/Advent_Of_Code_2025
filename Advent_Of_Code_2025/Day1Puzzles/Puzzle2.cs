namespace Advent_Of_Code_2025.Day1
{
    internal partial class Day1Puzzles
    {
        public static int SolvePuzzle2(string[] rotations)
        {
            int dialPosition = DIAL_START;
            int answer = 0;

            foreach (var rotation in rotations)
            {
                if (string.IsNullOrEmpty(rotation))
                {
                    continue;
                }

                char direction = rotation[0];
                int timesRotated = Int32.Parse(rotation.Substring(1));
                int hits = 0;

                switch (direction)
                {
                    case 'R':
                        hits = (dialPosition + timesRotated) / DIAL_SIZE;
                        dialPosition = (dialPosition + timesRotated) % DIAL_SIZE;
                        break;
                    case 'L':
                        int stepsToFirstHit = dialPosition is 0 ? DIAL_SIZE : dialPosition;
                        hits = timesRotated >= stepsToFirstHit
                            ? 1 + (timesRotated - stepsToFirstHit) / DIAL_SIZE
                            : 0;

                        int effectiveRotation = timesRotated % DIAL_SIZE;
                        dialPosition = (dialPosition - effectiveRotation + DIAL_SIZE) % DIAL_SIZE;
                        break;
                    default:
                        throw new InvalidOperationException("Invalid direction");
                }

                answer += hits;
            }

            return answer;
        }
    }
}
