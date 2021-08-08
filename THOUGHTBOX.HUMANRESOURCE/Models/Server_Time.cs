using System;

namespace THOUGHTBOX.HUMANRESOURCE.Models
{
    public class Server_Time
    {
        DateTime DT = DateTime.Now.AddHours(00.00);
        public string dt_data = string.Empty;
        public Server_Time()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string GetDay()
        {
            dt_data = DT.Day.ToString();
            return (dt_data.Length == 1) ? "0" + dt_data : dt_data;
        }
        public string GetMonth()
        {
            dt_data = DT.Month.ToString();
            return (dt_data.Length == 1) ? "0" + dt_data : dt_data;
        }
        public string GetYear()
        {
            dt_data = DT.Year.ToString();
            return (dt_data.Length == 2) ? "20" + dt_data : dt_data;
        }
        public string GetDate()
        {
            return GetDay() + "/" + GetMonth() + "/" + GetYear();
        }
        public string GetAM_PM()
        {
            dt_data = DT.ToString("tt");
            return dt_data;
        }

        public string GetHour()
        {
            dt_data = DT.Hour.ToString();
            return (dt_data.Length == 1) ? "0" + dt_data : dt_data;
        }
        public string GetMinute()
        {
            dt_data = DT.Minute.ToString();
            return (dt_data.Length == 1) ? "0" + dt_data : dt_data;
        }
        public string GetSecond()
        {
            dt_data = DT.Second.ToString();
            return (dt_data.Length == 1) ? "0" + dt_data : dt_data;
        }
        public string GetTime()
        {
            return GetHour() + ":" + GetMinute() + ":" + GetSecond();
        }

        public string convert_DDMMYYYY_To_MMDDYYYY(string strDate)
        {
            string strTemp = strDate.Substring(strDate.IndexOf("/") + 1, strDate.LastIndexOf("/") - strDate.IndexOf("/") - 1) + "/";
            strTemp += strDate.Substring(0, strDate.IndexOf("/")) + "/";
            strTemp += strDate.Substring(strDate.LastIndexOf("/") + 1);
            return strTemp;
        }
        public int BusinessDays()
        {

            DateTime firstDay = new DateTime(DT.Year, DT.Month, 01);
            DateTime lastDay = new DateTime(DT.Year, DT.Month, DateTime.DaysInMonth(DT.Year, DT.Month));
            if (firstDay > lastDay)
                throw new ArgumentException("Incorrect last day " + lastDay);

            TimeSpan span = lastDay - firstDay;
            int businessDays = span.Days + 1;
            int fullWeekCount = businessDays / 7;
            // find out if there are weekends during the time exceedng the full weeks
            if (businessDays > fullWeekCount * 7)
            {
                // we are here to find out if there is a 1-day or 2-days weekend
                // in the time interval remaining after subtracting the complete weeks
                int firstDayOfWeek = (int)firstDay.DayOfWeek;
                int lastDayOfWeek = (int)lastDay.DayOfWeek;
                if (lastDayOfWeek < firstDayOfWeek)
                    lastDayOfWeek += 7;
                if (firstDayOfWeek <= 6)
                {
                    if (lastDayOfWeek >= 7)// Both Saturday and Sunday are in the remaining time interval
                        businessDays -= 2;
                    else if (lastDayOfWeek >= 6)// Only Saturday is in the remaining time interval
                        businessDays -= 1;
                }
                else if (firstDayOfWeek <= 7 && lastDayOfWeek >= 7)// Only Sunday is in the remaining time interval
                    businessDays -= 1;
            }

            // subtract the weekends during the full weeks in the interval
            businessDays -= fullWeekCount;


            return businessDays;
        }
    }
}
