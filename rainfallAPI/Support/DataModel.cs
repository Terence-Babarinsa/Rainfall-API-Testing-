using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rainfallAPI.Support
{
    public class DataModel
    {

        public class Rootobject
        {
            public string context { get; set; }
            public Meta meta { get; set; }
            public Items items { get; set; }
        }

        public class Meta
        {
            public string publisher { get; set; }
            public string licence { get; set; }
            public string documentation { get; set; }
            public string version { get; set; }
            public string comment { get; set; }
            public string[] hasFormat { get; set; }
        }

        public class Items
        {
            public string id { get; set; }
            public string RLOIid { get; set; }
            public string catchmentName { get; set; }
            public string dateOpened { get; set; }
            public string eaAreaName { get; set; }
            public string eaRegionName { get; set; }
            public int easting { get; set; }
            public string label { get; set; }
            public float lat { get; set; }
            public float _long { get; set; }
            public Measures measures { get; set; }
            public int northing { get; set; }
            public string notation { get; set; }
            public string riverName { get; set; }
            public Stagescale stageScale { get; set; }
            public string stationReference { get; set; }
            public string status { get; set; }
            public string town { get; set; }
            public string[] type { get; set; }
            public string wiskiID { get; set; }
        }

        public class Measures
        {
            public string id { get; set; }
            public string datumType { get; set; }
            public string label { get; set; }
            public Latestreading latestReading { get; set; }
            public string notation { get; set; }
            public string parameter { get; set; }
            public string parameterName { get; set; }
            public int period { get; set; }
            public string qualifier { get; set; }
            public string station { get; set; }
            public string stationReference { get; set; }
            public string[] type { get; set; }
            public string unit { get; set; }
            public string unitName { get; set; }
            public string valueType { get; set; }
        }

        public class Latestreading
        {
            public string id { get; set; }
            public string date { get; set; }
            public DateTime dateTime { get; set; }
            public string measure { get; set; }
            public float value { get; set; }
        }

        public class Stagescale
        {
            public string id { get; set; }
            public int datum { get; set; }
            public Highestrecent highestRecent { get; set; }
            public Maxonrecord maxOnRecord { get; set; }
            public Minonrecord minOnRecord { get; set; }
            public int scaleMax { get; set; }
            public float typicalRangeHigh { get; set; }
            public float typicalRangeLow { get; set; }
        }

        public class Highestrecent
        {
            public string id { get; set; }
            public DateTime dateTime { get; set; }
            public float value { get; set; }
        }

        public class Maxonrecord
        {
            public string id { get; set; }
            public DateTime dateTime { get; set; }
            public float value { get; set; }
        }

        public class Minonrecord
        {
            public string id { get; set; }
            public DateTime dateTime { get; set; }
            public float value { get; set; }
        }

    }
}
