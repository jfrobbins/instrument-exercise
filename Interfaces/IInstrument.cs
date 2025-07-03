using Ivi.Visa;

namespace InstrumentsExercise.Interfaces
{
    public interface IInstrument
    {
        // TODO: Add public methods like Disconnect, Send, Read, SendRead

        public void Send(string msg);
        public string Read();
        public string SendRead(string msg);
        public void Reset();
        public void ClearErrors();
        public bool Opc();
        public string Idn();
    }
}