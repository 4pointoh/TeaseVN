﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    public class EventManager
    {
        public Game1 game { get; set; }
        public EventManager(Game1 game)
        {
            this.game = game;
        }
        public void washEvent()
        {
            this.game.flagManager.increaseCleanliness(10);
            this.game.timeManager.progressHour(2);
        }

        public bool getTempJobAvailable()
        {
            return (this.game.timeManager.hour > 10 && this.game.timeManager.hour < 16);
        }

        public void setDinnerCooked(bool cooked)
        {
            game.flagManager.globalFlags.dinnerCooked = cooked;
        }

        public bool getDinnerCooked()
        {
            return game.flagManager.globalFlags.dinnerCooked;
        }

        public bool getEatEventAvailable()
        {
            return game.flagManager.globalFlags.dinnerCooked;
        }

        public bool getEatEventSufficientHygiene()
        {
            return game.flagManager.playerFlags.cleanliness > 0;
        }

        public void workoutEvent()
        {
            this.game.flagManager.playerFlags.cleanliness -= 10;
            if (this.game.flagManager.playerFlags.cleanliness < 0)
            {
                this.game.flagManager.playerFlags.cleanliness = 0;
            }
        }
    }
}
