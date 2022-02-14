﻿using System;
using System.Collections.Generic;
using System.Text;
using TeaseVN.Scenes.EatDinnerQuest;
using TeaseVN.Scenes.Ending;
using TeaseVN.Scenes.Intro;
using TeaseVN.Scenes.SleepQuest;

namespace TeaseVN.Core
{
    class SceneStorage
    {
        Dictionary<String, Scene> sceneById;
        Game1 game;

        public static String COOKING_SCENE = "Cooking";
        public static String DINNER_SCENE = "EatDinner";
        public static String ENDING_SCENE = "Ending";
        public static String FIRST_DAY_SCENE = "FirstDay";
        public static String WORK_SCENE = "Work";
        public static String SLEEP_SCENE = "Sleep";
        public static String NO_SCENE = "NoScene";
        public static String CHAT_SCENE = "Chat";

        public SceneStorage(Game1 game)
        {
            this.game = game;
            this.sceneById = new Dictionary<string, Scene>();
            EatDinnerScene eatDinnerScene = new EatDinnerScene(game);
            EndingScene endingScene = new EndingScene(game);
            FirstDayChoiceScene firstDayChoiceScene = new FirstDayChoiceScene(game);
            GoToWorkScene goToWorkScene = new GoToWorkScene(game);
            NoScene noScene = new NoScene(game);
            SleepScene sleepScene = new SleepScene(game);
            CookingScene cookingScene = new CookingScene(game);
            ChatScene chatScene = new ChatScene(game);

            sceneById.Add(DINNER_SCENE, eatDinnerScene);
            sceneById.Add(ENDING_SCENE, endingScene);
            sceneById.Add(FIRST_DAY_SCENE, firstDayChoiceScene);
            sceneById.Add(WORK_SCENE, goToWorkScene);
            sceneById.Add(NO_SCENE, noScene);
            sceneById.Add(SLEEP_SCENE, sleepScene);
            sceneById.Add(COOKING_SCENE, cookingScene);
            sceneById.Add(CHAT_SCENE, chatScene);
        }

        public Scene getScene(String id)
        {
            return sceneById[id];
        }
    }
}
