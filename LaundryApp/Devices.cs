using System;
using System.Globalization;
using System.IO.Ports;
using System.Text.RegularExpressions;
using Microsoft.PointOfService;
using LaundryApp.Model;

namespace LaundryApp.Devices
{
    public class ReceiptPrinter
    {
        PosPrinter printer;
        Order _orderDetail;

        public string TenantName { get; set; }
        public string TenantPhone { get; set; }
        public string TenantAddress { get; set; }

        public ReceiptPrinter()
        {
            TenantName = Properties.Settings.Default.TenantName;
            TenantPhone = Properties.Settings.Default.TenantPhone;
            TenantAddress = Properties.Settings.Default.TenantAddress;
        }

        public ReceiptPrinter(Order orderDetail)
        {
            SetOrderDetail = orderDetail;
        }

        public Order SetOrderDetail
        {
            set
            {
                _orderDetail = value;
            }
        }

        public PosPrinter PrinterInstance
        {
            get
            {
                return printer;
            }
        }

        public void Initialized()
        {
            string logicalName = "PosPrinter";
            try
            {
                PosExplorer posExplorer = new PosExplorer();
                DeviceInfo deviceInfo = null;

                try
                {
                    deviceInfo = posExplorer.GetDevice(DeviceType.PosPrinter, logicalName);
                    printer = (PosPrinter)posExplorer.CreateInstance(deviceInfo);
                }
                catch (Exception)
                {
                    return;
                }

                printer.Open();
                printer.Claim(1000);
                printer.DeviceEnabled = true;
            }
            catch (PosControlException)
            {
            }
        }

        public void PrintAcceptOrder()
        {
            try
            {
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" +
                                    TenantName + "\n" +
                                    TenantPhone + "\n" +
                                    TenantAddress + "\n");

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|2uF\n");
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" + Transformer.GenerateString(printer.RecLineChars, "-") + "\n");
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" + Transformer.MakePrintString(
                    printer.RecLineChars,
                    "NO TRANS:" + _orderDetail.OrderId,
                    "CUSTOMER:" + _orderDetail.CustomerName
                ) + "\n");
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" + Transformer.GenerateString(printer.RecLineChars, "-") + "\n");

