using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClipsList : MonoBehaviour
{
    [SerializeField] BroadcastItems clips = default;
    [SerializeField] ClipsListItem itemPrefab = default;
    [SerializeField] RectTransform listContent = default;
    [SerializeField] Scrollbar scrollbar = default;

    public ClipsListItem selected;
    
    private void Start()
    {
        for (int i = 0; i < clips.clips.Count; i++) {
            

            ClipsListItem item = Instantiate(itemPrefab);
            item.Name = clips.clips[i].name;
            item.transform.SetParent(listContent, false);
            item.menu = this;
            item.clip = clips.clips[i];

            StartCoroutine(ApplyScrollPosition(scrollbar, 1f));
        }
    }

    IEnumerator ApplyScrollPosition(Scrollbar sr, float verticalPos)
    {
        yield return new WaitForEndOfFrame();
        scrollbar.value = verticalPos;
    }

    public void Set(ClipsListItem item)
    {
        selected?.Deselect();
        selected = item;
    }
}
