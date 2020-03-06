using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Question : MonoBehaviour
{
    public Questiondata InitQuestion()
    {
        string json = File.ReadAllText(Application.dataPath + "/database.json");
        Questiondata loadQuesData = JsonUtility.FromJson<Questiondata>("{\"objects\":" + json + "}");
        return loadQuesData;
    }

    [Serializable]
    public class Questiondata
    {
        public QuesData[] objects;
    }

    [Serializable]
    public class QuesData
    {
        public int Type;
        public int Id;
        public string Text;
        public string A;
        public string B;
        public string C;
        public string D;
        public string CorrectAnswer;
    }
}
