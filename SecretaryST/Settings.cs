using System.Collections.Generic;

namespace SecretaryST
{
    class Settings
    {
        public static class StartProtOptions
        {
            private readonly static StartProt startProtGroup1 = new StartProt();
            private readonly static StartProt startProtGroup2 = new StartProt();
            private readonly static StartProt startProtGroup4 = new StartProt();
            private readonly static StartProt startProtMain = new StartProt();

            public static StartProt StartProtGroup1 => startProtGroup1;

            public static StartProt StartProtGroup2 => startProtGroup2;

            public static StartProt StartProtGroup4 => startProtGroup4;

            public static StartProt StartProtMain => startProtMain;

            public class StartProt
            {
                private List<Header> headers;
                private bool enableRandomOrder;
                private bool enableNrGeneration;
                private bool useDelegationNr;

                public StartProt()
                {
                    Headers = new List<Header>();
                    this.EnableRandomOrder = false;
                    this.EnableNrGeneration = false;
                    this.UseDelegationNr = false;
                }

                public bool EnableRandomOrder { get => enableRandomOrder; set => enableRandomOrder = value; }
                public bool EnableNrGeneration { get => enableNrGeneration; set => enableNrGeneration = value; }
                public bool UseDelegationNr { get => useDelegationNr; set => useDelegationNr = value; }
                public List<Header> Headers { get => headers; set => headers = value; }
                public bool TryGetHeader(string name, out Header dest, bool useShortName = true)
                {
                    foreach (Header h in Headers)
                    {
                        string toCompare = useShortName ? h.ShortName : h.ReadableName;

                        if (toCompare.Equals(name))
                        {
                            dest = h;
                            return true;
                        }
                    }

                    dest = null;
                    return false;
                }

                public class Header
                {
                    private string shortName;
                    private string fullName;
                    private string readableName;
                    private double colWidth;

                    public Header(string shortName, string fullName, string readableName, double colWidth)
                    {
                        this.ShortName = shortName;
                        this.FullName = fullName;
                        this.ReadableName = readableName;
                        this.ColWidth = colWidth;
                    }

                    public string ShortName { get => shortName; set => shortName = value; }
                    public string FullName { get => fullName; set => fullName = value; }
                    public string ReadableName { get => readableName; set => readableName = value; }
                    public double ColWidth { get => colWidth; set => colWidth = value; }
                }
            }

            public static void save()
            {
                OptionsSheet.SaveHeaders();
            }
        }
    }
}
