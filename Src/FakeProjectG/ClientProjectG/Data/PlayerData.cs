using System;
using System.Runtime.InteropServices;

namespace FakeProjectG.ClientProjectG.Data
{
    public class PlayerInfo
    {
        public StatisticData Statistic;
        public PlayerMemberMacro GameMacro { get; set; }
        public PlayerMemberGuild Guild { get; set; }
        public PlayerMemberRecordInfo MapRecord { get; set; }

        public PlayerLobby Lobby;
        public PlayerInfo()
        {
            Statistic = new StatisticData();
            GameMacro = new PlayerMemberMacro();
            Guild = new PlayerMemberGuild();
            MapRecord = new PlayerMemberRecordInfo();
            Lobby = new PlayerLobby();
        }

        public void SetMacro(string[] macro)
        {
            GameMacro.Macro1 = macro[0];//macro1
            GameMacro.Macro2 = macro[1];//macro1
            GameMacro.Macro3 = macro[2];//macro1
            GameMacro.Macro4 = macro[3];//macro1
            GameMacro.Macro5 = macro[4];//macro1
            GameMacro.Macro6 = macro[5];//macro1
            GameMacro.Macro7 = macro[6];//macro1
            GameMacro.Macro8 = macro[7];//macro8    
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StatisticData
    {
        public UInt32 Drive { get; set; }
        public UInt32 Putt { get; set; }
        public UInt32 PlayTime { get; set; }
        // Second
        public UInt32 ShotTime { get; set; }
        public float LongestDistance { get; set; }
        public UInt32 Pangya { get; set; }
        public UInt32 TimeOut { get; set; }
        public UInt32 OB { get; set; }
        public UInt32 DistanceTotal { get; set; }
        public UInt32 Hole { get; set; }
        public UInt32 TeamHole { get; set; }
        public UInt32 HIO { get; set; }
        public ushort Bunker { get; set; }
        public UInt32 Fairway { get; set; }
        public UInt32 Albratoss { get; set; }
        public UInt32 Holein { get; set; }
        public UInt32 Puttin { get; set; }
        public float LongestPutt { get; set; }
        public float LongestChip { get; set; }
        public UInt32 EXP { get; set; }
        public byte Level { get; set; }
        public UInt64 Pang { get; set; }
        public UInt32 TotalScore { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x05)]
        public byte[] Score;
        public byte Unknown { get; set; }
        public UInt64 MaxPang0 { get; set; }
        public UInt64 MaxPang1 { get; set; }
        public UInt64 MaxPang2 { get; set; }
        public UInt64 MaxPang3 { get; set; }
        public UInt64 MaxPang4 { get; set; }
        public UInt64 SumPang { get; set; }
        public UInt32 GamePlayed { get; set; }
        public UInt32 Disconnected { get; set; }
        public UInt32 TeamWin { get; set; }
        public UInt32 TeamGame { get; set; }
        public UInt32 LadderPoint { get; set; }
        public UInt32 LadderWin { get; set; }
        public UInt32 LadderLose { get; set; }
        public UInt32 LadderDraw { get; set; }
        public UInt32 LadderHole { get; set; }
        public UInt32 ComboCount { get; set; }
        public UInt32 MaxCombo { get; set; }
        public UInt32 NoMannerGameCount { get; set; }
        public UInt64 SkinsPang { get; set; }
        public UInt32 SkinsWin { get; set; }
        public UInt32 SkinsLose { get; set; }
        public UInt32 SkinsRunHole { get; set; }
        public UInt32 SkinsStrikePoint { get; set; }
        public UInt32 SKinsAllinCount { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x06)]
        public byte[] Unknown1;
        public UInt32 GameCountSeason { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x08)]
        public byte[] Unknown2;

