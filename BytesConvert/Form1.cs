using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
namespace BytesConvert
{
    public partial class Form1 : Form
    {
        List<ProcessMode> list;
        public Form1()
        {
            InitializeComponent();

            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    ((TextBox)control).Enter += Clear;
                    ((TextBox)control).TextChanged += NextTab;
                }
            }
        } 
        private void Form1_Load(object sender, EventArgs e)
        {
            list = new List<ProcessMode>(
               new ProcessMode[] {
                  new ProcessMode() {   Mode_ID =1,Mode_Byte="y=I1(x)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =2,Mode_Byte="y=UI1(x)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =3,Mode_Byte="y=I2(x1,x2)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =4,Mode_Byte="y=UI2(x1,x2)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =5,Mode_Byte="y=I4(x1,x2,x3,x4)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =6,Mode_Byte="y=UI4(x1,x2,x3,x4)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =7,Mode_Byte="y=R4(x1,x2,x3,x4)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =8,Mode_Byte="y=I2(x2,x1)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =9,Mode_Byte="y=UI2(x2,x1)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =10,Mode_Byte="y=I4(x4,x3,x2,x1)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =11,Mode_Byte="y=UI4(x4,x3,x2,x1)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =12,Mode_Byte="y=R4(x4,x3,x2,x1)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =13,Mode_Byte="y=I4(x3,x4,x1,x2)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =14,Mode_Byte="y=UI4(x3,x4,x1,x2)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =15,Mode_Byte="y=R4(x3,x4,x1,x2)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =16,Mode_Byte="y=I4(x2,x1,x4,x3)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =17,Mode_Byte="y=UI4(x2,x1,x4,x3)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =18,Mode_Byte="y=R4(x2,x1,x4,x3)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =19,Mode_Byte="y=SI2(x1,x2)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =20,Mode_Byte="y=SI2(x2,x1)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =21,Mode_Byte="y=SI4(x1,x2,x3,x4)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =22,Mode_Byte="y=SI4(x4,x3,x2,x1)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =23,Mode_Byte="y=SI4(x3,x4,x1,x2)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =24,Mode_Byte="y=SI4(x2,x1,x4,x3)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =25,Mode_Byte="y=R8(x1,2,3,4,5,6,7,8)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =26,Mode_Byte="y=R8(x2,1,4,3,6,5,8,7)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =27,Mode_Byte="y=R8(x8,7,6,5,4,3,2,1)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =28,Mode_Byte="y=R8(x7,8,5,6,3,4,1,2)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =29,Mode_Byte="y=R8(x5,6,7,8,1,2,3,4)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =30,Mode_Byte="y=R8(x6,5,8,7,2,1,4,3)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =31,Mode_Byte="y=I8(x1,2,3,4,5,6,7,8)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =32,Mode_Byte="y=I8(x2,1,4,3,6,5,8,7)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =33,Mode_Byte="y=I8(x8,7,6,5,4,3,2,1)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =34,Mode_Byte="y=I8(x7,8,5,6,3,4,1,2)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =35,Mode_Byte="y=I8(x5,6,7,8,1,2,3,4)",Mode_Value="-" },
                  new ProcessMode() {   Mode_ID =36,Mode_Byte="y=I8(x6,5,8,7,2,1,4,3)",Mode_Value="-" }
               }
             );
            dgvData.DataSource = list;
        }
        /// <summary>
        /// 修改当前值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string byte1 = (string.IsNullOrWhiteSpace(txt1.Text.Trim()) ? "00" : txt1.Text.Trim());
            string byte2 = (string.IsNullOrWhiteSpace(txt2.Text.Trim()) ? "00" : txt2.Text.Trim());
            string byte3 = (string.IsNullOrWhiteSpace(txt3.Text.Trim()) ? "00" : txt3.Text.Trim());
            string byte4 = (string.IsNullOrWhiteSpace(txt4.Text.Trim()) ? "00" : txt4.Text.Trim());
            string byte5 = (string.IsNullOrWhiteSpace(txt5.Text.Trim()) ? "00" : txt5.Text.Trim());
            string byte6 = (string.IsNullOrWhiteSpace(txt6.Text.Trim()) ? "00" : txt6.Text.Trim());
            string byte7 = (string.IsNullOrWhiteSpace(txt7.Text.Trim()) ? "00" : txt7.Text.Trim());
            string byte8 = (string.IsNullOrWhiteSpace(txt8.Text.Trim()) ? "00" : txt8.Text.Trim());


            #region 单字节=》整数
            //单字转换为有符号整数
            dgvData.Rows[0].Cells["Mode_Value"].Value = Calculate.byte2Int(byte1 + byte2).ToString();

            //单字转换为无符号整数
            dgvData.Rows[1].Cells["Mode_Value"].Value = Calculate.Byte2Uint(byte1 + byte2).ToString();
            #endregion

            #region 单字（双字节）=》整数

            //单字转换为有符号整数
            dgvData.Rows[2].Cells["Mode_Value"].Value = Calculate.Word2int(byte1 + byte2).ToString();

            //单字转换为无符号整数
            dgvData.Rows[3].Cells["Mode_Value"].Value = Calculate.Word2Uint(byte1 + byte2).ToString();


            //单字转换为有符号整数 反高低字节
            dgvData.Rows[7].Cells["Mode_Value"].Value = Calculate.RWord2int(byte1 + byte2).ToString();

            //单字转换为无符号整数 反高低字节
            dgvData.Rows[8].Cells["Mode_Value"].Value = Calculate.RWord2Uint(byte1 + byte2).ToString();


            #endregion

            #region 双字（四字节） =》 整数
            //双字转换为有符号整数
            dgvData.Rows[4].Cells["Mode_Value"].Value = Calculate.Dword2Int(byte1 + byte2 + byte3 + byte4).ToString();

            //双字转换为无符号整数
            dgvData.Rows[5].Cells["Mode_Value"].Value = Calculate.Dword2UInt(byte1 + byte2 + byte3 + byte4).ToString();


            //双字转换为有符号整数 反高低字节
            dgvData.Rows[9].Cells["Mode_Value"].Value = Calculate.RDword2Int(byte1 + byte2 + byte3 + byte4).ToString();

            //双字转换为无符号整数 反高低字节
            dgvData.Rows[10].Cells["Mode_Value"].Value = Calculate.RDword2UInt(byte1 + byte2 + byte3 + byte4).ToString();



            //双字转换为有符号整数  反高低字
            dgvData.Rows[12].Cells["Mode_Value"].Value = Calculate.RWDWord2Int(byte1 + byte2, byte3 + byte4).ToString();

            //双字转换为无符号整数 反高低字
            dgvData.Rows[13].Cells["Mode_Value"].Value = Calculate.RWDWord2UInt(byte1 + byte2, byte3 + byte4).ToString();

            //双字转换为有符号整数 单字反高低字节
            dgvData.Rows[15].Cells["Mode_Value"].Value = Calculate.RBDWord2Int(byte1 + byte2, byte3 + byte4).ToString();

            //双字转换为无符号整数 单字反高低字节
            dgvData.Rows[16].Cells["Mode_Value"].Value = Calculate.RBDWord2UInt(byte1 + byte2, byte3 + byte4).ToString();

            #endregion

            #region 四字（8字节）=》64位整数
            //四字（8字节）=》64位整数
            dgvData.Rows[30].Cells["Mode_Value"].Value = Calculate.I8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.one).ToString();
            dgvData.Rows[31].Cells["Mode_Value"].Value = Calculate.I8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.two).ToString();
            dgvData.Rows[32].Cells["Mode_Value"].Value = Calculate.I8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.three).ToString();
            dgvData.Rows[33].Cells["Mode_Value"].Value = Calculate.I8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.four).ToString();
            dgvData.Rows[34].Cells["Mode_Value"].Value = Calculate.I8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.five).ToString();
            dgvData.Rows[35].Cells["Mode_Value"].Value = Calculate.I8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.six).ToString();

            #endregion

            #region 最高位为符号位=》整数 
            //最高位为符号位=》整数 
            dgvData.Rows[18].Cells["Mode_Value"].Value = Calculate.Byte2Int(byte1, byte2).ToString();
            dgvData.Rows[19].Cells["Mode_Value"].Value = Calculate.RByte2Int(byte1, byte2).ToString();
            dgvData.Rows[20].Cells["Mode_Value"].Value = Calculate.Byte2Int(byte1, byte2, byte3, byte4, Bytes4Order.one).ToString();
            dgvData.Rows[21].Cells["Mode_Value"].Value = Calculate.Byte2Int(byte1, byte2, byte3, byte4, Bytes4Order.two).ToString();
            dgvData.Rows[22].Cells["Mode_Value"].Value = Calculate.Byte2Int(byte1, byte2, byte3, byte4, Bytes4Order.three).ToString();
            dgvData.Rows[23].Cells["Mode_Value"].Value = Calculate.Byte2Int(byte1, byte2, byte3, byte4, Bytes4Order.four).ToString();
            #endregion

            #region 4字节 =》 单精度 

            //4字节 =》 单精度 
            dgvData.Rows[6].Cells["Mode_Value"].Value = Calculate.R4(byte1, byte2, byte3, byte4, Bytes4Order.one).ToString();
            dgvData.Rows[11].Cells["Mode_Value"].Value = Calculate.R4(byte1, byte2, byte3, byte4, Bytes4Order.two).ToString();
            dgvData.Rows[14].Cells["Mode_Value"].Value = Calculate.R4(byte1, byte2, byte3, byte4, Bytes4Order.three).ToString();
            dgvData.Rows[17].Cells["Mode_Value"].Value = Calculate.R4(byte1, byte2, byte3, byte4, Bytes4Order.four).ToString();
            #endregion


            #region 8字节 =》 双精度
            //8字节 =》 双精度
            dgvData.Rows[24].Cells["Mode_Value"].Value = Calculate.R8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.one).ToString();
            dgvData.Rows[25].Cells["Mode_Value"].Value = Calculate.R8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.two).ToString();
            dgvData.Rows[26].Cells["Mode_Value"].Value = Calculate.R8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.three).ToString();
            dgvData.Rows[27].Cells["Mode_Value"].Value = Calculate.R8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.four).ToString();
            dgvData.Rows[28].Cells["Mode_Value"].Value = Calculate.R8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.five).ToString();
            dgvData.Rows[29].Cells["Mode_Value"].Value = Calculate.R8(byte1, byte2, byte3, byte4, byte5, byte6, byte7, byte8, Bytes8Order.six).ToString();
            #endregion
        }


        public void Clear(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = string.Empty;
        }

        public void NextTab(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length >= 2)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }

    public class Calculate
    {
        #region 单字节转换为整数
        /// <summary>
        /// 单字节转换为有符号整数
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static int byte2Int(string strHex)
        {
            return BitConverter.ToInt16(StrHex2bytes(strHex), 0);
        }
        /// <summary>
        /// 单字节转换为无符号整数
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static int Byte2Uint(string strHex)
        {
            return BitConverter.ToInt16(StrHex2bytes(strHex), 0);
        }
        #endregion


        #region 双字节转换为整数 
        /// <summary>
        /// word 转换为有符号整数
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static int Word2int(string strHex)
        {
            return BitConverter.ToInt16(StrHex2bytes(strHex), 0);
        }
        /// <summary>
        /// word 转换为无符号整数
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static int Word2Uint(string strHex)
        {
            return BitConverter.ToUInt16(StrHex2bytes(strHex), 0);
        }
        /// <summary>
        /// word 转换为有符号整数 反高低字节
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static int RWord2int(string strHex)
        {
            byte[] bytes = StrHex2bytes(strHex);
            Array.Reverse(bytes);
            return BitConverter.ToInt16(bytes, 0);
        }
        /// <summary>
        /// word 转换为无符号整数 反高低字节
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static int RWord2Uint(string strHex)
        {
            byte[] bytes = StrHex2bytes(strHex);
            Array.Reverse(bytes);
            return BitConverter.ToUInt16(bytes, 0);
        }
        #endregion


        #region 双字（四字节）转换为整数 
        /// <summary>
        /// 双字=》有符号整数
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static int Dword2Int(string strHex)
        {
            try
            {
                return BitConverter.ToInt32(StrHex2bytes(strHex), 0);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 双字=》无符号整数
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static uint Dword2UInt(string strHex)
        {
            try
            {
                return BitConverter.ToUInt32(StrHex2bytes(strHex), 0);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 双字=》有符号整数 反高低字节
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static int RDword2Int(string strHex)
        {
            try
            {
                Byte[] bytes = StrHex2bytes(strHex);
                Array.Reverse(bytes);
                return BitConverter.ToInt32(bytes, 0);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 双字 =》无符号整数 反高低字节
        /// </summary>
        /// <param name="strHex"></param>
        /// <returns></returns>
        public static uint RDword2UInt(string strHex)
        {
            Byte[] bytes = StrHex2bytes(strHex);
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }
        /// <summary>
        /// 双字 =》有符号整数 反高低字
        /// </summary>
        /// <param name="strHex1"></param>
        /// <param name="strHex2"></param>
        /// <returns></returns>
        public static int RWDWord2Int(string strHex1, string strHex2)
        {
            byte[] bytes = StrHex2bytes(strHex2 + strHex1);
            return BitConverter.ToInt32(bytes, 0);
        }
        /// <summary>
        /// 双字 =》无符号整数 反高低字
        /// </summary>
        /// <param name="strHex1"></param>
        /// <param name="strHex2"></param>
        /// <returns></returns>
        public static uint RWDWord2UInt(string strHex1, string strHex2)
        {
            byte[] bytes = StrHex2bytes(strHex2 + strHex1);
            return BitConverter.ToUInt32(bytes, 0);
        }


        /// <summary>
        /// 双字 =》有符号整数 单字反高低字节
        /// </summary>
        /// <param name="strHex1"></param>
        /// <param name="strHex2"></param>
        /// <returns></returns>
        public static int RBDWord2Int(string strHex1, string strHex2)
        {
            byte[] bytes1 = StrHex2bytes(strHex1); Array.Reverse(bytes1);
            byte[] bytes2 = StrHex2bytes(strHex2); Array.Reverse(bytes2);

            return BitConverter.ToInt32(bytes1.Concat(bytes2).ToArray(), 0);
        }
        /// <summary>
        /// 双字 =》无符号整数 单字反高低字节
        /// </summary>
        /// <param name="strHex1"></param>
        /// <param name="strHex2"></param>
        /// <returns></returns>
        public static uint RBDWord2UInt(string strHex1, string strHex2)
        {
            byte[] bytes1 = StrHex2bytes(strHex1); Array.Reverse(bytes1);
            byte[] bytes2 = StrHex2bytes(strHex2); Array.Reverse(bytes2);
            return BitConverter.ToUInt32(bytes1.Concat(bytes2).ToArray(), 0);
        }
        #endregion


        #region 四字（8字节）=》64位整数

        public static long I8(string hex1, string hex2, string hex3, string hex4, string hex5, string hex6, string hex7, string hex8, Bytes8Order model)
        {

            try
            {
                switch (model)
                {
                    case Bytes8Order.one:
                        return BitConverter.ToInt64(StrHex2bytes(hex1 + hex2 + hex3 + hex4 + hex5 + hex6 + hex7 + hex8), 0);
                    case Bytes8Order.two:
                        return BitConverter.ToInt64(StrHex2bytes(hex2 + hex1 + hex4 + hex3 + hex6 + hex5 + hex8 + hex7), 0);
                    case Bytes8Order.three:
                        return BitConverter.ToInt64(StrHex2bytes(hex8 + hex7 + hex6 + hex5 + hex4 + hex3 + hex2 + hex1), 0);
                    case Bytes8Order.four:
                        return BitConverter.ToInt64(StrHex2bytes(hex7 + hex8 + hex5 + hex6 + hex3 + hex4 + hex1 + hex2), 0);
                    case Bytes8Order.five:
                        return BitConverter.ToInt64(StrHex2bytes(hex5 + hex6 + hex7 + hex8 + hex1 + hex2 + hex3 + hex4), 0);
                    case Bytes8Order.six:
                        return BitConverter.ToInt64(StrHex2bytes(hex6 + hex5 + hex8 + hex7 + hex2 + hex1 + hex4 + hex3), 0);
                    default: return 0;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion


        #region 将byte转换为有符号Int 最高位为符号位 
        /// <summary>
        /// 2字节=》有符号int 最高位为符号位
        /// </summary>
        /// <param name="hex1"></param>
        /// <param name="hex2"></param>
        /// <returns></returns>
        public static int Byte2Int(string hex1, string hex2)
        {
            return Byte2Int(StrHex2bytes(hex2 + hex1));
        }
        /// <summary>
        /// 2字节=》有符号int 最高位为符号位  反高低字节
        /// </summary>
        /// <param name="hex1"></param>
        /// <param name="hex2"></param>
        /// <returns></returns>
        public static int RByte2Int(string hex1, string hex2)
        {
            return Byte2Int(StrHex2bytes(hex1 + hex2));
        }

        /// <summary>
        /// 4字节=》有符号int 最高位为符号位
        /// </summary>
        /// <param name="hex1"></param>
        /// <param name="hex2"></param>
        /// <param name="hex3"></param>
        /// <param name="hex4"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Byte2Int(string hex1, string hex2, string hex3, string hex4, Bytes4Order model)
        {
            switch (model)
            {
                case Bytes4Order.one:
                    return Byte2Int(StrHex2bytes(hex4 + hex3 + hex2 + hex1));
                case Bytes4Order.two:
                    return Byte2Int(StrHex2bytes(hex1 + hex2 + hex3 + hex4));
                case Bytes4Order.three:
                    return Byte2Int(StrHex2bytes(hex2 + hex1 + hex4 + hex3));
                case Bytes4Order.four:
                    return Byte2Int(StrHex2bytes(hex3 + hex4 + hex1 + hex2));
                default: return 0;
            }

        }

        /// <summary>
        /// 将byte转换为有符号Int 最高位为符号位
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Byte2Int(byte[] data)
        {
            string strBin = string.Empty;
            foreach (byte b in data)
            {
                strBin += Convert.ToString(b, 2).PadLeft(8, '0');
            }
            int result;
            ///负数  将第一个1修改为0 转换为十进制整数
            if (strBin.Substring(0, 1) == "1")
            {
                StringBuilder sb = new StringBuilder(strBin);
                sb.Replace('1', '0', 0, 1);
                result = -Convert.ToInt32(sb.ToString(), 2);
            }
            //正数 不修改直接转换为十进制整数
            else
            {
                result = Convert.ToInt32(strBin, 2);
            }
            return result;
        }

        #endregion


        #region 4byte=》float 
        /// <summary>
        /// 4byte =》 float
        /// </summary>
        /// <param name="hex1"></param>
        /// <param name="hex2"></param>
        /// <param name="hex3"></param>
        /// <param name="hex4"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static float R4(string hex1, string hex2, string hex3, string hex4, Bytes4Order model)
        {
            try
            {
                switch (model)
                {
                    case Bytes4Order.one:
                        return BitConverter.ToSingle(StrHex2bytes(hex1 + hex2 + hex3 + hex4), 0);
                    case Bytes4Order.two:
                        return BitConverter.ToSingle(StrHex2bytes(hex2 + hex1 + hex4 + hex3), 0);
                    case Bytes4Order.three:
                        return BitConverter.ToSingle(StrHex2bytes(hex4 + hex3 + hex2 + hex1), 0);
                    case Bytes4Order.four:
                        return BitConverter.ToSingle(StrHex2bytes(hex3 + hex4 + hex1 + hex2), 0);
                    default: return 0;
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 8byte=》double 
        /// <summary>
        /// 8byte =》 double
        /// </summary>
        /// <param name="hex1"></param>
        /// <param name="hex2"></param>
        /// <param name="hex3"></param>
        /// <param name="hex4"></param>
        /// <param name="hex5"></param>
        /// <param name="hex6"></param>
        /// <param name="hex7"></param>
        /// <param name="hex8"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static double R8(string hex1, string hex2, string hex3, string hex4, string hex5, string hex6, string hex7, string hex8, Bytes8Order model)
        {

            try
            {
                switch (model)
                {
                    case Bytes8Order.one:
                        return BitConverter.ToDouble(StrHex2bytes(hex1 + hex2 + hex3 + hex4 + hex5 + hex6 + hex7 + hex8), 0);
                    case Bytes8Order.two:
                        return BitConverter.ToDouble(StrHex2bytes(hex2 + hex1 + hex4 + hex3 + hex6 + hex5 + hex8 + hex7), 0);
                    case Bytes8Order.three:
                        return BitConverter.ToDouble(StrHex2bytes(hex8 + hex7 + hex6 + hex5 + hex4 + hex3 + hex2 + hex1), 0);
                    case Bytes8Order.four:
                        return BitConverter.ToDouble(StrHex2bytes(hex7 + hex8 + hex5 + hex6 + hex3 + hex4 + hex1 + hex2), 0);
                    case Bytes8Order.five:
                        return BitConverter.ToDouble(StrHex2bytes(hex5 + hex6 + hex7 + hex8 + hex1 + hex2 + hex3 + hex4), 0);
                    case Bytes8Order.six:
                        return BitConverter.ToDouble(StrHex2bytes(hex6 + hex5 + hex8 + hex7 + hex2 + hex1 + hex4 + hex3), 0);
                    default: return 0;
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 16进制数据转换为byte数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StrHex2bytes(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return null;
            str = str.Replace(" ", "");
            byte[] bytes = new byte[str.Length / 2];
            for (int i = 0; i < str.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);
            }
            return bytes;
        }


    }
    public class ProcessMode
    {
        public int Mode_ID { get; set; }
        public string Mode_Byte { get; set; }
        public string Mode_Value { get; set; }
    }
    public enum Bytes8Order
    {
        one = 12345678,
        two = 21436587,
        three = 87654321,
        four = 78563412,
        five = 56781234,
        six = 65872143
    }
    public enum Bytes4Order
    {
        one = 1234,
        two = 4321,
        three = 3412,
        four = 2143
    }
}
