using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ClothSelectionMenuSlider : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;
    public HorizontalLayoutGroup HLG;
    public TMP_Text nameLabel;
    public string[] ItemNames;
    public Button[] itemButtons;
    public float selectedScale = 1.2f;
    public Color selectedColor = Color.yellow;
    public Color normalColor = Color.white;
    public float snapForce;
    private float snapSpeed;
    private bool isSnapped;
    private bool isManualScrolling;
    private int currentItem;

    void Start()
    {
        isSnapped = false;
        isManualScrolling = false;
        scrollRect.onValueChanged.AddListener(OnScroll);
        
        for (int i = 0; i < itemButtons.Length; i++)
        {
            int index = i;
            itemButtons[i].onClick.AddListener(() => OnItemClick(index));
        }
    }

    void Update()
    {
        if (!isManualScrolling && !isSnapped)
        {
            SnapToItem();
        }
    }

    private void OnItemClick(int index)
    {
        currentItem = index;
        isManualScrolling = false;
        isSnapped = false;
        SnapToItem();

        // Scale and color change
        for (int i = 0; i < itemButtons.Length; i++)
        {
            if (i == currentItem)
            {
                itemButtons[i].transform.localScale = Vector3.one * selectedScale;
                itemButtons[i].GetComponent<Image>().color = selectedColor;
            }
            else
            {
                itemButtons[i].transform.localScale = Vector3.one;
                itemButtons[i].GetComponent<Image>().color = normalColor;
            }
        }
    }

    private void SnapToItem()
    {
        snapSpeed += snapForce * Time.deltaTime;
        contentPanel.localPosition = new Vector3(
            Mathf.MoveTowards(contentPanel.localPosition.x, 0 - (currentItem * (sampleListItem.rect.width + HLG.spacing)), snapSpeed),
            contentPanel.localPosition.y,
            contentPanel.localPosition.z);
        nameLabel.text = ItemNames[currentItem];
        if (Mathf.Approximately(contentPanel.localPosition.x, 0 - (currentItem * (sampleListItem.rect.width + HLG.spacing))))
        {
            isSnapped = true;
        }
    }

    private void OnScroll(Vector2 position)
    {
        if (scrollRect.velocity.magnitude > 0)
        {
            isManualScrolling = true;
            isSnapped = true;  
        }

        if (scrollRect.velocity.magnitude < 200 && isManualScrolling)
        {
            isManualScrolling = false;  
        }
    }
}