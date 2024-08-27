using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace NPC
{
    public class LinearIMGUIDlg : MonoBehaviour
    {
        public string[] linesOfDlg;
        public int lineIndex;
        public string characterName;
        public bool showDlg,showGrid;
        private void OnGUI()
        {
            if (showGrid)
            {
                Grid();
            }

            Dlg();
            
        }
        void Dlg()
        {
            if (showDlg)
            {
                //GUI.Box(UIPos(0, 6, 16, 3),characterName + ":" + linesOfDlg[lineIndex]);
                GUI.Box(UIPos(0, 6, 16, 3), $"{characterName}: {linesOfDlg[lineIndex]}");
                //if we are not on the last line/end of the dlg
                if (lineIndex < linesOfDlg.Length-1)
                {                       //place this
                    if (GUI.Button(UIPos(1, 1, 1, 1), "Next"))
                    {
                        //move to next line
                        lineIndex++;
                    }
                }
                else
                {
                    if (GUI.Button(UIPos(2, 1, 1, 1), "End"))
                    {
                        showDlg = false;
                        lineIndex = 0;
                    }
                }
            }
        }

        void Grid()
        {
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    GUI.Box(UIPos(x, y, 1, 1), "");
                    GUI.Label(UIPos(x, y, 1, 1), "");
                }
            }

            //GUI.Box(UIPos(7.5f, 4, 1, 1), "");
            //GUI.Box(UIPos(7.75f, 4.25f, 0.5f, 0.5f), "");
        }

        private Rect UIPos(float startX, float startY, float sizeX, float sizeY)
        {
            return new Rect(startX * Screen.width / 16, startY * Screen.height / 9, sizeX * Screen.width / 16, sizeY * Screen.height / 9);
        }
    }
}

