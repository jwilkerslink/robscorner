using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RFID
{
    public enum parseType
    {
        parseNotification,
        parseTag
        //what should the remote do with the data?
    };

    public class packet
    {
        DateTime toc;
        public parseType result;
        public string data;
        //other packet data goes here. this is so that
        //we can send all notification messages to remote handler.

        public packet(string input, parseType action, DateTime t)
        {
            data = input;
            result = action;
            toc = t;
        }
    }
    public class tagByte
    {
        public string tagID;
        public string location;
        public string evnt;
        public string RSSI;
        public DateTime dateTime;
        public tagByte(string t, string l, DateTime d)
        {
            tagID = t;
            location = l;
            dateTime = d;
        }
    }

    public class Worker
    {
        static readonly string tagKeyS = "<TagID>";
        static readonly string tagKeyE = "</TagID>";

        static readonly string locKeyS = "<Antenna>";
        static readonly string locKeyE = "</Antenna>";

        static readonly string reaKeyS = "<Reason>";
        static readonly string reaKeyE = "</Reason>";

        static readonly string timeKeyS = "<Time>";
        static readonly string timeKeyE = "</Time>";

        static readonly string RSSIKeyS = "<RSSI>";
        static readonly string RSSIKeyE = "</RSSI>";

        // the wat??
        public List<tagByte> ParsePacket(packet p)
        {

            int sT, eT = 0; int sL, eL = 0; int sR, eR = 0;
            int a, z, i;

            DateTime dateTime;
            string location, tagID, evnt;
            string RSSI;

            switch (p.result)
            {
                case parseType.parseTag:

                    a = p.data.IndexOf(timeKeyS);
                    z = p.data.IndexOf(timeKeyE);

                    dateTime = Convert.ToDateTime(p.data.Substring(a + timeKeyS.Length, (z - (a + timeKeyS.Length))));

                    i = Regex.Matches(p.data, tagKeyS).Count;

                    List<tagByte> retval = new List<tagByte>(i);

                    for (int x = 0; x < i; x++)
                    {
                            sR = p.data.IndexOf(RSSIKeyS, eR);
                            eR = p.data.IndexOf(RSSIKeyE, sR);

                        RSSI =p.data.Substring(sR + RSSIKeyS.Length, (eR - (sR + RSSIKeyS.Length)));

                        // Convert.ToInt32(

                            sT = p.data.IndexOf(tagKeyS, eT);
                            eT = p.data.IndexOf(tagKeyE, sT);

                        tagID = p.data.Substring((sT + tagKeyS.Length), ((eT - sT) - tagKeyS.Length));

                            sL = p.data.IndexOf(locKeyS, eL);
                            eL = p.data.IndexOf(locKeyE, sL);

                        location = p.data.Substring((sL + locKeyS.Length), ((eL - sL) - locKeyS.Length));

                        retval.Add(new tagByte(tagID, location, dateTime));
                        retval[x].RSSI = RSSI;
                        retval[x].evnt = "TagStream";
                    }

                    return retval;
                default:
                    Console.WriteLine("");
                    break;
            }
            return new List<tagByte>();
        }
    }
}
