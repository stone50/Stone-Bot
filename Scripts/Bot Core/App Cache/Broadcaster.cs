﻿namespace StoneBot.Scripts.Bot_Core.App_Cache {
    using Models;
    using System.Threading.Tasks;

    internal class Broadcaster : User {
        public static async Task<Broadcaster?> Create() {
            var config = await AppCache.Config.Get();
            if (config is null) {
                return null;
            }

            var potentialData = await GetData(config.BroadcasterLogin);
            return potentialData is null ? null : new((UserData)potentialData);
        }

        private Broadcaster(UserData data) : base(data) { }
    }
}
