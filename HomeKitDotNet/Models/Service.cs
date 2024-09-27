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

        protected ICharacteristic? GetCharacteristic(string type, ServiceJSON service)
        {
            CharacteristicJSON? json = service.Characteristics.FirstOrDefault(c => c.Type == type);
            switch (type)
            {
                case "262":
                    return (json != null) ? new AccessCodeControlPoint(this, json) : null;
                case "261":
                    return (json != null) ? new AccessCodeSupportedConfiguration(this, json) : null;
                case "E5":
                    return (json != null) ? new AccessControlLevel(this, json) : null;
                case "A6":
                    return (json != null) ? new AccessoryFlags(this, json) : null;
                case "57":
                    return (json != null) ? new AccessoryIdentifier(this, json) : null;
                case "B0":
                    return (json != null) ? new Active(this, json) : null;
                case "E7":
                    return (json != null) ? new ActiveIdentifier(this, json) : null;
                case "23B":
                    return (json != null) ? new ActivityInterval(this, json) : null;
                case "1":
                    return (json != null) ? new AdministratorOnlyAccess(this, json) : null;
                case "64":
                    return (json != null) ? new AirParticulateDensity(this, json) : null;
                case "65":
                    return (json != null) ? new AirParticulateSize(this, json) : null;
                case "25B":
                    return (json != null) ? new AirPlayEnable(this, json) : null;
                case "95":
                    return (json != null) ? new AirQuality(this, json) : null;
                case "A4":
                    return (json != null) ? new AppMatchingIdentifier(this, json) : null;
                case "269":
                    return (json != null) ? new AssetUpdateReadiness(this, json) : null;
                case "5":
                    return (json != null) ? new AudioFeedback(this, json) : null;
                case "68":
                    return (json != null) ? new BatteryLevel(this, json) : null;
                case "8":
                    return (json != null) ? new Brightness(this, json) : null;
                case "126":
                    return (json != null) ? new ButtonEvent(this, json) : null;
                case "21D":
                    return (json != null) ? new CameraOperatingModeIndicator(this, json) : null;
                case "92":
                    return (json != null) ? new CarbonDioxideDetected(this, json) : null;
                case "93":
                    return (json != null) ? new CarbonDioxideLevel(this, json) : null;
                case "94":
                    return (json != null) ? new CarbonDioxidePeakLevel(this, json) : null;
                case "69":
                    return (json != null) ? new CarbonMonoxideDetected(this, json) : null;
                case "90":
                    return (json != null) ? new CarbonMonoxideLevel(this, json) : null;
                case "91":
                    return (json != null) ? new CarbonMonoxidePeakLevel(this, json) : null;
                case "246":
                    return (json != null) ? new CCAEnergyDetectThreshold(this, json) : null;
                case "245":
                    return (json != null) ? new CCASignalDetectThreshold(this, json) : null;
                case "24B":
                    return (json != null) ? new CharacteristicValueActiveTransitionCount(this, json) : null;
                case "143":
                    return (json != null) ? new CharacteristicValueTransitionControl(this, json) : null;
                case "8F":
                    return (json != null) ? new ChargingState(this, json) : null;
                case "DD":
                    return (json != null) ? new ClosedCaptions(this, json) : null;
                case "CE":
                    return (json != null) ? new ColorTemperature(this, json) : null;
                case "263":
                    return (json != null) ? new ConfigurationState(this, json) : null;
                case "E3":
                    return (json != null) ? new ConfiguredName(this, json) : null;
                case "6A":
                    return (json != null) ? new ContactSensorState(this, json) : null;
                case "D":
                    return (json != null) ? new CoolingThresholdTemperature(this, json) : null;
                case "250":
                    return (json != null) ? new CryptoHash(this, json) : null;
                case "A9":
                    return (json != null) ? new CurrentAirPurifierState(this, json) : null;
                case "6B":
                    return (json != null) ? new CurrentAmbientLightLevel(this, json) : null;
                case "E":
                    return (json != null) ? new CurrentDoorState(this, json) : null;
                case "AF":
                    return (json != null) ? new CurrentFanState(this, json) : null;
                case "B1":
                    return (json != null) ? new CurrentHeaterCoolerState(this, json) : null;
                case "F":
                    return (json != null) ? new CurrentHeatingCoolingState(this, json) : null;
                case "6C":
                    return (json != null) ? new CurrentHorizontalTiltAngle(this, json) : null;
                case "B3":
                    return (json != null) ? new CurrentHumidifierDehumidifierState(this, json) : null;
                case "E0":
                    return (json != null) ? new CurrentMediaState(this, json) : null;
                case "6D":
                    return (json != null) ? new CurrentPosition(this, json) : null;
                case "10":
                    return (json != null) ? new CurrentRelativeHumidity(this, json) : null;
                case "AA":
                    return (json != null) ? new CurrentSlatState(this, json) : null;
                case "11":
                    return (json != null) ? new CurrentTemperature(this, json) : null;
                case "C1":
                    return (json != null) ? new CurrentTiltAngle(this, json) : null;
                case "22B":
                    return (json != null) ? new CurrentTransport(this, json) : null;
                case "6E":
                    return (json != null) ? new CurrentVerticalTiltAngle(this, json) : null;
                case "135":
                    return (json != null) ? new CurrentVisibilityState(this, json) : null;
                case "138":
                    return (json != null) ? new DataStreamHAPTransport(this, json) : null;
                case "139":
                    return (json != null) ? new DataStreamHAPTransportInterrupt(this, json) : null;
                case "224":
                    return (json != null) ? new DiagonalFieldOfView(this, json) : null;
                case "11D":
                    return (json != null) ? new DigitalZoom(this, json) : null;
                case "136":
                    return (json != null) ? new DisplayOrder(this, json) : null;
                case "23D":
                    return (json != null) ? new EventRetransmissionMaximum(this, json) : null;
                case "223":
                    return (json != null) ? new EventSnapshotsActive(this, json) : null;
                case "23E":
                    return (json != null) ? new EventTransmissionCounters(this, json) : null;
                case "AC":
                    return (json != null) ? new FilterChangeIndication(this, json) : null;
                case "AB":
                    return (json != null) ? new FilterLifeLevel(this, json) : null;
                case "52":
                    return (json != null) ? new FirmwareRevision(this, json) : null;
                case "234":
                    return (json != null) ? new FirmwareUpdateReadiness(this, json) : null;
                case "235":
                    return (json != null) ? new FirmwareUpdateStatus(this, json) : null;
                case "26C":
                    return (json != null) ? new HardwareFinish(this, json) : null;
                case "53":
                    return (json != null) ? new HardwareRevision(this, json) : null;
                case "24A":
                    return (json != null) ? new HeartBeat(this, json) : null;
                case "12":
                    return (json != null) ? new HeatingThresholdTemperature(this, json) : null;
                case "6F":
                    return (json != null) ? new HoldPosition(this, json) : null;
                case "21B":
                    return (json != null) ? new HomeKitCameraActive(this, json) : null;
                case "13":
                    return (json != null) ? new Hue(this, json) : null;
                case "E6":
                    return (json != null) ? new Identifier(this, json) : null;
                case "14":
                    return (json != null) ? new Identify(this, json) : null;
                case "11F":
                    return (json != null) ? new ImageMirroring(this, json) : null;
                case "11E":
                    return (json != null) ? new ImageRotation(this, json) : null;
                case "DC":
                    return (json != null) ? new InputDeviceType(this, json) : null;
                case "DB":
                    return (json != null) ? new InputSourceType(this, json) : null;
                case "D2":
                    return (json != null) ? new InUse(this, json) : null;
                case "D6":
                    return (json != null) ? new IsConfigured(this, json) : null;
                case "70":
                    return (json != null) ? new LeakDetected(this, json) : null;
                case "50":
                    return (json != null) ? new ListPairings(this, json) : null;
                case "19":
                    return (json != null) ? new LockControlPoint(this, json) : null;
                case "1D":
                    return (json != null) ? new LockCurrentState(this, json) : null;
                case "1C":
                    return (json != null) ? new LockLastKnownAction(this, json) : null;
                case "1A":
                    return (json != null) ? new LockManagementAutoSecurityTimeout(this, json) : null;
                case "A7":
                    return (json != null) ? new LockPhysicalControls(this, json) : null;
                case "1E":
                    return (json != null) ? new LockTargetState(this, json) : null;
                case "1F":
                    return (json != null) ? new Logs(this, json) : null;
                case "247":
                    return (json != null) ? new MACRetransmissionMaximum(this, json) : null;
                case "248":
                    return (json != null) ? new MACTransmissionCounters(this, json) : null;
                case "215":
                    return (json != null) ? new ManagedNetworkEnable(this, json) : null;
                case "227":
                    return (json != null) ? new ManuallyDisabled(this, json) : null;
                case "20":
                    return (json != null) ? new Manufacturer(this, json) : null;
                case "243":
                    return (json != null) ? new MaximumTransmitPower(this, json) : null;
                case "272":
                    return (json != null) ? new MetricsBufferFullState(this, json) : null;
                case "21":
                    return (json != null) ? new Model(this, json) : null;
                case "22":
                    return (json != null) ? new MotionDetected(this, json) : null;
                case "26B":
                    return (json != null) ? new MultifunctionButton(this, json) : null;
                case "11A":
                    return (json != null) ? new Mute(this, json) : null;
                case "23":
                    return (json != null) ? new Name(this, json) : null;
                case "21F":
                    return (json != null) ? new NetworkAccessViolationControl(this, json) : null;
                case "20C":
                    return (json != null) ? new NetworkClientProfileControl(this, json) : null;
                case "20D":
                    return (json != null) ? new NetworkClientStatusControl(this, json) : null;
                case "264":
                    return (json != null) ? new NFCAccessControlPoint(this, json) : null;
                case "265":
                    return (json != null) ? new NFCAccessSupportedConfiguration(this, json) : null;
                case "11B":
                    return (json != null) ? new NightVision(this, json) : null;
                case "C4":
                    return (json != null) ? new NitrogenDioxideDensity(this, json) : null;
                case "24":
                    return (json != null) ? new ObstructionDetected(this, json) : null;
                case "71":
                    return (json != null) ? new OccupancyDetected(this, json) : null;
                case "25":
                    return (json != null) ? new On(this, json) : null;
                case "232":
                    return (json != null) ? new OperatingStateResponse(this, json) : null;
                case "11C":
                    return (json != null) ? new OpticalZoom(this, json) : null;
                case "26":
                    return (json != null) ? new OutletInUse(this, json) : null;
                case "C3":
                    return (json != null) ? new OzoneDensity(this, json) : null;
                case "4F":
                    return (json != null) ? new PairingFeatures(this, json) : null;
                case "4C":
                    return (json != null) ? new PairSetup(this, json) : null;
                case "4E":
                    return (json != null) ? new PairVerify(this, json) : null;
                case "E4":
                    return (json != null) ? new PasswordSetting(this, json) : null;
                case "225":
                    return (json != null) ? new PeriodicSnapshotsActive(this, json) : null;
                case "E2":
                    return (json != null) ? new PictureMode(this, json) : null;
                case "23C":
                    return (json != null) ? new Ping(this, json) : null;
                case "C7":
                    return (json != null) ? new PM10Density(this, json) : null;
                case "C6":
                    return (json != null) ? new PM2_5Density(this, json) : null;
                case "72":
                    return (json != null) ? new PositionState(this, json) : null;
                case "DF":
                    return (json != null) ? new PowerModeSelection(this, json) : null;
                case "220":
                    return (json != null) ? new ProductData(this, json) : null;
                case "73":
                    return (json != null) ? new ProgrammableSwitchEvent(this, json) : null;
                case "74":
                    return (json != null) ? new ProgrammableSwitchOutputState(this, json) : null;
                case "D1":
                    return (json != null) ? new ProgramMode(this, json) : null;
                case "23F":
                    return (json != null) ? new ReceivedSignalStrengthIndication(this, json) : null;
                case "244":
                    return (json != null) ? new ReceiverSensitivity(this, json) : null;
                case "226":
                    return (json != null) ? new RecordingAudioActive(this, json) : null;
                case "C9":
                    return (json != null) ? new RelativeHumidityDehumidifierThreshold(this, json) : null;
                case "CA":
                    return (json != null) ? new RelativeHumidityHumidifierThreshold(this, json) : null;
                case "5E":
                    return (json != null) ? new RelayControlPoint(this, json) : null;
                case "5B":
                    return (json != null) ? new RelayEnabled(this, json) : null;
                case "5C":
                    return (json != null) ? new RelayState(this, json) : null;
                case "D4":
                    return (json != null) ? new RemainingDuration(this, json) : null;
                case "E1":
                    return (json != null) ? new RemoteKey(this, json) : null;
                case "AD":
                    return (json != null) ? new ResetFilterIndication(this, json) : null;
                case "28":
                    return (json != null) ? new RotationDirection(this, json) : null;
                case "29":
                    return (json != null) ? new RotationSpeed(this, json) : null;
                case "20E":
                    return (json != null) ? new RouterStatus(this, json) : null;
                case "2F":
                    return (json != null) ? new Saturation(this, json) : null;
                case "8E":
                    return (json != null) ? new SecuritySystemAlarmType(this, json) : null;
                case "66":
                    return (json != null) ? new SecuritySystemCurrentState(this, json) : null;
                case "67":
                    return (json != null) ? new SecuritySystemTargetState(this, json) : null;
                case "128":
                    return (json != null) ? new SelectedAudioStreamConfiguration(this, json) : null;
                case "209":
                    return (json != null) ? new SelectedCameraRecordingConfiguration(this, json) : null;
                case "24D":
                    return (json != null) ? new SelectedDiagnosticsModes(this, json) : null;
                case "117":
                    return (json != null) ? new SelectedRTPStreamConfiguration(this, json) : null;
                case "252":
                    return (json != null) ? new SelectedSleepConfiguration(this, json) : null;
                case "30":
                    return (json != null) ? new SerialNumber(this, json) : null;
                case "CB":
                    return (json != null) ? new ServiceLabelIndex(this, json) : null;
                case "CD":
                    return (json != null) ? new ServiceLabelNamespace(this, json) : null;
                case "D3":
                    return (json != null) ? new SetDuration(this, json) : null;
                case "131":
                    return (json != null) ? new SetupDataStreamTransport(this, json) : null;
                case "118":
                    return (json != null) ? new SetupEndpoints(this, json) : null;
                case "201":
                    return (json != null) ? new SetupTransferTransport(this, json) : null;
                case "241":
                    return (json != null) ? new SignalToNoiseRatio(this, json) : null;
                case "255":
                    return (json != null) ? new SiriEnable(this, json) : null;
                case "254":
                    return (json != null) ? new SiriEndpointSessionStatus(this, json) : null;
                case "25A":
                    return (json != null) ? new SiriEngineVersion(this, json) : null;
                case "132":
                    return (json != null) ? new SiriInputType(this, json) : null;
                case "258":
                    return (json != null) ? new SiriLightOnUse(this, json) : null;
                case "256":
                    return (json != null) ? new SiriListening(this, json) : null;
                case "257":
                    return (json != null) ? new SiriTouchToUse(this, json) : null;
                case "C0":
                    return (json != null) ? new SlatType(this, json) : null;
                case "E8":
                    return (json != null) ? new SleepDiscoveryMode(this, json) : null;
                case "23A":
                    return (json != null) ? new SleepInterval(this, json) : null;
                case "76":
                    return (json != null) ? new SmokeDetected(this, json) : null;
                case "54":
                    return (json != null) ? new SoftwareRevision(this, json) : null;
                case "249":
                    return (json != null) ? new StagedFirmwareVersion(this, json) : null;
                case "75":
                    return (json != null) ? new StatusActive(this, json) : null;
                case "77":
                    return (json != null) ? new StatusFault(this, json) : null;
                case "78":
                    return (json != null) ? new StatusJammed(this, json) : null;
                case "79":
                    return (json != null) ? new StatusLowBattery(this, json) : null;
                case "7A":
                    return (json != null) ? new StatusTampered(this, json) : null;
                case "120":
                    return (json != null) ? new StreamingStatus(this, json) : null;
                case "C5":
                    return (json != null) ? new SulphurDioxideDensity(this, json) : null;
                case "268":
                    return (json != null) ? new SupportedAssetTypes(this, json) : null;
                case "207":
                    return (json != null) ? new SupportedAudioRecordingConfiguration(this, json) : null;
                case "115":
                    return (json != null) ? new SupportedAudioStreamConfiguration(this, json) : null;
                case "205":
                    return (json != null) ? new SupportedCameraRecordingConfiguration(this, json) : null;
                case "144":
                    return (json != null) ? new SupportedCharacteristicValueTransitionConfiguration(this, json) : null;
                case "130":
                    return (json != null) ? new SupportedDataStreamTransportConfiguration(this, json) : null;
                case "24C":
                    return (json != null) ? new SupportedDiagnosticsModes(this, json) : null;
                case "238":
                    return (json != null) ? new SupportedDiagnosticsSnapshot(this, json) : null;
                case "233":
                    return (json != null) ? new SupportedFirmwareUpdateConfiguration(this, json) : null;
                case "271":
                    return (json != null) ? new SupportedMetrics(this, json) : null;
                case "210":
                    return (json != null) ? new SupportedRouterConfiguration(this, json) : null;
                case "116":
                    return (json != null) ? new SupportedRTPConfiguration(this, json) : null;
                case "251":
                    return (json != null) ? new SupportedSleepConfiguration(this, json) : null;
                case "202":
                    return (json != null) ? new SupportedTransferTransportConfiguration(this, json) : null;
                case "206":
                    return (json != null) ? new SupportedVideoRecordingConfiguration(this, json) : null;
                case "114":
                    return (json != null) ? new SupportedVideoStreamConfiguration(this, json) : null;
                case "B6":
                    return (json != null) ? new SwingMode(this, json) : null;
                case "22F":
                    return (json != null) ? new TapType(this, json) : null;
                case "A8":
                    return (json != null) ? new TargetAirPurifierState(this, json) : null;
                case "124":
                    return (json != null) ? new TargetControlList(this, json) : null;
                case "123":
                    return (json != null) ? new TargetControlSupportedConfiguration(this, json) : null;
                case "32":
                    return (json != null) ? new TargetDoorState(this, json) : null;
                case "BF":
                    return (json != null) ? new TargetFanState(this, json) : null;
                case "B2":
                    return (json != null) ? new TargetHeaterCoolerState(this, json) : null;
                case "33":
                    return (json != null) ? new TargetHeatingCoolingState(this, json) : null;
                case "7B":
                    return (json != null) ? new TargetHorizontalTiltAngle(this, json) : null;
                case "B4":
                    return (json != null) ? new TargetHumidifierDehumidifierState(this, json) : null;
                case "137":
                    return (json != null) ? new TargetMediaState(this, json) : null;
                case "7C":
                    return (json != null) ? new TargetPosition(this, json) : null;
                case "34":
                    return (json != null) ? new TargetRelativeHumidity(this, json) : null;
                case "35":
                    return (json != null) ? new TargetTemperature(this, json) : null;
                case "C2":
                    return (json != null) ? new TargetTiltAngle(this, json) : null;
                case "7D":
                    return (json != null) ? new TargetVerticalTiltAngle(this, json) : null;
                case "134":
                    return (json != null) ? new TargetVisibilityState(this, json) : null;
                case "36":
                    return (json != null) ? new TemperatureDisplayUnits(this, json) : null;
                case "21C":
                    return (json != null) ? new ThirdPartyCameraActive(this, json) : null;
                case "704":
                    return (json != null) ? new ThreadControlPoint(this, json) : null;
                case "702":
                    return (json != null) ? new ThreadNodeCapabilities(this, json) : null;
                case "706":
                    return (json != null) ? new ThreadOpenThreadVersion(this, json) : null;
                case "703":
                    return (json != null) ? new ThreadStatus(this, json) : null;
                case "231":
                    return (json != null) ? new Token(this, json) : null;
                case "242":
                    return (json != null) ? new TransmitPower(this, json) : null;
                case "61":
                    return (json != null) ? new TunnelConnectionTimeout(this, json) : null;
                case "60":
                    return (json != null) ? new TunneledAccessoryAdvertising(this, json) : null;
                case "59":
                    return (json != null) ? new TunneledAccessoryConnected(this, json) : null;
                case "58":
                    return (json != null) ? new TunneledAccessoryStateNumber(this, json) : null;
                case "D5":
                    return (json != null) ? new ValveType(this, json) : null;
                case "37":
                    return (json != null) ? new Version(this, json) : null;
                case "229":
                    return (json != null) ? new VideoAnalysisActive(this, json) : null;
                case "C8":
                    return (json != null) ? new VOCDensity(this, json) : null;
                case "119":
                    return (json != null) ? new Volume(this, json) : null;
                case "E9":
                    return (json != null) ? new VolumeControlType(this, json) : null;
                case "EA":
                    return (json != null) ? new VolumeSelector(this, json) : null;
                case "222":
                    return (json != null) ? new WakeConfiguration(this, json) : null;
                case "211":
                    return (json != null) ? new WANConfigurationList(this, json) : null;
                case "212":
                    return (json != null) ? new WANStatusList(this, json) : null;
                case "B5":
                    return (json != null) ? new WaterLevel(this, json) : null;
                case "22C":
                    return (json != null) ? new WiFiCapabilities(this, json) : null;
                case "22D":
                    return (json != null) ? new WiFiConfigurationControl(this, json) : null;
                case "21E":
                    return (json != null) ? new WiFiSatelliteStatus(this, json) : null;
            }
            return null;
        }
    }
}
