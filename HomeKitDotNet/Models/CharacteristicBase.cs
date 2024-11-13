using HomeKitDotNet.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKitDotNet.Models
{
    public class CharacteristicBase
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
            //TODO
            return false;
        }

        public string Type { get; init; }
        public int InstanceID => _json.InstanceID;
        public string? Description => _json.Description;
        public string? Unit => _json.Description;
        public CharacteristicPermission[] Permissions => _json.Permissions;
        public bool CanRead { get { return Permissions.Contains(CharacteristicPermission.pr); } }
        public bool CanWrite { get { return Permissions.Contains(CharacteristicPermission.pw); } }
        public bool CanSubscribe { get { return Permissions.Contains(CharacteristicPermission.ev); } }
    }
}
