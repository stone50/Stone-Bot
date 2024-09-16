﻿namespace StoneBot.Scripts.Bot_Core {
    using Godot;
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    internal static class Util {
        public static async Task<T?> GetMessageAs<T>(HttpResponseMessage? message) where T : struct {
            var successfulString = await GetSuccessfulString(message);
            if (successfulString is null) {
                return null;
            }

            T messageAsT;
            try {
                messageAsT = JsonSerializer.Deserialize<T>(successfulString);
            } catch (Exception e) {
                GD.PushWarning($"Cannot get message as {typeof(T).Name} because JsonSerializer.Deserialize failed: {e}.");
                return null;
            }

            return messageAsT;
        }
        public static async Task<T?> GetMessageAs<T>(Task<HttpResponseMessage?> messageTask) where T : struct => await GetMessageAs<T>(await messageTask);

        public static async Task<string?> GetSuccessfulString(HttpResponseMessage? message) {
            if (message is null) {
                GD.PushWarning("Cannot get successful string because message is null.");
                return null;
            }

            if (!message.IsSuccessStatusCode) {
                GD.PushWarning($"Cannot get successful string because message.IsSuccessStatusCode is false.");
                return null;
            }

            string successfulString;
            try {
                successfulString = await message.Content.ReadAsStringAsync();
            } catch (Exception e) {
                GD.PushWarning($"Cannot get successful string because message.Content.ReadAsStringAsync failed: {e}.");
                return null;
            }

            return successfulString;
        }
        public static async Task<string?> GetSuccessfulString(Task<HttpResponseMessage?> messageTask) => await GetSuccessfulString(await messageTask);
    }
}
