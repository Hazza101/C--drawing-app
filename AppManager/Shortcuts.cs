namespace GrafPack.AppManager
{
    public class Shortcuts
    {

        Keys[] keys;
        string[] actions;

        Dictionary<string, Keys> keyMappings;

        public Shortcuts()
        {
            keys = new Keys[] {
                Keys.D, //0
                Keys.Control, //1
                Keys.S, // 2
                Keys.R, // 3
                Keys.T, // 4
                Keys.Shift, //5
                Keys.D1, // 6
                Keys.D2, // 7
                Keys.D3, // 8
                Keys.D4, // 9
                Keys.D5, // 10
                Keys.D6, // 11
                Keys.X
            };

            actions = new string[] {
                "&Select",
                "&Delete",
                "&Scale",
                "&Translate",
                "&Rotate",
                "&Reflect",
                "&Square",
                "&Triangle",
                "&Circle",
                "&Rectangle",
                "&Ellipse",
                "&Polygon",
                "&Exit",
                
                
            };

            keyMappings = new Dictionary<string, Keys>();
            // select ctrl + s
            keyMappings.Add(actions[0], keys[1] | keys[2]);
            // delete ctrl + d
            keyMappings.Add(actions[1], keys[1] | keys[0]);
            // scale ctrl + shift + s
            keyMappings.Add(actions[2], keys[1] | keys[5] | keys[2]);
            // translate ctrl + shift + t
            keyMappings.Add(actions[3], keys[1] | keys[5] | keys[4]);
            // rotate ctrl + r
            keyMappings.Add(actions[4], keys[1] |  keys[3]);
            // reflect ctrl + shift + r
            keyMappings.Add(actions[5], keys[1] | keys[5] | keys[3]);
            // square ctrl + 1
            keyMappings.Add(actions[6], keys[1] |  keys[6]);
            // triangle ctrl + 2
            keyMappings.Add(actions[7], keys[1] |  keys[7]);
            // circle ctrl + 3
            keyMappings.Add(actions[8], keys[1] |  keys[8]);
            // rectangle ctrl + 4
            keyMappings.Add(actions[9], keys[1] |  keys[9]);
            // ellipse ctrl + 5
            keyMappings.Add(actions[10], keys[1] |  keys[10]);
            // polygon ctrl + 6
            keyMappings.Add(actions[11], keys[1] |  keys[11]);
            // exit ctrl + x
            keyMappings.Add(actions[12], keys[1] |  keys[12]);



        }

        public bool HasShortcut(string action)
        {
            return keyMappings.TryGetValue(action, out Keys saveKey);
        }

        public Keys GetShortCutKeys(string action)
        {
            if (keyMappings.TryGetValue(action, out Keys shortcut))
            {
                return shortcut;
            }
            return Keys.None;
        }

    }
}