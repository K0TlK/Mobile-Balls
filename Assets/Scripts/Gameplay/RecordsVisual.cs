using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordsVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI linePrefab;
    [SerializeField] private float lineHeight = 150;
    [SerializeField] private RectTransform content;
    [SerializeField] private int lineCount = 30;
    [SerializeField] private Button btPushResult;
    [SerializeField] private Button btClose;
    [SerializeField] private TMP_InputField nameField;

    private List<TextMeshProUGUI> lines = new List<TextMeshProUGUI>();

    private void Start()
    {
        for (int i = 0; i < lineCount; i++)
        {
            lines.Add(Instantiate(linePrefab, content));
            lines[i].text = $"line {i+1}";
            lines[i].gameObject.name = $"line{i+1}";
        }

        content.sizeDelta = new Vector2(0, lineHeight * lineCount);
        btClose.onClick.AddListener(Close);
        UpdateRecords();
    }

    private void OnEnable()
    {
        if (PointerCounter.Instance.Points >= RecordsController.Instance.MinPoint)
        {
            btPushResult.gameObject.SetActive(true);
            nameField.gameObject.SetActive(true);
        }
        else
        {
            btPushResult.gameObject.SetActive(false);
            nameField.gameObject.SetActive(false);
        }
        nameField.text = "";
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }

    public void UpdateRecords()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            lines[i].text = RecordsController.Instance.GetRecordLine(i);
        }
    }

    public void AddRecords()
    {
        RecordsController.Instance.AddNewRecords(nameField.text);
        UpdateRecords();
    }
}
