using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangProjectG.Defines
{
    /// <summary>
    /// PacketId Is Response
    /// </summary>
    public enum LoginPacketEnumResponse
    {
        PLAYER_CONNECTION = 0x0B00,
        PLAYER_LOGIN_DATA = 0x0001,
        GAME_SERVERS_LIST_DATA = 0x0002,
        PLAYER_SELECT_SERVER_DATA = 0x0003,
        PLAYER_GAME_MACRO_DATA = 0x0006,
        MESSENGE_SERVER_LIST_DATA = 0x0009,
        PLAYER_AUTH_LOGIN_KEY_DATA = 0x0010,
        MESSAGEBOX_NICKNAME = 0x000E
    }

    internal enum LoginPacketCodeEnum
    {
        Sucess = 0x00,
        InvalidoIdPw = 0x01,
        InvalidoId = 0x02,
        UsuarioEmUso = 0x04,
        Banido = 0x05,
        UsernameOuSenhaInvalido = 0x06,
        ContaSuspensa = 0x07,
        Player13AnosOuMenos = 0x09,
        SSNIncorreto = 0x0C,
        UsuarioIncorreto = 0x0D,
        OnlyUserAllowed = 0x0E,
        ServerInMaintenance = 0x0F,
        NaoDisponivelNaSuaArea = 0x10,
        CreateNickName_US = 0xD8,
        CreateNickName = 0xD9,
    }
    internal enum THLoginPacketCodeEnum : uint
    {
        Sucess = 0x00,
        InvalidoId = 0xE36FD24D,
        InvalidoIdPw = 0xE35BD24D,
        Banido = 0xE3F4D14D,
        UsuarioEmUso = 0xE3F3D14,
        ServerInMaintenance = 0xE348D24D
    }

    internal enum PLAYER_GAME_LOGIN_RESULT : uint
    {
        SUCESS = 0x00,
        LOAD_SERVER_TIME = 0XD3,
        UNKNOW = 0XD2,
    }
    internal enum LoginPacketConfirmNickEnum
    {
        Disponivel = 0x00, //Nickname disponível
        OcorreuUmErro = 0x01, //Ocorreu um erro ao verificar
        Indisponivel = 0x03,
        FormatoOuTamanhoInvalido = 0x04,
        PointsInsuficientes = 0x05,
        PalavasInapropriadas = 0x06,
        DBError = 0x07,
        MesmoNickNameSeraUsado = 0x09
    }

    internal enum ModeTypeRecord
    {
        Natural = 0x33,
        GrandPrix = 0x34,
        Normal = 0x05,
    }

    internal enum GameLoginPacketCodeEnum
    {
        PLAYER_LOGIN_MAIN_COMPLETE = 0x06,
        SERVER_LOAD = 0XD2,
        TYPE_UNKOWN = 0XD2,
    }

    internal enum GameCodeEnum
    {
        CREATE = 0X01,
        DESTROY = 0x02,
        UPDATE = 0X03,
        LIST = 0X07,
    }
    internal enum GameActionModeEnum
    {
        ROTATION = 0x00,
        UNK = 0x01,
        APPEAR = 0x04,
        SUB = 0x05,
        MOVE = 0x06,
        ANIMATION = 0x07,
        HEADER = 0x08,
        NULL = 0x9,
        ANIMATION_WITH_EFFECTS = 0x0A
    }

    public enum GamePacketEnumCall
    {
        PLAYER_LOGIN = 0x0002,
        PLAYER_CHAT = 0x0003,
        PLAYER_SELECT_LOBBY = 0x0004,

        PLAYER_CREATE_GAME = 0x0008,
        PLAYER_JOIN_GAME = 0x0009,

        PLAYER_CHANGE_NICKNAME = 0x0038,
        PLAYER_EXCEPTION = 0x33,
        PLAYER_JOIN_MULTIGAME_LIST = 0x0081,
        PLAYER_LEAVE_MULTIGAME_LIST = 0x0082,
        PLAYER_REQUEST_MESSENGER_LIST = 0x008B,
        PLAYER_JOIN_MULTIGAME_GRANDPRIX = 0x0176,
        PLAYER_LEAVE_MULTIGAME_GRANDPRIX = 0x0177,
        PLAYER_ENTER_GRANDPRIX = 0x0179,
        PLAYER_OPEN_PAPEL = 0x0098,
        PLAYER_OPEN_NORMAL_BONGDARI = 0x014B,
        PLAYER_OPEN_BIG_BONGDARI = 0x0186,
        PLAYER_SAVE_MACRO = 0x0069,
        PLAYER_OPEN_MAILBOX = 0x0143,
        PLAYER_READ_MAIL = 0x0144,
        PLAYER_RELEASE_MAILITEM = 0x0146,
        PLAYER_DELETE_MAIL = 0x0147,
        PLAYER_GM_COMMAND = 0x008F,
        //{GAME PROCESS}
        PLAYER_USE_ITEM = 0x0017,
        PLAYER_SEND_INVITE_CONFIRM = 0x0029,
        PLAYER_SEND_INVITE = 0x00BA,
        PLAYER_PRESS_READY = 0x000D,
        PLAYER_START_GAME = 0x000E,
        PLAYER_LEAVE_GAME = 0x000F,
        PLAYER_KEEPLIVE = 0xF4,
        PLAYER_LOAD_OK = 0x0011,
        PLAYER_SHOT_DATA = 0x001B,
        PLAYER_ACTION = 0x0063,
        //{MAY BE USE FOR CHAT ROOM ONLY}
        PLAYER_ENTER_TO_ROOM = 0x00EB,
        PLAYER_CLOSE_SHOP = 0x0075,
        PLAYER_OPEN_SHOP = 0x0076,
        PLAYER_ENTER_SHOP = 0x0077,
        PLAYER_SHOP_CREATE_VISITORS_COUNT = 0X0078,
        PLAYER_EDIT_SHOP_NAME = 0X0079,
        PLAYER_SHOP_VISITORS_COUNT = 0X007A,
        PLAYER_SHOP_ITEMS = 0X007C,
        PLAYER_BUY_SHOP_ITEM = 0X007D,
        PLAYER_SHOP_PANGS = 0X007B,
        //
        PLAYER_REQUEST_CHAT_OFFLINE = 0x003C,
        PLAYER_MASTER_KICK_PLAYER = 0x0026,
        PLAYER_CHANGE_GAME_OPTION = 0x000A,
        PLAYER_LEAVE_GRANDPRIX = 0x017A,
        PLAYER_AFTER_UPLOAD_UCC = 0x00B9,
        PLAYER_REQUEST_UPLOAD_KEY = 0x00C9,
        PLAYER_1ST_SHOT_READY = 0x0034,
        PLAYER_LOADING_INFO = 0x0048,
        PLAYER_GAME_ROTATE = 0x0013,
        PLAYER_CHANGE_CLUB = 0x0016,
        PLAYER_GAME_MARK = 0x012E,
        PLAYER_ACTION_SHOT = 0x0012,
        PLAYER_SHOT_SYNC = 0x001C,
        PLAYER_HOLE_INFORMATIONS = 0x001A,
        PLAYER_TUTORIAL_MISSION = 0X00AE,
        PLAYER_MY_TURN = 0x0022,
        PLAYER_HOLE_COMPLETE = 0x0031,
        PLAYER_CHAT_ICON = 0x0018,
        PLAYER_SLEEP_ICON = 0x0032,
        PLAYER_MATCH_DATA = 0x012F,
        PLAYER_MOVE_BAR = 0x0014,
        PLAYER_PAUSE_GAME = 0x0030,
        PLAYER_QUIT_SINGLE_PLAYER = 0x0130,
        PLAYER_CALL_ASSIST_PUTTING = 0x0185,
        PLAYER_USE_TIMEBOOSTER = 0x0065,
        PLAYER_DROP_BALL = 0x0019,
        PLAYER_CHANGE_TEAM = 0x0010,
        PLAYER_VERSUS_TEAM_SCORE = 0x0035,
        PLAYER_POWER_SHOT = 0x0015,
        PLAYER_WIND_CHANGE = 0x0141,
        PLAYER_SEND_GAMERESULT = 0x0006,

        //{ITEM SPECIAL}
        PLAYER_REQUEST_ANIMALHAND_EFFECT = 0x015C,
        PLAYER_REQUEST_RING_EFFECTS = 0x015D,
        teste = 0x0181,
        PLAYER_BUY_ITEM_GAME = 0x001D,
        PLAYER_ENTER_TO_SHOP = 0x0140,
        PLAYER_CHECK_USER_FOR_GIFT = 0x0007,

        PLAYER_SAVE_BAR = 0x000B,
        PLAYER_CHANGE_EQUIPMENT = 0x000C,
        PLAYER_CHANGE_EQUIPMENTS = 0x0020,
        PLAYER_WHISPER = 0x002A,
        PLAYER_REQUEST_TIME = 0x005C,
        PLAYER_GM_DESTROY_ROOM = 0x0060,
        PLAYER_GM_KICK_USER = 0x0061,
        PLAYER_GM_ENTER_ROOM = 0x003E,
        PLAYER_GM_IDENTITY = 0x0041,
        PLAYER_REQUEST_LOBBY_INFO = 0x0043,
        PLAYER_REMOVE_ITEM = 0x0064,
        PLAYER_PLAY_AZTEC_BOX = 0x00EC,
        PLAYER_OPEN_BOX = 0x00EF,
        PLAYER_CHANGE_SERVER = 0x0119,
        PLAYER_ASSIST_CONTROL = 0x0184,
        // PLAYER ITEM RECYCLE
        PLAYER_RECYCLE_ITEM = 0x018D,
        PLAYER_SELECT_LOBBY_WITH_ENTER_Lobby = 0x0083,
        PLAYER_REQUEST_GAMEINFO = 0x002D,
        PLAYER_GM_SEND_NOTICE = 0x0057,
        PLAYER_REQUEST_PLAYERINFO = 0x002F,
        PLAYER_CHANGE_MASCOT_MESSAGE = 0x0073,
        PLAYER_ENTER_ROOM = 0x00B5,
        PLAYER_ENTER_ROOM_GETINFO = 0x00B7,

        //SCRATCHCARD SYSTEM
        PLAYER_OPENUP_SCRATCHCARD = 0x012A,
        PLAYER_PLAY_SCRATCHCARD = 0x0070,
        PLAYER_ENTER_SCRATCHY_SERIAL = 0x0071,

        //DOLFINI LOCKER
        PLAYER_FIRST_SET_LOCKER = 0x00D0,
        PLAYER_ENTER_TO_LOCKER = 0x00D3,
        PLAYER_OPEN_LOCKER = 0x00CC,
        PLAYER_CHANGE_LOCKERPWD = 0x00D1,
        PLAYER_GET_LOCKERPANG = 0x00D5,
        PLAYER_LOCKERPANG_CONTROL = 0x00D4,
        PLAYER_CALL_LOCKERITEMLIST = 0x00CD,
        PLAYER_PUT_ITEMLOCKER = 0x00CE,
        PLAYER_TAKE_ITEMLOCKER = 0x00CF,

        // CLUB
        PLAYER_UPGRADE_CLUB = 0x0164,
        PLAYER_UPGRADE_ACCEPT = 0x0165,
        PLAYER_UPGRADE_CALCEL = 0x0166,
        PLAYER_UPGRADE_RANK = 0x0167,
        PLAYER_TRASAFER_CLUBPOINT = 0x016C,
        PLAYER_CLUBSET_ABBOT = 0x016B,
        PLAYER_CLUBSET_POWER = 0x016D,
        PLAYER_CHANGE_INTRO = 0x0106,
        PLAYER_CHANGE_NOTICE = 0x0105,
        PLAYER_CHANGE_SELFINTRO = 0x0111,
        PLAYER_LEAVE_GUILD = 0x0113,
        PLAYER_UPGRADE_CLUB_SLOT = 0x004B,

        // GUILD SYSTEM
        PLAYER_CALL_GUILD_LIST = 0x0108,
        PLAYER_SEARCH_GUILD = 0x0109,
        PLAYER_GUILD_AVAIABLE = 0x0102,
        PLAYER_CREATE_GUILD = 0x0101,
        PLAYER_REQUEST_GUILDDATA = 0x0104,
        PLAYER_GUILD_GET_PLAYER = 0x0112,
        PLAYER_GUILD_LOG = 0x010A,
        PLAYER_JOIN_GUILD = 0x010C,
        PLAYER_CANCEL_JOIN_GUILD = 0x010D,
        PLAYER_GUILD_ACCEPT = 0x010E,
        PLAYER_GUILD_KICK = 0x0114,
        PLAYER_GUILD_PROMOTE = 0x0110,
        PLAYER_GUILD_DESTROY = 0x0107,
        PLAYER_GUILD_CALL_UPLOAD = 0x0115,
        PLAYER_GUILD_CALL_AFTER_UPLOAD = 0x0116,

        // DIALY LOGIN
        PLAYER_REQUEST_CHECK_DAILY_ITEM = 0x016E,
        PLAYER_REQUEST_ITEM_DAILY = 0x016F,

        // ACHIEVEMENT
        PLAYER_CALL_ACHIEVEMENT = 0x0157,

        // Tiki Report
        PLAYER_OPEN_TIKIREPORT = 0x00AB,


        PLAYER_REQUEST_WEB_COOKIES = 0x00C1,

        // Memorial
        PLAYER_MEMORIAL = 0x017F,

        // PLAYER CARD SYSTEM
        PLAYER_OPEN_CARD = 0x00CA,
        PLAYER_CARD_SPECIAL = 0x00BD,
        PLAYER_PUT_CARD = 0x018A,
        PLAYER_PUT_BONUS_CARD = 0x018B,
        PLAYER_REMOVE_CARD = 0x018C,
        PLAYER_LOLO_CARD_DECK = 0x0155,

        PLAYER_CALL_CUTIN = 0x00E5,

        // Magic Box
        PLAYER_DO_MAGICBOX = 0x0158,

        // RENT ITEM
        PLAYER_RENEW_RENT = 0x00E6,
        PLAYER_DELETE_RENT = 0x00E7,

        // QUEST
        PLAYER_LOAD_QUEST = 0x0151,
        PLAYER_ACCEPT_QUEST = 0x0152,

        PLAYER_MATCH_HISTORY = 0x009C,

        // TOP NOTICE
        PLAYER_SEND_TOP_NOTICE = 0x0066,
        PLAYER_CHECK_NOTICE_COOKIE = 0x0067,

        //CADDIE NOTICE EXPIRATION
        PLAYER_REQUEST_CADDIE_RENEW = 0x006B,

        PLAYER_UPGRADE_STATUS = 0x0188,
        PLAYER_DOWNGRADE_STATUS = 0x0189,
        PACKET_UNKNOWN = 01010101
    }

    public enum GamePacketEnumResponse
    {
        PLAYER_CONNECTION = 0x600,
        PLAYER_GAME_RESUME = 0x004A,
        PLAYER_GAME_SUCESS = 0x0049,
        PLAYER_TRANSTION_ITEMS = 0x0216,
        GAME_CHANNEL_DATA = 0x004D,
        GAME_CHANNEL_INVALID = 0x0095,
        PLAYER_ENTER_CHANNEL_RESULT = 0x004E,
        PACKET_UNK_F6 = 0x01F6,
        PACKET_UNK_F1 = 0x00F1,
        PACKET_UNK_F5 = 0x00F5,
        PACKET_UNK_131 = 0x0131,
        PACKET_UNK_136 = 0x0136,
        PACKET_UNK_181 = 0x0181,
        PACKET_UNK_B4 = 0x00B4,
        PLAYER_ACHIEVEMENT_COUNTER = 0x021D,
        PLAYER_ACHIEVEMENT = 0x021E,
        PLAYER_CARD_DATA = 0x0138,
        PLAYER_CARD_EQUIPED = 0x0137,
        PLAYER_MAIN_DATA = 0x0044,
        GAME_PLAY_INFO = 0x0052,
        PLAYER_FURNITURE_DATA = 0x012D,
        PLAYER_ACTION_GAME = 0x00C4,
        PLAYER_ACTION_SHOT = 0x0055,
        PLAYER_ACTION_ROTATE = 0x0056,
        PLAYER_ACTION_CHANGE_CLUB = 0x0059,
        PLAYER_TROPHIES_DATA = 0x0169,
        PLAYER_TROPHIES_DATA_SP = 0x00B4,
        PLAYER_TROPHIES_DATA_GP = 0x025D,
        PLAYER_NEXT = 0x0063,
        PLAYER_CHARACTERS_DATA = 0x0070,
        PLAYER_CADDIES_DATA = 0x0071,
        PLAYER_CADDIES_EXPIRATION_DATA = 0x00D4,
        PLAYER_EQUIP_DATA = 0x0072,
        PLAYER_ITEMS_DATA = 0x0073,
        PLAYER_1ST_SHOT_READY = 0x0090,
        PLAYER_COOKIES = 0x0096,
        PLAYER_LOADING_INFO = 0x00A3,
        PLAYER_MASCOTS_DATA = 0x00E1,
        PLAYER_CALL_MESSAGESERVER_DATA = 0x00FC,
        PLAYER_TUTORIAL_DATA = 0x011F,
        PLAYER_DAILYLOGIN_CHECK_DATA = 0x0248,
        PLAYER_DAILYLOGIN_ITEM_DATA = 0x0249,
        /// <summary>
        /// call packet = player request info
        /// </summary>
        PLAYER_STATISTIC_DATA = 0x0158,
        PLAYER_REQUEST_INFO = 0X0157,
        PLAYER_CHARACTER_INFO = 0X015E,
        PLAYER_TOOLBAR_INFO = 0x0156,
        PLAYER_GUILD_INFO = 0X015D,
        PLAYER_RECORD_INFO = 0X015C,
        PLAYER_TROPHY_INFO_NORMAL = 0X0159,
        PLAYER_TROPHY_INFO_SPECIAL = 0X015A,
        PLAYER_TROPHY_INFO_GP = 0X0157,
        //
        PLAYER_MAILBOX_POPUP_DATA = 0x0210,
        PLAYER_OPEN_MAILBOX_DATA = 0x0211,
        PLAYER_CHAT_RECV_DATA = 0X4000,
        PLAYER_KEEPLIVE = 0x01A9,
        PLAYER_LOBBY_DATA = 0X0046,
        PLAYER_GAME_HEADERDATA = 0X004B,
        PLAYER_GAME_INFORMATIONDATA = 0X0049,
        CREATE_PLAYER_IN_GAME = 72,
        PLAYER_ACQUIRE_DATA = 0X0076,
        NOTICE_GAME = 0X0042,
        PLAYER_START_GAME = 0X007F,
        LOADING_MAP_TREASURES = 0X0131,
        GAME_ACTION = 0X0047,
        PLAYER_BUY_ITEM_SHOP = 0X00AA,
        PLAYER_REQUEST_INFO_RESULT_TYPE = 0x0089,
        NOTHING = 0xFFFF,
    }
    public enum MessengeServerPacketEnum
    {
        /// <summary>
        /// LOGIN PLAYER IN SERVER MS
        /// </summary>
        PLAYER_LOGIN = 0x0012,
        /// <summary>
        /// RECONNECT TO PLAYER IN SERVER
        /// </summary>
        PLAYER_RECONNECT_SERVER = 0x0014,
        /// <summary>
        /// DISCONNECT TO PLAYER IN SERVER
        /// </summary>
        PLAYER_REQUEST_DISCONNECT_MSSERVER = 0x0016,
        /// <summary>
        /// requesita procurar um amigo, usando messanger_server
        /// </summary>
        PLAYER_FIND_FRIEND = 0x0017,

        PLAYER_REQUEST_FIND_FRIEND = 0x0018,

        Unknown_19 = 0x0019,

        /// <summary>
        /// Envia o canal selecionado pelo player
        /// </summary>
        PLAYER_SELECT_CHANNEL = 0x0023,
        /// <summary>
        /// chat para guild no messenger server
        /// </summary>
        PLAYER_REQUEST_GUILD_CHAT = 0x0025,
        /// <summary>
        /// jogador bloqueia amigo
        /// </summary>
        PLAYER_BLOCK_FRIEND = 0x001A,
        /// <summary>
        /// jogador desbloqueia amigo
        /// </summary>
        PLAYER_UNBLOCK_FRIEND = 0x001B,
        /// <summary>
        /// jogaodr deleta o amigo da lista de amigos
        /// </summary>
        PLAYER_DELETE_FRIEND = 0x001C,
        /// <summary>
        /// PLAYER ONLINE
        /// </summary>
        SERVER_CHECK_PLAYER_CONNECTED = 0x001D,
        /// <summary>
        /// chat do messenger server
        /// </summary>
        PLAYER_REQUEST_CHAT = 0x001E,

        /// <summary>
        /// MUDA O APELIDO DO JOGADOR 
        /// </summary>
        PLAYER_CHANGE_FRIEND_NICKNAME = 0x001F,

        Unknown_42 = 0x002A,
    }
}
