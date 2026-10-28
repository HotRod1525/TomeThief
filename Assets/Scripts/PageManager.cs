using UnityEngine;
using TMPro;

public class PageManager : MonoBehaviour
{
    public int totalPages = 3;
    public TMP_Text pagesText;

    private int collectedPages = 0;

    void Start()
    {
        UpdatePagesText();
    }

    public void CollectPage()
    {
        collectedPages++;

        UpdatePagesText();

        Debug.Log("Pages collected: " + collectedPages);
    }

    void UpdatePagesText()
    {
        if (pagesText != null)
        {
            pagesText.text = "Pages: " + collectedPages + "/" + totalPages;
        }
    }

    public bool HasAllPages()
    {
        return collectedPages >= totalPages;
    }
}