using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TreeContentItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	[SerializeField]
	Text treeText;

	[SerializeField]
	Text uiText;

	[SerializeField]
	Image uiBackground;
	[SerializeField]
	Image uiIcon;

	private readonly Color[] colors = new Color[] {
		new Color(1, 1, 1, 1),
		new Color(0.9f, 0.9f, 1, 1),
	};

	public void UpdateItem(int count)
    {

    }
	public void UpdateItem(int count)
	{
		uiText.text = (count + 1).ToString("00");
		uiBackground.color = colors[Mathf.Abs(count) % colors.Length];
		uiIcon.sprite = Resources.Load<Sprite>((Mathf.Abs(count) % 30 + 1).ToString("icon000"));
	}
}
