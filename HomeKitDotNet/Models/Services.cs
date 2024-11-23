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
    /// 
    /// Access Code
    /// 
    public class AccessCode : Service
    {
        public AccessCode(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.AccessCodeControlPoint = (AccessCodeControlPoint)GetCharacteristic("262", json)!;
            this.AccessCodeSupportedConfiguration = (AccessCodeSupportedConfiguration)GetCharacteristic("261", json)!;
            this.ConfigurationState = (ConfigurationState)GetCharacteristic("263", json)!;
        }

        // Required Characteristics
        public AccessCodeControlPoint AccessCodeControlPoint { get; init; }
        public AccessCodeSupportedConfiguration AccessCodeSupportedConfiguration { get; init; }
        public ConfigurationState ConfigurationState { get; init; }
    }

    /// 
    /// Access Control
    /// 
    public class AccessControl : Service
    {
        public AccessControl(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.AccessControlLevel = (AccessControlLevel)GetCharacteristic("E5", json)!;
            this.PasswordSetting = (PasswordSetting?)GetCharacteristic("E4", json)!;
        }

        // Required Characteristics
        public AccessControlLevel AccessControlLevel { get; init; }
        // Optional Characteristics
        public PasswordSetting? PasswordSetting { get; init; }
    }

    /// 
    /// Accessory Information
    /// 
    public class AccessoryInformation : Service
    {
        public AccessoryInformation(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Identify = (Identify)GetCharacteristic("14", json)!;
            this.Manufacturer = (Manufacturer)GetCharacteristic("20", json)!;
            this.Model = (Model)GetCharacteristic("21", json)!;
            this.Name = (Name)GetCharacteristic("23", json)!;
            this.SerialNumber = (SerialNumber)GetCharacteristic("30", json)!;
            this.FirmwareRevision = (FirmwareRevision)GetCharacteristic("52", json)!;
            this.AccessoryFlags = (AccessoryFlags?)GetCharacteristic("A6", json)!;
            this.AppMatchingIdentifier = (AppMatchingIdentifier?)GetCharacteristic("A4", json)!;
            this.ConfiguredName = (ConfiguredName?)GetCharacteristic("E3", json)!;
            this.HardwareFinish = (HardwareFinish?)GetCharacteristic("26C", json)!;
            this.HardwareRevision = (HardwareRevision?)GetCharacteristic("53", json)!;
            this.ProductData = (ProductData?)GetCharacteristic("220", json)!;
            this.SoftwareRevision = (SoftwareRevision?)GetCharacteristic("54", json)!;
        }

        // Required Characteristics
        public Identify Identify { get; init; }
        public Manufacturer Manufacturer { get; init; }
        public Model Model { get; init; }
        public Name Name { get; init; }
        public SerialNumber SerialNumber { get; init; }
        public FirmwareRevision FirmwareRevision { get; init; }
        // Optional Characteristics
        public AccessoryFlags? AccessoryFlags { get; init; }
        public AppMatchingIdentifier? AppMatchingIdentifier { get; init; }
        public ConfiguredName? ConfiguredName { get; init; }
        public HardwareFinish? HardwareFinish { get; init; }
        public HardwareRevision? HardwareRevision { get; init; }
        public ProductData? ProductData { get; init; }
        public SoftwareRevision? SoftwareRevision { get; init; }
    }

    /// 
    /// Accessory Metrics
    /// 
    public class AccessoryMetrics : Service
    {
        public AccessoryMetrics(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.MetricsBufferFullState = (MetricsBufferFullState)GetCharacteristic("272", json)!;
            this.SupportedMetrics = (SupportedMetrics)GetCharacteristic("271", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public MetricsBufferFullState MetricsBufferFullState { get; init; }
        public SupportedMetrics SupportedMetrics { get; init; }
    }

    /// 
    /// Accessory Runtime Information
    /// 
    public class AccessoryRuntimeInformation : Service
    {
        public AccessoryRuntimeInformation(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Ping = (Ping)GetCharacteristic("23C", json)!;
            this.ActivityInterval = (ActivityInterval?)GetCharacteristic("23B", json)!;
            this.HeartBeat = (HeartBeat?)GetCharacteristic("24A", json)!;
            this.SleepInterval = (SleepInterval?)GetCharacteristic("23A", json)!;
        }

        // Required Characteristics
        public Ping Ping { get; init; }
        // Optional Characteristics
        public ActivityInterval? ActivityInterval { get; init; }
        public HeartBeat? HeartBeat { get; init; }
        public SleepInterval? SleepInterval { get; init; }
    }

    /// 
    /// Air Purifier
    /// 
    public class AirPurifier : Service
    {
        public AirPurifier(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.CurrentAirPurifierState = (CurrentAirPurifierState)GetCharacteristic("A9", json)!;
            this.TargetAirPurifierState = (TargetAirPurifierState)GetCharacteristic("A8", json)!;
            this.LockPhysicalControls = (LockPhysicalControls?)GetCharacteristic("A7", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.RotationSpeed = (RotationSpeed?)GetCharacteristic("29", json)!;
            this.SwingMode = (SwingMode?)GetCharacteristic("B6", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public CurrentAirPurifierState CurrentAirPurifierState { get; init; }
        public TargetAirPurifierState TargetAirPurifierState { get; init; }
        // Optional Characteristics
        public LockPhysicalControls? LockPhysicalControls { get; init; }
        public Name? Name { get; init; }
        public RotationSpeed? RotationSpeed { get; init; }
        public SwingMode? SwingMode { get; init; }
    }

    /// 
    /// Air Quality Sensor
    /// 
    public class AirQualitySensor : Service
    {
        public AirQualitySensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.AirQuality = (AirQuality)GetCharacteristic("95", json)!;
            this.NitrogenDioxideDensity = (NitrogenDioxideDensity?)GetCharacteristic("C4", json)!;
            this.OzoneDensity = (OzoneDensity?)GetCharacteristic("C3", json)!;
            this.PM10Density = (PM10Density?)GetCharacteristic("C7", json)!;
            this.PM2_5Density = (PM2_5Density?)GetCharacteristic("C6", json)!;
            this.SulphurDioxideDensity = (SulphurDioxideDensity?)GetCharacteristic("C5", json)!;
            this.VOCDensity = (VOCDensity?)GetCharacteristic("C8", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public AirQuality AirQuality { get; init; }
        // Optional Characteristics
        public NitrogenDioxideDensity? NitrogenDioxideDensity { get; init; }
        public OzoneDensity? OzoneDensity { get; init; }
        public PM10Density? PM10Density { get; init; }
        public PM2_5Density? PM2_5Density { get; init; }
        public SulphurDioxideDensity? SulphurDioxideDensity { get; init; }
        public VOCDensity? VOCDensity { get; init; }
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Asset Update
    /// 
    public class AssetUpdate : Service
    {
        public AssetUpdate(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.AssetUpdateReadiness = (AssetUpdateReadiness)GetCharacteristic("269", json)!;
            this.SupportedAssetTypes = (SupportedAssetTypes)GetCharacteristic("268", json)!;
        }

        // Required Characteristics
        public AssetUpdateReadiness AssetUpdateReadiness { get; init; }
        public SupportedAssetTypes SupportedAssetTypes { get; init; }
    }

    /// 
    /// Assistant
    /// 
    public class Assistant : Service
    {
        public Assistant(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.Identifier = (Identifier)GetCharacteristic("E6", json)!;
            this.Name = (Name)GetCharacteristic("23", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public Identifier Identifier { get; init; }
        public Name Name { get; init; }
    }

    /// 
    /// Audio Stream Management
    /// 
    public class AudioStreamManagement : Service
    {
        public AudioStreamManagement(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.SupportedAudioStreamConfiguration = (SupportedAudioStreamConfiguration)GetCharacteristic("115", json)!;
            this.SelectedAudioStreamConfiguration = (SelectedAudioStreamConfiguration)GetCharacteristic("128", json)!;
        }

        // Required Characteristics
        public SupportedAudioStreamConfiguration SupportedAudioStreamConfiguration { get; init; }
        public SelectedAudioStreamConfiguration SelectedAudioStreamConfiguration { get; init; }
    }

    /// 
    /// Battery
    /// 
    public class Battery : Service
    {
        public Battery(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.StatusLowBattery = (StatusLowBattery)GetCharacteristic("79", json)!;
            this.BatteryLevel = (BatteryLevel?)GetCharacteristic("68", json)!;
            this.ChargingState = (ChargingState?)GetCharacteristic("8F", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
        }

        // Required Characteristics
        public StatusLowBattery StatusLowBattery { get; init; }
        // Optional Characteristics
        public BatteryLevel? BatteryLevel { get; init; }
        public ChargingState? ChargingState { get; init; }
        public Name? Name { get; init; }
    }

    /// 
    /// Camera Operating Mode
    /// 
    public class CameraOperatingMode : Service
    {
        public CameraOperatingMode(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.EventSnapshotsActive = (EventSnapshotsActive)GetCharacteristic("223", json)!;
            this.HomeKitCameraActive = (HomeKitCameraActive)GetCharacteristic("21B", json)!;
            this.CameraOperatingModeIndicator = (CameraOperatingModeIndicator?)GetCharacteristic("21D", json)!;
            this.ManuallyDisabled = (ManuallyDisabled?)GetCharacteristic("227", json)!;
            this.NightVision = (NightVision?)GetCharacteristic("11B", json)!;
            this.PeriodicSnapshotsActive = (PeriodicSnapshotsActive?)GetCharacteristic("225", json)!;
            this.ThirdPartyCameraActive = (ThirdPartyCameraActive?)GetCharacteristic("21C", json)!;
            this.DiagonalFieldOfView = (DiagonalFieldOfView?)GetCharacteristic("224", json)!;
        }

        // Required Characteristics
        public EventSnapshotsActive EventSnapshotsActive { get; init; }
        public HomeKitCameraActive HomeKitCameraActive { get; init; }
        // Optional Characteristics
        public CameraOperatingModeIndicator? CameraOperatingModeIndicator { get; init; }
        public ManuallyDisabled? ManuallyDisabled { get; init; }
        public NightVision? NightVision { get; init; }
        public PeriodicSnapshotsActive? PeriodicSnapshotsActive { get; init; }
        public ThirdPartyCameraActive? ThirdPartyCameraActive { get; init; }
        public DiagonalFieldOfView? DiagonalFieldOfView { get; init; }
    }

    /// 
    /// Camera Recording Management
    /// 
    public class CameraRecordingManagement : Service
    {
        public CameraRecordingManagement(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.SelectedCameraRecordingConfiguration = (SelectedCameraRecordingConfiguration)GetCharacteristic("209", json)!;
            this.SupportedAudioRecordingConfiguration = (SupportedAudioRecordingConfiguration)GetCharacteristic("207", json)!;
            this.SupportedCameraRecordingConfiguration = (SupportedCameraRecordingConfiguration)GetCharacteristic("205", json)!;
            this.SupportedVideoRecordingConfiguration = (SupportedVideoRecordingConfiguration)GetCharacteristic("206", json)!;
            this.RecordingAudioActive = (RecordingAudioActive?)GetCharacteristic("226", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public SelectedCameraRecordingConfiguration SelectedCameraRecordingConfiguration { get; init; }
        public SupportedAudioRecordingConfiguration SupportedAudioRecordingConfiguration { get; init; }
        public SupportedCameraRecordingConfiguration SupportedCameraRecordingConfiguration { get; init; }
        public SupportedVideoRecordingConfiguration SupportedVideoRecordingConfiguration { get; init; }
        // Optional Characteristics
        public RecordingAudioActive? RecordingAudioActive { get; init; }
    }

    /// 
    /// Camera RTP Stream Management
    /// 
    public class CameraRTPStreamManagement : Service
    {
        public CameraRTPStreamManagement(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.SelectedRTPStreamConfiguration = (SelectedRTPStreamConfiguration)GetCharacteristic("117", json)!;
            this.SetupEndpoints = (SetupEndpoints)GetCharacteristic("118", json)!;
            this.StreamingStatus = (StreamingStatus)GetCharacteristic("120", json)!;
            this.SupportedAudioStreamConfiguration = (SupportedAudioStreamConfiguration)GetCharacteristic("115", json)!;
            this.SupportedRTPConfiguration = (SupportedRTPConfiguration)GetCharacteristic("116", json)!;
            this.SupportedVideoStreamConfiguration = (SupportedVideoStreamConfiguration)GetCharacteristic("114", json)!;
            this.Active = (Active?)GetCharacteristic("B0", json)!;
        }

        // Required Characteristics
        public SelectedRTPStreamConfiguration SelectedRTPStreamConfiguration { get; init; }
        public SetupEndpoints SetupEndpoints { get; init; }
        public StreamingStatus StreamingStatus { get; init; }
        public SupportedAudioStreamConfiguration SupportedAudioStreamConfiguration { get; init; }
        public SupportedRTPConfiguration SupportedRTPConfiguration { get; init; }
        public SupportedVideoStreamConfiguration SupportedVideoStreamConfiguration { get; init; }
        // Optional Characteristics
        public Active? Active { get; init; }
    }

    /// 
    /// Carbon Dioxide Sensor
    /// 
    public class CarbonDioxideSensor : Service
    {
        public CarbonDioxideSensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CarbonDioxideDetected = (CarbonDioxideDetected)GetCharacteristic("92", json)!;
            this.CarbonDioxideLevel = (CarbonDioxideLevel?)GetCharacteristic("93", json)!;
            this.CarbonDioxidePeakLevel = (CarbonDioxidePeakLevel?)GetCharacteristic("94", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public CarbonDioxideDetected CarbonDioxideDetected { get; init; }
        // Optional Characteristics
        public CarbonDioxideLevel? CarbonDioxideLevel { get; init; }
        public CarbonDioxidePeakLevel? CarbonDioxidePeakLevel { get; init; }
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Carbon Monoxide Sensor
    /// 
    public class CarbonMonoxideSensor : Service
    {
        public CarbonMonoxideSensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CarbonMonoxideDetected = (CarbonMonoxideDetected)GetCharacteristic("69", json)!;
            this.CarbonMonoxideLevel = (CarbonMonoxideLevel?)GetCharacteristic("90", json)!;
            this.CarbonMonoxidePeakLevel = (CarbonMonoxidePeakLevel?)GetCharacteristic("91", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public CarbonMonoxideDetected CarbonMonoxideDetected { get; init; }
        // Optional Characteristics
        public CarbonMonoxideLevel? CarbonMonoxideLevel { get; init; }
        public CarbonMonoxidePeakLevel? CarbonMonoxidePeakLevel { get; init; }
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Cloud Relay
    /// 
    public class CloudRelay : Service
    {
        public CloudRelay(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.RelayControlPoint = (RelayControlPoint)GetCharacteristic("5E", json)!;
            this.RelayState = (RelayState)GetCharacteristic("5C", json)!;
            this.RelayEnabled = (RelayEnabled)GetCharacteristic("5B", json)!;
        }

        // Required Characteristics
        public RelayControlPoint RelayControlPoint { get; init; }
        public RelayState RelayState { get; init; }
        public RelayEnabled RelayEnabled { get; init; }
    }

    /// 
    /// Contact Sensor
    /// 
    public class ContactSensor : Service
    {
        public ContactSensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.ContactSensorState = (ContactSensorState)GetCharacteristic("6A", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public ContactSensorState ContactSensorState { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Data Stream Transport Management
    /// 
    public class DataStreamTransportManagement : Service
    {
        public DataStreamTransportManagement(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.SetupDataStreamTransport = (SetupDataStreamTransport)GetCharacteristic("131", json)!;
            this.SupportedDataStreamTransportConfiguration = (SupportedDataStreamTransportConfiguration)GetCharacteristic("130", json)!;
            this.Version = (Version)GetCharacteristic("37", json)!;
        }

        // Required Characteristics
        public SetupDataStreamTransport SetupDataStreamTransport { get; init; }
        public SupportedDataStreamTransportConfiguration SupportedDataStreamTransportConfiguration { get; init; }
        public Version Version { get; init; }
    }

    /// 
    /// Diagnostics
    /// 
    public class Diagnostics : Service
    {
        public Diagnostics(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.SupportedDiagnosticsSnapshot = (SupportedDiagnosticsSnapshot)GetCharacteristic("238", json)!;
            this.SelectedDiagnosticsModes = (SelectedDiagnosticsModes?)GetCharacteristic("24D", json)!;
            this.SupportedDiagnosticsModes = (SupportedDiagnosticsModes?)GetCharacteristic("24C", json)!;
        }

        // Required Characteristics
        public SupportedDiagnosticsSnapshot SupportedDiagnosticsSnapshot { get; init; }
        // Optional Characteristics
        public SelectedDiagnosticsModes? SelectedDiagnosticsModes { get; init; }
        public SupportedDiagnosticsModes? SupportedDiagnosticsModes { get; init; }
    }

    /// 
    /// Door
    /// 
    public class Door : Service
    {
        public Door(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentPosition = (CurrentPosition)GetCharacteristic("6D", json)!;
            this.PositionState = (PositionState)GetCharacteristic("72", json)!;
            this.TargetPosition = (TargetPosition)GetCharacteristic("7C", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.ObstructionDetected = (ObstructionDetected?)GetCharacteristic("24", json)!;
            this.HoldPosition = (HoldPosition?)GetCharacteristic("6F", json)!;
        }

        // Required Characteristics
        public CurrentPosition CurrentPosition { get; init; }
        public PositionState PositionState { get; init; }
        public TargetPosition TargetPosition { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public ObstructionDetected? ObstructionDetected { get; init; }
        public HoldPosition? HoldPosition { get; init; }
    }

    /// 
    /// Doorbell
    /// 
    public class Doorbell : Service
    {
        public Doorbell(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.ProgrammableSwitchEvent = (ProgrammableSwitchEvent)GetCharacteristic("73", json)!;
            this.Brightness = (Brightness?)GetCharacteristic("8", json)!;
            this.Mute = (Mute?)GetCharacteristic("11A", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.OperatingStateResponse = (OperatingStateResponse?)GetCharacteristic("232", json)!;
            this.Volume = (Volume?)GetCharacteristic("119", json)!;
        }

        // Required Characteristics
        public ProgrammableSwitchEvent ProgrammableSwitchEvent { get; init; }
        // Optional Characteristics
        public Brightness? Brightness { get; init; }
        public Mute? Mute { get; init; }
        public Name? Name { get; init; }
        public OperatingStateResponse? OperatingStateResponse { get; init; }
        public Volume? Volume { get; init; }
    }

    /// 
    /// Fan
    /// 
    public class Fan : Service
    {
        public Fan(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.On = (On)GetCharacteristic("25", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.RotationDirection = (RotationDirection?)GetCharacteristic("28", json)!;
            this.RotationSpeed = (RotationSpeed?)GetCharacteristic("29", json)!;
        }

        // Required Characteristics
        public On On { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public RotationDirection? RotationDirection { get; init; }
        public RotationSpeed? RotationSpeed { get; init; }
    }

    /// 
    /// Fanv2
    /// 
    public class Fanv2 : Service
    {
        public Fanv2(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.CurrentFanState = (CurrentFanState?)GetCharacteristic("AF", json)!;
            this.TargetFanState = (TargetFanState?)GetCharacteristic("BF", json)!;
            this.LockPhysicalControls = (LockPhysicalControls?)GetCharacteristic("A7", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.RotationDirection = (RotationDirection?)GetCharacteristic("28", json)!;
            this.RotationSpeed = (RotationSpeed?)GetCharacteristic("29", json)!;
            this.SwingMode = (SwingMode?)GetCharacteristic("B6", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        // Optional Characteristics
        public CurrentFanState? CurrentFanState { get; init; }
        public TargetFanState? TargetFanState { get; init; }
        public LockPhysicalControls? LockPhysicalControls { get; init; }
        public Name? Name { get; init; }
        public RotationDirection? RotationDirection { get; init; }
        public RotationSpeed? RotationSpeed { get; init; }
        public SwingMode? SwingMode { get; init; }
    }

    /// 
    /// Faucet
    /// 
    public class Faucet : Service
    {
        public Faucet(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public StatusFault? StatusFault { get; init; }
    }

    /// 
    /// Filter Maintenance
    /// 
    public class FilterMaintenance : Service
    {
        public FilterMaintenance(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.FilterChangeIndication = (FilterChangeIndication)GetCharacteristic("AC", json)!;
            this.FilterLifeLevel = (FilterLifeLevel?)GetCharacteristic("AB", json)!;
            this.ResetFilterIndication = (ResetFilterIndication?)GetCharacteristic("AD", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
        }

        // Required Characteristics
        public FilterChangeIndication FilterChangeIndication { get; init; }
        // Optional Characteristics
        public FilterLifeLevel? FilterLifeLevel { get; init; }
        public ResetFilterIndication? ResetFilterIndication { get; init; }
        public Name? Name { get; init; }
    }

    /// 
    /// Firmware Update
    /// 
    public class FirmwareUpdate : Service
    {
        public FirmwareUpdate(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.FirmwareUpdateReadiness = (FirmwareUpdateReadiness)GetCharacteristic("234", json)!;
            this.FirmwareUpdateStatus = (FirmwareUpdateStatus)GetCharacteristic("235", json)!;
            this.StagedFirmwareVersion = (StagedFirmwareVersion?)GetCharacteristic("249", json)!;
            this.SupportedFirmwareUpdateConfiguration = (SupportedFirmwareUpdateConfiguration?)GetCharacteristic("233", json)!;
        }

        // Required Characteristics
        public FirmwareUpdateReadiness FirmwareUpdateReadiness { get; init; }
        public FirmwareUpdateStatus FirmwareUpdateStatus { get; init; }
        // Optional Characteristics
        public StagedFirmwareVersion? StagedFirmwareVersion { get; init; }
        public SupportedFirmwareUpdateConfiguration? SupportedFirmwareUpdateConfiguration { get; init; }
    }

    /// 
    /// Garage Door Opener
    /// 
    public class GarageDoorOpener : Service
    {
        public GarageDoorOpener(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentDoorState = (CurrentDoorState)GetCharacteristic("E", json)!;
            this.TargetDoorState = (TargetDoorState)GetCharacteristic("32", json)!;
            this.ObstructionDetected = (ObstructionDetected)GetCharacteristic("24", json)!;
            this.LockCurrentState = (LockCurrentState?)GetCharacteristic("1D", json)!;
            this.LockTargetState = (LockTargetState?)GetCharacteristic("1E", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
        }

        // Required Characteristics
        public CurrentDoorState CurrentDoorState { get; init; }
        public TargetDoorState TargetDoorState { get; init; }
        public ObstructionDetected ObstructionDetected { get; init; }
        // Optional Characteristics
        public LockCurrentState? LockCurrentState { get; init; }
        public LockTargetState? LockTargetState { get; init; }
        public Name? Name { get; init; }
    }

    /// 
    /// Heater-Cooler
    /// 
    public class HeaterCooler : Service
    {
        public HeaterCooler(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.CurrentHeaterCoolerState = (CurrentHeaterCoolerState)GetCharacteristic("B1", json)!;
            this.TargetHeaterCoolerState = (TargetHeaterCoolerState)GetCharacteristic("B2", json)!;
            this.CurrentTemperature = (CurrentTemperature)GetCharacteristic("11", json)!;
            this.LockPhysicalControls = (LockPhysicalControls?)GetCharacteristic("A7", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.RotationSpeed = (RotationSpeed?)GetCharacteristic("29", json)!;
            this.SwingMode = (SwingMode?)GetCharacteristic("B6", json)!;
            this.CoolingThresholdTemperature = (CoolingThresholdTemperature?)GetCharacteristic("D", json)!;
            this.HeatingThresholdTemperature = (HeatingThresholdTemperature?)GetCharacteristic("12", json)!;
            this.TemperatureDisplayUnits = (TemperatureDisplayUnits?)GetCharacteristic("36", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public CurrentHeaterCoolerState CurrentHeaterCoolerState { get; init; }
        public TargetHeaterCoolerState TargetHeaterCoolerState { get; init; }
        public CurrentTemperature CurrentTemperature { get; init; }
        // Optional Characteristics
        public LockPhysicalControls? LockPhysicalControls { get; init; }
        public Name? Name { get; init; }
        public RotationSpeed? RotationSpeed { get; init; }
        public SwingMode? SwingMode { get; init; }
        public CoolingThresholdTemperature? CoolingThresholdTemperature { get; init; }
        public HeatingThresholdTemperature? HeatingThresholdTemperature { get; init; }
        public TemperatureDisplayUnits? TemperatureDisplayUnits { get; init; }
    }

    /// 
    /// Humidifier-Dehumidifier
    /// 
    public class HumidifierDehumidifier : Service
    {
        public HumidifierDehumidifier(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.CurrentHumidifierDehumidifierState = (CurrentHumidifierDehumidifierState)GetCharacteristic("B3", json)!;
            this.TargetHumidifierDehumidifierState = (TargetHumidifierDehumidifierState)GetCharacteristic("B4", json)!;
            this.CurrentRelativeHumidity = (CurrentRelativeHumidity)GetCharacteristic("10", json)!;
            this.LockPhysicalControls = (LockPhysicalControls?)GetCharacteristic("A7", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.RelativeHumidityDehumidifierThreshold = (RelativeHumidityDehumidifierThreshold?)GetCharacteristic("C9", json)!;
            this.RelativeHumidityHumidifierThreshold = (RelativeHumidityHumidifierThreshold?)GetCharacteristic("CA", json)!;
            this.RotationSpeed = (RotationSpeed?)GetCharacteristic("29", json)!;
            this.SwingMode = (SwingMode?)GetCharacteristic("B6", json)!;
            this.WaterLevel = (WaterLevel?)GetCharacteristic("B5", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public CurrentHumidifierDehumidifierState CurrentHumidifierDehumidifierState { get; init; }
        public TargetHumidifierDehumidifierState TargetHumidifierDehumidifierState { get; init; }
        public CurrentRelativeHumidity CurrentRelativeHumidity { get; init; }
        // Optional Characteristics
        public LockPhysicalControls? LockPhysicalControls { get; init; }
        public Name? Name { get; init; }
        public RelativeHumidityDehumidifierThreshold? RelativeHumidityDehumidifierThreshold { get; init; }
        public RelativeHumidityHumidifierThreshold? RelativeHumidityHumidifierThreshold { get; init; }
        public RotationSpeed? RotationSpeed { get; init; }
        public SwingMode? SwingMode { get; init; }
        public WaterLevel? WaterLevel { get; init; }
    }

    /// 
    /// Humidity Sensor
    /// 
    public class HumiditySensor : Service
    {
        public HumiditySensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentRelativeHumidity = (CurrentRelativeHumidity)GetCharacteristic("10", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public CurrentRelativeHumidity CurrentRelativeHumidity { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Input Source
    /// 
    public class InputSource : Service
    {
        public InputSource(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.ConfiguredName = (ConfiguredName)GetCharacteristic("E3", json)!;
            this.InputSourceType = (InputSourceType)GetCharacteristic("DB", json)!;
            this.IsConfigured = (IsConfigured)GetCharacteristic("D6", json)!;
            this.Name = (Name)GetCharacteristic("23", json)!;
            this.CurrentVisibilityState = (CurrentVisibilityState)GetCharacteristic("135", json)!;
            this.Identifier = (Identifier?)GetCharacteristic("E6", json)!;
            this.InputDeviceType = (InputDeviceType?)GetCharacteristic("DC", json)!;
            this.TargetVisibilityState = (TargetVisibilityState?)GetCharacteristic("134", json)!;
        }

        // Required Characteristics
        public ConfiguredName ConfiguredName { get; init; }
        public InputSourceType InputSourceType { get; init; }
        public IsConfigured IsConfigured { get; init; }
        public Name Name { get; init; }
        public CurrentVisibilityState CurrentVisibilityState { get; init; }
        // Optional Characteristics
        public Identifier? Identifier { get; init; }
        public InputDeviceType? InputDeviceType { get; init; }
        public TargetVisibilityState? TargetVisibilityState { get; init; }
    }

    /// 
    /// Irrigation-System
    /// 
    public class IrrigationSystem : Service
    {
        public IrrigationSystem(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.ProgramMode = (ProgramMode)GetCharacteristic("D1", json)!;
            this.InUse = (InUse)GetCharacteristic("D2", json)!;
            this.RemainingDuration = (RemainingDuration?)GetCharacteristic("D4", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public ProgramMode ProgramMode { get; init; }
        public InUse InUse { get; init; }
        // Optional Characteristics
        public RemainingDuration? RemainingDuration { get; init; }
        public Name? Name { get; init; }
        public StatusFault? StatusFault { get; init; }
    }

    /// 
    /// Leak Sensor
    /// 
    public class LeakSensor : Service
    {
        public LeakSensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.LeakDetected = (LeakDetected)GetCharacteristic("70", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public LeakDetected LeakDetected { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Lightbulb
    /// 
    public class Lightbulb : Service
    {
        public Lightbulb(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.On = (On)GetCharacteristic("25", json)!;
            this.Brightness = (Brightness?)GetCharacteristic("8", json)!;
            this.CharacteristicValueActiveTransitionCount = (CharacteristicValueActiveTransitionCount?)GetCharacteristic("24B", json)!;
            this.CharacteristicValueTransitionControl = (CharacteristicValueTransitionControl?)GetCharacteristic("143", json)!;
            this.ColorTemperature = (ColorTemperature?)GetCharacteristic("CE", json)!;
            this.Hue = (Hue?)GetCharacteristic("13", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.Saturation = (Saturation?)GetCharacteristic("2F", json)!;
            this.SupportedCharacteristicValueTransitionConfiguration = (SupportedCharacteristicValueTransitionConfiguration?)GetCharacteristic("144", json)!;
        }

        // Required Characteristics
        public On On { get; init; }
        // Optional Characteristics
        public Brightness? Brightness { get; init; }
        public CharacteristicValueActiveTransitionCount? CharacteristicValueActiveTransitionCount { get; init; }
        public CharacteristicValueTransitionControl? CharacteristicValueTransitionControl { get; init; }
        public ColorTemperature? ColorTemperature { get; init; }
        public Hue? Hue { get; init; }
        public Name? Name { get; init; }
        public Saturation? Saturation { get; init; }
        public SupportedCharacteristicValueTransitionConfiguration? SupportedCharacteristicValueTransitionConfiguration { get; init; }
    }

    /// 
    /// Light Sensor
    /// 
    public class LightSensor : Service
    {
        public LightSensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentAmbientLightLevel = (CurrentAmbientLightLevel)GetCharacteristic("6B", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public CurrentAmbientLightLevel CurrentAmbientLightLevel { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Lock Management
    /// 
    public class LockManagement : Service
    {
        public LockManagement(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.LockControlPoint = (LockControlPoint)GetCharacteristic("19", json)!;
            this.Version = (Version)GetCharacteristic("37", json)!;
            this.AdministratorOnlyAccess = (AdministratorOnlyAccess?)GetCharacteristic("1", json)!;
            this.AudioFeedback = (AudioFeedback?)GetCharacteristic("5", json)!;
            this.CurrentDoorState = (CurrentDoorState?)GetCharacteristic("E", json)!;
            this.LockManagementAutoSecurityTimeout = (LockManagementAutoSecurityTimeout?)GetCharacteristic("1A", json)!;
            this.LockLastKnownAction = (LockLastKnownAction?)GetCharacteristic("1C", json)!;
            this.Logs = (Logs?)GetCharacteristic("1F", json)!;
            this.MotionDetected = (MotionDetected?)GetCharacteristic("22", json)!;
        }

        // Required Characteristics
        public LockControlPoint LockControlPoint { get; init; }
        public Version Version { get; init; }
        // Optional Characteristics
        public AdministratorOnlyAccess? AdministratorOnlyAccess { get; init; }
        public AudioFeedback? AudioFeedback { get; init; }
        public CurrentDoorState? CurrentDoorState { get; init; }
        public LockManagementAutoSecurityTimeout? LockManagementAutoSecurityTimeout { get; init; }
        public LockLastKnownAction? LockLastKnownAction { get; init; }
        public Logs? Logs { get; init; }
        public MotionDetected? MotionDetected { get; init; }
    }

    /// 
    /// Lock Mechanism
    /// 
    public class LockMechanism : Service
    {
        public LockMechanism(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.LockCurrentState = (LockCurrentState)GetCharacteristic("1D", json)!;
            this.LockTargetState = (LockTargetState)GetCharacteristic("1E", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
        }

        // Required Characteristics
        public LockCurrentState LockCurrentState { get; init; }
        public LockTargetState LockTargetState { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
    }

    /// 
    /// Microphone
    /// 
    public class Microphone : Service
    {
        public Microphone(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Mute = (Mute)GetCharacteristic("11A", json)!;
            this.Volume = (Volume?)GetCharacteristic("119", json)!;
        }

        // Required Characteristics
        public Mute Mute { get; init; }
        // Optional Characteristics
        public Volume? Volume { get; init; }
    }

    /// 
    /// Motion Sensor
    /// 
    public class MotionSensor : Service
    {
        public MotionSensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.MotionDetected = (MotionDetected)GetCharacteristic("22", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public MotionDetected MotionDetected { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// NFC Access
    /// 
    public class NFCAccess : Service
    {
        public NFCAccess(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.ConfigurationState = (ConfigurationState)GetCharacteristic("263", json)!;
            this.NFCAccessControlPoint = (NFCAccessControlPoint)GetCharacteristic("264", json)!;
            this.NFCAccessSupportedConfiguration = (NFCAccessSupportedConfiguration)GetCharacteristic("265", json)!;
        }

        // Required Characteristics
        public ConfigurationState ConfigurationState { get; init; }
        public NFCAccessControlPoint NFCAccessControlPoint { get; init; }
        public NFCAccessSupportedConfiguration NFCAccessSupportedConfiguration { get; init; }
    }

    /// 
    /// Occupancy Sensor
    /// 
    public class OccupancySensor : Service
    {
        public OccupancySensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.OccupancyDetected = (OccupancyDetected)GetCharacteristic("71", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public OccupancyDetected OccupancyDetected { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Outlet
    /// 
    public class Outlet : Service
    {
        public Outlet(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.On = (On)GetCharacteristic("25", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.OutletInUse = (OutletInUse?)GetCharacteristic("26", json)!;
        }

        // Required Characteristics
        public On On { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public OutletInUse? OutletInUse { get; init; }
    }

    /// 
    /// Pairing
    /// 
    public class Pairing : Service
    {
        public Pairing(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.ListPairings = (ListPairings)GetCharacteristic("50", json)!;
            this.PairSetup = (PairSetup)GetCharacteristic("4C", json)!;
            this.PairVerify = (PairVerify)GetCharacteristic("4E", json)!;
            this.PairingFeatures = (PairingFeatures)GetCharacteristic("4F", json)!;
        }

        // Required Characteristics
        public ListPairings ListPairings { get; init; }
        public PairSetup PairSetup { get; init; }
        public PairVerify PairVerify { get; init; }
        public PairingFeatures PairingFeatures { get; init; }
    }

    /// 
    /// Power Management
    /// 
    public class PowerManagement : Service
    {
        public PowerManagement(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.WakeConfiguration = (WakeConfiguration)GetCharacteristic("222", json)!;
            this.SelectedSleepConfiguration = (SelectedSleepConfiguration?)GetCharacteristic("252", json)!;
            this.SupportedSleepConfiguration = (SupportedSleepConfiguration?)GetCharacteristic("251", json)!;
        }

        // Required Characteristics
        public WakeConfiguration WakeConfiguration { get; init; }
        // Optional Characteristics
        public SelectedSleepConfiguration? SelectedSleepConfiguration { get; init; }
        public SupportedSleepConfiguration? SupportedSleepConfiguration { get; init; }
    }

    /// 
    /// Protocol Information
    /// 
    public class ProtocolInformation : Service
    {
        public ProtocolInformation(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Version = (Version)GetCharacteristic("37", json)!;
        }

        // Required Characteristics
        public Version Version { get; init; }
    }

    /// 
    /// Security System
    /// 
    public class SecuritySystem : Service
    {
        public SecuritySystem(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.SecuritySystemCurrentState = (SecuritySystemCurrentState)GetCharacteristic("66", json)!;
            this.SecuritySystemTargetState = (SecuritySystemTargetState)GetCharacteristic("67", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.SecuritySystemAlarmType = (SecuritySystemAlarmType?)GetCharacteristic("8E", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public SecuritySystemCurrentState SecuritySystemCurrentState { get; init; }
        public SecuritySystemTargetState SecuritySystemTargetState { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public SecuritySystemAlarmType? SecuritySystemAlarmType { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Service Label
    /// 
    public class ServiceLabel : Service
    {
        public ServiceLabel(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.ServiceLabelNamespace = (ServiceLabelNamespace)GetCharacteristic("CD", json)!;
        }

        // Required Characteristics
        public ServiceLabelNamespace ServiceLabelNamespace { get; init; }
    }

    /// 
    /// Siri
    /// 
    public class Siri : Service
    {
        public Siri(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.SiriInputType = (SiriInputType)GetCharacteristic("132", json)!;
            this.MultifunctionButton = (MultifunctionButton?)GetCharacteristic("26B", json)!;
            this.SiriEnable = (SiriEnable?)GetCharacteristic("255", json)!;
            this.SiriEngineVersion = (SiriEngineVersion?)GetCharacteristic("25A", json)!;
            this.SiriLightOnUse = (SiriLightOnUse?)GetCharacteristic("258", json)!;
            this.SiriListening = (SiriListening?)GetCharacteristic("256", json)!;
            this.SiriTouchToUse = (SiriTouchToUse?)GetCharacteristic("257", json)!;
        }

        // Required Characteristics
        public SiriInputType SiriInputType { get; init; }
        // Optional Characteristics
        public MultifunctionButton? MultifunctionButton { get; init; }
        public SiriEnable? SiriEnable { get; init; }
        public SiriEngineVersion? SiriEngineVersion { get; init; }
        public SiriLightOnUse? SiriLightOnUse { get; init; }
        public SiriListening? SiriListening { get; init; }
        public SiriTouchToUse? SiriTouchToUse { get; init; }
    }

    /// 
    /// Siri Endpoint
    /// 
    public class SiriEndpoint : Service
    {
        public SiriEndpoint(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.SiriEndpointSessionStatus = (SiriEndpointSessionStatus)GetCharacteristic("254", json)!;
            this.Version = (Version)GetCharacteristic("37", json)!;
            this.ActiveIdentifier = (ActiveIdentifier?)GetCharacteristic("E7", json)!;
            this.ManuallyDisabled = (ManuallyDisabled?)GetCharacteristic("227", json)!;
        }

        // Required Characteristics
        public SiriEndpointSessionStatus SiriEndpointSessionStatus { get; init; }
        public Version Version { get; init; }
        // Optional Characteristics
        public ActiveIdentifier? ActiveIdentifier { get; init; }
        public ManuallyDisabled? ManuallyDisabled { get; init; }
    }

    /// 
    /// Slats
    /// 
    public class Slats : Service
    {
        public Slats(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentSlatState = (CurrentSlatState)GetCharacteristic("AA", json)!;
            this.SlatType = (SlatType)GetCharacteristic("C0", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.SwingMode = (SwingMode?)GetCharacteristic("B6", json)!;
            this.CurrentTiltAngle = (CurrentTiltAngle?)GetCharacteristic("C1", json)!;
            this.TargetTiltAngle = (TargetTiltAngle?)GetCharacteristic("C2", json)!;
        }

        // Required Characteristics
        public CurrentSlatState CurrentSlatState { get; init; }
        public SlatType SlatType { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public SwingMode? SwingMode { get; init; }
        public CurrentTiltAngle? CurrentTiltAngle { get; init; }
        public TargetTiltAngle? TargetTiltAngle { get; init; }
    }

    /// 
    /// Smart Speaker
    /// 
    public class SmartSpeaker : Service
    {
        public SmartSpeaker(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentMediaState = (CurrentMediaState)GetCharacteristic("E0", json)!;
            this.TargetMediaState = (TargetMediaState)GetCharacteristic("137", json)!;
            this.AirPlayEnable = (AirPlayEnable?)GetCharacteristic("25B", json)!;
            this.ConfiguredName = (ConfiguredName?)GetCharacteristic("E3", json)!;
            this.Mute = (Mute?)GetCharacteristic("11A", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.Volume = (Volume?)GetCharacteristic("119", json)!;
        }

        // Required Characteristics
        public CurrentMediaState CurrentMediaState { get; init; }
        public TargetMediaState TargetMediaState { get; init; }
        // Optional Characteristics
        public AirPlayEnable? AirPlayEnable { get; init; }
        public ConfiguredName? ConfiguredName { get; init; }
        public Mute? Mute { get; init; }
        public Name? Name { get; init; }
        public Volume? Volume { get; init; }
    }

    /// 
    /// Smoke Sensor
    /// 
    public class SmokeSensor : Service
    {
        public SmokeSensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.SmokeDetected = (SmokeDetected)GetCharacteristic("76", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public SmokeDetected SmokeDetected { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Speaker
    /// 
    public class Speaker : Service
    {
        public Speaker(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Mute = (Mute)GetCharacteristic("11A", json)!;
            this.Active = (Active?)GetCharacteristic("B0", json)!;
            this.Volume = (Volume?)GetCharacteristic("119", json)!;
        }

        // Required Characteristics
        public Mute Mute { get; init; }
        // Optional Characteristics
        public Active? Active { get; init; }
        public Volume? Volume { get; init; }
    }

    /// 
    /// Stateful Programmable Switch
    /// 
    public class StatefulProgrammableSwitch : Service
    {
        public StatefulProgrammableSwitch(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.ProgrammableSwitchEvent = (ProgrammableSwitchEvent)GetCharacteristic("73", json)!;
            this.ProgrammableSwitchOutputState = (ProgrammableSwitchOutputState)GetCharacteristic("74", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
        }

        // Required Characteristics
        public ProgrammableSwitchEvent ProgrammableSwitchEvent { get; init; }
        public ProgrammableSwitchOutputState ProgrammableSwitchOutputState { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
    }

    /// 
    /// Stateless Programmable Switch
    /// 
    public class StatelessProgrammableSwitch : Service
    {
        public StatelessProgrammableSwitch(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.ProgrammableSwitchEvent = (ProgrammableSwitchEvent)GetCharacteristic("73", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.ServiceLabelIndex = (ServiceLabelIndex?)GetCharacteristic("CB", json)!;
        }

        // Required Characteristics
        public ProgrammableSwitchEvent ProgrammableSwitchEvent { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public ServiceLabelIndex? ServiceLabelIndex { get; init; }
    }

    /// 
    /// Switch
    /// 
    public class Switch : Service
    {
        public Switch(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.On = (On)GetCharacteristic("25", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
        }

        // Required Characteristics
        public On On { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
    }

    /// 
    /// Tap Management
    /// 
    public class TapManagement : Service
    {
        public TapManagement(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.CryptoHash = (CryptoHash)GetCharacteristic("250", json)!;
            this.TapType = (TapType)GetCharacteristic("22F", json)!;
            this.Token = (Token)GetCharacteristic("231", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public CryptoHash CryptoHash { get; init; }
        public TapType TapType { get; init; }
        public Token Token { get; init; }
    }

    /// 
    /// Target Control
    /// 
    public class TargetControl : Service
    {
        public TargetControl(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.ActiveIdentifier = (ActiveIdentifier)GetCharacteristic("E7", json)!;
            this.ButtonEvent = (ButtonEvent)GetCharacteristic("126", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public ActiveIdentifier ActiveIdentifier { get; init; }
        public ButtonEvent ButtonEvent { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
    }

    /// 
    /// Target Control Management
    /// 
    public class TargetControlManagement : Service
    {
        public TargetControlManagement(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.TargetControlSupportedConfiguration = (TargetControlSupportedConfiguration)GetCharacteristic("123", json)!;
            this.TargetControlList = (TargetControlList)GetCharacteristic("124", json)!;
        }

        // Required Characteristics
        public TargetControlSupportedConfiguration TargetControlSupportedConfiguration { get; init; }
        public TargetControlList TargetControlList { get; init; }
    }

    /// 
    /// Television
    /// 
    public class Television : Service
    {
        public Television(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.ActiveIdentifier = (ActiveIdentifier)GetCharacteristic("E7", json)!;
            this.ConfiguredName = (ConfiguredName)GetCharacteristic("E3", json)!;
            this.RemoteKey = (RemoteKey)GetCharacteristic("E1", json)!;
            this.SleepDiscoveryMode = (SleepDiscoveryMode)GetCharacteristic("E8", json)!;
            this.Brightness = (Brightness?)GetCharacteristic("8", json)!;
            this.ClosedCaptions = (ClosedCaptions?)GetCharacteristic("DD", json)!;
            this.DisplayOrder = (DisplayOrder?)GetCharacteristic("136", json)!;
            this.CurrentMediaState = (CurrentMediaState?)GetCharacteristic("E0", json)!;
            this.TargetMediaState = (TargetMediaState?)GetCharacteristic("137", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.PictureMode = (PictureMode?)GetCharacteristic("E2", json)!;
            this.PowerModeSelection = (PowerModeSelection?)GetCharacteristic("DF", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public ActiveIdentifier ActiveIdentifier { get; init; }
        public ConfiguredName ConfiguredName { get; init; }
        public RemoteKey RemoteKey { get; init; }
        public SleepDiscoveryMode SleepDiscoveryMode { get; init; }
        // Optional Characteristics
        public Brightness? Brightness { get; init; }
        public ClosedCaptions? ClosedCaptions { get; init; }
        public DisplayOrder? DisplayOrder { get; init; }
        public CurrentMediaState? CurrentMediaState { get; init; }
        public TargetMediaState? TargetMediaState { get; init; }
        public Name? Name { get; init; }
        public PictureMode? PictureMode { get; init; }
        public PowerModeSelection? PowerModeSelection { get; init; }
    }

    /// 
    /// Television Speaker
    /// 
    public class TelevisionSpeaker : Service
    {
        public TelevisionSpeaker(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Mute = (Mute)GetCharacteristic("11A", json)!;
            this.Active = (Active?)GetCharacteristic("B0", json)!;
            this.Volume = (Volume?)GetCharacteristic("119", json)!;
            this.VolumeControlType = (VolumeControlType?)GetCharacteristic("E9", json)!;
            this.VolumeSelector = (VolumeSelector?)GetCharacteristic("EA", json)!;
        }

        // Required Characteristics
        public Mute Mute { get; init; }
        // Optional Characteristics
        public Active? Active { get; init; }
        public Volume? Volume { get; init; }
        public VolumeControlType? VolumeControlType { get; init; }
        public VolumeSelector? VolumeSelector { get; init; }
    }

    /// 
    /// Temperature Sensor
    /// 
    public class TemperatureSensor : Service
    {
        public TemperatureSensor(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentTemperature = (CurrentTemperature)GetCharacteristic("11", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.StatusActive = (StatusActive?)GetCharacteristic("75", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
            this.StatusLowBattery = (StatusLowBattery?)GetCharacteristic("79", json)!;
            this.StatusTampered = (StatusTampered?)GetCharacteristic("7A", json)!;
        }

        // Required Characteristics
        public CurrentTemperature CurrentTemperature { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public StatusActive? StatusActive { get; init; }
        public StatusFault? StatusFault { get; init; }
        public StatusLowBattery? StatusLowBattery { get; init; }
        public StatusTampered? StatusTampered { get; init; }
    }

    /// 
    /// Thermostat
    /// 
    public class Thermostat : Service
    {
        public Thermostat(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentHeatingCoolingState = (CurrentHeatingCoolingState)GetCharacteristic("F", json)!;
            this.TargetHeatingCoolingState = (TargetHeatingCoolingState)GetCharacteristic("33", json)!;
            this.CurrentTemperature = (CurrentTemperature)GetCharacteristic("11", json)!;
            this.TargetTemperature = (TargetTemperature)GetCharacteristic("35", json)!;
            this.TemperatureDisplayUnits = (TemperatureDisplayUnits)GetCharacteristic("36", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.CurrentRelativeHumidity = (CurrentRelativeHumidity?)GetCharacteristic("10", json)!;
            this.TargetRelativeHumidity = (TargetRelativeHumidity?)GetCharacteristic("34", json)!;
            this.CoolingThresholdTemperature = (CoolingThresholdTemperature?)GetCharacteristic("D", json)!;
            this.HeatingThresholdTemperature = (HeatingThresholdTemperature?)GetCharacteristic("12", json)!;
        }

        // Required Characteristics
        public CurrentHeatingCoolingState CurrentHeatingCoolingState { get; init; }
        public TargetHeatingCoolingState TargetHeatingCoolingState { get; init; }
        public CurrentTemperature CurrentTemperature { get; init; }
        public TargetTemperature TargetTemperature { get; init; }
        public TemperatureDisplayUnits TemperatureDisplayUnits { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public CurrentRelativeHumidity? CurrentRelativeHumidity { get; init; }
        public TargetRelativeHumidity? TargetRelativeHumidity { get; init; }
        public CoolingThresholdTemperature? CoolingThresholdTemperature { get; init; }
        public HeatingThresholdTemperature? HeatingThresholdTemperature { get; init; }
    }

    /// 
    /// Thread Transport
    /// 
    public class ThreadTransport : Service
    {
        public ThreadTransport(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentTransport = (CurrentTransport)GetCharacteristic("22B", json)!;
            this.ThreadControlPoint = (ThreadControlPoint)GetCharacteristic("704", json)!;
            this.ThreadNodeCapabilities = (ThreadNodeCapabilities)GetCharacteristic("702", json)!;
            this.ThreadStatus = (ThreadStatus)GetCharacteristic("703", json)!;
            this.CCAEnergyDetectThreshold = (CCAEnergyDetectThreshold?)GetCharacteristic("246", json)!;
            this.CCASignalDetectThreshold = (CCASignalDetectThreshold?)GetCharacteristic("245", json)!;
            this.EventRetransmissionMaximum = (EventRetransmissionMaximum?)GetCharacteristic("23D", json)!;
            this.EventTransmissionCounters = (EventTransmissionCounters?)GetCharacteristic("23E", json)!;
            this.MACRetransmissionMaximum = (MACRetransmissionMaximum?)GetCharacteristic("247", json)!;
            this.MACTransmissionCounters = (MACTransmissionCounters?)GetCharacteristic("248", json)!;
            this.ReceiverSensitivity = (ReceiverSensitivity?)GetCharacteristic("244", json)!;
            this.ReceivedSignalStrengthIndication = (ReceivedSignalStrengthIndication?)GetCharacteristic("23F", json)!;
            this.SignalToNoiseRatio = (SignalToNoiseRatio?)GetCharacteristic("241", json)!;
            this.ThreadOpenThreadVersion = (ThreadOpenThreadVersion?)GetCharacteristic("706", json)!;
            this.TransmitPower = (TransmitPower?)GetCharacteristic("242", json)!;
            this.MaximumTransmitPower = (MaximumTransmitPower?)GetCharacteristic("243", json)!;
        }

        // Required Characteristics
        public CurrentTransport CurrentTransport { get; init; }
        public ThreadControlPoint ThreadControlPoint { get; init; }
        public ThreadNodeCapabilities ThreadNodeCapabilities { get; init; }
        public ThreadStatus ThreadStatus { get; init; }
        // Optional Characteristics
        public CCAEnergyDetectThreshold? CCAEnergyDetectThreshold { get; init; }
        public CCASignalDetectThreshold? CCASignalDetectThreshold { get; init; }
        public EventRetransmissionMaximum? EventRetransmissionMaximum { get; init; }
        public EventTransmissionCounters? EventTransmissionCounters { get; init; }
        public MACRetransmissionMaximum? MACRetransmissionMaximum { get; init; }
        public MACTransmissionCounters? MACTransmissionCounters { get; init; }
        public ReceiverSensitivity? ReceiverSensitivity { get; init; }
        public ReceivedSignalStrengthIndication? ReceivedSignalStrengthIndication { get; init; }
        public SignalToNoiseRatio? SignalToNoiseRatio { get; init; }
        public ThreadOpenThreadVersion? ThreadOpenThreadVersion { get; init; }
        public TransmitPower? TransmitPower { get; init; }
        public MaximumTransmitPower? MaximumTransmitPower { get; init; }
    }

    /// 
    /// Transfer Transport Management
    /// 
    public class TransferTransportManagement : Service
    {
        public TransferTransportManagement(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.SupportedTransferTransportConfiguration = (SupportedTransferTransportConfiguration)GetCharacteristic("202", json)!;
            this.SetupTransferTransport = (SetupTransferTransport)GetCharacteristic("201", json)!;
        }

        // Required Characteristics
        public SupportedTransferTransportConfiguration SupportedTransferTransportConfiguration { get; init; }
        public SetupTransferTransport SetupTransferTransport { get; init; }
    }

    /// 
    /// Tunnel
    /// 
    public class Tunnel : Service
    {
        public Tunnel(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.AccessoryIdentifier = (AccessoryIdentifier)GetCharacteristic("57", json)!;
            this.TunnelConnectionTimeout = (TunnelConnectionTimeout)GetCharacteristic("61", json)!;
            this.TunneledAccessoryAdvertising = (TunneledAccessoryAdvertising)GetCharacteristic("60", json)!;
            this.TunneledAccessoryConnected = (TunneledAccessoryConnected)GetCharacteristic("59", json)!;
            this.TunneledAccessoryStateNumber = (TunneledAccessoryStateNumber)GetCharacteristic("58", json)!;
        }

        // Required Characteristics
        public AccessoryIdentifier AccessoryIdentifier { get; init; }
        public TunnelConnectionTimeout TunnelConnectionTimeout { get; init; }
        public TunneledAccessoryAdvertising TunneledAccessoryAdvertising { get; init; }
        public TunneledAccessoryConnected TunneledAccessoryConnected { get; init; }
        public TunneledAccessoryStateNumber TunneledAccessoryStateNumber { get; init; }
    }

    /// 
    /// Valve
    /// 
    public class Valve : Service
    {
        public Valve(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.Active = (Active)GetCharacteristic("B0", json)!;
            this.InUse = (InUse)GetCharacteristic("D2", json)!;
            this.ValveType = (ValveType)GetCharacteristic("D5", json)!;
            this.IsConfigured = (IsConfigured?)GetCharacteristic("D6", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.RemainingDuration = (RemainingDuration?)GetCharacteristic("D4", json)!;
            this.ServiceLabelIndex = (ServiceLabelIndex?)GetCharacteristic("CB", json)!;
            this.SetDuration = (SetDuration?)GetCharacteristic("D3", json)!;
            this.StatusFault = (StatusFault?)GetCharacteristic("77", json)!;
        }

        // Required Characteristics
        public Active Active { get; init; }
        public InUse InUse { get; init; }
        public ValveType ValveType { get; init; }
        // Optional Characteristics
        public IsConfigured? IsConfigured { get; init; }
        public Name? Name { get; init; }
        public RemainingDuration? RemainingDuration { get; init; }
        public ServiceLabelIndex? ServiceLabelIndex { get; init; }
        public SetDuration? SetDuration { get; init; }
        public StatusFault? StatusFault { get; init; }
    }

    /// 
    /// Wi-Fi Router
    /// 
    public class WiFiRouter : Service
    {
        public WiFiRouter(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.ConfiguredName = (ConfiguredName)GetCharacteristic("E3", json)!;
            this.ManagedNetworkEnable = (ManagedNetworkEnable)GetCharacteristic("215", json)!;
            this.NetworkAccessViolationControl = (NetworkAccessViolationControl)GetCharacteristic("21F", json)!;
            this.NetworkClientProfileControl = (NetworkClientProfileControl)GetCharacteristic("20C", json)!;
            this.NetworkClientStatusControl = (NetworkClientStatusControl)GetCharacteristic("20D", json)!;
            this.RouterStatus = (RouterStatus)GetCharacteristic("20E", json)!;
            this.SupportedRouterConfiguration = (SupportedRouterConfiguration)GetCharacteristic("210", json)!;
            this.WANConfigurationList = (WANConfigurationList)GetCharacteristic("211", json)!;
            this.WANStatusList = (WANStatusList)GetCharacteristic("212", json)!;
        }

        // Required Characteristics
        public ConfiguredName ConfiguredName { get; init; }
        public ManagedNetworkEnable ManagedNetworkEnable { get; init; }
        public NetworkAccessViolationControl NetworkAccessViolationControl { get; init; }
        public NetworkClientProfileControl NetworkClientProfileControl { get; init; }
        public NetworkClientStatusControl NetworkClientStatusControl { get; init; }
        public RouterStatus RouterStatus { get; init; }
        public SupportedRouterConfiguration SupportedRouterConfiguration { get; init; }
        public WANConfigurationList WANConfigurationList { get; init; }
        public WANStatusList WANStatusList { get; init; }
    }

    /// 
    /// Wi-Fi Satellite
    /// 
    public class WiFiSatellite : Service
    {
        public WiFiSatellite(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.WiFiSatelliteStatus = (WiFiSatelliteStatus)GetCharacteristic("21E", json)!;
        }

        // Required Characteristics
        public WiFiSatelliteStatus WiFiSatelliteStatus { get; init; }
    }

    /// 
    /// Wi-Fi Transport
    /// 
    public class WiFiTransport : Service
    {
        public WiFiTransport(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentTransport = (CurrentTransport)GetCharacteristic("22B", json)!;
            this.WiFiCapabilities = (WiFiCapabilities)GetCharacteristic("22C", json)!;
            this.WiFiConfigurationControl = (WiFiConfigurationControl?)GetCharacteristic("22D", json)!;
        }

        // Required Characteristics
        public CurrentTransport CurrentTransport { get; init; }
        public WiFiCapabilities WiFiCapabilities { get; init; }
        // Optional Characteristics
        public WiFiConfigurationControl? WiFiConfigurationControl { get; init; }
    }

    /// 
    /// Window
    /// 
    public class Window : Service
    {
        public Window(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentPosition = (CurrentPosition)GetCharacteristic("6D", json)!;
            this.PositionState = (PositionState)GetCharacteristic("72", json)!;
            this.TargetPosition = (TargetPosition)GetCharacteristic("7C", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.ObstructionDetected = (ObstructionDetected?)GetCharacteristic("24", json)!;
            this.HoldPosition = (HoldPosition?)GetCharacteristic("6F", json)!;
        }

        // Required Characteristics
        public CurrentPosition CurrentPosition { get; init; }
        public PositionState PositionState { get; init; }
        public TargetPosition TargetPosition { get; init; }
        // Optional Characteristics
        public Name? Name { get; init; }
        public ObstructionDetected? ObstructionDetected { get; init; }
        public HoldPosition? HoldPosition { get; init; }
    }

    /// 
    /// Window Covering
    /// 
    public class WindowCovering : Service
    {
        public WindowCovering(Accessory accessory, ServiceJSON json) : base(accessory, json)
        {
            this.CurrentPosition = (CurrentPosition)GetCharacteristic("6D", json)!;
            this.PositionState = (PositionState)GetCharacteristic("72", json)!;
            this.TargetPosition = (TargetPosition)GetCharacteristic("7C", json)!;
            this.CurrentHorizontalTiltAngle = (CurrentHorizontalTiltAngle?)GetCharacteristic("6C", json)!;
            this.TargetHorizontalTiltAngle = (TargetHorizontalTiltAngle?)GetCharacteristic("7B", json)!;
            this.Name = (Name?)GetCharacteristic("23", json)!;
            this.ObstructionDetected = (ObstructionDetected?)GetCharacteristic("24", json)!;
            this.HoldPosition = (HoldPosition?)GetCharacteristic("6F", json)!;
            this.CurrentVerticalTiltAngle = (CurrentVerticalTiltAngle?)GetCharacteristic("6E", json)!;
            this.TargetVerticalTiltAngle = (TargetVerticalTiltAngle?)GetCharacteristic("7D", json)!;
        }

        // Required Characteristics
        public CurrentPosition CurrentPosition { get; init; }
        public PositionState PositionState { get; init; }
        public TargetPosition TargetPosition { get; init; }
        // Optional Characteristics
        public CurrentHorizontalTiltAngle? CurrentHorizontalTiltAngle { get; init; }
        public TargetHorizontalTiltAngle? TargetHorizontalTiltAngle { get; init; }
        public Name? Name { get; init; }
        public ObstructionDetected? ObstructionDetected { get; init; }
        public HoldPosition? HoldPosition { get; init; }
        public CurrentVerticalTiltAngle? CurrentVerticalTiltAngle { get; init; }
        public TargetVerticalTiltAngle? TargetVerticalTiltAngle { get; init; }
    }

}