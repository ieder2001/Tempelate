using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meter
{
    class ModbusClass
    {
        public byte[] MakeCRC16_Old(byte[] data, byte startIndex, int len)
        {
            byte CRC16Lo, CRC16Hi;
            byte CL, CH;
            byte SaveHi, SaveLo;
            int i, Flag;
            CRC16Lo = 0xff;
            CRC16Hi = 0xff;
            CL = 0x01;
            CH = 0xA0;
            for (i = startIndex; i < (startIndex + len); i++)
            {
                CRC16Lo ^= data[i];
                for (Flag = 0; Flag <= 7; Flag++)
                {
                    SaveHi = CRC16Hi;
                    SaveLo = CRC16Lo;
                    CRC16Hi /= 2;
                    CRC16Lo /= 2;
                    if ((SaveHi & 0x01) == 0x01)
                    {
                        CRC16Lo |= 0x80;
                    }
                    if ((SaveLo & 0x01) == 0x01)
                    {
                        CRC16Hi ^= CH;
                        CRC16Lo ^= CL;
                    }
                }
            }
            byte[] ReturnData = new byte[2];
            ReturnData[0] = CRC16Hi;
            ReturnData[1] = CRC16Lo;
            return ReturnData;
        }
        public byte[] MakeCRC16(byte[] data, byte startIndex, byte len)
        {
            byte CRC16Lo, CRC16Hi;   //CRC寄存器
            byte CL, CH;       //多項式碼&HA001
            byte SaveHi, SaveLo;
            int i;
            int Flag;


            CRC16Lo = 0xFF;
            CRC16Hi = 0xFF;
            CL = 0x1;
            CH = 0xA0;
            for (i = startIndex; i <= (startIndex + len - 1); i++)
            {
                CRC16Lo = Convert.ToByte(CRC16Lo ^ data[i]);//每一個數据与CRC寄存器進行异或
                for (Flag = 0; Flag <= 7; Flag++)
                {
                    SaveHi = CRC16Hi;
                    SaveLo = CRC16Lo;
                    CRC16Hi = Convert.ToByte(CRC16Hi / 2);     // '高位右移一位
                    CRC16Lo = Convert.ToByte(CRC16Lo / 2);     //'低位右移一位
                    if ((SaveHi & 0x01) == 0x01)  //'如果高位字節最后一位為1
                    {
                        CRC16Lo = Convert.ToByte(CRC16Lo | 0x80);   //'則低位字節右移后前面補1
                    }             // '否則自動補0
                    if ((SaveLo & 0x01) == 0x01)  //'如果LSB為1，則与多項式碼進行异或
                    {
                        CRC16Hi = Convert.ToByte(CRC16Hi ^ CH);
                        CRC16Lo = Convert.ToByte(CRC16Lo ^ CL);
                    }
                }
            }
            Byte[] ReturnData = new Byte[2];
            ReturnData[0] = CRC16Hi;       //'CRC高位
            ReturnData[1] = CRC16Lo;      //'CRC低位
            return ReturnData;
        }

        public bool CheckCRC16(byte[] response)
        {
            try
            {
                byte[] crc16 = MakeCRC16(response, 0, Convert.ToByte(response[2] + 3));
                if ((response[response.Length - 2] != crc16[1]) || (response[response.Length - 1] != crc16[0]))
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #region CRC16校验
        /// <summary>
        /// CRC16校验算法,低字节在前，高字节在后
        /// </summary>
        /// <param name="data">要校验的数组</param>
        /// <returns>返回校验结果，低字节在前，高字节在后</returns>
        public byte[] CRC16(byte[] data, int len)
        {
            if (data.Length == 0)
                throw new Exception("调用CRC16校验算法,（低字节在前，高字节在后）时发生异常，异常信息：被校验的数组长度为0。");
            int xda, xdapoly;
            int i, j, xdabit;
            xda = 0xFFFF;
            xdapoly = 0xA001;
            for (i = 0; i < len; i++)
            {
                xda ^= data[i];
                for (j = 0; j < 8; j++)
                {
                    xdabit = (int)(xda & 0x01);
                    xda >>= 1;
                    if (xdabit == 1)
                        xda ^= xdapoly;
                }
            }
            byte[] temdata = new byte[2] { (byte)(xda & 0xFF), (byte)(xda >> 8) };
            return temdata;
        }
        #endregion
    }
}
