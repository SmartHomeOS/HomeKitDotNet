using HomeKitDotNet.JSON;
using System.Text.Json;

namespace HomeKitDotNet.Models
{
    public abstract class CharacteristicBase
    {
        protected Service service;
        protected CharacteristicJSON _json;

        public CharacteristicBase(Service service, CharacteristicJSON json)
        {
            this._json = json;
            this.Type = json.Type;
            this.service = service;
        }

        protected async Task<bool> Events(bool subscribe)
        {
            if (!CanSubscribe)
                throw new InvalidOperationException("Subscriptions are prohibited");
            CharacteristicNotificationsJSON write = new CharacteristicNotificationsJSON(service.Accessory.ID, InstanceID);
            write.EventNotifications = subscribe;
            Dictionary<string, CharacteristicNotificationsJSON[]> dict = new Dictionary<string, CharacteristicNotificationsJSON[]>();
            dict.Add("characteristics", [write]);
            return (await service.Accessory.EndPoint.Connection.Put("/characteristics", JsonSerializer.SerializeToUtf8Bytes(dict))).StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        internal abstract void FireUpdate(JsonElement? value);

        public string Type { get; init; }
        public int InstanceID => _json.InstanceID;
        public string? Description => _json.Description;
        public string? Unit => _json.Unit;
        public CharacteristicPermission[] Permissions => _json.Permissions;
        public bool CanRead { get { return Permissions.Contains(CharacteristicPermission.pr); } }
        public bool CanWrite { get { return Permissions.Contains(CharacteristicPermission.pw); } }
        public bool CanSubscribe { get { return Permissions.Contains(CharacteristicPermission.ev); } }
    }
}
