using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class QuestionLoader : MonoBehaviour
{
    [SerializeField] string url = "https://opentdb.com/api.php?amount=10";
    
    [TextArea(3, 10)]
    [SerializeField] string response;

    [SerializeField] DataObtained questionData;

    IEnumerator GetText()
    {
        if (!url.Contains(("http")))
            url = Application.streamingAssetsPath + "/" + url;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string jsonText = www.downloadHandler.text; 
                response = jsonText;
                Debug.Log(jsonText);
                questionData = JsonUtility.FromJson<DataObtained>(jsonText);
                questionData.ProcessRawData();
            }
        }
    }

    [ContextMenu("Load Questions")]
    public void LoadQuestions()
    {
        StartCoroutine(GetText());
    }

    void Start()
    {
        StartCoroutine(GetText());
    }

    [ContextMenu("LoadQuestionData")]
    public async void LoadQuestionDataInUI() {
        DataObtained d = await GetDataFromURL("https://opentdb.com/api.php?amount=1");
        
        if (d != null) {
            Debug.Log(d.finalResults[0].question);
        }
    }

    public static async Task<DataObtained> GetDataFromURL(string url)
    {
        try
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url))
            {
                await www.SendWebRequest();
                if (www.error != null)
                {
                    Debug.Log(www.error);
                    return null;
                }
                else
                {
                    string s = www.downloadHandler.text;
                    DataObtained actualData = JsonUtility.FromJson<DataObtained>(s);
                    actualData.ProcessRawData();
                    return actualData;
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error al hacer la petición: {e.Message}");
            return null;
        }
    }
}
