/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public enum DbContextActionMessageType { Info = 2, Error = 3, Warning = 4 }
    public sealed class DbContextActionMessage
    {
        private readonly string _text;
        private readonly DbContextActionMessageType _type;
        public string Text => _text;
        public DbContextActionMessageType MessageType => _type;
        public DbContextActionMessage(string text, DbContextActionMessageType msgType)
        {
            _text = text;
            _type = msgType;
        }
    }
}
