using SecretaryST.Enums;

namespace SecretaryST.Structs
{
    public struct GroupIndexAmountStruct
    {
        public GroupIndexAmountStruct(int groupIndex, DistanceGroupAmount amnt)
        {
            this.GroupIndex = groupIndex;
            this.Amnt = amnt;
        }

        public int GroupIndex { get; set; }
        public DistanceGroupAmount Amnt { get; set; }
    }
}
