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
    // 
    // Access Code Control Point
    // 
    public class AccessCodeControlPoint(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Access Code Supported Configuration
    // 
    public class AccessCodeSupportedConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Access Control Level
    // 
    public class AccessControlLevel(Service service, CharacteristicJSON json) : Characteristic<ushort>(service, json), IService
    {
        public async Task<ushort?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(ushort value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Accessory Flags
    // 
    public class AccessoryFlags(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public const uint REQUIRES_ADDITIONAL_SETUP_BIT_MASK = 1;

        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Accessory Identifier
    // 
    public class AccessoryIdentifier(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    public enum ActiveType : byte { INACTIVE = 0, ACTIVE = 1, }
    // 
    // Active
    // 
    public class Active(Service service, CharacteristicJSON json) : Characteristic<ActiveType>(service, json), IService
    {
        public async Task<ActiveType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(ActiveType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Active Identifier
    // 
    public class ActiveIdentifier(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(uint value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Activity Interval
    // 
    public class ActivityInterval(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Administrator Only Access
    // 
    public class AdministratorOnlyAccess(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Air Particulate Density
    // 
    public class AirParticulateDensity(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum AirParticulateSizeType : byte { _2_5_M = 0, _10_M = 1, }
    // 
    // Air Particulate Size
    // 
    public class AirParticulateSize(Service service, CharacteristicJSON json) : Characteristic<AirParticulateSizeType>(service, json), IService
    {
        public async Task<AirParticulateSizeType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // AirPlay Enable
    // 
    public class AirPlayEnable(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum AirQualityType : byte { UNKNOWN = 0, EXCELLENT = 1, GOOD = 2, FAIR = 3, INFERIOR = 4, POOR = 5, }
    // 
    // Air Quality
    // 
    public class AirQuality(Service service, CharacteristicJSON json) : Characteristic<AirQualityType>(service, json), IService
    {
        public async Task<AirQualityType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // App Matching Identifier
    // 
    public class AppMatchingIdentifier(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Asset Update Readiness
    // 
    public class AssetUpdateReadiness(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Audio Feedback
    // 
    public class AudioFeedback(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Battery Level
    // 
    public class BatteryLevel(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Brightness
    // 
    public class Brightness(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(int value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Button Event
    // 
    public class ButtonEvent(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Camera Operating Mode Indicator
    // 
    public class CameraOperatingModeIndicator(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CarbonDioxideDetectedType : byte { CO2_LEVELS_NORMAL = 0, CO2_LEVELS_ABNORMAL = 1, }
    // 
    // Carbon Dioxide Detected
    // 
    public class CarbonDioxideDetected(Service service, CharacteristicJSON json) : Characteristic<CarbonDioxideDetectedType>(service, json), IService
    {
        public async Task<CarbonDioxideDetectedType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Carbon Dioxide Level
    // 
    public class CarbonDioxideLevel(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Carbon Dioxide Peak Level
    // 
    public class CarbonDioxidePeakLevel(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CarbonMonoxideDetectedType : byte { CO_LEVELS_NORMAL = 0, CO_LEVELS_ABNORMAL = 1, }
    // 
    // Carbon Monoxide Detected
    // 
    public class CarbonMonoxideDetected(Service service, CharacteristicJSON json) : Characteristic<CarbonMonoxideDetectedType>(service, json), IService
    {
        public async Task<CarbonMonoxideDetectedType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Carbon Monoxide Level
    // 
    public class CarbonMonoxideLevel(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Carbon Monoxide Peak Level
    // 
    public class CarbonMonoxidePeakLevel(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // CCA Energy Detect Threshold
    // 
    public class CCAEnergyDetectThreshold(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
    }
    // 
    // CCA Signal Detect Threshold
    // 
    public class CCASignalDetectThreshold(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
    }
    // 
    // Characteristic Value Active Transition Count
    // 
    public class CharacteristicValueActiveTransitionCount(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Characteristic Value Transition Control
    // 
    public class CharacteristicValueTransitionControl(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    public enum ChargingStateType : byte { NOT_CHARGING = 0, CHARGING = 1, NOT_CHARGEABLE = 2, }
    // 
    // Charging State
    // 
    public class ChargingState(Service service, CharacteristicJSON json) : Characteristic<ChargingStateType>(service, json), IService
    {
        public async Task<ChargingStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum ClosedCaptionsType : byte { DISABLED = 0, ENABLED = 1, }
    // 
    // Closed Captions
    // 
    public class ClosedCaptions(Service service, CharacteristicJSON json) : Characteristic<ClosedCaptionsType>(service, json), IService
    {
        public async Task<ClosedCaptionsType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(ClosedCaptionsType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Color Temperature
    // 
    public class ColorTemperature(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(int value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Configuration State
    // 
    public class ConfigurationState(Service service, CharacteristicJSON json) : Characteristic<ushort>(service, json), IService
    {
        public async Task<ushort?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Configured Name
    // 
    public class ConfiguredName(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(string value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum ContactSensorStateType : byte { CONTACT_DETECTED = 0, CONTACT_NOT_DETECTED = 1, }
    // 
    // Contact Sensor State
    // 
    public class ContactSensorState(Service service, CharacteristicJSON json) : Characteristic<ContactSensorStateType>(service, json), IService
    {
        public async Task<ContactSensorStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Cooling Threshold Temperature
    // 
    public class CoolingThresholdTemperature(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Crypto Hash
    // 
    public class CryptoHash(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    public enum CurrentAirPurifierStateType : byte { INACTIVE = 0, IDLE = 1, PURIFYING_AIR = 2, }
    // 
    // Current Air Purifier State
    // 
    public class CurrentAirPurifierState(Service service, CharacteristicJSON json) : Characteristic<CurrentAirPurifierStateType>(service, json), IService
    {
        public async Task<CurrentAirPurifierStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Current Ambient Light Level
    // 
    public class CurrentAmbientLightLevel(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CurrentDoorStateType : byte { OPEN = 0, CLOSED = 1, OPENING = 2, CLOSING = 3, STOPPED = 4, }
    // 
    // Current Door State
    // 
    public class CurrentDoorState(Service service, CharacteristicJSON json) : Characteristic<CurrentDoorStateType>(service, json), IService
    {
        public async Task<CurrentDoorStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CurrentFanStateType : byte { INACTIVE = 0, IDLE = 1, BLOWING_AIR = 2, }
    // 
    // Current Fan State
    // 
    public class CurrentFanState(Service service, CharacteristicJSON json) : Characteristic<CurrentFanStateType>(service, json), IService
    {
        public async Task<CurrentFanStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CurrentHeaterCoolerStateType : byte { INACTIVE = 0, IDLE = 1, HEATING = 2, COOLING = 3, }
    // 
    // Current Heater-Cooler State
    // 
    public class CurrentHeaterCoolerState(Service service, CharacteristicJSON json) : Characteristic<CurrentHeaterCoolerStateType>(service, json), IService
    {
        public async Task<CurrentHeaterCoolerStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CurrentHeatingCoolingStateType : byte { OFF = 0, HEAT = 1, COOL = 2, }
    // 
    // Current Heating Cooling State
    // 
    public class CurrentHeatingCoolingState(Service service, CharacteristicJSON json) : Characteristic<CurrentHeatingCoolingStateType>(service, json), IService
    {
        public async Task<CurrentHeatingCoolingStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Current Horizontal Tilt Angle
    // 
    public class CurrentHorizontalTiltAngle(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CurrentHumidifierDehumidifierStateType : byte { INACTIVE = 0, IDLE = 1, HUMIDIFYING = 2, DEHUMIDIFYING = 3, }
    // 
    // Current Humidifier-Dehumidifier State
    // 
    public class CurrentHumidifierDehumidifierState(Service service, CharacteristicJSON json) : Characteristic<CurrentHumidifierDehumidifierStateType>(service, json), IService
    {
        public async Task<CurrentHumidifierDehumidifierStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CurrentMediaStateType : byte { PLAY = 0, PAUSE = 1, STOP = 2, LOADING = 4, INTERRUPTED = 5, }
    // 
    // Current Media State
    // 
    public class CurrentMediaState(Service service, CharacteristicJSON json) : Characteristic<CurrentMediaStateType>(service, json), IService
    {
        public async Task<CurrentMediaStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Current Position
    // 
    public class CurrentPosition(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Current Relative Humidity
    // 
    public class CurrentRelativeHumidity(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CurrentSlatStateType : byte { FIXED = 0, JAMMED = 1, SWINGING = 2, }
    // 
    // Current Slat State
    // 
    public class CurrentSlatState(Service service, CharacteristicJSON json) : Characteristic<CurrentSlatStateType>(service, json), IService
    {
        public async Task<CurrentSlatStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Current Temperature
    // 
    public class CurrentTemperature(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Current Tilt Angle
    // 
    public class CurrentTiltAngle(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Current Transport
    // 
    public class CurrentTransport(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
    }
    // 
    // Current Vertical Tilt Angle
    // 
    public class CurrentVerticalTiltAngle(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum CurrentVisibilityStateType : byte { SHOWN = 0, HIDDEN = 1, }
    // 
    // Current Visibility State
    // 
    public class CurrentVisibilityState(Service service, CharacteristicJSON json) : Characteristic<CurrentVisibilityStateType>(service, json), IService
    {
        public async Task<CurrentVisibilityStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Data Stream HAP Transport
    // 
    public class DataStreamHAPTransport(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Data Stream HAP Transport Interrupt
    // 
    public class DataStreamHAPTransportInterrupt(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Diagonal Field Of View
    // 
    public class DiagonalFieldOfView(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Digital Zoom
    // 
    public class DigitalZoom(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Display Order
    // 
    public class DisplayOrder(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Event Retransmission Maximum
    // 
    public class EventRetransmissionMaximum(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
    }
    public enum EventSnapshotsActiveType : byte { DISABLE = 0, ENABLE = 1, }
    // 
    // Event Snapshots Active
    // 
    public class EventSnapshotsActive(Service service, CharacteristicJSON json) : Characteristic<EventSnapshotsActiveType>(service, json), IService
    {
        public async Task<EventSnapshotsActiveType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(EventSnapshotsActiveType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Event Transmission Counters
    // 
    public class EventTransmissionCounters(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
    }
    public enum FilterChangeIndicationType : byte { FILTER_OK = 0, CHANGE_FILTER = 1, }
    // 
    // Filter Change Indication
    // 
    public class FilterChangeIndication(Service service, CharacteristicJSON json) : Characteristic<FilterChangeIndicationType>(service, json), IService
    {
        public async Task<FilterChangeIndicationType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Filter Life Level
    // 
    public class FilterLifeLevel(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Firmware Revision
    // 
    public class FirmwareRevision(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Firmware Update Readiness
    // 
    public class FirmwareUpdateReadiness(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Firmware Update Status
    // 
    public class FirmwareUpdateStatus(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Hardware Finish
    // 
    public class HardwareFinish(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Hardware Revision
    // 
    public class HardwareRevision(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Heart Beat
    // 
    public class HeartBeat(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Heating Threshold Temperature
    // 
    public class HeatingThresholdTemperature(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Hold Position
    // 
    public class HoldPosition(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool> SetValue(bool value) { return await Write(value); }
    }
    public enum HomeKitCameraActiveType : byte { OFF = 0, ON = 1, }
    // 
    // HomeKit Camera Active
    // 
    public class HomeKitCameraActive(Service service, CharacteristicJSON json) : Characteristic<HomeKitCameraActiveType>(service, json), IService
    {
        public async Task<HomeKitCameraActiveType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(HomeKitCameraActiveType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Hue
    // 
    public class Hue(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Identifier
    // 
    public class Identifier(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
    }
    // 
    // Identify
    // 
    public class Identify(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool> SetValue(bool value) { return await Write(value); }
    }
    // 
    // Image Mirroring
    // 
    public class ImageMirroring(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Image Rotation
    // 
    public class ImageRotation(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(int value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum InputDeviceTypeType : byte { OTHER = 0, TV = 1, RECORDING = 2, TUNER = 3, PLAYBACK = 4, AUDIO_SYSTEM = 5, }
    // 
    // Input Device Type
    // 
    public class InputDeviceType(Service service, CharacteristicJSON json) : Characteristic<InputDeviceTypeType>(service, json), IService
    {
        public async Task<InputDeviceTypeType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum InputSourceTypeType : byte { OTHER = 0, HOME_SCREEN = 1, TUNER = 2, HDMI = 3, COMPOSITE_VIDEO = 4, S_VIDEO = 5, COMPONENT_VIDEO = 6, DVI = 7, AIRPLAY = 8, USB = 9, APPLICATION = 10, }
    // 
    // Input Source Type
    // 
    public class InputSourceType(Service service, CharacteristicJSON json) : Characteristic<InputSourceTypeType>(service, json), IService
    {
        public async Task<InputSourceTypeType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum InUseType : byte { NOT_IN_USE = 0, IN_USE = 1, }
    // 
    // In Use
    // 
    public class InUse(Service service, CharacteristicJSON json) : Characteristic<InUseType>(service, json), IService
    {
        public async Task<InUseType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum IsConfiguredType : byte { NOT_CONFIGURED = 0, CONFIGURED = 1, }
    // 
    // Is Configured
    // 
    public class IsConfigured(Service service, CharacteristicJSON json) : Characteristic<IsConfiguredType>(service, json), IService
    {
        public async Task<IsConfiguredType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(IsConfiguredType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum LeakDetectedType : byte { LEAK_NOT_DETECTED = 0, LEAK_DETECTED = 1, }
    // 
    // Leak Detected
    // 
    public class LeakDetected(Service service, CharacteristicJSON json) : Characteristic<LeakDetectedType>(service, json), IService
    {
        public async Task<LeakDetectedType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // List Pairings
    // 
    public class ListPairings(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Lock Control Point
    // 
    public class LockControlPoint(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    public enum LockCurrentStateType : byte { UNSECURED = 0, SECURED = 1, JAMMED = 2, UNKNOWN = 3, }
    // 
    // Lock Current State
    // 
    public class LockCurrentState(Service service, CharacteristicJSON json) : Characteristic<LockCurrentStateType>(service, json), IService
    {
        public async Task<LockCurrentStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum LockLastKnownActionType : byte { SECURED_PHYSICALLY_INTERIOR = 0, UNSECURED_PHYSICALLY_INTERIOR = 1, SECURED_PHYSICALLY_EXTERIOR = 2, UNSECURED_PHYSICALLY_EXTERIOR = 3, SECURED_BY_KEYPAD = 4, UNSECURED_BY_KEYPAD = 5, SECURED_REMOTELY = 6, UNSECURED_REMOTELY = 7, SECURED_BY_AUTO_SECURE_TIMEOUT = 8, SECURED_PHYSICALLY = 9, UNSECURED_PHYSICALLY = 10, }
    // 
    // Lock Last Known Action
    // 
    public class LockLastKnownAction(Service service, CharacteristicJSON json) : Characteristic<LockLastKnownActionType>(service, json), IService
    {
        public async Task<LockLastKnownActionType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Lock Management Auto Security Timeout
    // 
    public class LockManagementAutoSecurityTimeout(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(uint value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum LockPhysicalControlsType : byte { CONTROL_LOCK_DISABLED = 0, CONTROL_LOCK_ENABLED = 1, }
    // 
    // Lock Physical Controls
    // 
    public class LockPhysicalControls(Service service, CharacteristicJSON json) : Characteristic<LockPhysicalControlsType>(service, json), IService
    {
        public async Task<LockPhysicalControlsType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(LockPhysicalControlsType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum LockTargetStateType : byte { UNSECURED = 0, SECURED = 1, }
    // 
    // Lock Target State
    // 
    public class LockTargetState(Service service, CharacteristicJSON json) : Characteristic<LockTargetStateType>(service, json), IService
    {
        public async Task<LockTargetStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(LockTargetStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Logs
    // 
    public class Logs(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // MAC Retransmission Maximum
    // 
    public class MACRetransmissionMaximum(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
    }
    // 
    // MAC Transmission Counters
    // 
    public class MACTransmissionCounters(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    public enum ManagedNetworkEnableType : byte { DISABLED = 0, ENABLED = 1, }
    // 
    // Managed Network Enable
    // 
    public class ManagedNetworkEnable(Service service, CharacteristicJSON json) : Characteristic<ManagedNetworkEnableType>(service, json), IService
    {
        public async Task<ManagedNetworkEnableType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(ManagedNetworkEnableType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Manually Disabled
    // 
    public class ManuallyDisabled(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Manufacturer
    // 
    public class Manufacturer(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Maximum Transmit Power
    // 
    public class MaximumTransmitPower(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
    }
    // 
    // Metrics Buffer Full State
    // 
    public class MetricsBufferFullState(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Model
    // 
    public class Model(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Motion Detected
    // 
    public class MotionDetected(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Multifunction Button
    // 
    public class MultifunctionButton(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Mute
    // 
    public class Mute(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Name
    // 
    public class Name(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Network Access Violation Control
    // 
    public class NetworkAccessViolationControl(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Network Client Profile Control
    // 
    public class NetworkClientProfileControl(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Network Client Status Control
    // 
    public class NetworkClientStatusControl(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // NFC Access Control Point
    // 
    public class NFCAccessControlPoint(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // NFC Access Supported Configuration
    // 
    public class NFCAccessSupportedConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Night Vision
    // 
    public class NightVision(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Nitrogen Dioxide Density
    // 
    public class NitrogenDioxideDensity(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Obstruction Detected
    // 
    public class ObstructionDetected(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum OccupancyDetectedType : byte { OCCUPANCY_NOT_DETECTED = 0, OCCUPANCY_DETECTED = 1, }
    // 
    // Occupancy Detected
    // 
    public class OccupancyDetected(Service service, CharacteristicJSON json) : Characteristic<OccupancyDetectedType>(service, json), IService
    {
        public async Task<OccupancyDetectedType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // On
    // 
    public class On(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Operating State Response
    // 
    public class OperatingStateResponse(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Optical Zoom
    // 
    public class OpticalZoom(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Outlet In Use
    // 
    public class OutletInUse(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Ozone Density
    // 
    public class OzoneDensity(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Pairing Features
    // 
    public class PairingFeatures(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
    }
    // 
    // Pair Setup
    // 
    public class PairSetup(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Pair Verify
    // 
    public class PairVerify(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Password Setting
    // 
    public class PasswordSetting(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum PeriodicSnapshotsActiveType : byte { DISABLE = 0, ENABLE = 1, }
    // 
    // Periodic Snapshots Active
    // 
    public class PeriodicSnapshotsActive(Service service, CharacteristicJSON json) : Characteristic<PeriodicSnapshotsActiveType>(service, json), IService
    {
        public async Task<PeriodicSnapshotsActiveType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(PeriodicSnapshotsActiveType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum PictureModeType : byte { OTHER = 0, STANDARD = 1, CALIBRATED = 2, CALIBRATED_DARK = 3, VIVID = 4, GAME = 5, COMPUTER = 6, CUSTOM = 7, }
    // 
    // Picture Mode
    // 
    public class PictureMode(Service service, CharacteristicJSON json) : Characteristic<PictureModeType>(service, json), IService
    {
        public async Task<PictureModeType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(PictureModeType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Ping
    // 
    public class Ping(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // PM10 Density
    // 
    public class PM10Density(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // PM2.5 Density
    // 
    public class PM2_5Density(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum PositionStateType : byte { DECREASING = 0, INCREASING = 1, STOPPED = 2, }
    // 
    // Position State
    // 
    public class PositionState(Service service, CharacteristicJSON json) : Characteristic<PositionStateType>(service, json), IService
    {
        public async Task<PositionStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum PowerModeSelectionType : byte { SHOW = 0, HIDE = 1, }
    // 
    // Power Mode Selection
    // 
    public class PowerModeSelection(Service service, CharacteristicJSON json) : Characteristic<PowerModeSelectionType>(service, json), IService
    {
        public async Task<bool> SetValue(PowerModeSelectionType value) { return await Write(value); }
    }
    // 
    // Product Data
    // 
    public class ProductData(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    public enum ProgrammableSwitchEventType : byte { SINGLE_PRESS = 0, DOUBLE_PRESS = 1, LONG_PRESS = 2, }
    // 
    // Programmable Switch Event
    // 
    public class ProgrammableSwitchEvent(Service service, CharacteristicJSON json) : Characteristic<ProgrammableSwitchEventType>(service, json), IService
    {
        public async Task<ProgrammableSwitchEventType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Programmable Switch Output State
    // 
    public class ProgrammableSwitchOutputState(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum ProgramModeType : byte { NO_PROGRAM_SCHEDULED = 0, PROGRAM_SCHEDULED = 1, PROGRAM_SCHEDULED_MANUAL_MODE = 2, }
    // 
    // Program Mode
    // 
    public class ProgramMode(Service service, CharacteristicJSON json) : Characteristic<ProgramModeType>(service, json), IService
    {
        public async Task<ProgramModeType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Received Signal Strength Indication
    // 
    public class ReceivedSignalStrengthIndication(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
    }
    // 
    // Receiver Sensitivity
    // 
    public class ReceiverSensitivity(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
    }
    public enum RecordingAudioActiveType : byte { DISABLE = 0, ENABLE = 1, }
    // 
    // Recording Audio Active
    // 
    public class RecordingAudioActive(Service service, CharacteristicJSON json) : Characteristic<RecordingAudioActiveType>(service, json), IService
    {
        public async Task<RecordingAudioActiveType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(RecordingAudioActiveType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Relative Humidity Dehumidifier Threshold
    // 
    public class RelativeHumidityDehumidifierThreshold(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Relative Humidity Humidifier Threshold
    // 
    public class RelativeHumidityHumidifierThreshold(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Relay Control Point
    // 
    public class RelayControlPoint(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Relay Enabled
    // 
    public class RelayEnabled(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Relay State
    // 
    public class RelayState(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Remaining Duration
    // 
    public class RemainingDuration(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum RemoteKeyType : byte { REWIND = 0, FAST_FORWARD = 1, NEXT_TRACK = 2, PREVIOUS_TRACK = 3, ARROW_UP = 4, ARROW_DOWN = 5, ARROW_LEFT = 6, ARROW_RIGHT = 7, SELECT = 8, BACK = 9, EXIT = 10, PLAY_PAUSE = 11, INFORMATION = 15, }
    // 
    // Remote Key
    // 
    public class RemoteKey(Service service, CharacteristicJSON json) : Characteristic<RemoteKeyType>(service, json), IService
    {
        public async Task<bool> SetValue(RemoteKeyType value) { return await Write(value); }
    }
    // 
    // Reset Filter Indication
    // 
    public class ResetFilterIndication(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<bool> SetValue(byte value) { return await Write(value); }
    }
    public enum RotationDirectionType : int { CLOCKWISE = 0, COUNTER_CLOCKWISE = 1, }
    // 
    // Rotation Direction
    // 
    public class RotationDirection(Service service, CharacteristicJSON json) : Characteristic<RotationDirectionType>(service, json), IService
    {
        public async Task<RotationDirectionType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(RotationDirectionType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Rotation Speed
    // 
    public class RotationSpeed(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum RouterStatusType : byte { READY = 0, NOT_READY = 1, }
    // 
    // Router Status
    // 
    public class RouterStatus(Service service, CharacteristicJSON json) : Characteristic<RouterStatusType>(service, json), IService
    {
        public async Task<RouterStatusType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Saturation
    // 
    public class Saturation(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Security System Alarm Type
    // 
    public class SecuritySystemAlarmType(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum SecuritySystemCurrentStateType : byte { STAY_ARM = 0, AWAY_ARM = 1, NIGHT_ARM = 2, DISARMED = 3, ALARM_TRIGGERED = 4, }
    // 
    // Security System Current State
    // 
    public class SecuritySystemCurrentState(Service service, CharacteristicJSON json) : Characteristic<SecuritySystemCurrentStateType>(service, json), IService
    {
        public async Task<SecuritySystemCurrentStateType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum SecuritySystemTargetStateType : byte { STAY_ARM = 0, AWAY_ARM = 1, NIGHT_ARM = 2, DISARM = 3, }
    // 
    // Security System Target State
    // 
    public class SecuritySystemTargetState(Service service, CharacteristicJSON json) : Characteristic<SecuritySystemTargetStateType>(service, json), IService
    {
        public async Task<SecuritySystemTargetStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(SecuritySystemTargetStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Selected Audio Stream Configuration
    // 
    public class SelectedAudioStreamConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Selected Camera Recording Configuration
    // 
    public class SelectedCameraRecordingConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Selected Diagnostics Modes
    // 
    public class SelectedDiagnosticsModes(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(uint value) { return await Write(value); }
    }
    // 
    // Selected RTP Stream Configuration
    // 
    public class SelectedRTPStreamConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Selected Sleep Configuration
    // 
    public class SelectedSleepConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Serial Number
    // 
    public class SerialNumber(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Service Label Index
    // 
    public class ServiceLabelIndex(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
    }
    public enum ServiceLabelNamespaceType : byte { DOTS = 0, ARABIC_NUMERALS = 1, }
    // 
    // Service Label Namespace
    // 
    public class ServiceLabelNamespace(Service service, CharacteristicJSON json) : Characteristic<ServiceLabelNamespaceType>(service, json), IService
    {
        public async Task<ServiceLabelNamespaceType?> GetValue() { return (await Read()); }
    }
    // 
    // Set Duration
    // 
    public class SetDuration(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(uint value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Setup Data Stream Transport
    // 
    public class SetupDataStreamTransport(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Setup Endpoints
    // 
    public class SetupEndpoints(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Setup Transfer Transport
    // 
    public class SetupTransferTransport(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Signal To Noise Ratio
    // 
    public class SignalToNoiseRatio(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
    }
    // 
    // Siri Enable
    // 
    public class SiriEnable(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Siri Endpoint Session Status
    // 
    public class SiriEndpointSessionStatus(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Siri Engine Version
    // 
    public class SiriEngineVersion(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Siri Input Type
    // 
    public class SiriInputType(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public const byte PUSH_BUTTON_TRIGGERED_APPLE_TV = 0;

        public async Task<byte?> GetValue() { return await Read(); }
    }
    // 
    // Siri Light On Use
    // 
    public class SiriLightOnUse(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Siri Listening
    // 
    public class SiriListening(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Siri Touch To Use
    // 
    public class SiriTouchToUse(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum SlatTypeType : byte { HORIZONTAL = 0, VERTICAL = 1, }
    // 
    // Slat Type
    // 
    public class SlatType(Service service, CharacteristicJSON json) : Characteristic<SlatTypeType>(service, json), IService
    {
        public async Task<SlatTypeType?> GetValue() { return (await Read()); }
    }
    public enum SleepDiscoveryModeType : byte { NOT_DISCOVERABLE = 0, ALWAYS_DISCOVERABLE = 1, }
    // 
    // Sleep Discovery Mode
    // 
    public class SleepDiscoveryMode(Service service, CharacteristicJSON json) : Characteristic<SleepDiscoveryModeType>(service, json), IService
    {
        public async Task<SleepDiscoveryModeType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Sleep Interval
    // 
    public class SleepInterval(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum SmokeDetectedType : byte { SMOKE_NOT_DETECTED = 0, SMOKE_DETECTED = 1, }
    // 
    // Smoke Detected
    // 
    public class SmokeDetected(Service service, CharacteristicJSON json) : Characteristic<SmokeDetectedType>(service, json), IService
    {
        public async Task<SmokeDetectedType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Software Revision
    // 
    public class SoftwareRevision(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Staged Firmware Version
    // 
    public class StagedFirmwareVersion(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Status Active
    // 
    public class StatusActive(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum StatusFaultType : byte { NO_FAULT = 0, GENERAL_FAULT = 1, }
    // 
    // Status Fault
    // 
    public class StatusFault(Service service, CharacteristicJSON json) : Characteristic<StatusFaultType>(service, json), IService
    {
        public async Task<StatusFaultType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum StatusJammedType : byte { NOT_JAMMED = 0, JAMMED = 1, }
    // 
    // Status Jammed
    // 
    public class StatusJammed(Service service, CharacteristicJSON json) : Characteristic<StatusJammedType>(service, json), IService
    {
        public async Task<StatusJammedType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum StatusLowBatteryType : byte { BATTERY_LEVEL_NORMAL = 0, BATTERY_LEVEL_LOW = 1, }
    // 
    // Status Low Battery
    // 
    public class StatusLowBattery(Service service, CharacteristicJSON json) : Characteristic<StatusLowBatteryType>(service, json), IService
    {
        public async Task<StatusLowBatteryType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum StatusTamperedType : byte { NOT_TAMPERED = 0, TAMPERED = 1, }
    // 
    // Status Tampered
    // 
    public class StatusTampered(Service service, CharacteristicJSON json) : Characteristic<StatusTamperedType>(service, json), IService
    {
        public async Task<StatusTamperedType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Streaming Status
    // 
    public class StreamingStatus(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Sulphur Dioxide Density
    // 
    public class SulphurDioxideDensity(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Supported Asset Types
    // 
    public class SupportedAssetTypes(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
    }
    // 
    // Supported Audio Recording Configuration
    // 
    public class SupportedAudioRecordingConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Supported Audio Stream Configuration
    // 
    public class SupportedAudioStreamConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Supported Camera Recording Configuration
    // 
    public class SupportedCameraRecordingConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Supported Characteristic Value Transition Configuration
    // 
    public class SupportedCharacteristicValueTransitionConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Supported Data Stream Transport Configuration
    // 
    public class SupportedDataStreamTransportConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Supported Diagnostics Modes
    // 
    public class SupportedDiagnosticsModes(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
    }
    // 
    // Supported Diagnostics Snapshot
    // 
    public class SupportedDiagnosticsSnapshot(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Supported Firmware Update Configuration
    // 
    public class SupportedFirmwareUpdateConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Supported Metrics
    // 
    public class SupportedMetrics(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Supported Router Configuration
    // 
    public class SupportedRouterConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Supported RTP Configuration
    // 
    public class SupportedRTPConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Supported Sleep Configuration
    // 
    public class SupportedSleepConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Supported Transfer Transport Configuration
    // 
    public class SupportedTransferTransportConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // Supported Video Recording Configuration
    // 
    public class SupportedVideoRecordingConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Supported Video Stream Configuration
    // 
    public class SupportedVideoStreamConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    public enum SwingModeType : byte { SWING_DISABLED = 0, SWING_ENABLED = 1, }
    // 
    // Swing Mode
    // 
    public class SwingMode(Service service, CharacteristicJSON json) : Characteristic<SwingModeType>(service, json), IService
    {
        public async Task<SwingModeType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(SwingModeType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Tap Type
    // 
    public class TapType(Service service, CharacteristicJSON json) : Characteristic<ushort>(service, json), IService
    {
        public async Task<ushort?> GetValue() { return await Read(); }
    }
    public enum TargetAirPurifierStateType : byte { MANUAL = 0, AUTO = 1, }
    // 
    // Target Air Purifier State
    // 
    public class TargetAirPurifierState(Service service, CharacteristicJSON json) : Characteristic<TargetAirPurifierStateType>(service, json), IService
    {
        public async Task<TargetAirPurifierStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(TargetAirPurifierStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Target Control List
    // 
    public class TargetControlList(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Target Control Supported Configuration
    // 
    public class TargetControlSupportedConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    public enum TargetDoorStateType : byte { OPEN = 0, CLOSED = 1, }
    // 
    // Target Door State
    // 
    public class TargetDoorState(Service service, CharacteristicJSON json) : Characteristic<TargetDoorStateType>(service, json), IService
    {
        public async Task<TargetDoorStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(TargetDoorStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum TargetFanStateType : byte { MANUAL = 0, AUTO = 1, }
    // 
    // Target Fan State
    // 
    public class TargetFanState(Service service, CharacteristicJSON json) : Characteristic<TargetFanStateType>(service, json), IService
    {
        public async Task<TargetFanStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(TargetFanStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum TargetHeaterCoolerStateType : byte { AUTO = 0, HEAT = 1, COOL = 2, }
    // 
    // Target Heater-Cooler State
    // 
    public class TargetHeaterCoolerState(Service service, CharacteristicJSON json) : Characteristic<TargetHeaterCoolerStateType>(service, json), IService
    {
        public async Task<TargetHeaterCoolerStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(TargetHeaterCoolerStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum TargetHeatingCoolingStateType : byte { OFF = 0, HEAT = 1, COOL = 2, AUTO = 3, }
    // 
    // Target Heating Cooling State
    // 
    public class TargetHeatingCoolingState(Service service, CharacteristicJSON json) : Characteristic<TargetHeatingCoolingStateType>(service, json), IService
    {
        public async Task<TargetHeatingCoolingStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(TargetHeatingCoolingStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Target Horizontal Tilt Angle
    // 
    public class TargetHorizontalTiltAngle(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(int value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum TargetHumidifierDehumidifierStateType : byte { HUMIDIFIER_OR_DEHUMIDIFIER = 0, HUMIDIFIER = 1, DEHUMIDIFIER = 2, }
    // 
    // Target Humidifier-Dehumidifier State
    // 
    public class TargetHumidifierDehumidifierState(Service service, CharacteristicJSON json) : Characteristic<TargetHumidifierDehumidifierStateType>(service, json), IService
    {
        public async Task<TargetHumidifierDehumidifierStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(TargetHumidifierDehumidifierStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum TargetMediaStateType : byte { PLAY = 0, PAUSE = 1, STOP = 2, }
    // 
    // Target Media State
    // 
    public class TargetMediaState(Service service, CharacteristicJSON json) : Characteristic<TargetMediaStateType>(service, json), IService
    {
        public async Task<TargetMediaStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(TargetMediaStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Target Position
    // 
    public class TargetPosition(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Target Relative Humidity
    // 
    public class TargetRelativeHumidity(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Target Temperature
    // 
    public class TargetTemperature(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(float value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Target Tilt Angle
    // 
    public class TargetTiltAngle(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(int value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Target Vertical Tilt Angle
    // 
    public class TargetVerticalTiltAngle(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(int value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum TargetVisibilityStateType : byte { SHOWN = 0, HIDDEN = 1, }
    // 
    // Target Visibility State
    // 
    public class TargetVisibilityState(Service service, CharacteristicJSON json) : Characteristic<TargetVisibilityStateType>(service, json), IService
    {
        public async Task<TargetVisibilityStateType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(TargetVisibilityStateType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum TemperatureDisplayUnitsType : byte { CELSIUS = 0, FAHRENHEIT = 1, }
    // 
    // Temperature Display Units
    // 
    public class TemperatureDisplayUnits(Service service, CharacteristicJSON json) : Characteristic<TemperatureDisplayUnitsType>(service, json), IService
    {
        public async Task<TemperatureDisplayUnitsType?> GetValue() { return (await Read()); }
        public async Task<bool> SetValue(TemperatureDisplayUnitsType value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum ThirdPartyCameraActiveType : byte { OFF = 0, ON = 1, }
    // 
    // Third Party Camera Active
    // 
    public class ThirdPartyCameraActive(Service service, CharacteristicJSON json) : Characteristic<ThirdPartyCameraActiveType>(service, json), IService
    {
        public async Task<ThirdPartyCameraActiveType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Thread Control Point
    // 
    public class ThreadControlPoint(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Thread Node Capabilities
    // 
    public class ThreadNodeCapabilities(Service service, CharacteristicJSON json) : Characteristic<ushort>(service, json), IService
    {
        public async Task<ushort?> GetValue() { return await Read(); }
    }
    // 
    // Thread OpenThread Version
    // 
    public class ThreadOpenThreadVersion(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Thread Status
    // 
    public class ThreadStatus(Service service, CharacteristicJSON json) : Characteristic<ushort>(service, json), IService
    {
        public async Task<ushort?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Token
    // 
    public class Token(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
    }
    // 
    // Transmit Power
    // 
    public class TransmitPower(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
    }
    // 
    // Tunnel Connection Timeout
    // 
    public class TunnelConnectionTimeout(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(int value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Tunneled Accessory Advertising
    // 
    public class TunneledAccessoryAdvertising(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Tunneled Accessory Connected
    // 
    public class TunneledAccessoryConnected(Service service, CharacteristicJSON json) : Characteristic<bool>(service, json), IService
    {
        public async Task<bool?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(bool value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Tunneled Accessory State Number
    // 
    public class TunneledAccessoryStateNumber(Service service, CharacteristicJSON json) : Characteristic<int>(service, json), IService
    {
        public async Task<int?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum ValveTypeType : byte { GENERIC_VALVE = 0, IRRIGATION = 1, SHOWER_HEAD = 2, WATER_FAUCET = 3, }
    // 
    // Valve Type
    // 
    public class ValveType(Service service, CharacteristicJSON json) : Characteristic<ValveTypeType>(service, json), IService
    {
        public async Task<ValveTypeType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Version
    // 
    public class Version(Service service, CharacteristicJSON json) : StringCharacteristic(service, json), IService
    {
        public async Task<string?> GetValue() { return await Read(); }
    }
    // 
    // Video Analysis Active
    // 
    public class VideoAnalysisActive(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // VOC Density
    // 
    public class VOCDensity(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Volume
    // 
    public class Volume(Service service, CharacteristicJSON json) : Characteristic<byte>(service, json), IService
    {
        public async Task<byte?> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum VolumeControlTypeType : byte { NONE = 0, RELATIVE = 1, RELATIVE_WITH_CURRENT = 2, ABSOLUTE = 3, }
    // 
    // Volume Control Type
    // 
    public class VolumeControlType(Service service, CharacteristicJSON json) : Characteristic<VolumeControlTypeType>(service, json), IService
    {
        public async Task<VolumeControlTypeType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum VolumeSelectorType : byte { INCREMENT = 0, DECREMENT = 1, }
    // 
    // Volume Selector
    // 
    public class VolumeSelector(Service service, CharacteristicJSON json) : Characteristic<VolumeSelectorType>(service, json), IService
    {
        public async Task<bool> SetValue(VolumeSelectorType value) { return await Write(value); }
    }
    // 
    // Wake Configuration
    // 
    public class WakeConfiguration(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
    }
    // 
    // WAN Configuration List
    // 
    public class WANConfigurationList(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // WAN Status List
    // 
    public class WANStatusList(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Water Level
    // 
    public class WaterLevel(Service service, CharacteristicJSON json) : Characteristic<float>(service, json), IService
    {
        public async Task<float?> GetValue() { return await Read(); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    // 
    // Wi-Fi Capabilities
    // 
    public class WiFiCapabilities(Service service, CharacteristicJSON json) : Characteristic<uint>(service, json), IService
    {
        public async Task<uint?> GetValue() { return await Read(); }
    }
    // 
    // Wi-Fi Configuration Control
    // 
    public class WiFiConfigurationControl(Service service, CharacteristicJSON json) : BinaryCharacteristic(service, json), IService
    {
        public async Task<byte[]> GetValue() { return await Read(); }
        public async Task<bool> SetValue(byte[] value) { return await Write(value); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
    public enum WiFiSatelliteStatusType : byte { UNKNOWN = 0, CONNECTED = 1, NOT_CONNECTED = 2, }
    // 
    // Wi-Fi Satellite Status
    // 
    public class WiFiSatelliteStatus(Service service, CharacteristicJSON json) : Characteristic<WiFiSatelliteStatusType>(service, json), IService
    {
        public async Task<WiFiSatelliteStatusType?> GetValue() { return (await Read()); }
        public async Task<bool> ToggleNotifications(bool subscribe) { return await Events(subscribe); }
    }
}