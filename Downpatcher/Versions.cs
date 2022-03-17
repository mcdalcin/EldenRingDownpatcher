namespace Downpatcher {
    class Versions {
        public class GameVersion {
            public string name;
            public long size;
            public string[] manifestIds;
        }

        public string depotDownloaderVersion = "";
        public GameVersion[] versions = new GameVersion[0];
    }
}
