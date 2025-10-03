namespace neo_protocol.Packet.MinecraftPacket;

public class McpeDisconnect : Packet
{
    public enum DisconnectReason
    {
        Unknown = 0,
        CantConnectNoInternet,
        NoPermissions,
        UnrecoverableError,
        ThirdPartyBlocked,
        ThirdPartyNoInternet,
        ThirdPartyBadIP,
        ThirdPartyNoServerOrServerLocked,
        VersionMismatch,
        SkinIssue,
        InviteSessionNotFound,
        EduLevelSettingsMissing,
        LocalServerNotFound,
        LegacyDisconnect,
        UserLeaveGameAttempted,
        PlatformLockedSkinsError,
        RealmsWorldUnassigned,
        RealmsServerCantConnect,
        RealmsServerHidden,
        RealmsServerDisabledBeta,
        RealmsServerDisabled,
        CrossPlatformDisabled,
        CantConnect,
        SessionNotFound,
        // ������һ��ֵ (26)
        ServerFull = 27,
        InvalidPlatformSkin,
        EditionVersionMismatch,
        EditionMismatch,
        LevelNewerThanExeVersion,
        NoFailOccurred,
        BannedSkin,
        Timeout,
        ServerNotFound,
        OutdatedServer,
        OutdatedClient,
        // ������һ��ֵ (38)
        MultiplayerDisabled = 39,
        NoWiFi,
        // ������һ��ֵ (41)
        NoReason = 42,
        Disconnected,
        InvalidPlayer,
        LoggedInOtherLocation,
        ServerIdConflict,
        NotAllowed,
        NotAuthenticated,
        InvalidTenant,
        UnknownPacket,
        UnexpectedPacket,
        InvalidCommandRequestPacket,
        HostSuspended,
        LoginPacketNoRequest,
        LoginPacketNoCert,
        MissingClient,
        Kicked,
        KickedForExploit,
        KickedForIdle,
        ResourcePackProblem,
        IncompatiblePack,
        OutOfStorage,
        InvalidLevel,
        // ������һ��ֵ (67)
        BlockMismatch = 68,
        InvalidHeights,
        InvalidWidths,
        // ����������ֵ (71, 72)
        Shutdown = 73,
        // ������һ��ֵ (74)
        LoadingStateTimeout = 75,
        ResourcePackLoadingFailed,
        SearchingForSessionLoadingScreenFailed,
        NetherNetProtocolVersion,
        SubsystemStatusError,
        EmptyAuthFromDiscovery,
        EmptyUrlFromDiscovery,
        ExpiredAuthFromDiscovery,
        UnknownSignalServiceSignInFailure,
        XBLJoinLobbyFailure,
        UnspecifiedClientInstanceDisconnection,
        NetherNetSessionNotFound,
        NetherNetCreatePeerConnection,
        NetherNetICE,
        NetherNetConnectRequest,
        NetherNetConnectResponse,
        NetherNetNegotiationTimeout,
        NetherNetInactivityTimeout,
        StaleConnectionBeingReplaced,
        // ������һ��ֵ (97)
        BadPacket = 98,
        NetherNetFailedToCreateOffer,
        NetherNetFailedToCreateAnswer,
        NetherNetFailedToSetLocalDescription,
        NetherNetFailedToSetRemoteDescription,
        NetherNetNegotiationTimeoutWaitingForResponse,
        NetherNetNegotiationTimeoutWaitingForAccept,
        NetherNetIncomingConnectionIgnored,
        NetherNetSignalingParsingFailure,
        NetherNetSignalingUnknownError,
        NetherNetSignalingUnicastDeliveryFailed,
        NetherNetSignalingBroadcastDeliveryFailed,
        NetherNetSignalingGenericDeliveryFailed,
        EditorMismatchEditorWorld,
        EditorMismatchVanillaWorld,
        WorldTransferNotPrimaryClient,
        RequestServerShutdown,
        ClientGameSetupCancelled,
        ClientGameSetupFailed,
        // ������һ��ֵ (119)
        NetherNetSignalingSigninFailed = 120,
        SessionAccessDenied,
        ServiceSigninIssue,
        NetherNetNoSignalingChannel,
        NetherNetNotLoggedIn,
        NetherNetClientSignalingError,
        SubClientLoginDisabled,
        DeepLinkTryingToOpenDemoWorldWhileSignedIn,
        AsyncJoinTaskDenied,
        RealmsTimelineRequired,
        GuestWithoutHost,
        FailedToJoinExperience,
        NetherNetDataChannelClosed
    }
    public DisconnectReason failReason; // = null;
    public string filteredMessage; // = null

    public bool hideDisconnectReason; // = null;
    public string message; // = null;

    public McpeDisconnect()
    {
        Id = 0x05;
        IsMcpe = true;
    }

    protected override void EncodePacket()
    {
        base.EncodePacket();


        WriteUnsignedVarInt(0); //todo
        Write(hideDisconnectReason);
        Write(message);
        Write(filteredMessage);
    }


    protected override void DecodePacket()
    {
        base.DecodePacket();


        failReason = (DisconnectReason)ReadUnsignedVarInt();
        hideDisconnectReason = ReadBool();
        message = ReadString();
        filteredMessage = ReadString();
    }


    protected override void ResetPacket()
    {
        base.ResetPacket();

        hideDisconnectReason = default;
        message = default;
        failReason = default(int);
    }
}