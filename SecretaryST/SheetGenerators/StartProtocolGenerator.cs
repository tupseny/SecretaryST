using Microsoft.Office.Tools.Excel;
using SecretaryST.Enums;

namespace SecretaryST.SheetGenerators
{
    class StartProtocolGenerator : GeneratorAbstract
    {
        public StartProtocolGenerator(DistanceGroupAmount type)
        {
            string typeRepresent = EnumCasters.GroupAmountStringRepresent(type);

            SheetName = Globals.SheetNames.StartProtocol + " (" + typeRepresent + ")";
        }

        public override void Create()
        {
            PerformanceMode(true);

            CreateSheet();

            //todo: insert data into sheet

            PerformanceMode(false);
        }


    }
}
