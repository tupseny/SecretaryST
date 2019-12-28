using SecretaryST.Enums;
using SecretaryST.Models;
using System.Collections.Generic;
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

        public static void GroupNotFullAlert(int grIndex, DistanceGroupAmount grAmount)
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

        public static void GroupAlreadyExistsAlert(Structs.GroupIndexAmountStruct data, DistanceGroup gr)
        {
            string msg = EnumCasters.GroupAmountStringRepresent(data.Amnt) + " в составе:\n";

            List<string> names = new List<string>();
            gr.Members.ForEach(p => names.Add(p.Name));

            msg += string.Join("\n", names.ToArray());
            msg += "\nуже существует!";
            
            AlertMsg(title: "Ошибка", msg: msg);
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