        public static StatisticData operator +(StatisticData Left, StatisticData Right)
        {
            var Result = new StatisticData()
            {

                //{ Drive }
                Drive = Left.Drive + Right.Drive,
                //{ Putt}
                Putt = Left.Putt + Right.Putt,
                //{ Player Time Do Nothing }
                PlayTime = Left.PlayTime,
                //{ Shot Time }
                ShotTime = Left.ShotTime + Right.ShotTime
            };
            //{ Longest }
            if (Right.LongestDistance > Left.LongestDistance)
            {
                Result.LongestDistance = Right.LongestDistance;
            }
            else
            {
                Result.LongestDistance = Left.LongestDistance;
            }
            //{ Hit Pangya }
            Result.Pangya = Left.Pangya + Right.Pangya;
            //{ Timeout }
            Result.TimeOut = Left.TimeOut;
            //{ OB }
            Result.OB = Left.OB + Right.OB;
            //{ Total Distance }
            Result.DistanceTotal = Left.DistanceTotal + Right.DistanceTotal;
            //{ Hole Total }
            Result.Hole = Left.Hole + Right.Hole;
            //{ Team Hole }
            Result.TeamHole = Left.TeamHole;
            //{ Hole In One }
            Result.HIO = Left.HIO;
            //{ Bunker }
            Result.Bunker = (ushort)(Left.Bunker + Right.Bunker);
            //{ Fairway }
            Result.Fairway = Left.Fairway + Right.Fairway;
            //{ Albratoss }
            Result.Albratoss = Left.Albratoss + Right.Albratoss;
            //{ Holein ? }
            Result.Holein = Left.Holein + (Result.Hole - Right.Holein);
            //{ Puttin }
            Result.Puttin = Left.Puttin + Right.Puttin;
            //{ Longest Putt }
            if (Right.LongestPutt > Left.LongestPutt)
            {
                Result.LongestPutt = Right.LongestPutt;
            }
            else
            {
                Result.LongestPutt = Left.LongestPutt;
            }
            //{ Longest Chip }
            if (Right.LongestChip > Left.LongestChip)
            {
                Result.LongestChip = Right.LongestChip;
            }
            else
            {
                Result.LongestChip = Left.LongestChip;
            }
            return Result;
        }
    }
    public class PlayerMemberMacro
    {
        public string Macro1 { get; set; }
        public string Macro2 { get; set; }
        public string Macro3 { get; set; }
        public string Macro4 { get; set; }
        public string Macro5 { get; set; }
        public string Macro6 { get; set; }
        public string Macro7 { get; set; }
        public string Macro8 { get; set; }
        public string Macro9 { get; set; }
        public string Macro10 { get; set; } = "Pangya!";
    }

    public class PlayerMemberGuild
    {
        public int GUILD_TOTAL_MEMBER { get; set; }
        public int GUILD_INDEX { get; set; }
        public int GUILD_LEADER_UID { get; set; }
        public int? GUILD_POINT { get; set; } = 0;
        public int? GUILD_PANG { get; set; } = 0;
        public int? GUILD_IMAGE_KEY_UPLOAD { get; set; }
        public string GUILD_NAME { get; set; }
        public string GUILD_IMAGE { get; set; }
        public string GUILD_NOTICE { get; set; }
        public string GUILD_INTRODUCING { get; set; }
        public string GUILD_LEADER_NICKNAME { get; set; }
        public byte? GUILD_POSITION { get; set; }
        public byte? GUILD_VALID { get; set; }
        public DateTime? GUILD_CREATE_DATE { get; set; }

    }

    public class PlayerMemberRecordInfo
    {
        public int ID { get; set; }
        public short Map { get; set; }
        public int Drive { get; set; }
        public int Putt { get; set; }
        public int Hole { get; set; }
        public int Fairway { get; set; }
        public int Holein { get; set; }
        public int PuttIn { get; set; }
        public int TotalScore { get; set; }
        public short BestScore { get; set; }
        public int MaxPang { get; set; }
        public int CharTypeId { get; set; }
        public byte EventScore { get; set; }
        public byte Assist { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PlayerLobby
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Name { get; set; }
        public short MaxPlayer { get; set; }
        public short CurrUser { get; set; }
        public byte ID { get; set; }
        public int Type { get; set; }
        public int UN { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PlayerChatNormal
    {
        public byte Type { get; set; }
        public string NickName { get; set; }
        public string Message { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ServerInfo
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Name { get; set; }
        public int ID { get; set; }
        public int MaxPlayers { get; set; }
        public int UsersOnline { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
        public string IP { get; set; }
        public int Port { get; set; }
        public int Property { get; set; }
        public int AngelicNumber { get; set; }
        public short EventFlag { get; set; }
        public ushort UnkNown2 { get; set; }
        public int UnkNown3 { get; set; }
        public short ImgNo { get; set; }
    }
}
