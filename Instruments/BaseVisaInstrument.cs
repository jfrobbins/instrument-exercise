using InstrumentsExercise.Interfaces;
using Ivi.Visa;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices.Swift;

namespace InstrumentsExercise.Instruments
{
    public abstract class BaseVisaInstrument : IInstrument
    {
        public int TimeoutMs { get; protected set; }
        public IMessageBasedSession VisaSession { get; protected set; }
        
        // constructor:
        protected BaseVisaInstrument(string connectionString, int timeoutMs)
        {
            this.TimeoutMs = timeoutMs;
            IMessageBasedSession h = Connect(connectionString);
        }
        
        protected internal IMessageBasedSession Connect(string connectionString)
        {
            IVisaSession h = GlobalResourceManager.Open(connectionString, AccessModes.None, this.TimeoutMs);
            h.TimeoutMilliseconds = this.TimeoutMs;
            this.VisaSession = h as IMessageBasedSession ?? throw new InvalidOperationException($"Cannot connect to instrument: {connectionString}");
            return this.VisaSession;
        }


        // TODO: Add VISA session variable and implement IInstrument methods

        public string SendRead(string msg)
        {
            Send(msg);
            return Read();
        }

        // These are standard IEEE 488.2 common commands
        // Can be overridden when needed.

        public void Send(string msg)
        {
            VisaSession.RawIO.Write(msg);
        }

        public string Read()
        {
            return VisaSession.RawIO.ReadString();
        }
        
        public void Reset()
        {
            // These are IEEE 488.2 common commands, so it should work on most
            // instruments, but can be overridden when needed.

            // reset instrument
            Send("*RST");
            // clear errors and status registers
            ClearErrors();
        }

        public void ClearErrors()
        {
            Send("*CLS");
            Opc();
        }

        public bool Opc()
        {
            Send("*OPC?");
            try
            {
                while (!Read().Contains("1")) ;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Idn()
        {
            // "*IDN?" Standard Identification Query
            string idnString = SendRead("*IDN?");

            return idnString;
        }
    }
}
