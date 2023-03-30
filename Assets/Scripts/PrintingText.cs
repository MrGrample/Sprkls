using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintingText : MonoBehaviour
{

    private TextMeshProUGUI text;
    private IEnumerator coroutineTyping;
    private IEnumerator coroutineLastChar;
    private bool isOver = false;
    [SerializeField]
    float typingSpeed = 0.2f;
    [SerializeField]
    float lastCharSpeed = 1.0f;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        coroutineLastChar = CoroutineLast();
    }

    public void SetFirstPhrase(string newText)
    {
        coroutineTyping = TextCoroutine(newText);
        text.text = "";
        StartCoroutine(coroutineTyping);
        GetComponentInParent<Canvas>().sortingOrder = 2;
    }

    public void ChangeText(string newText)
    {
        isOver = false;
        StopAllCoroutines();
        coroutineTyping = TextCoroutine(newText);
        text.text = "";
        StartCoroutine(coroutineTyping);
    }

    IEnumerator TextCoroutine(string newText)
    {
        foreach (char c in newText)
        {
            text.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        text.text += "\nֽאזלטעו Enter";
        isOver = true;
        StartCoroutine(coroutineLastChar);
    }

    IEnumerator CoroutineLast()
    {
        while (isOver)
        {
            text.text += '_';
            yield return new WaitForSeconds(lastCharSpeed);
            if (text.text[text.text.Length - 1] == '_')
            {
                text.text = text.text.Remove(text.text.Length - 1);
            }
            yield return new WaitForSeconds(lastCharSpeed);
        }
    }
}
