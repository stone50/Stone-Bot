﻿namespace StoneBot.Scripts.Models.EventSub_Message {
    using System.Text.Json.Serialization;

    public struct EventSubSessionData {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("connected_at")]
        public string ConnectedAt { get; set; }
        [JsonPropertyName("keepalive_timeout_seconds")]
        public int KeepaliveTimeoutSeconds { get; set; }
        [JsonPropertyName("reconnect_url")]
        public string? ReconnectUrl { get; set; }
    }
}
