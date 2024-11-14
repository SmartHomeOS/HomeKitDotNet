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
    public class Service : IService
    {
        protected Service(Accessory accessory, string type)
        {
            this.Type = type;
            this.Accessory = accessory;
        }

        public string Type { get; init; }
        public Accessory Accessory { get; init; }

        protected CharacteristicBase? GetCharacteristic(string type, ServiceJSON service)
        {
            CharacteristicJSON? json = service.Characteristics.FirstOrDefault(c => c.Type == type);
            if (json != null)
            {
                CharacteristicBase? charBase = MapCharacteristic(type, json);
                if (charBase != null)
                    Accessory.RegisterCharacteristic(json.InstanceID, charBase);
                return charBase;
            }
            return null;
        }

        private CharacteristicBase? MapCharacteristic(string type, CharacteristicJSON json)
        {
            switch (type)
            {
                case "262":
                    return new AccessCodeControlPoint(this, json);
                case "261":
                    return new AccessCodeSupportedConfiguration(this, json);
                case "E5":
                    return new AccessControlLevel(this, json);
                case "A6":
                    return new AccessoryFlags(this, json);
                case "57":
                    return new AccessoryIdentifier(this, json);
                case "B0":
                    return new Active(this, json);
                case "E7":
                    return new ActiveIdentifier(this, json);
                case "23B":
                    return new ActivityInterval(this, json);
                case "1":
                    return new AdministratorOnlyAccess(this, json);
                case "64":
                    return new AirParticulateDensity(this, json);
                case "65":
                    return new AirParticulateSize(this, json);
                case "25B":
                    return new AirPlayEnable(this, json);
                case "95":
                    return new AirQuality(this, json);
                case "A4":
                    return new AppMatchingIdentifier(this, json);
                case "269":
                    return new AssetUpdateReadiness(this, json);
                case "5":
                    return new AudioFeedback(this, json);
                case "68":
                    return new BatteryLevel(this, json);
                case "8":
                    return new Brightness(this, json);
                case "126":
                    return new ButtonEvent(this, json);
                case "21D":
                    return new CameraOperatingModeIndicator(this, json);
                case "92":
                    return new CarbonDioxideDetected(this, json);
                case "93":
                    return new CarbonDioxideLevel(this, json);
                case "94":
                    return new CarbonDioxidePeakLevel(this, json);
                case "69":
                    return new CarbonMonoxideDetected(this, json);
                case "90":
                    return new CarbonMonoxideLevel(this, json);
                case "91":
                    return new CarbonMonoxidePeakLevel(this, json);
                case "246":
                    return new CCAEnergyDetectThreshold(this, json);
                case "245":
                    return new CCASignalDetectThreshold(this, json);
                case "24B":
                    return new CharacteristicValueActiveTransitionCount(this, json);
                case "143":
                    return new CharacteristicValueTransitionControl(this, json);
                case "8F":
                    return new ChargingState(this, json);
                case "DD":
                    return new ClosedCaptions(this, json);
                case "CE":
                    return new ColorTemperature(this, json);
                case "263":
                    return new ConfigurationState(this, json);
                case "E3":
                    return new ConfiguredName(this, json);
                case "6A":
                    return new ContactSensorState(this, json);
                case "D":
                    return new CoolingThresholdTemperature(this, json);
                case "250":
                    return new CryptoHash(this, json);
                case "A9":
                    return new CurrentAirPurifierState(this, json);
                case "6B":
                    return new CurrentAmbientLightLevel(this, json);
                case "E":
                    return new CurrentDoorState(this, json);
                case "AF":
                    return new CurrentFanState(this, json);
                case "B1":
                    return new CurrentHeaterCoolerState(this, json);
                case "F":
                    return new CurrentHeatingCoolingState(this, json);
                case "6C":
                    return new CurrentHorizontalTiltAngle(this, json);
                case "B3":
                    return new CurrentHumidifierDehumidifierState(this, json);
                case "E0":
                    return new CurrentMediaState(this, json);
                case "6D":
                    return new CurrentPosition(this, json);
                case "10":
                    return new CurrentRelativeHumidity(this, json);
                case "AA":
                    return new CurrentSlatState(this, json);
                case "11":
                    return new CurrentTemperature(this, json);
                case "C1":
                    return new CurrentTiltAngle(this, json);
                case "22B":
                    return new CurrentTransport(this, json);
                case "6E":
                    return new CurrentVerticalTiltAngle(this, json);
                case "135":
                    return new CurrentVisibilityState(this, json);
                case "138":
                    return new DataStreamHAPTransport(this, json);
                case "139":
                    return new DataStreamHAPTransportInterrupt(this, json);
                case "224":
                    return new DiagonalFieldOfView(this, json);
                case "11D":
                    return new DigitalZoom(this, json);
                case "136":
                    return new DisplayOrder(this, json);
                case "23D":
                    return new EventRetransmissionMaximum(this, json);
                case "223":
                    return new EventSnapshotsActive(this, json);
                case "23E":
                    return new EventTransmissionCounters(this, json);
                case "AC":
                    return new FilterChangeIndication(this, json);
                case "AB":
                    return new FilterLifeLevel(this, json);
                case "52":
                    return new FirmwareRevision(this, json);
                case "234":
                    return new FirmwareUpdateReadiness(this, json);
                case "235":
                    return new FirmwareUpdateStatus(this, json);
                case "26C":
                    return new HardwareFinish(this, json);
                case "53":
                    return new HardwareRevision(this, json);
                case "24A":
                    return new HeartBeat(this, json);
                case "12":
                    return new HeatingThresholdTemperature(this, json);
                case "6F":
                    return new HoldPosition(this, json);
                case "21B":
                    return new HomeKitCameraActive(this, json);
                case "13":
                    return new Hue(this, json);
                case "E6":
                    return new Identifier(this, json);
                case "14":
                    return new Identify(this, json);
                case "11F":
                    return new ImageMirroring(this, json);
                case "11E":
                    return new ImageRotation(this, json);
                case "DC":
                    return new InputDeviceType(this, json);
                case "DB":
                    return new InputSourceType(this, json);
                case "D2":
                    return new InUse(this, json);
                case "D6":
                    return new IsConfigured(this, json);
                case "70":
                    return new LeakDetected(this, json);
                case "50":
                    return new ListPairings(this, json);
                case "19":
                    return new LockControlPoint(this, json);
                case "1D":
                    return new LockCurrentState(this, json);
                case "1C":
                    return new LockLastKnownAction(this, json);
                case "1A":
                    return new LockManagementAutoSecurityTimeout(this, json);
                case "A7":
                    return new LockPhysicalControls(this, json);
                case "1E":
                    return new LockTargetState(this, json);
                case "1F":
                    return new Logs(this, json);
                case "247":
                    return new MACRetransmissionMaximum(this, json);
                case "248":
                    return new MACTransmissionCounters(this, json);
                case "215":
                    return new ManagedNetworkEnable(this, json);
                case "227":
                    return new ManuallyDisabled(this, json);
                case "20":
                    return new Manufacturer(this, json);
                case "243":
                    return new MaximumTransmitPower(this, json);
                case "272":
                    return new MetricsBufferFullState(this, json);
                case "21":
                    return new Model(this, json);
                case "22":
                    return new MotionDetected(this, json);
                case "26B":
                    return new MultifunctionButton(this, json);
                case "11A":
                    return new Mute(this, json);
                case "23":
                    return new Name(this, json);
                case "21F":
                    return new NetworkAccessViolationControl(this, json);
                case "20C":
                    return new NetworkClientProfileControl(this, json);
                case "20D":
                    return new NetworkClientStatusControl(this, json);
                case "264":
                    return new NFCAccessControlPoint(this, json);
                case "265":
                    return new NFCAccessSupportedConfiguration(this, json);
                case "11B":
                    return new NightVision(this, json);
                case "C4":
                    return new NitrogenDioxideDensity(this, json);
                case "24":
                    return new ObstructionDetected(this, json);
                case "71":
                    return new OccupancyDetected(this, json);
                case "25":
                    return new On(this, json);
                case "232":
                    return new OperatingStateResponse(this, json);
                case "11C":
                    return new OpticalZoom(this, json);
                case "26":
                    return new OutletInUse(this, json);
                case "C3":
                    return new OzoneDensity(this, json);
                case "4F":
                    return new PairingFeatures(this, json);
                case "4C":
                    return new PairSetup(this, json);
                case "4E":
                    return new PairVerify(this, json);
                case "E4":
                    return new PasswordSetting(this, json);
                case "225":
                    return new PeriodicSnapshotsActive(this, json);
                case "E2":
                    return new PictureMode(this, json);
                case "23C":
                    return new Ping(this, json);
                case "C7":
                    return new PM10Density(this, json);
                case "C6":
                    return new PM2_5Density(this, json);
                case "72":
                    return new PositionState(this, json);
                case "DF":
                    return new PowerModeSelection(this, json);
                case "220":
                    return new ProductData(this, json);
                case "73":
                    return new ProgrammableSwitchEvent(this, json);
                case "74":
                    return new ProgrammableSwitchOutputState(this, json);
                case "D1":
                    return new ProgramMode(this, json);
                case "23F":
                    return new ReceivedSignalStrengthIndication(this, json);
                case "244":
                    return new ReceiverSensitivity(this, json);
                case "226":
                    return new RecordingAudioActive(this, json);
                case "C9":
                    return new RelativeHumidityDehumidifierThreshold(this, json);
                case "CA":
                    return new RelativeHumidityHumidifierThreshold(this, json);
                case "5E":
                    return new RelayControlPoint(this, json);
                case "5B":
                    return new RelayEnabled(this, json);
                case "5C":
                    return new RelayState(this, json);
                case "D4":
                    return new RemainingDuration(this, json);
                case "E1":
                    return new RemoteKey(this, json);
                case "AD":
                    return new ResetFilterIndication(this, json);
                case "28":
                    return new RotationDirection(this, json);
                case "29":
                    return new RotationSpeed(this, json);
                case "20E":
                    return new RouterStatus(this, json);
                case "2F":
                    return new Saturation(this, json);
                case "8E":
                    return new SecuritySystemAlarmType(this, json);
                case "66":
                    return new SecuritySystemCurrentState(this, json);
                case "67":
                    return new SecuritySystemTargetState(this, json);
                case "128":
                    return new SelectedAudioStreamConfiguration(this, json);
                case "209":
                    return new SelectedCameraRecordingConfiguration(this, json);
                case "24D":
                    return new SelectedDiagnosticsModes(this, json);
                case "117":
                    return new SelectedRTPStreamConfiguration(this, json);
                case "252":
                    return new SelectedSleepConfiguration(this, json);
                case "30":
                    return new SerialNumber(this, json);
                case "CB":
                    return new ServiceLabelIndex(this, json);
                case "CD":
                    return new ServiceLabelNamespace(this, json);
                case "D3":
                    return new SetDuration(this, json);
                case "131":
                    return new SetupDataStreamTransport(this, json);
                case "118":
                    return new SetupEndpoints(this, json);
                case "201":
                    return new SetupTransferTransport(this, json);
                case "241":
                    return new SignalToNoiseRatio(this, json);
                case "255":
                    return new SiriEnable(this, json);
                case "254":
                    return new SiriEndpointSessionStatus(this, json);
                case "25A":
                    return new SiriEngineVersion(this, json);
                case "132":
                    return new SiriInputType(this, json);
                case "258":
                    return new SiriLightOnUse(this, json);
                case "256":
                    return new SiriListening(this, json);
                case "257":
                    return new SiriTouchToUse(this, json);
                case "C0":
                    return new SlatType(this, json);
                case "E8":
                    return new SleepDiscoveryMode(this, json);
                case "23A":
                    return new SleepInterval(this, json);
                case "76":
                    return new SmokeDetected(this, json);
                case "54":
                    return new SoftwareRevision(this, json);
                case "249":
                    return new StagedFirmwareVersion(this, json);
                case "75":
                    return new StatusActive(this, json);
                case "77":
                    return new StatusFault(this, json);
                case "78":
                    return new StatusJammed(this, json);
                case "79":
                    return new StatusLowBattery(this, json);
                case "7A":
                    return new StatusTampered(this, json);
                case "120":
                    return new StreamingStatus(this, json);
                case "C5":
                    return new SulphurDioxideDensity(this, json);
                case "268":
                    return new SupportedAssetTypes(this, json);
                case "207":
                    return new SupportedAudioRecordingConfiguration(this, json);
                case "115":
                    return new SupportedAudioStreamConfiguration(this, json);
                case "205":
                    return new SupportedCameraRecordingConfiguration(this, json);
                case "144":
                    return new SupportedCharacteristicValueTransitionConfiguration(this, json);
                case "130":
                    return new SupportedDataStreamTransportConfiguration(this, json);
                case "24C":
                    return new SupportedDiagnosticsModes(this, json);
                case "238":
                    return new SupportedDiagnosticsSnapshot(this, json);
                case "233":
                    return new SupportedFirmwareUpdateConfiguration(this, json);
                case "271":
                    return new SupportedMetrics(this, json);
                case "210":
                    return new SupportedRouterConfiguration(this, json);
                case "116":
                    return new SupportedRTPConfiguration(this, json);
                case "251":
                    return new SupportedSleepConfiguration(this, json);
                case "202":
                    return new SupportedTransferTransportConfiguration(this, json);
                case "206":
                    return new SupportedVideoRecordingConfiguration(this, json);
                case "114":
                    return new SupportedVideoStreamConfiguration(this, json);
                case "B6":
                    return new SwingMode(this, json);
                case "22F":
                    return new TapType(this, json);
                case "A8":
                    return new TargetAirPurifierState(this, json);
                case "124":
                    return new TargetControlList(this, json);
                case "123":
                    return new TargetControlSupportedConfiguration(this, json);
                case "32":
                    return new TargetDoorState(this, json);
                case "BF":
                    return new TargetFanState(this, json);
                case "B2":
                    return new TargetHeaterCoolerState(this, json);
                case "33":
                    return new TargetHeatingCoolingState(this, json);
                case "7B":
                    return new TargetHorizontalTiltAngle(this, json);
                case "B4":
                    return new TargetHumidifierDehumidifierState(this, json);
                case "137":
                    return new TargetMediaState(this, json);
                case "7C":
                    return new TargetPosition(this, json);
                case "34":
                    return new TargetRelativeHumidity(this, json);
                case "35":
                    return new TargetTemperature(this, json);
                case "C2":
                    return new TargetTiltAngle(this, json);
                case "7D":
                    return new TargetVerticalTiltAngle(this, json);
                case "134":
                    return new TargetVisibilityState(this, json);
                case "36":
                    return new TemperatureDisplayUnits(this, json);
                case "21C":
                    return new ThirdPartyCameraActive(this, json);
                case "704":
                    return new ThreadControlPoint(this, json);
                case "702":
                    return new ThreadNodeCapabilities(this, json);
                case "706":
                    return new ThreadOpenThreadVersion(this, json);
                case "703":
                    return new ThreadStatus(this, json);
                case "231":
                    return new Token(this, json);
                case "242":
                    return new TransmitPower(this, json);
                case "61":
                    return new TunnelConnectionTimeout(this, json);
                case "60":
                    return new TunneledAccessoryAdvertising(this, json);
                case "59":
                    return new TunneledAccessoryConnected(this, json);
                case "58":
                    return new TunneledAccessoryStateNumber(this, json);
                case "D5":
                    return new ValveType(this, json);
                case "37":
                    return new Version(this, json);
                case "229":
                    return new VideoAnalysisActive(this, json);
                case "C8":
                    return new VOCDensity(this, json);
                case "119":
                    return new Volume(this, json);
                case "E9":
                    return new VolumeControlType(this, json);
                case "EA":
                    return new VolumeSelector(this, json);
                case "222":
                    return new WakeConfiguration(this, json);
                case "211":
                    return new WANConfigurationList(this, json);
                case "212":
                    return new WANStatusList(this, json);
                case "B5":
                    return new WaterLevel(this, json);
                case "22C":
                    return new WiFiCapabilities(this, json);
                case "22D":
                    return new WiFiConfigurationControl(this, json);
                case "21E":
                    return new WiFiSatelliteStatus(this, json);

            }
            return null;
        }
    }
}
