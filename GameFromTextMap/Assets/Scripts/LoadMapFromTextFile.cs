using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMapFromTextFile : MonoBehaviour
{
    public TextAsset levelDataTextFile;

    public GameObject floor_848;
    public GameObject corridor_849;
    public GameObject horiz_1034;
    public GameObject vert_1025;
    public GameObject corpse_175;
    public GameObject door_844;
    public GameObject potion_675;
    public GameObject chest_586;
    public GameObject alter_583;
    public GameObject stairs_up_994;
    public GameObject stairs_down_993;
    public GameObject wizard_287;

    public Dictionary<char, GameObject> dictionary = new Dictionary<char, GameObject>();

    private void Awake()
    {
        char newlineChar = '\n';

        dictionary['.'] = floor_848;
        dictionary['#'] = corridor_849;
        dictionary['('] = chest_586;
        dictionary['!'] = potion_675;
        dictionary['_'] = alter_583;
        dictionary['>'] = stairs_down_993;
        dictionary['<'] = stairs_up_994;
        dictionary['-'] = horiz_1034;
        dictionary['|'] = vert_1025;
        dictionary['+'] = door_844;
        dictionary['%'] = corpse_175;
        dictionary['@'] = wizard_287;

        string[] stringArray = levelDataTextFile.text.Split(newlineChar);
        BuildMaze(stringArray);
    }

    private void BuildMaze(string[] stringArray)
    {
        int numRows = stringArray.Length;
        float yOffset = numRows / 2;
        for(int row = 0; row < numRows; row++)
        {
            string currentRowString = stringArray[row];
            float y = -1 * (row - yOffset);
            CreateRow(currentRowString, y);
        }
    }

    private void CreateRow(string currentRowString, float y)
    {
        int numChars = currentRowString.Length;
        float xOffset = numChars / 2;

        for(int charPos = 0; charPos < numChars; charPos++)
        {
            float x = charPos - xOffset;
            char prefabCharacter = currentRowString[charPos];

            if (dictionary.ContainsKey(prefabCharacter)) 
            {
                CreatePrefabInstance(dictionary[prefabCharacter], x, y);
            }
        }
    }

    private void CreatePrefabInstance(GameObject objectPrefab, float x, float y) 
    {
        float z = 0;
        Vector3 position = new Vector3(x, y, z);
        Quaternion noRotation = Quaternion.identity;
        Instantiate(objectPrefab, position, noRotation);
    }
}
