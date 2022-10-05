using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class RecordsController : Singleton<RecordsController>
{
    [SerializeField] private int MaxRecordsCount = 40;
    private List<KeyValuePair<int, string>> records;
    private readonly string recKey = "recKey_";
    private readonly string recValue = "recValue_";
    private int minPoints = 0;

    public int MinPoint => minPoints;

    private void Awake()
    {
        LoadRecords();
    }

    public void LoadRecords()
    {
        minPoints = 100000;
        StringBuilder sb = new StringBuilder();
        records = new List<KeyValuePair<int, string>>();
        for (int i = 0; i < MaxRecordsCount; i++)
        {
            string name = PlayerPrefs.GetString($"{recValue}{i}", "UserName");
            int points = PlayerPrefs.GetInt($"{recKey}{i}", -1);
            sb.AppendLine($"{i}) {name} - {points}");
            if (points < minPoints)
            {
                minPoints = points;
            }
            records.Add(new KeyValuePair<int, string>(points, name));
        }
        Debug.Log($"Load records, min points: {minPoints}\n" + sb.ToString());
    }

    public void SaveRecords()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < records.Count; i++)
        {
            PlayerPrefs.SetString($"{recValue}{i}", records[i].Value);
            PlayerPrefs.SetInt($"{recKey}{i}", records[i].Key);
            sb.AppendLine($"{i}) {records[i].Value} - {records[i].Key}");
        }
        Debug.Log($"Save records, min points: {minPoints}\n" + sb.ToString());
    }

    public void AddNewRecords(string name)
    {
        records.Add(new KeyValuePair<int, string>(PointerCounter.Instance.Points, name));
        PointerCounter.Instance.Clear();
        records.Sort(delegate (KeyValuePair<int, string> first, KeyValuePair<int, string> second)
        {
            return second.Key.CompareTo(first.Key);
        });
        records.RemoveAt(records.Count - 1);
        SaveRecords();
    }

    public string GetRecordLine(int index)
    {
        if (index < records.Count && index < MaxRecordsCount && index >= 0)
        {
            return $"{index + 1}) {records[index].Value} - {records[index].Key}";
        }
        return $"[{index}] out of range";
    }
}
