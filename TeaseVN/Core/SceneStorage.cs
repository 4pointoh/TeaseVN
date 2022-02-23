using System;
using System.Collections.Generic;
using TeaseVN.Scenes;
using TeaseVN.Scenes.EatDinnerQuest;
using TeaseVN.Scenes.Ending;
using TeaseVN.Scenes.Intro;
using TeaseVN.Scenes.SleepQuest;

namespace TeaseVN.Core
{
    class SceneStorage
    {
        Dictionary<String, Type> sceneTypeById;
        Game1 game;

        public static String COOKING_SCENE = "Cooking";
        public static String DINNER_SCENE = "EatDinner";
        public static String ENDING_SCENE = "Ending";
        public static String FIRST_DAY_SCENE = "FirstDay";
        public static String WORK_SCENE = "Work";
        public static String SLEEP_SCENE = "Sleep";
        public static String NO_SCENE = "NoScene";
        public static String CHAT_SCENE = "Chat";
        public static String WASH_SCENE = "Wash";
        public static String EAT_SCENE = "Eat";
        public static String BEDTIME_SCENE = "Bedtime";
        public static String WORKOUT_SCENE = "Workout";
        public static String TEMP_JOB_SCENE = "TempJob";

        public SceneStorage(Game1 game)
        {
            this.game = game;
            this.sceneTypeById = new Dictionary<string, Type>();

            sceneTypeById.Add(DINNER_SCENE, typeof(EatDinnerScene));
            sceneTypeById.Add(ENDING_SCENE, typeof(EndingScene));
            sceneTypeById.Add(FIRST_DAY_SCENE, typeof(FirstDayChoiceScene));
            sceneTypeById.Add(WORK_SCENE, typeof(GoToWorkScene));
            sceneTypeById.Add(NO_SCENE, typeof(NoScene));
            sceneTypeById.Add(SLEEP_SCENE, typeof(SleepScene));
            sceneTypeById.Add(COOKING_SCENE, typeof(CookingScene));
            sceneTypeById.Add(CHAT_SCENE, typeof(ChatScene));
            sceneTypeById.Add(WASH_SCENE, typeof(WashScene));
            sceneTypeById.Add(EAT_SCENE, typeof(EatScene));
            sceneTypeById.Add(BEDTIME_SCENE, typeof(BedtimeScene));
            sceneTypeById.Add(WORKOUT_SCENE, typeof(WorkoutScene));
            sceneTypeById.Add(TEMP_JOB_SCENE, typeof(TempJobScene));
        }

        public Scene getScene(String id)
        {
            if (!sceneTypeById.ContainsKey(id))
            {
                return null;
            }

            return (Scene) Activator.CreateInstance(sceneTypeById[id], this.game);
        }
    }
}
