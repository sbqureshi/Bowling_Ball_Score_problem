

namespace Bowling_Ball_Score_problem.Interface
{
    public interface IBowlingGame
    {
        void Roll( int pins);

        int Score { get; }
    }
}
