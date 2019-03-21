using System;

namespace Lab01.Models {
    public class Storage {
        public event Action<Basic> InfoChanged;
        public Basic Info { get; private set; }

        public void ChangeInfo(Basic info) {
            Info = info;
            InfoChanged?.Invoke(info);
        }
    }
}