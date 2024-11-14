// HomeKitDotNet Copyright (C) 2024 
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU Affero General Public License for more details.
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using HomeKitDotNet.JSON;

namespace HomeKitDotNet.Models
{
    public class Accessory
    {
        private Dictionary<int, CharacteristicBase> instanceTable = new Dictionary<int, CharacteristicBase>();
        internal Accessory(HomeKitEndPoint endPoint, AccessoryJSON json)
        {
            this.EndPoint = endPoint;
            ID = json.AccessoryInstanceID;
            List<Service> services = new List<Service>();
            foreach (ServiceJSON service in json.Services)
            {
                Service? instance = (Service?)GetService(service.Type, service);
                if (instance != null)
                    services.Add(instance);
            }
            Services = services.ToArray();
        }

        public Service[] Services { get; init; }
        public int ID { get; init; }
        public HomeKitEndPoint EndPoint { get; init; }

        protected IService? GetService(string type, ServiceJSON service)
        {
            switch (type)
            {
                case "260":
                    return new AccessCode(this, service);
                case "DA":
                    return new AccessControl(this, service);
                case "3E":
                    return new AccessoryInformation(this, service);
                case "270":
                    return new AccessoryMetrics(this, service);
                case "239":
                    return new AccessoryRuntimeInformation(this, service);
                case "BB":
                    return new AirPurifier(this, service);
                case "8D":
                    return new AirQualitySensor(this, service);
                case "267":
                    return new AssetUpdate(this, service);
                case "26A":
                    return new Assistant(this, service);
                case "127":
                    return new AudioStreamManagement(this, service);
                case "96":
                    return new Battery(this, service);
                case "21A":
                    return new CameraOperatingMode(this, service);
                case "204":
                    return new CameraRecordingManagement(this, service);
                case "110":
                    return new CameraRTPStreamManagement(this, service);
                case "97":
                    return new CarbonDioxideSensor(this, service);
                case "7F":
                    return new CarbonMonoxideSensor(this, service);
                case "5A":
                    return new CloudRelay(this, service);
                case "80":
                    return new ContactSensor(this, service);
                case "129":
                    return new DataStreamTransportManagement(this, service);
                case "237":
                    return new Diagnostics(this, service);
                case "81":
                    return new Door(this, service);
                case "121":
                    return new Doorbell(this, service);
                case "40":
                    return new Fan(this, service);
                case "B7":
                    return new Fanv2(this, service);
                case "D7":
                    return new Faucet(this, service);
                case "BA":
                    return new FilterMaintenance(this, service);
                case "236":
                    return new FirmwareUpdate(this, service);
                case "41":
                    return new GarageDoorOpener(this, service);
                case "BC":
                    return new HeaterCooler(this, service);
                case "BD":
                    return new HumidifierDehumidifier(this, service);
                case "82":
                    return new HumiditySensor(this, service);
                case "D9":
                    return new InputSource(this, service);
                case "CF":
                    return new IrrigationSystem(this, service);
                case "83":
                    return new LeakSensor(this, service);
                case "43":
                    return new Lightbulb(this, service);
                case "84":
                    return new LightSensor(this, service);
                case "44":
                    return new LockManagement(this, service);
                case "45":
                    return new LockMechanism(this, service);
                case "112":
                    return new Microphone(this, service);
                case "85":
                    return new MotionSensor(this, service);
                case "266":
                    return new NFCAccess(this, service);
                case "86":
                    return new OccupancySensor(this, service);
                case "47":
                    return new Outlet(this, service);
                case "55":
                    return new Pairing(this, service);
                case "221":
                    return new PowerManagement(this, service);
                case "A2":
                    return new ProtocolInformation(this, service);
                case "7E":
                    return new SecuritySystem(this, service);
                case "CC":
                    return new ServiceLabel(this, service);
                case "133":
                    return new Siri(this, service);
                case "253":
                    return new SiriEndpoint(this, service);
                case "B9":
                    return new Slats(this, service);
                case "228":
                    return new SmartSpeaker(this, service);
                case "87":
                    return new SmokeSensor(this, service);
                case "88":
                    return new StatefulProgrammableSwitch(this, service);
                case "89":
                    return new StatelessProgrammableSwitch(this, service);
                case "49":
                    return new Switch(this, service);
                case "22E":
                    return new TapManagement(this, service);
                case "125":
                    return new TargetControl(this, service);
                case "122":
                    return new TargetControlManagement(this, service);
                case "D8":
                    return new Television(this, service);
                case "113":
                    return new TelevisionSpeaker(this, service);
                case "8A":
                    return new TemperatureSensor(this, service);
                case "4A":
                    return new Thermostat(this, service);
                case "701":
                    return new ThreadTransport(this, service);
                case "203":
                    return new TransferTransportManagement(this, service);
                case "56":
                    return new Tunnel(this, service);
                case "D0":
                    return new Valve(this, service);
                case "20A":
                    return new WiFiRouter(this, service);
                case "20F":
                    return new WiFiSatellite(this, service);
                case "22A":
                    return new WiFiTransport(this, service);
                case "8B":
                    return new Window(this, service);
                case "8C":
                    return new WindowCovering(this, service);


            }
            return null;
        }

        internal void RegisterCharacteristic(int instance, CharacteristicBase characteristic)
        {
            instanceTable.TryAdd(instance, characteristic);
        }

        internal void InvokeEvent(CharacteristicEventJSON json)
        {
            if (instanceTable.TryGetValue(json.InstanceID, out CharacteristicBase? characteristic))
                characteristic.FireUpdate(json.Value);
        }
    }
}
