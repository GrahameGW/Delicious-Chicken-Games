using UnityEngine;

public class MusicClipsList : MonoBehaviour
{
    [SerializeField] BroadcastItems availableClips = default;
    [SerializeField] MusicSlotUIButton musicSlotPrefab = default;
    [SerializeField] ScheduleManager scheduleManager = default;
    [SerializeField] RectTransform listContent = default;
    public MusicSlotUIButton selected;

    private void Start()
    {
        for (int i = 0; i < availableClips.music.Count; i++) {
            MusicSlotUIButton item = Instantiate(musicSlotPrefab);
            item.menu = this;
            item.music = availableClips.music[i];
            item.Name = item.music.name;
            item.transform.SetParent(listContent, false);
        }
    }

    public void SetMusic(MusicSlotUIButton item)
    {
        scheduleManager.selectedMusic = item.music;
        selected?.Deselect();
        selected = item;
    }
}
