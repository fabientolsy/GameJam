using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_KeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;
    private Transform Container;
    private Transform KeyTemplate;

    private void Awake()
    {
        Container = transform.Find("Container");
        KeyTemplate = Container.Find("KeyTemplate");
        KeyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        keyHolder.OnKeysChanged += KeyHolder_OnKeysChanged;
    }

    private void KeyHolder_OnKeysChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach(Transform child in Container)
        {
            if (child == KeyTemplate) continue;
            {
                Destroy(child.gameObject);
            }
        }

        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++)
        {
            Key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(KeyTemplate, Container);
            KeyTemplate.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(18 * i, 0);
            Image keyImage = keyTransform.Find("image").GetComponent<Image>();
            switch (keyType)
            {
                default:
                case Key.KeyType.Green: 
                    keyImage.color = Color.green;
                    break;
                case Key.KeyType.Blue:
                    keyImage.color = Color.blue;
                    break;
            }
        }
    }
}
