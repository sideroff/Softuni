﻿using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("grade cannot be negative");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGradecannot be negative");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("maxGrade cannot be smaller or equal to minGrade");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException("comments cannot be null or empty");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
