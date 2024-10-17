using System;
using System.Collections.Generic;
using UnityEngine;

/*
{
  "response_code": 0,
  "results": [
    {
      "type": "multiple",
      "difficulty": "hard",
      "category": "Entertainment: Japanese Anime &amp; Manga",
      "question": "In &quot;One Piece&quot;, who confirms the existence of the legendary treasure, One Piece?",
      "correct_answer": "Edward &quot;Whitebeard&quot; Newgate",
      "incorrect_answers": [
        "Former Marine Fleet Admiral Sengoku",
        "Pirate King Gol D Roger",
        "Silvers Rayleigh"
      ]
    },
    {
      "type": "boolean",
      "difficulty": "easy",
      "category": "General Knowledge",
      "question": "Video streaming website YouTube was purchased in it&#039;s entirety by Facebook for US$1.65 billion in stock.",
      "correct_answer": "False",
      "incorrect_answers": [
        "True"
      ]
    },
    ...
    ]
}
*/


[Serializable]
public class DataObtained
{
    public int response_code;

    [HideInInspector] public List<QuestionRawData> results;
    public List<QuestionData> finalResults;

    public void ProcessRawData()
    {
        finalResults = new List<QuestionData>();
        foreach (var result in results)
        {
            finalResults.Add(new QuestionData(result));
        }
    }
}
