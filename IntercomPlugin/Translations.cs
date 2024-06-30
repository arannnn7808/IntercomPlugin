using Exiled.API.Interfaces;

namespace IntercomPlugin
{
    public sealed class Translations : ITranslation
    {
        
        public string Information { get; set; } = "------Information------";
        public string ClassDText { get; set; } = "Class-D";
        
        public string FoundationForces { get; set; } = "Foundation Forces";
        
        public string Scientists { get; set; } = "Scientist";

        public string ChaosInsurgency { get; set; } = "Chaos Insurgency";
        
        public string SCPs { get; set; } = "SCP's";
        
        public string Timer { get; set; } = "Time Remaining";
        
        public string State { get; set; } = "Intercom State";
        
    }
}