using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    public class FlagManager
    {
        public GlobalFlags globalFlags;
        public PlayerFlags playerFlags;
        public CharacterFlags characterFlags;
        public SceneFlags sceneFlags;

        public FlagManager()
        {
            globalFlags = new GlobalFlags();
            playerFlags = new PlayerFlags();
            characterFlags = new CharacterFlags();
            sceneFlags = new SceneFlags();
        }

        public class PlayerFlags
        {
            public int money { get; set; }
            public int fitness { get; set; }
            public int cleanliness { get; set; }
            public int charisma { get; set; }
            public int selfControl { get; set; }
            public int massageSkill { get; set; }
            public int personalTrainerSkill { get; set; }
            public int racquetballSkill { get; set; }
            public int pokerSkill { get; set; }
            public int yogaSkill { get; set; }
            public int fashionSkill { get; set; }

        }

        public class CharacterFlags
        {
            public int annaAttraction { get; set; }
            public int amyAttraction { get; set; }
            public int kaliAttraction { get; set; }
        }

        public class GlobalFlags
        {
            public bool dinnerCooked { get; set; }
        }

        public class SceneFlags
        {
            //tbd this may need to be more dynamic, not just constants
        }
    }
}
