using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.Application.Interfaces;
using VM.Domain.Constants;

namespace VM.Application.Services
{
    public class DisplayMessageService : IDisplayMessage
    {

            private string currentMessage = Messages.Inserted_coin;
            public string GetMessage() => currentMessage;
            public void SetMessage(string message) => currentMessage = message;
            public void ResetMessage()
            {
                currentMessage = Messages.Inserted_coin;
            }
     }
    
}
