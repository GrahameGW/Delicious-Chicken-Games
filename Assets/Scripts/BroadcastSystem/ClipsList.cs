using UnityEngine;

public class ClipsList : MonoBehaviour
{
    [SerializeField] BroadcastItems clips = default;
    [SerializeField] ClipsListItem itemPrefab = default;
    [SerializeField] RectTransform listContent = default;

    public ClipsListItem selected;
    
    private void Start()
    {
        for (int i = 0; i < clips.clips.Count; i++) {
            ClipsListItem item = Instantiate(itemPrefab);
            item.Name = clips.clips[i].name;
            item.transform.SetParent(listContent, false);
            item.menu = this;
            item.clip = clips.clips[i];
        }
    }

    public void Set(ClipsListItem item)
    {
        selected?.Deselect();
        selected = item;
    }
}
