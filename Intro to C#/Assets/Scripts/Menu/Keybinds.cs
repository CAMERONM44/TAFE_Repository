using System.Collections.Generic; // Allows use of lists and dictionaries
using UnityEngine; // Connects to Unity
using UnityEngine.UI; // Allows use and modification of Canvas UI Elements
using System; // Allows use of Serializable to see struct in the inspector

public class Keybinds : MonoBehaviour
{
    /// <summary>
    /// A structure type (or struct type) is a value type that can encapsulate data and related functionality
    /// Action Map Data - A struct that contains the collection of data for each input
    /// </summary>

    [Serializable] // Allows it and its fields to be broken down into a byte[] array (binary data) and passed around easily

    public struct ActionMapData
    {
        public string actionName;
        public Text keycodeDisplay;
        public string defaultKey;
    }
    [SerializeField] ActionMapData[] actionMapData;
    [SerializeField] public GameObject currentSelectedKey;

    // 
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    // Colours for when a key is selected to be changed and after it has been changed
    [SerializeField] private Color32 selectedColour = new Color32(239, 116, 36, 225);
    [SerializeField] private Color32 changedColour = new Color32(39, 171, 249, 225);

    // Adds each
    private void Start()
    {
        for (int i = 0; i < actionMapData.Length; i++)
        {
            keys.Add(actionMapData[i].actionName, (KeyCode)Enum.Parse(typeof(KeyCode), actionMapData[i].defaultKey));
            actionMapData[i].keycodeDisplay.text = keys[actionMapData[i].actionName].ToString();
        }
    }


    public void ChangeKey(GameObject clickedKey)
    {
        currentSelectedKey = clickedKey;
        if (currentSelectedKey != null)
        {
            currentSelectedKey.GetComponent<Image>().color = selectedColour;
        }
    }
    private void OnGUI()
    {
        string newKeyCode = "";
        Event changeKeyEvent = Event.current;

        if (currentSelectedKey != null)
        {
            if (changeKeyEvent.isKey)
            {
                if (!keys.ContainsValue(changeKeyEvent.keyCode))
                {
                newKeyCode = changeKeyEvent.keyCode.ToString();
                keys[currentSelectedKey.name] = changeKeyEvent.keyCode;
                currentSelectedKey.GetComponentInChildren<Text>().text = newKeyCode;
                currentSelectedKey.GetComponent <Image>().color = changedColour;
                currentSelectedKey = null;
                }
                else
                {
                    currentSelectedKey.GetComponent<Image>().color = Color.white; 
                    currentSelectedKey = null;
                }
            }
        }
    }
}