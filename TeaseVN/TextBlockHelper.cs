using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeaseVN
{
    class TextBlockHelper
    {
        public static String formatText(String text, SpriteFont font, int maxLength)
        {
            //Provided string is less than 1 line in length
            Vector2 currentSize = font.MeasureString(text);
            if (currentSize.Length() <= maxLength)
            {
                return text;
            }

            //Provided string is > 1 line in length
            List<String> words = text.Split(" ").ToList();
            List<String> lines = new List<String>();

            String currentLine = "";
            for(int i = 0; i < words.Count; i++)
            {
                String word = words[i];

                String lineUpdated;
                if(i == 0)
                {
                    lineUpdated = word;
                }
                else
                {
                    lineUpdated = currentLine + " " + word;
                }
                
                currentSize = font.MeasureString(lineUpdated);
                if (currentSize.Length() <= maxLength)
                {
                    currentLine = lineUpdated;
                }
                else
                {
                    currentLine += "\n";
                    lines.Add(currentLine);
                    currentLine = word;
                }

                if(i == words.Count - 1)
                {
                    lines.Add(currentLine);
                }
            }

            return String.Join("\n", lines);
        }
    }
}
