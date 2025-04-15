using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Text;

public static class SerialPortManager
{
    private static SerialPort _serialPort; //not relevent
    private static int _handShakeTime = 10;
    private static int _maxTimesToSendAgain = 100;
    private static int _timesToSendAgain = 0;
    private static bool _handshakeReaingFlag = false;

    static byte[] connect = { 0x01 };

    private static Dictionary<SettingsView_Local_SerialPort, SerialPort>
        _serialPortConnectionsDictionary = new Dictionary<SettingsView_Local_SerialPort, SerialPort>();

    public static void AddNewSerialPortConnection(SettingsView_Local_SerialPort key, string portName, int baudRate)
    {
        _serialPortConnectionsDictionary.Add(key, new SerialPort(portName, baudRate, 0, 8, StopBits.One));
    }

    public static void SetNewSerialPortBaudRate(SettingsView_Local_SerialPort key, int newBaudRate)
    {
        _serialPortConnectionsDictionary[key].BaudRate = newBaudRate;
    }

    public static void SetNewSerialPortName(SettingsView_Local_SerialPort key, string newPortName)
    {
        _serialPortConnectionsDictionary[key].PortName = newPortName;
    }

    public static string GetSerialPortName(SettingsView_Local_SerialPort key)
    {
        return _serialPortConnectionsDictionary[key].PortName;
    }

    public static void Init(SettingsView_Local_SerialPort key)
    {
        try
        {

        } catch (Exception e)
        {

        }
    }

    public static async Task<bool> ConnectToSerialPort(SettingsView_Local_SerialPort key)
    {
        //return await Task.Run(async () =>
        //{

        //});
        SerialPortConsole.ConsoleMessage("Connecting...", key);

        try
        {

            if (key != null)
            {
                _serialPortConnectionsDictionary[key].Open();
                
                //await HandShake(key);
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (IOException ex)
        {
            return false;
        }
    }

    

    public static void init(string portName, int baudRate)
    {
        _serialPort = new SerialPort(portName, baudRate, 0, 8, StopBits.One);
    }

    //?
    public static async Task<bool> ConnectToSerialPort()
    {
        return await Task.Run(async () =>
        {
            try
            {
                _serialPort.Open();
                await HandShake();
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
        });
    }

    public static void a(byte[] b)
    {

    }

    public static async Task HandShake(SettingsView_Local_SerialPort key)
    {
        //a(new byte[]{ 0x01 });

        byte[] pack = {  }; //start byte - 0x01; 
                            //size byte - (256 is enough) 
                            //data bytes
                            //crc byte
                            //
                            //end byte - 0x02

        byte[] SYN = { 0x16 };
        byte[] ACK = { 0x06 };
        byte[] SYNACK = { 0x1c };

        
        //8x5=40 pixels in lcd

        //! Adding a parity bit to flags

        //client(pc) is the one initiating the communication.
        //client(pc)        server(arduino)
        //  |                     |
        //  |  ->      SYN    ->  |
        //  |                     |
        //  |  <-    SYN+ACK  <-  | openning timer to get ACK back
        //  |                     | if not send again ACK. 
        //  |  ->      ACK    ->  |
        //pc and arduino openning timers if 1 sec if pc get SYN+ACK again send ACK again.  


        //corrupted pack send once -> timer activated -> recived valid response that the func successfully applied. 
        //                             /         \          |              
        //                            /           \         |--|
        //              no response send again.    \        |  |
        //                                      bad response request last response                                        


        try
        {
            await _serialPortConnectionsDictionary[key].BaseStream?.WriteAsync(connect, 0, connect.Length);
        }catch (Exception ex)
        {
            SerialPortConsole.ConsoleErrorMessage(ex.Message, key);
            Debug.LogError(ex.Message);
        }
    }

    private static async Task HandShake( //delegate here...
        )
    {
        //send message
        _handshakeReaingFlag = true;
        string sendFirstHandShake = "SYN";
        byte[] handShakeByteMessage = Encoding.ASCII.GetBytes(sendFirstHandShake);
        //TODO: what serial port. specify -> _serialPortConnectionsDictionary[key].Open();
        await _serialPort.BaseStream?.WriteAsync(handShakeByteMessage, 0, handShakeByteMessage.Length);

        //"timer"
        while (_serialPort.IsOpen)
        {
            if (_handshakeReaingFlag)
            {
                _timesToSendAgain = 0;
                break;
            }

            await Task.Delay(10);
            string incomingData = await _readHandshake(_serialPort);

            switch (incomingData)
            {
                case "v":
                    _timesToSendAgain = 100;
                    break;
                case "SYN":
                    handShakeByteMessage = Encoding.ASCII.GetBytes("ACK");
                    await _serialPort.BaseStream?.WriteAsync(handShakeByteMessage, 0, handShakeByteMessage.Length); //changin the message to ACT so the timer and error detector will send again ACK
                    _timesToSendAgain = 0;
                    _handshakeReaingFlag = false;
                    break;
                default:
                    _timesToSendAgain = 100;
                    break;
            }

            if (_timesToSendAgain >= _maxTimesToSendAgain)
            {
                await _serialPort.BaseStream?.WriteAsync(handShakeByteMessage, 0, handShakeByteMessage.Length);
                _timesToSendAgain = 0;
            }
            _timesToSendAgain++;
        }
    }

    //Old Handshake
    private static async Task<string> _readHandshake(SerialPort serialPort)
    {
        byte[] buffer = new byte[3]; //17
        var data = await serialPort.BaseStream?.ReadAsync(buffer, 0, buffer.Length);
        var byteArray = new byte[data];
        Array.Copy(buffer, byteArray, data);
        return System.Text.Encoding.UTF8.GetString(byteArray, 0, data);
        
        //if(buffer.Length > 3 || buffer.Length < 1)
        //{
        //    _timesToSendAgain = 100; //reseting the times and casing the code to send another request
        //    return;
        //}

        //if (s == "v") // v - for error
        //{
        //    _timesToSendAgain = 100; //reseting the times and casing the code to send another request
        //    return;
        //}

        //if (s == "SYN")
        //{
        //    _handshakeReaingFlag = true;
        //    return;
        //}
    }

    public static async Task<bool> DisconnectFromSerialPort()
    {
        return await Task.Run(() =>
        {
            try
            {
                _serialPort.Close();
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
        });
    }

    static async Task run(SerialPort serialPort)
    {
        while (serialPort.IsOpen)
        {
            await write(serialPort);

            await Task.Delay(10);
            await read(serialPort);
        }
    }

    static async Task read(SerialPort serialPort)
    {
        byte[] buffer = new byte[27]; //17
        var data = await serialPort.BaseStream?.ReadAsync(buffer, 0, buffer.Length);
        var byteArray = new byte[data];
        Array.Copy(buffer, byteArray, data);
        string s = System.Text.Encoding.UTF8.GetString(byteArray, 0, data);
        if (byteArray.Length < 27) //17
        {
            Console.WriteLine("return");
            return;
        }        
    }

    static async Task write(SerialPort serialPort)
    {
        await Task.Run(() => {
            serialPort.Write("c");
        });
    }
}
