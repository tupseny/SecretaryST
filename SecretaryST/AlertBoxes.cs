using SecretaryST.Enums;
using System.Windows.Forms;

namespace SecretaryST
{
    class AlertBoxes
    {
        public static DialogResult SureDeleteAllSheetAlert()
        {
            string t = "Удалить дополнительные листы";
            string msg = "Все дополнительные (не основные) листы будут удалены. Вы уверены?";

            return YesNoMsg(msg, t);
        }

        public static void GroupNotFullalert(int grIndex, DistanceGroupAmount grAmount)
        {
            string title = "Неполная группа";
            string msg = EnumCasters.GroupAmountStringRepresent(grAmount) + " под номером " + grIndex + " не полная!";
            AlertMsg(msg, title);
        }

        public static void FieldTypeAlert(string cell, string requiredType)
        {
            string title = "Неправильный формат значения";

            string msg = "Формат значения в ячейке -'" + cell + "' неправильный. Должно быть - '" + requiredType + "' (Ячейка выделена)";
            AlertMsg(msg, title);
        }

        public static void GroupFullAlert(Structs.GroupIndexAmountStruct data)
        {
            AlertMsg(title: "Ошибка", msg: EnumCasters.GroupAmountStringRepresent(data.Amnt) + " номер - '" + data.GroupIndex + "' уже полная");
        }

        public static void AlertMsg(string msg, string title = "Ошибка")
        {
            MessageBox.Show(msg, title);
        }

        public static DialogResult YesNoMsg(string msg, string title = "Уверены?")
        {
            return MessageBox.Show(msg, title, MessageBoxButtons.YesNo);
        }
    }
}
