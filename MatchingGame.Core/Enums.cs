namespace MatchingGame.Core
{
    public enum GameLifeCycle
    {
        NewGame, PlayGame, GameOver, PlayAgain
    }

    public enum CardState
    {
        Closed, OpenGreen, OpenRed, Hidden
    }

    public enum GameDifficulty
    {
        Easy = 3, Medium = 10, Hard = 25
    }

    public enum PlayerFace
    {
        Watch = 0, Happy = 1, Unhappy = 2
    }
}
