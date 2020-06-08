namespace FakeProjectG.ClientProjectG
{
    public partial class PClient
    {
        public bool SetKey(byte[] message)
        {
            if (KeyLogin == byte.MaxValue || KeyGame == byte.MaxValue)
            {
                if (message[0] == 0)
                {
                    if (message[1] == 0x0B)
                    {
                       
                        return true;
                    }
                    else if (message[1] == 0x06)
                    {
                        GetKey = message[8];
                        KeyGame = GetKey;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
