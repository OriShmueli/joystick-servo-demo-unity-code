using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.IO;
using System.Threading.Tasks;
using System;

public static class SerialPortManager
{
    private static SerialPort _serialPort;
    private static int _handShakeTime = 10;
    private static int _maxTimesToSendAgain = 100;
    private static int _timesToSendAgain = 0;
    private static bool _handshakeReaingFlag = false;

    public static void init(string portName, int baudRate)
    {
        _serialPort = new SerialPort(portName, baudRate, 0, 8, StopBits.One);
    }

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

    private static async Task HandShake( //delegate here...
        )
    {
        //send message
        char sendFirstHandShake = 'h';
        byte[] handShakeByteMessage = BitConverter.GetBytes(sendFirstHandShake);
        await _serialPort.BaseStream?.WriteAsync(handShakeByteMessage, 0, handShakeByteMessage.Length);

        //"timer"
        while (_serialPort.IsOpen)
        {
            if (_handshakeReaingFlag)
            {
                return;
            }

            await Task.Delay(10);
            await _readHandshake(_serialPort);

            if(_timesToSendAgain >= _maxTimesToSendAgain)
            {
                await _serialPort.BaseStream?.WriteAsync(handShakeByteMessage, 0, handShakeByteMessage.Length);
                _timesToSendAgain = 0;
            }
            _timesToSendAgain++;
        }
    }

    private static async Task _readHandshake(SerialPort serialPort)
    {
        byte[] buffer = new byte[3]; //17
        var data = await serialPort.BaseStream?.ReadAsync(buffer, 0, buffer.Length);
        var byteArray = new byte[data];
        Array.Copy(buffer, byteArray, data);
        string s = System.Text.Encoding.UTF8.GetString(byteArray, 0, data);
        if(buffer.Length > 3 || buffer.Length < 1)
        {
            _timesToSendAgain = 100; //reseting the times and casing the code to send another request
            return;
        }

        if (s == "v") // v - for error
        {
            _timesToSendAgain = 100; //reseting the times and casing the code to send another request
            return;
        }

        if (s == "h")
        {
            _handshakeReaingFlag = true;
            return;
        }

       
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
