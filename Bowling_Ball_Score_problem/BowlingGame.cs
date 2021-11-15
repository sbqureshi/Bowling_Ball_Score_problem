using Bowling_Ball_Score_problem.Interface;

namespace Bowling_Ball_Score_problem
{
    public class BowlingGame : IBowlingGame
    {
        #region LocalVariable
        private int[] rolls = new int[21];

        private int CurrentRoll = 0;
        #endregion

        #region Properties
        public int Score
        {
            get
            {
                return CalculateScore();

            }
        }
        #endregion

        #region Public Method
        public void Roll(int pins)
        {
            rolls[CurrentRoll++] += pins;
        }
        #endregion
        
        #region PrivateMethod
        private int GetStanddardScore(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }
        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }
        private int GetSpareScore(int rollInedex)
        {
            return rolls[rollInedex] + rolls[rollInedex + 1] + rolls[rollInedex + 2];
        }
        private int CalculateScore()
        {
            int score = 0;
            int rollIndex = 0;
            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += GetSpareScore(rollIndex);
                    rollIndex++;
                    continue;
                }
                else if (IsSpare(rollIndex))
                {
                    score += GetSpareScore(rollIndex);
                }
                else
                {
                    score += GetStanddardScore(rollIndex);
                }
                rollIndex += 2;
            }
            return score;
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        #endregion
    }
}
