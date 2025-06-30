using Ivi.Visa;

namespace InstrumentsExercise.Interfaces
{
    public interface IInstrument
    {
        // TODO: Add public methods like Disconnect, Send, Read, SendRead

        public int TimeoutMs { get; protected set; }
        public IMessageBasedSession VisaSession { get; protected set; }
        
        protected internal IMessageBasedSession Connect(string connectionString)
        {
            IVisaSession h = GlobalResourceManager.Open(connectionString, AccessModes.None, this.TimeoutMs);
            h.TimeoutMilliseconds = this.TimeoutMs;
            this.VisaSession = h as IMessageBasedSession ?? throw new InvalidOperationException($"Cannot connect to instrument: {connectionString}");
            return this.VisaSession;
        }

        public void Send(string msg);
        public string Read();
        public string SendRead(string msg);
        public void Reset();
        public void ClearErrors();
        public bool Opc();
        public string Idn();
    }
}