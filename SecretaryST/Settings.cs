using System.Collections.Generic;

namespace SecretaryST
{
    class Settings
    {
        public static class StartProtOptions
        {
            private static List<Header> allHeaders = new List<Header>();

            private readonly static StartProt startProtGroup1 = new StartProt()
            {
                Headers = new List<string>()
                {
                    "nr", "name", "person-nr", "rang", "birth", "sex", "compeete_name", "delegation", "region", "start-time"
                }
            };
            private readonly static StartProt startProtGroup2 = new StartProt()
            {
                Headers = new List<string>()
                {
                    "nr", "both-nr", "name-coop", "delegation", "region", "compeete_name",  "start-time"
                }
            };
            private readonly static StartProt startProtGroup4 = new StartProt()
            {
                Headers = new List<string>()
                {
                    "nr", "name-coop", "both-nr", "region", "delegation-manager", "compeete_name",  "start-time"
                }
            };

            public static StartProt StartProtGroup1 => startProtGroup1;

            public static StartProt StartProtGroup2 => startProtGroup2;

            public static StartProt StartProtGroup4 => startProtGroup4;

            public static List<Header> AllHeaders { get => allHeaders; set => allHeaders = value; }

            public static bool TryGetHeader(string name, out Header dest, bool useReadableName = true)
            {
                foreach (Header h in AllHeaders)
                {
                    string toCompare = useReadableName ? h.ReadableName : h.ShortName;

                    if (toCompare.Equals(name))
                    {
                        dest = h;
                        return true;
                    }
                }

                dest = null;
                return false;
            }

            public class StartProt
            {
                private List<string> headers;
                private List<string> choosedHeaders;
                private bool enableRandomOrder;
                private bool enableNrGeneration;
                private bool useDelegationNr;

                public StartProt()
                {
                    ChoosedHeaders = new List<string>();
                    Headers = new List<string>();

                    this.EnableRandomOrder = false;
                    this.EnableNrGeneration = false;
                    this.UseDelegationNr = false;
                }

                public bool EnableRandomOrder { get => enableRandomOrder; set => enableRandomOrder = value; }
                public bool EnableNrGeneration { get => enableNrGeneration; set => enableNrGeneration = value; }
                public bool UseDelegationNr { get => useDelegationNr; set => useDelegationNr = value; }
                public List<string> ChoosedHeaders { get => choosedHeaders; set => choosedHeaders = value; }
                public List<string> Headers { get => headers; set => headers = value; }
                public string[] HeaderShortNameArray()
                {
                    string[] data = new string[this.Headers.Count];
                    this.Headers.CopyTo(data);
                    return data;
                }
                public string[] ReadableHeadersArray()
                {
                    string[] data = new string[this.headers.Count];

                    List<string> tmp = new List<string>();
                    foreach (Header item in AllHeaders)
                    {
                        if (this.headers.Contains(item.ShortName))
                        {
                            tmp.Add(item.ReadableName);
                        }
                    }

                    tmp.CopyTo(data);
                    return data;
                }
                public string[] ReadableChoosedHeadersArray()
                {
                    string[] data = new string[this.headers.Count];

                    List<string> tmp = new List<string>();
                    foreach (Header item in AllHeaders)
                    {
                        if (this.choosedHeaders.Contains(item.ShortName))
                        {
                            tmp.Add(item.ReadableName);
                        }
                    }

                    tmp.CopyTo(data);
                    return data;
                }

                public List<string> ReadableChoosedHeadersList()
                {
                    List<string> tmp = new List<string>();
                    foreach (Header item in AllHeaders)
                    {
                        if (this.choosedHeaders.Contains(item.ShortName))
                        {
                            tmp.Add(item.ReadableName);
                        }
                    }

                    return tmp;
                }

            }

            public class Header
            {
                private string shortName;
                private string readableName;
                private double colWidth;

                public Header(string shortName, string readableName, double colWidth)
                {
                    this.ShortName = shortName;
                    this.ReadableName = readableName;
                    this.ColWidth = colWidth;
                }

                public string ShortName { get => shortName; set => shortName = value; }
                public string ReadableName { get => readableName; set => readableName = value; }
                public double ColWidth { get => colWidth; set => colWidth = value; }
            }

            public static void save()
            {
                OptionsSheet.SaveHeaders();
            }
        }
    }
}

