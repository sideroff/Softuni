using System;

public class CSharpExam : Exam
{
    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentOutOfRangeException("Score cannot be negative.");
        }

        this.Score = score;
    }

    public int Score { get; }

    public override ExamResult Check()
    {
        if (this.Score < 0 || this.Score > 100)
        {
            throw new ArgumentOutOfRangeException("Score was out of bounds (0-100)");
        }
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
