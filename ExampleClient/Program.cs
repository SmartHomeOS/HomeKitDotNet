using HomeKitDotNet;
using HomeKitDotNet.Models;
using System.Globalization;
using System.Net;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //Detect accessory on the network and grab the QR code
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("10.20.30.40"), 21067);
        QRParser parser = new QRParser("X-HM://00UQ3OYGA9CTI");

        //Randomly generate keys and keep them in a safe place (or let the controller do it for you using the other Controller constructor)
        byte[] DeviceID = Encoding.UTF8.GetBytes(Guid.Parse("cafef517-351a-4280-93f6-995d3b881587").ToString("D", CultureInfo.InvariantCulture));
        byte[] LTPK = [0xD8, 0x54, 0x66, 0x74, 0x20, 0xB0, 0x0F, 0xF7, 0x18, 0x67, 0xB6, 0xBD, 0x97, 0x6A, 0xE9, 0xE0, 0x34, 0x50, 0xD2, 0x18, 0x24, 0xEA, 0x5D, 0x72, 0x7A, 0xD8, 0xAD, 0xA2, 0x60, 0xEE, 0x59, 0xC3];
        byte[] LTSK = [0x9E, 0x07, 0x26, 0x1A, 0xA1, 0x36, 0x61, 0xDE, 0x6E, 0x73, 0x49, 0xBC, 0x0D, 0x91, 0x08, 0x9B, 0xEF, 0x58, 0x61, 0x5C, 0x5B, 0x2A, 0xC6, 0x01, 0x7C, 0x7C, 0xC4, 0xA1, 0x92, 0x37, 0x8D, 0x0C, 0xD8, 0x54, 0x66, 0x74, 0x20, 0xB0, 0x0F, 0xF7, 0x18, 0x67, 0xB6, 0xBD, 0x97, 0x6A, 0xE9, 0xE0, 0x34, 0x50, 0xD2, 0x18, 0x24, 0xEA, 0x5D, 0x72, 0x7A, 0xD8, 0xAD, 0xA2, 0x60, 0xEE, 0x59, 0xC3];
        
        Controller controller = new Controller(LTSK, LTPK, DeviceID);
        //Pair with the device (only 1 time) and then call connect for future sessions
        var pairing = await controller.Pair(parser.SetupPin, ep);
        HomeKitEndPoint connection = await controller.Connect(ep, pairing.ID, pairing.LTPK);

        //Once connected you can read and write any characteristics on any services
        AccessoryInformation info = (connection.Accessories[0].Services.First(s => s is AccessoryInformation) as AccessoryInformation)!;
        Console.WriteLine($"Device Name: {info.Name.LastValue}");
        Console.WriteLine($"Device Serial: {info.SerialNumber.LastValue}");
        Console.WriteLine($"Device Make: {info.Manufacturer.LastValue}");
        Console.WriteLine($"Device Configured Name: {info.ConfiguredName?.LastValue}");
        Console.WriteLine($"Device Version: {await info.FirmwareRevision.GetValue()}");
        Console.WriteLine($"Device Software Version: {info.SoftwareRevision?.LastValue}");

        //Any characteristic that supports events can be subscribed to
        if (info.ConfiguredName != null)
        {
            await info.ConfiguredName.ToggleNotifications(true); //Subscribe
            info.ConfiguredName.Updated += ConfiguredName_Updated;
        }

        //It's that easy
        Console.ReadLine();
    }

    private static Task ConfiguredName_Updated(Service service, StringCharacteristic characteristic, string? newValue)
    {
        Console.WriteLine("Previous Name: " + ((ConfiguredName)characteristic).LastValue);
        Console.WriteLine("New Value: " + newValue);
        //After this event is handled, LastValue is set to newValue
        return Task.CompletedTask;
    }
}