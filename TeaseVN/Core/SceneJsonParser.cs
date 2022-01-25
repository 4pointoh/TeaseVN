using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using TeaseVN.Core.SceneUtil;
using Microsoft.Xna.Framework.Graphics;

namespace TeaseVN.Core
{
    class SceneJsonParser
    {
        private static SceneData loadSceneJson(String scene)
        {
            scene += ".json";
            String currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory = Path.Combine(currentDirectory, Path.GetFileName("SceneConfig"));
            String fullPath = Path.Combine(currentDirectory, Path.GetFileName(scene));
            String fullText = File.ReadAllText(fullPath);

            SceneData sceneObject = JsonConvert.DeserializeObject<SceneData>(fullText);
            return sceneObject;
        }

        public static List<Panel> loadScene(String scene, Game1 game)
        {
            SceneData data = loadSceneJson(scene);
            List<Panel> panels = new List<Panel>();

            for (int i = 0; i < data.panels.Count; i++)
            {
                Panel newPanel = new Panel();
                Panels panel = data.panels[i];
                newPanel.backgroundTexture = game.Content.Load<Texture2D>(panel.image);
                newPanel.text = panel.text;
                newPanel.id = panel.id;
                newPanel.guaranteedNextPanel = panel.guaranteedNextPanelId;

                if(i < data.panels.Count && data.panels[i].choices != null)
                {
                    foreach (Choices choice in data.panels[i].choices)
                    {
                        newPanel.choices.Add(choice.choice);
                    }
                }

                panels.Add(newPanel);
            }

            return panels;
        }
    }
}
