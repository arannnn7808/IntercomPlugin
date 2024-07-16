using Exiled.API.Interfaces;

namespace IntercomPlugin
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public bool RoundTimer { get; set; } = true;
        public bool ClassD { get; set; } = true;
        public bool NTF { get; set; } = true;
        public bool Scientist { get; set; } = true;
        public bool Chaos { get; set; } = true;
        public bool SCPS { get; set; } = true;
        
    }
}