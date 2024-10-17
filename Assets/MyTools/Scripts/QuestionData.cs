using System;
using System.Collections.Generic;
using UnityEngine;

/*
{
    "type": "multiple",
    "difficulty": "hard",
    "category": "Entertainment: Japanese Anime &amp; Manga",
    "question": "In &quot;One Piece&quot;, who confirms the existence of the legendary treasure, One Piece?",
    "correct_answer": "Edward &quot;Whitebeard&quot; Newgate",
    "incorrect_answers": [
        "Former Marine Fleet Admiral Sengoku",
        "Pirate King Gol D Roger",
        "Silvers Rayleigh" ]
}
*/

[Serializable]
public class QuestionData
{
    public QuestionType type;
    public QuestionDifficulty difficulty;
    public string category;
    public string question;
    public string correct_answer;
    public List<string> incorrect_answers;

    public QuestionData(QuestionRawData rawData)
    {
        type = (QuestionType)Enum.Parse(typeof(QuestionType), rawData.type, true);
        difficulty = (QuestionDifficulty)Enum.Parse(typeof(QuestionDifficulty), rawData.difficulty, true);
        category = rawData.category;
        question = rawData.question;
        correct_answer = rawData.correct_answer;
        incorrect_answers = rawData.incorrect_answers;
    }
}

[Serializable]
public class QuestionRawData
{
    public string type;
    public string difficulty;
    public string category;
    public string question;
    public string correct_answer;
    public List<string> incorrect_answers;
}