                if (_orderDetail.OrderItems.Count > 0)
                {
                    foreach (OrderItem good in _orderDetail.OrderItems)
                    {
                        printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" + good.ItemName + Transformer.MakePrintInt(good.ItemQty, 3, false) + " x" + "\n");
                        printer.PrintNormal(PrinterStation.Receipt, "\u001b|rA" + Transformer.CurrencyFormat(good.ItemPrice) + "\n");
                    }
                }

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Berat, Kg : ", Transformer.WeightFormat(_orderDetail.Weight)) + "\n" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Service : ", _orderDetail.ServiceType) + "\n" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Status : ", _orderDetail.IsPaid ? "Lunas" : "Belum Lunas") + "\n" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Total Bayar, Rp : ", Transformer.CurrencyFormat(_orderDetail.Price)) + "\n");

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|5uF\n");

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" +
                                    "TERIMA KASIH" + "\n" +
                                    DateTime.Now.ToShortDateString() + "\n");

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|5uF\n");
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");
            }
            catch (Exception)
            {
                Close();
            }

            Close();
        }

        public void PrintPaidOrder(long paid, long subTotal, long change)
        {
            try
            {
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" +
                                    TenantName + "\n" +
                                    TenantPhone + "\n" +
                                    TenantAddress + "\n");

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|2uF\n");
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" + Transformer.GenerateString(printer.RecLineChars, "-") + "\n");
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" + Transformer.MakePrintString(
                    printer.RecLineChars,
                    "NO TRANS:" + _orderDetail.OrderId,
                    "CUSTOMER:" + _orderDetail.CustomerName
                ) + "\n");
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" + Transformer.GenerateString(printer.RecLineChars, "-") + "\n");

                if (_orderDetail.OrderItems.Count > 0)
                {
                    foreach (OrderItem item in _orderDetail.OrderItems)
                    {
                        printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" + item.ItemName + Transformer.MakePrintInt(item.ItemQty, 3, false) + " x" + "\n");
                        printer.PrintNormal(PrinterStation.Receipt, "\u001b|rA" + Transformer.CurrencyFormat(item.ItemPrice) + "\n");
                    }
                }

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|N" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Berat, Kg : ", Transformer.WeightFormat(_orderDetail.Weight)) + "\n" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Service : ", _orderDetail.ServiceType) + "\n" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Status : ", _orderDetail.IsPaid ? "Lunas" : "Belum Lunas") + "\n" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Bayar, Rp : ", Transformer.CurrencyFormat(paid)) + "\n" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Total Bayar, Rp : ", Transformer.CurrencyFormat(subTotal)) + "\n" +
                                    Transformer.MakePrintString(printer.RecLineChars, "Kembali, Rp : ", Transformer.CurrencyFormat(change)) + "\n");

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|5uF\n");

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|cA" +
                                    "TERIMA KASIH" + "\n" +
                                    DateTime.Now.ToShortDateString() + "\n");

                printer.PrintNormal(PrinterStation.Receipt, "\u001b|5uF\n");
                printer.PrintNormal(PrinterStation.Receipt, "\u001b|fP");
            }
            catch (Exception)
            {
                Close();
            }

            Close();
        }

        public bool ReceiptPrinterInitialized()
        {
            return printer != null && printer is PosPrinter;
        }

        public bool ReceiptPrinterStatus()
        {
            return printer.State != ControlState.Closed && printer.State == ControlState.Idle;
        }

        public void Close()
        {
            try
            {
                printer.DeviceEnabled = false;
                printer.Release();
            }
            catch (PosControlException)
            {
            }
            finally
            {
                printer.Close();
            }
        }
    }

    public class DigitalScale
    {
        string DefaultPortName { get; set; }
        SerialPort serialPort = null;
        
        public void Initialize()
        {
            foreach (string port in SerialPort.GetPortNames())
            {
                if (port.ToLower().StartsWith("com"))
                {
                    DefaultPortName = port;
                    break;
                }
            }

            if (DefaultPortName != null)
            {
                serialPort = new SerialPort(DefaultPortName);

                if (serialPort is SerialPort)
                {
                    serialPort.ReadTimeout = 500;
                    serialPort.DtrEnable = true;
                    serialPort.Open();
                }
            }
        }

        public bool ScaleStatus()
        {
            return serialPort.IsOpen;
        }

        public bool ScalesInitialized()
        {
            return serialPort is SerialPort && DefaultPortName != null;
        }

        public void Close()
        {
            if (ScalesInitialized())
            {
                serialPort.Close();
            }
        }
        
        public SerialPort BaseSerialPort()
        {
            return serialPort;
        }

        public String ParseRegex(string current)
        {
            Regex rx = new Regex("(\\d{1,2}\\.\\d{3})", RegexOptions.Compiled);
            return rx.Match(current).ToString();
        }
    }

    public class Transformer
    {
        public static NumberFormatInfo CustomNumberFormatInfo
        {
            get
            {
                NumberFormatInfo numberFormat = CultureInfo.CreateSpecificCulture("id-ID").NumberFormat;
                numberFormat.CurrencySymbol = "";
                return numberFormat;
            }
        }

        public static String GenerateInvoice(int OrderId, int maxSize = 7)
        {
            string invoiceId = "#";

            for (int i = 0; i < maxSize; i++)
            {
                invoiceId += "0";
            }

            return invoiceId + OrderId.ToString();
        }

        public static String CurrencyFormat(long price)
        {
            return price.ToString("C", CustomNumberFormatInfo);
        }

        public static String CurrencyFormat(double price)
        {
            return price.ToString("C", CustomNumberFormatInfo);
        }

        public static String WeightFormat(double weight)
        {
            return weight.ToString();
        }

        public static String MakePrintInt(int decimals, int maxChars, bool isPrice = true)
        {
            int iSpaces = 0;
            string sPrice = "";

            if (isPrice)
            {
                sPrice = CurrencyFormat(decimals);
            }
            else
            {
                sPrice = Convert.ToString(decimals);
            }

            iSpaces = maxChars - sPrice.Length;

            string tab = GenerateString(iSpaces);

            return tab + sPrice;
        }

        public static String MakePrintInt(long decimals, int maxChars, bool isPrice = true)
        {
            int iSpaces = 0;
            String sPrice = "";

            if (isPrice)
            {
                sPrice = CurrencyFormat(decimals);
            }
            else
            {
                sPrice = Convert.ToString(decimals);
            }

            iSpaces = maxChars - sPrice.Length;

            String tab = GenerateString(iSpaces);

            return tab + sPrice;
        }

        public static String MakePrintString(int iLineChars, string strBuff, string strPrice)
        {
            int iSpaces = 0;
            int iSumChars = strBuff.Length + strPrice.Length;
            double dCharRanges = Convert.ToDouble(iSumChars / iLineChars);
            int iCeil = Convert.ToInt32(Math.Ceiling(dCharRanges));

            if (iLineChars < strBuff.Length)
            {
                iSpaces = (iLineChars * iCeil) - iSumChars;
            }
            else
            {
                iSpaces = iLineChars - iSumChars;
            }

            String tab = GenerateString(iSpaces);

            return strBuff + tab + strPrice;
        }

        public static String GenerateString(int iLength, string sGenerate = " ")
        {
            String generateFor = "";

            for (int j = 0; j < iLength; j++)
            {
                generateFor += sGenerate;
            }

            return generateFor;
        }
    }
}
