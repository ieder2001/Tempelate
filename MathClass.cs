using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meter
{
    class MathClass
    {
        
        public double work16to754(string _val)
        {
            double ans = 0;
            byte[] _temp = new byte[4];
            _temp[0] = Convert.ToByte(_val.Substring(0, 2), 16);
            _temp[1] = Convert.ToByte(_val.Substring(2, 2), 16);
            _temp[2] = Convert.ToByte(_val.Substring(4, 2), 16);
            _temp[3] = Convert.ToByte(_val.Substring(6, 2), 16);
            ans = BitConverter.ToSingle(_temp, 0);
            return ans;
        }

        public double work16to754(byte dataHH, byte dataHL, byte dataLH, byte dataLL)
        {
            double ans = 0;
            byte[] _temp = new byte[4];
            _temp[0] = dataHH;
            _temp[1] = dataHL;
            _temp[2] = dataLH;
            _temp[3] = dataLL;
            ans = BitConverter.ToSingle(_temp, 0);
            return ans;
        }

        public string Reverse(string str)
        {
            char[] caArray = str.ToCharArray();
            Array.Reverse(caArray);            //將char array中的元素位置反轉
            string str2 = new string(caArray); //將反轉完的char array轉回字串
            return str2;
        }

       


        public int work16to10(byte hi, byte lo)
        {
            int ans = 0;
            ans = hi * 256 + lo;
            return ans;

        }
        public byte[] work10to16(int _val)
        {
            ushort org = Convert.ToUInt16(_val);
            byte[] ans = BitConverter.GetBytes(org);
            return ans;
        }

        public byte[] work10to16(double _val)
        {
            ushort org = Convert.ToUInt16(_val);
            byte[] ans = BitConverter.GetBytes(org);
            return ans;
        }


        #region work10to16-2
        //public byte[] work10to16(int num)

        //{
        //    int HH = 0;
        //    int HL = 0;
        //    int LL = 0;
        //    byte[] hexnum = new byte[2];

        //    LL = num % 16;
        //    if (num / 16 > 0)
        //    {
        //        LH = (num / 16) % 16;
        //        if ((num / 16) / 16 > 0)
        //        {
        //            HL = ((num / 16)/16) % 16;
        //            if (((num / 16) / 16) / 16 > 0)
        //            {
        //                HH = (((num / 16) / 16)/16) % 16;
        //            }
        //            else
        //            {
        //                HH = (((num / 16) / 16) / 16) % 16;
        //            }
        //        }
        //        else
        //        {
        //            HL = ((num / 16) / 16) % 16;
        //        }

        //    }
        //    else
        //    {
        //        LH = (num / 16) % 16;
        //    }

        //    int H = HH * 16 + HL;
        //    int L = LH * 16 + LL;
        //    hexnum[0] = (byte)H;
        //    hexnum[1] = (byte)L;
        //    return hexnum;
        //}

        #endregion

        public int work16to754(byte _hidata, byte _lodata)
        {
            int ans = 0;
            ans = _hidata * 256 + _lodata;
            return ans;
        }

        public double AiSwitchNumber(int _kind, int _val, double _Emend)
        {
            double ans = 0;
            switch (_kind)
            {
                case 1:             //AI轉換
                case 2:
                case 3:
                case 4:
                    if (_val < 500)
                        ans = 0;
                    else
                        ans = 1;
                    break;
                case 5:             //溫度需解析
                    ans = AiTransform(_val) + _Emend;
                    break;
                case 6:             //溫度不需解析(除10)
                    if (_val < 32768)
                        ans = _val / 10;
                    else
                        ans = _val * -10;
                    break;
                case 7:             //濕度需解析
                    ans = 70 * _val / 408 - 6;
                    break;
                case 8:             //EE16-FT6A26溫度解析
                    ans = _val * 0.48828125;
                    break;
                case 9:             //EE16-FT6A26濕度解析
                    ans = _val * 0.09765625;
                    break;
            }
            return ans;
        }

        private double AiTransform(int heat)
        {
            int rt = heat;
            double T = 0;
            double lnx = Math.Log(Convert.ToDouble(heat));
            double d3 = Math.Pow(lnx, 3);
            double d2 = Math.Pow(lnx, 2);
            double nd8 = Math.Pow(10, -8);
            double rt4 = Math.Pow((rt - 784), 4);
            double nd6 = Math.Pow(10, -6);
            double nd4 = Math.Pow(10, -4);
            double rt3 = Math.Pow((rt - 784), 3);
            double rt2 = Math.Pow((rt - 784), 2);
            if (lnx >= 0 && rt < 33)
                T = 125;
            else if (rt >= 33 && rt < 512)
                T = -1.437 * d3 + 20.994 * d2 - 136.23 * (lnx) + 406.8;
            else if (rt >= 512 && rt < 783)
                T = -64.189 * d3 + 1203.9 * d2 - 7575.1 * (lnx) + 16012.5;
            else if (rt >= 783 && rt < 879)
                T = -1 * nd8 * rt4 + (2 * nd6) * rt3 - (3 * nd4) * rt2 - 0.0989 * (rt - 784) - 1;
            else if (rt >= 879 && rt < 955)
                T = -1 * nd8 * rt4 + (2 * nd6) * rt3 - (3 * nd4) * rt2 - 0.106 * (rt - 784) - 1;
            else if (rt >= 955)
                T = -20;
            T = Math.Round(T, 1);
            return T;
        }

        public double TOYO_PM650_V(int _val, int _pt)
        {
            int ans = 0;
            ans = _val * _pt / 10;
            return ans;
        }

        public double TOYO_PM650_A(int _val, int _ct)
        {
            int ans = 0;
            ans = _val * _ct / 1000;
            return ans;
        }

        public double TOYO_PM650_W(int _val,int _pt,int _ct)
        {
            int ans = 0;
            ans = _val * _pt * _ct;
            return ans;
        }
    }
}
