
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string characterName;
        public GameObject characterPrefab;
    }

    public CharacterData[] characters;

    public Transform previewPoint;

    private int selectedIndex;
    private GameObject currentPreview;

    void Start()
    {
        if (characters != null && characters.Length > 0)
            SelectCharacter(0);
    }

    public void SelectNext()
    {
        if (characters == null || characters.Length == 0)
            return;

        selectedIndex =
            (selectedIndex + 1) % characters.Length;

        SelectCharacter(selectedIndex);
    }

    public void SelectPrevious()
    {
        if (characters == null || characters.Length == 0)
            return;

        selectedIndex =
            (selectedIndex - 1 + characters.Length)
            % characters.Length;

        SelectCharacter(selectedIndex);
    }

    public void SelectCharacter(int index)
    {
        if (characters == null ||
            index < 0 ||
            index >= characters.Length)
            return;

        selectedIndex = index;

        if (currentPreview != null)
            Destroy(currentPreview);

        GameObject prefab =
            characters[selectedIndex].characterPrefab;

        if (prefab != null && previewPoint != null)
        {
            currentPreview = Instantiate(
                prefab,
                previewPoint.position,
                previewPoint.rotation
            );
        }

        Debug.Log(
            "Selected: " +
            characters[selectedIndex].characterName
        );
    }
}
